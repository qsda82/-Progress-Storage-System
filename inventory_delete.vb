Public Class inventory_delete
    Private access As New DBControl
    Private Sub inventory_delete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 食材名稱 FROM material ")
        For i = 0 To access.DBDT.Rows.Count - 1
            Dim x As DataRow = access.DBDT.Rows(i)
            ComboBox1.Items.Add(x("食材名稱").ToString)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        inventory.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("尚未選取任何項目，請重新選擇")
        Else
            access.AddParam("@name", ComboBox1.Text)
            access.ExecQuery("DELETE FROM material WHERE 食材名稱=@name")
            MsgBox("刪除成功!")
            Me.Close()
            inventory.Show()
        End If
    End Sub
End Class