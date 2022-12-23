Public Class drink_revise
    Private access As New DBControl
    Private Function NotError(Optional Report As Boolean = False) As Boolean
        If Not String.IsNullOrEmpty(access.Exception) Then
            If Report = True Then MsgBox(access.Exception)
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub drink_revise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 名稱 FROM drinks ")

        For i = 0 To access.DBDT.Rows.Count - 1
            Dim r As DataRow = access.DBDT.Rows(i)
            cbxchange.Items.Add(r("名稱").ToString)
        Next
        ComboBox1.Items.Add("果茶")
        ComboBox1.Items.Add("茶類")
        ComboBox1.Items.Add("多多")
        ComboBox1.Items.Add("奶類")
        ComboBox1.Items.Add("特調")
        ComboBox1.Items.Add("熱飲")
        ComboBox1.Items.Add("冰沙")
    End Sub
    Function revise_drink()

        access.AddParam("@name", txtname.Text)
        access.AddParam("@material", txtmaterial.Text)
        access.AddParam("@price", txtprice.Text)
        access.AddParam("@class", ComboBox1.Text)
        access.AddParam("@changename", cbxchange.Text)

        access.ExecQuery("UPDATE drinks SET 名稱=@name,食材=@material,價格=@price,類別=@class WHERE 名稱=@changename ")

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        revise_drink()
        MsgBox("修改成功!")
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtmaterial_TextChanged(sender As Object, e As EventArgs) Handles txtmaterial.TextChanged

    End Sub


End Class