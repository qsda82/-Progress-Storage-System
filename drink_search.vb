Public Class drink_search
    Private access As New DBControl
    Private Sub drink_search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 名稱 FROM drinks ")

        For i = 0 To access.DBDT.Rows.Count - 1
            Dim r As DataRow = access.DBDT.Rows(i)
            cbxchange.Items.Add(r("名稱").ToString)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cbxchange.SelectedIndex = -1 Then
            MsgBox("尚未選取任何項目")
        Else
            access.AddParam("@name", cbxchange.Text)
            access.ExecQuery("SELECT 名稱,食材,價格,類別 FROM drinks WHERE 名稱=@name")
            Dim r As DataRow = access.DBDT.Rows(0)
            MsgBox("名稱:" + r("名稱").ToString + vbCrLf + "食材:" + r("食材").ToString + vbCrLf + "價格:" + r("價格").ToString + vbCrLf + "類別:" + r("類別").ToString)
        End If
    End Sub

End Class