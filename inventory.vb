Public Class inventory
    Private access As New DBControl
    Private Function NotError(Optional Report As Boolean = False) As Boolean
        If Not String.IsNullOrEmpty(access.Exception) Then
            If Report = True Then MsgBox(access.Exception)
            Return False
        Else
            Return True
        End If
    End Function
    Function add_inventory()
        access.AddParam("@num", txtnum.Text)
        access.AddParam("@provider", txtprovider.Text)
        access.AddParam("@date", FormatDateTime(Now(), DateFormat.ShortDate))
        access.AddParam("@name", ComboBox1.Text)

        '執行sql
        access.ExecQuery("INSERT INTO parchase_record(份數,供應商,進貨日期,進貨項目) " &
                         "VALUES (@num,@provider,@date,@name); ")


    End Function

    Function revise_material()
        access.AddParam("@name1", ComboBox1.Text)
        access.ExecQuery("SELECT 食材名稱,目前存量 FROM material WHERE 食材名稱=@name1")
        Dim o As DataRow = access.DBDT.Rows(0)

        access.AddParam("@least", Int(o("目前存量").ToString) + Int(txtnum.Text))
        access.AddParam("@name", o("食材名稱").ToString)

        access.ExecQuery("UPDATE material SET 目前存量=@least WHERE 食材名稱=@name")
        MsgBox("新增成功")
        ComboBox1.Text = ""
        txtnum.Text = ""
        txtprovider.Text = ""
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        inventory_search.Show()

    End Sub

    Private Sub inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        access.ExecQuery("SELECT 食材名稱 FROM material ")
        For i = 0 To access.DBDT.Rows.Count - 1
            Dim x As DataRow = access.DBDT.Rows(i)
            ComboBox1.Items.Add(x("食材名稱").ToString)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtnum.Text.Trim()
        txtprovider.Text.Trim()
        If txtnum.Text = "" Or txtprovider.Text = "" Or ComboBox1.SelectedIndex = -1 Then
            If txtnum.Text = "" Then
                MsgBox("尚未輸入份數")
            End If
            If ComboBox1.SelectedIndex = -1 Then
                MsgBox("尚未選取進貨項目")
            End If
            If txtprovider.Text = "" Then
                MsgBox("尚未選擇供應商")
            End If
        Else
            add_inventory()
            revise_material()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        inventory_delete.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        inventory_revise.Show()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        inventory_create.Show()
    End Sub


End Class