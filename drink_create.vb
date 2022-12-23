Public Class drink_create
    Private access As New DBControl
    Function add_drink()
        access.AddParam("@name", txtname.Text)
        access.AddParam("@material", txtmaterial.Text)
        access.AddParam("@price", txtprice.Text)
        access.AddParam("@class", ComboBox1.Text)
        '執行sql
        access.ExecQuery("INSERT INTO drinks(名稱,食材,價格,類別) " &
                         "VALUES (@name,@material,@price,@class); ")
    End Function

    Private Sub create_drink_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("果茶")
        ComboBox1.Items.Add("茶類")
        ComboBox1.Items.Add("多多")
        ComboBox1.Items.Add("奶類")
        ComboBox1.Items.Add("特調")
        ComboBox1.Items.Add("熱飲")
        ComboBox1.Items.Add("冰沙")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        txtmaterial.Text.Trim()
        txtname.Text.Trim()
        txtprice.Text.Trim()
        If ComboBox1.SelectedIndex = -1 Or txtmaterial.Text = "" Or txtname.Text = "" Or txtprice.Text = "" Then
            If ComboBox1.SelectedIndex = -1 Then
                MsgBox("尚未選取類別")
            End If
            If txtmaterial.Text = "" Then
                MsgBox("尚未輸入食材")
            End If
            If txtname.Text = "" Then
                MsgBox("尚未輸入名稱")
            End If
            If txtprice.Text = "" Then
                MsgBox("尚未輸入價錢")
            End If
        Else
            add_drink()
            MsgBox("新增成功!")
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class