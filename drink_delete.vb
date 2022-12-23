Public Class drink_delete
    Private access As New DBControl
    Private Sub drink_delete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 名稱 FROM drinks ")

        For i = 0 To access.DBDT.Rows.Count - 1
            Dim r As DataRow = access.DBDT.Rows(i)
            cbxchange.Items.Add(r("名稱").ToString)
        Next
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cbxchange.SelectedIndex = -1 Then
            MsgBox("尚未選取任何項目")
        Else
            access.AddParam("@name", cbxchange.Text)
            access.ExecQuery("DELETE FROM drinks WHERE 名稱=@name")
            MsgBox("刪除成功!")
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class