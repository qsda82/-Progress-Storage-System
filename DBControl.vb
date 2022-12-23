Imports System.Data.OleDb
Public Class DBControl
    '資料庫連結
    Private DBCon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                                         "Data Source=D:\桌面\綠茶\大學作業和報告\程式類\系統分析\系統分析\WindowsApp2\WindowsApp2\database.accdb;")
    '資料庫指令
    Private DBcmd As OleDbCommand

    '資料庫資料
    Public DBDA As OleDbDataAdapter
    Public DBDT As DataTable

    'query 參數
    Public Params As New List(Of OleDbParameter)

    'query變數
    Public RecordCount As Integer
    Public Exception As String


    Public Sub ExecQuery(Query As String)
        '重制query變數
        RecordCount = 0
        Exception = ""

        Try
            'open connection
            DBCon.Open()
            'create DB command
            DBcmd = New OleDbCommand(Query, DBCon)

            '把參數傳到COMMAND
            Params.ForEach(Sub(p) DBcmd.Parameters.Add(p))
            'for Each p As OleDbParameter in Params
            'DBCmd.Parameters.Add(p)
            'next'

            'clear List
            Params.Clear()
            '執行command與傳到datatable
            DBDT = New DataTable
            DBDA = New OleDbDataAdapter(DBcmd) '把指令所抓取的資料全給DBDA

            RecordCount = DBDA.Fill(DBDT) '再把其資料傳到DATATABLE

        Catch ex As Exception
            Exception = ex.Message '抓錯誤

        End Try
        '結束連結
        If DBCon.State = ConnectionState.Open Then DBCon.Close()
    End Sub
    'include query & command parameters
    Public Sub AddParam(Name As String, value As Object)
        Dim NewParams As New OleDbParameter(Name, value)
        Params.Add(NewParams)
    End Sub



End Class
