Public Class drink_class
    Private access As New DBControl
    Private count_drink As New Integer
    Public send_drinkname As String
    Public send_drinkprice As Integer

    'error checking & report
    Private Function NotError(Optional Report As Boolean = False) As Boolean
        If Not String.IsNullOrEmpty(access.Exception) Then
            If Report = True Then MsgBox(access.Exception)
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub drink_class_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim color1 As Color
        If (order.DrinkClass = "果茶") Then color1 = Color.FromArgb(255, 206, 206)
        If (order.DrinkClass = "茶類") Then color1 = Color.FromArgb(255, 234, 206)
        If (order.DrinkClass = "多多") Then color1 = Color.FromArgb(255, 248, 206)
        If (order.DrinkClass = "奶類") Then color1 = Color.FromArgb(229, 227, 204)
        If (order.DrinkClass = "特調") Then color1 = Color.FromArgb(234, 255, 206)
        If (order.DrinkClass = "熱飲") Then color1 = Color.FromArgb(246, 206, 255)
        If (order.DrinkClass = "冰沙") Then color1 = Color.FromArgb(206, 255, 237)

        access.AddParam("@drink", order.DrinkClass)
        access.ExecQuery("SELECT 名稱 FROM drinks WHERE 類別=@drink")
        count_drink = access.DBDT.Rows.Count


        Dim drinkLable(count_drink) As Button


        For i = 1 To count_drink
            drinkLable(i) = New Button

            Me.Controls.Add(drinkLable(i))

            With drinkLable(i)

                .Enabled = True
                .ForeColor = Color.FromArgb(91, 69, 61)
                .Size = New Size(161, 78)
                .BackColor = color1
                .BringToFront()
                .Name = i
                .FlatAppearance.BorderColor = Color.Black
                .FlatAppearance.BorderSize = 2
                .FlatStyle = FlatStyle.Flat

            End With
            If i = 1 Then
                drinkLable(i).Location = New Point(44, 51)

            ElseIf i > 1 And i <= 5 Then
                drinkLable(i).Location = New Point(44 + 200 * (i - 1), 51)

            ElseIf i > 5 Then

                If i Mod 5 = 1 Then
                    Dim h1 As Integer = i \ 5

                    drinkLable(i).Location = New Point(44, 187 + 136 * (h1 - 1))
                End If
                If i Mod 5 = 2 Then
                    Dim h1 As Integer = i \ 5
                    drinkLable(i).Location = New Point(244, 187 + 136 * (h1 - 1))
                End If
                If i Mod 5 = 3 Then
                    Dim h1 As Integer = i \ 5
                    drinkLable(i).Location = New Point(444, 187 + 136 * (h1 - 1))
                End If
                If i Mod 5 = 4 Then
                    Dim h1 As Integer = i \ 5
                    drinkLable(i).Location = New Point(644, 187 + 136 * (h1 - 1))
                End If

                If i Mod 5 = 0 Then
                    Dim h1 As Integer = i \ 5 - 1
                    drinkLable(i).Location = New Point(844, 187 + 136 * (h1 - 1))
                End If
            End If

            With drinkLable(i)
                Dim r As DataRow = access.DBDT.Rows(i - 1)
                .Text = r("名稱").ToString
                .TextAlign = ContentAlignment.MiddleCenter
                .Font = New Font("微軟正黑體", 18, FontStyle.Bold)
            End With

            AddHandler drinkLable(i).Click, AddressOf myButtonclick


        Next

        If NotError(True) = False OrElse access.RecordCount < 1 Then Exit Sub
    End Sub
    Private Sub myButtonclick(ByVal sender As Object, ByVal e As System.EventArgs)
        send_drinkname = CType(sender, Button).Text
        access.AddParam("@name", send_drinkname)
        access.ExecQuery("SELECT 價格 FROM drinks WHERE 名稱=@name")
        Dim q As DataRow = access.DBDT.Rows(0)
        send_drinkprice = Int(q("價格").ToString)
        drink_orderdata.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        order.Show()
        order.dataRefresh()
        Me.Close()
    End Sub
End Class