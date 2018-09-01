Module ModelFunction

    Public Sub updateFloating()
        Dim db As New DatabaseCon
        With db
            .cmd.Connection = db.con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update ledger set floating = 0 where check_date < Date()"
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()

            .cmd.CommandText = "Update ledger set floating = 1 where check_date >= Date()"
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()
            .cmd.Dispose()
            .con.Close()
        End With

    End Sub
End Module
