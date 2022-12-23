Public Class inventory_search
    Private access As New DBControl
    Private Sub inventory_search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 食材名稱 FROM material ")
        For i = 0 To access.DBDT.Rows.Count - 1
            Dim x As DataRow = access.DBDT.Rows(i)
            ComboBox1.Items.Add(x("食材名稱").ToString)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("未選取任何項目")
        Else
            access.AddParam("@name1", ComboBox1.Text)
            access.ExecQuery("SELECT 食材名稱,目前存量 FROM material WHERE 食材名稱=@name1")
            Dim o As DataRow = access.DBDT.Rows(0)
            MsgBox(o("食材名稱").ToString + "剩餘" + o("目前存量").ToString + "份")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        inventory.Show()
    End Sub
End Class