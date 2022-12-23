Public Class spec_caculate
    Private access As New DBControl
    Dim total_earn As Integer

    Function caculate_earn()
        Dim name As New List(Of String)
        Dim num As New List(Of Integer)
        access.AddParam("@datestart", FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate))
        access.AddParam("@dateend", FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate))

        access.ExecQuery("SELECT 名稱,數量 FROM trade_record WHERE 日期 BETWEEN @datestart AND @dateend")
        For i = 0 To access.DBDT.Rows.Count - 1
            Dim xx As DataRow = access.DBDT.Rows(i)
            name.Add(xx("名稱").ToString)
            num.Add(Int(xx("數量").ToString))
        Next

        For i = 0 To name.Count - 1

            access.AddParam("@name", name(i))
            access.ExecQuery("SELECT 食材,價格 FROM drinks WHERE 名稱=@name")
            Dim a As DataRow = access.DBDT.Rows(0)
            Dim cost As Integer = 0
            For j = 0 To 33
                If a("食材").ToString.Contains(start_form.materials(j)) Then
                    access.AddParam("@materialname", start_form.materials(j))
                    access.ExecQuery("SELECT 每份金額 FROM material WHERE 食材名稱=@materialname")
                    Dim x As DataRow = access.DBDT.Rows(0)
                    cost = cost + Int(x("每份金額").ToString)
                End If
            Next
            total_earn = total_earn + ((Int(a("價格").ToString) - cost) * num(i))
        Next

    End Function
    Function caculate()
        total_earn = 0
        With Me.cht
            .Legends.Clear()
            .Series.Clear()
            .ChartAreas.Clear()
            .Titles.Clear()
        End With



        cht.Titles.Add("銷售情形  單位:%")
        Dim series1 = cht.Series.Add("Series1")
        With series1
            .ChartType = DataVisualization.Charting.SeriesChartType.Pie
        End With
        cht.ChartAreas.Add("Areas1")
        cht.Legends.Add("Legends1")
        cht.Series("Series1").IsValueShownAsLabel = True
        cht.Series("Series1").Font = New Font("微軟正黑體", 10, FontStyle.Bold)
        cht.ChartAreas("Areas1").BackColor = Color.Ivory
        cht.Legends("Legends1").BackColor = Color.Ivory
        Dim tea As Integer = 0
        Dim fruit As Integer = 0
        Dim dodo As Integer = 0
        Dim ice As Integer = 0
        Dim hot As Integer = 0
        Dim milk As Integer = 0
        Dim spec As Integer = 0

        access.AddParam("@datestart", FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate))
        access.AddParam("@dateend", FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate))

        access.ExecQuery("SELECT 類別,數量,金額 FROM trade_record WHERE 日期 BETWEEN @datestart AND @dateend")
        For i = 0 To access.DBDT.Rows.Count - 1
            Dim x As DataRow = access.DBDT.Rows(i)
            If x("類別").ToString = "果茶" Then
                fruit = fruit + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "茶類" Then
                tea = tea + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "特調" Then
                spec = spec + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "熱飲" Then
                hot = hot + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "奶類" Then
                milk = milk + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "多多" Then
                dodo = dodo + Int(x("數量").ToString)
            End If
            If x("類別").ToString = "冰沙" Then
                ice = ice + Int(x("數量").ToString)
            End If
        Next
        Dim total = tea + fruit + ice + hot + spec + milk + dodo

        If tea <> 0 Then cht.Series("Series1").Points.AddXY("茶類", Math.Round((tea / total * 100%), 2).ToString)
        If fruit <> 0 Then cht.Series("Series1").Points.AddXY("果茶", Math.Round((fruit / total * 100%), 2).ToString)
        If dodo <> 0 Then cht.Series("Series1").Points.AddXY("多多", Math.Round((dodo / total * 100%), 2).ToString)
        If spec <> 0 Then cht.Series("Series1").Points.AddXY("特調", Math.Round((spec / total * 100%), 2).ToString)
        If ice <> 0 Then cht.Series("Series1").Points.AddXY("冰沙", Math.Round((ice / total * 100%), 2).ToString)
        If hot <> 0 Then cht.Series("Series1").Points.AddXY("熱飲", Math.Round((hot / total * 100%), 2).ToString)
        If milk <> 0 Then cht.Series("Series1").Points.AddXY("奶類", Math.Round((milk / total * 100%), 2).ToString)
        caculate_earn()
        Label1.Text = "淨額:" + total_earn.ToString
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        caculate()


    End Sub

End Class