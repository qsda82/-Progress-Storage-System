Public Class revise_drinkdata
    Dim price As Integer
    Dim number As Integer
    Dim sugar_word As String
    Dim ice_word As String
    Public discount As String
    Dim name As String
    Private access As New DBControl
    Public additional_eat As New List(Of String)
    Dim ice_index(,) = {{"去冰", 0}, {"微冰", 1}, {"少冰", 3}, {"正常冰", 5}}
    Dim sugar_index(,) = {{"無糖", 0}, {"微糖", 1}, {"半糖", 3}, {"正常糖", 5}}
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click
        If CheckBox4.Checked = True Then
            additional_eat.Add(CheckBox4.Text)
            price = price + 10

            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox4.Text)
            price = price - 10

            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.Click
        If CheckBox7.Checked = True Then
            additional_eat.Add(CheckBox7.Text)
            price = price + 15
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox7.Text)
            price = price - 15
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.Click
        If CheckBox6.Checked = True Then
            additional_eat.Add(CheckBox6.Text)
            price = price + 10
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox6.Text)
            price = price - 10
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.Click
        If CheckBox5.Checked = True Then
            additional_eat.Add(CheckBox5.Text)
            price = price + 10
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox5.Text)
            price = price - 10
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.Click
        If CheckBox8.Checked = True Then
            additional_eat.Add(CheckBox8.Text)
            price = price + 15
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox8.Text)
            price = price - 15
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked = True Then
            additional_eat.Add(CheckBox3.Text)
            price = price + 10
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox3.Text)
            price = price - 10
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then
            additional_eat.Add(CheckBox2.Text)
            price = price + 5
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox2.Text)
            price = price - 5
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click

        If CheckBox1.Checked = True Then
            additional_eat.Add(CheckBox1.Text)
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox9.Enabled = False
        Else
            additional_eat.Remove(CheckBox1.Text)
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            CheckBox5.Enabled = True
            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
            CheckBox9.Enabled = True
        End If

    End Sub
    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.Click
        If CheckBox1.Checked = True Then
            additional_eat.Add(CheckBox9.Text)
            price = price + 5
            CheckBox1.Enabled = False
        Else
            additional_eat.Remove(CheckBox9.Text)
            price = price - 5
            CheckBox1.Enabled = True
        End If
    End Sub
    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.Click
        If CheckBox10.Checked = True Then
            discount = "Yes"
            price = price - 10
        Else
            price = price + 10
            discount = "No"
        End If
    End Sub
    Private Sub cbx_ice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_ice.SelectedIndexChanged

        ice_word = cbx_ice.Text
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_sugar.SelectedIndexChanged

        sugar_word = cbx_sugar.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cbx_num.Text = Int(cbx_num.Text) + 1


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cbx_num.Text = Int(cbx_num.Text) - 1

    End Sub
    Private Sub revise_drinkdata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        discount = "No"
        cbx_ice.Text = ice_index(0, 0)
        ice_word = ice_index(0, 0)
        cbx_ice.Items.Add(ice_index(0, 0))
        cbx_ice.Items.Add(ice_index(1, 0))
        cbx_ice.Items.Add(ice_index(2, 0))
        cbx_ice.Items.Add(ice_index(3, 0))
        cbx_sugar.Text = sugar_index(0, 0)
        sugar_word = sugar_index(0, 0)

        cbx_sugar.Items.Add(sugar_index(0, 0))
        cbx_sugar.Items.Add(sugar_index(1, 0))
        cbx_sugar.Items.Add(sugar_index(2, 0))
        cbx_sugar.Items.Add(sugar_index(3, 0))
        For i = 1 To 20
            cbx_num.Items.Add(i)
        Next
        cbx_num.Text = 1
        number = 1
        access.AddParam("@name", start_form.orderData(order.revise_name).GetValue(0))
        access.ExecQuery("SELECT 價格 FROM drinks WHERE 名稱=@name ")
        Dim x As DataRow = access.DBDT.Rows(0)
        price = Int(x("價格").ToString) * number
        name = start_form.orderData(order.revise_name).GetValue(0)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i = 0
        Dim add As String = ""
        For i = 0 To additional_eat.Count - 1
            add = add + additional_eat(i)
            If (i + 1 <= additional_eat.Count - 1) Then
                add = add + "、"
            End If
        Next

        access.AddParam("@name", start_form.orderData(order.revise_name).GetValue(0))
        access.ExecQuery("SELECT 類別 FROM drinks WHERE 名稱=@name ")
        Dim x As DataRow = access.DBDT.Rows(0)
        Dim class1 As String = x("類別").ToString
        Dim sugar = start_form.orderData(order.revise_name).GetValue(6)
        Dim ice = start_form.orderData(order.revise_name).GetValue(7)
        number = Int(cbx_num.Text)
        price = price * number
        Dim Data() = {name, price, number, sugar_word, ice_word, add, sugar, ice, class1, discount}
        start_form.orderData.RemoveAt(order.revise_name)

        start_form.orderData.Add(Data)
        order.dt.Columns.Clear()
        order.dt.Rows.Clear()
        order.dataRefresh()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        order.Show()
        Me.Close()
    End Sub




End Class