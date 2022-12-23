Public Class inventory_create
    Private access As New DBControl
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtinventory.Text = "" Or txtprice.Text = "" Then
            MsgBox("尚未填寫完成")
        Else
            access.AddParam("@name", txtinventory.Text)
            access.AddParam("@num", 0)
            access.AddParam("@price", txtprice.Text)
            access.ExecQuery("INSERT INTO material(食材名稱,目前存量,每份金額) " &
                         "VALUES (@name,@num,@price); ")
            MsgBox("新增成功")
            Me.Close()
            inventory.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        inventory.Show()
    End Sub


End Class