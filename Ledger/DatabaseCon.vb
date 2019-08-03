Imports System.Data.OleDb

Public Class DatabaseCon
    Public con As New OleDbConnection
    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader

    Public Sub New()
        Try
            dbConnect()
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        End Try

    End Sub

    Public Sub dbConnect()
        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\db_jmcj.mdb"

        'for live
        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\db_jmcj.mdb"

        'For testing db
        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_jmcj.mdb"

        'database network
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\LHEE-GONZALES\shared\db_jmcj.mdb"

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If


    End Sub

    Public Sub selectTableByColumn(ByVal table As String, ByVal col As String, ByVal oper As String, ByVal val As String)
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM " & table & " Where " & col & " " & oper & " " & val
            dr = cmd.ExecuteReader
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
                MsgBox("The database is already open, selectTableByColumn", MsgBoxStyle.Critical)
            Else
                MsgBox(ex.Message & " " & cmd.CommandText, MsgBoxStyle.Critical)
            End If
        End Try
    End Sub

    Public Sub selectByQuery(ByVal q As String)

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = q
        dr = cmd.ExecuteReader
    End Sub

    Public Sub update_where(ByVal table As String, ByVal ID As String, ByVal col As String, ByVal val As String)
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE " & table & " SET [" & col & "] = " & val & " WHERE ID = " & ID
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
       
    End Sub

    Function isExist(ByVal table As String, ByVal column As String, ByVal val As String) As Boolean
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT " & column & " FROM " & table & " WHERE " & column & " = '" & val & "'"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                cmd.Dispose()
                dr.Close()
                con.Close()
                Return True
            Else
                cmd.Dispose()
                dr.Close()
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function get_id(ByVal table As String, ByVal col As String, ByVal val As String)
        Dim result As Integer = 0

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select id from " & table & " where UCASE(" & col & ") = UCASE('" & val & "')"
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            If dr.Read Then
                result = CInt(dr("id"))
            Else
                result = 0
            End If
        Else
            result = 0
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        Return result
    End Function
End Class
