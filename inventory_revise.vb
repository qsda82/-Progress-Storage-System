Public Class inventory_revise
    Private access As New DBControl
    Private Sub inventory_revise_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        access.ExecQuery("SELECT 食材名稱 FROM material ")

        For i = 0 To access.DBDT.Rows.Count - 1
            Dim r As DataRow = access.DBDT.Rows(i)
            cbxchange.Items.Add(r("食材名稱").ToString)
        Next

    End Sub
    Function revise_drink()

        access.AddParam("@name", txtname.Text)
        access.AddParam("@num", txtnum.Text)
        access.AddParam("@price", txtprice.Text)
        access.AddParam("@changename", cbxchange.Text)

        access.ExecQuery("UPDATE material SET 食材名稱=@name,目前存量=@num,每份金額=@price WHERE 食材名稱=@changename ")
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtnum.Text.Trim()
        txtname.Text.Trim()
        txtnum.Text.Trim()
        If cbxchange.SelectedIndex = -1 Or txtnum.Text = "" Or txtname.Text = "" Or txtnum.Text = "" Then
            If cbxchange.SelectedIndex = -1 Then
                MsgBox("尚未選取欲修改存貨")
            End If
            If txtnum.Text = "" Then
                MsgBox("尚未輸入份數")
            End If
            If txtname.Text = "" Then
                MsgBox("尚未輸入食材名稱")
            End If
            If txtnum.Text = "" Then
                MsgBox("尚未輸入每份金額")
            End If
        Else
            revise_drink()
            MsgBox("修改成功!")
            Me.Close()
            inventory.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        inventory.Show()
    End Sub

End Class