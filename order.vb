Public Class order
    Public DrinkClass As String
    Private access As New DBControl
    Public dt As New DataTable
    Dim count As Integer = 0
    Public revise_name As Integer


    ' Private orderdata As New drink_orderdata
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        DrinkClass = Label1.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        DrinkClass = Label2.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        DrinkClass = Label3.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        DrinkClass = Label4.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        DrinkClass = Label5.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        DrinkClass = Label6.Text
        drink_class.Show()
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        DrinkClass = Label7.Text
        drink_class.Show()
        Me.Close()

    End Sub
    Function dataRefresh()
        dt.Columns.Add("名稱")
        dt.Columns.Add("價錢")
        dt.Columns.Add("數量")
        dt.Columns.Add("糖度")
        dt.Columns.Add("冰塊")
        dt.Columns.Add("加料")
        dt.Columns.Add("學生折扣")
        'Dim i As Integer
        For i = 0 To start_form.orderData.Count - 1
            dt.Rows.Add(start_form.orderData(i).GetValue(0), start_form.orderData(i).GetValue(1), start_form.orderData(i).GetValue(2), start_form.orderData(i).GetValue(3), start_form.orderData(i).GetValue(4), start_form.orderData(i).GetValue(5), start_form.orderData(i).GetValue(9))
        Next
        drink_dt.DataSource = dt
        Dim totalprice As Integer
        For i = 0 To start_form.orderData.Count - 1
            totalprice = totalprice + start_form.orderData(i).GetValue(1)
        Next
        total_price.Text = "總金額：" + totalprice.ToString

    End Function

    Function payment()
        For i = 0 To start_form.orderData.Count - 1

            access.AddParam("@madeof", start_form.orderData(i).GetValue(0))
            access.ExecQuery("SELECT 食材 FROM drinks WHERE 名稱=@madeof")
            Dim r As DataRow = access.DBDT.Rows(0)
            Dim material As String = r("食材").ToString + "、" + start_form.orderData(i).GetValue(5)
            access.AddParam("@drink_name", start_form.orderData(i).GetValue(0))
            access.AddParam("@madeof_name", material)
            access.AddParam("@num", start_form.orderData(i).GetValue(2))
            access.AddParam("@sugar", start_form.orderData(i).GetValue(6))
            access.AddParam("@ice", start_form.orderData(i).GetValue(7))
            access.ExecQuery("INSERT INTO made_with(名稱,食材名稱,使用份數,糖量,冰量) VALUES(@drink_name,@madeof_name,@num,@sugar,@ice) ")



            For j = 0 To 33
                If InStr(material, start_form.materials(j)) <> 0 Then '跟資料庫裡的原理做比較，有使用到的就減掉份數
                    access.AddParam("@least", start_form.materials(j))
                    access.ExecQuery("SELECT 目前存量 FROM material WHERE 食材名稱=@least ")
                    Dim x As DataRow = access.DBDT.Rows(0)
                    Dim change_num As Integer = Int(x("目前存量").ToString) - 1 * start_form.orderData(i).GetValue(2) '減掉份數

                    access.AddParam("@change", change_num)
                    access.AddParam("@xx", start_form.materials(j))
                    access.ExecQuery("UPDATE material SET 目前存量=@change WHERE 食材名稱=@xx")
                End If
            Next
        Next
    End Function

    Function buy_record()
        For i = 0 To start_form.orderData.Count - 1
            access.AddParam("@price", start_form.orderData(i).GetValue(1))
            access.AddParam("@date", FormatDateTime(Now(), DateFormat.ShortDate))
            access.AddParam("@name", start_form.orderData(i).GetValue(0))
            access.AddParam("@num", start_form.orderData(i).GetValue(2))
            access.AddParam("@class", start_form.orderData(i).GetValue(8))
            access.AddParam("@discount", start_form.orderData(i).GetValue(9))
            access.ExecQuery("INSERT INTO trade_record(金額,日期,名稱,數量,類別,折扣) VALUES(@price,@date,@name,@num,@class,@discount) ")
        Next
        start_form.orderData.Clear()
    End Function
    Private Sub order_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        DrinkClass = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        start_form.orderData.Clear()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If drink_dt.Rows.Count = 0 Then
            MsgBox("尚未購買任何項目")
            drink_dt.Enabled = False
        Else
            payment()
            buy_record()
            MsgBox("購買完成")
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        drink_managment.Show()
    End Sub

    Private Sub select_drink(drinkname As String)
        revise_name = Int(drinkname)
        revise_drinkdata.Show()

    End Sub

    Private Sub drink_dt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles drink_dt.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            select_drink(drink_dt.Item(0, e.RowIndex).RowIndex)
        End If
    End Sub


End Class