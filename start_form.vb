Public Class start_form
    Public orderData As New List(Of Array)

    Public again As Integer = 0
    Private access As New DBControl
    Public materials As New List(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        order.Show()
        access.ExecQuery("SELECT 食材名稱 FROM material WHERE 目前存量<5")

        If access.DBDT.Rows.Count > 0 Then
            Dim name1 As String = ""
            For i = 0 To access.DBDT.Rows.Count - 1
                Dim x As DataRow = access.DBDT.Rows(i)
                name1 = name1 + x("食材名稱").ToString
                If (i + 1 <= access.DBDT.Rows.Count - 1) Then
                    name1 = name1 + "、"
                End If
            Next

            If again = 0 Then
                MsgBox(name1 + " 可以補貨囉")
                Dim ret = MsgBox("是否關閉補貨提醒?", MsgBoxStyle.YesNo)

                If ret = MsgBoxResult.No Then
                    again = 0
                Else
                    again = 1
                End If
            End If
        End If
    End Sub
    Function mater()
        For j = 0 To 33
            access.ExecQuery("SELECT 食材名稱 FROM material")
            If Not String.IsNullOrEmpty(access.Exception) Then MsgBox(access.Exception) : 
            Dim s As DataRow = access.DBDT.Rows(j)
            materials.Add(s("食材名稱").ToString)
        Next
    End Function
    Private Sub start_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mater()
        Dim a As String = "123  567"

        Dim vs As String() = Split(a, " ")

        MsgBox(vs(2))


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        inventory.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        spec_caculate.Show()
    End Sub


End Class
