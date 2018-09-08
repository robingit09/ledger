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

    Public Sub saveledgerType()
        Dim dbledger As New DatabaseCon
        With dbledger
            .selectByQuery("select distinct customer,ledger from ledger")
            If .dr.HasRows Then
                While .dr.Read
                    Dim customer As String = .dr("customer")
                    Dim ledger As String = .dr("ledger")

                    If Val(customer) > 0 And Val(ledger) > -1 Then
                        Dim dbupdate As New DatabaseCon
                        With dbupdate
                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "UPDATE company set ledger_type = " & ledger & " where id = " & customer
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()
                        End With
                    End If
                End While
            Else
                '.dr.Close()
                '.selectByQuery("Select ledger_type from company where id = " & selectedCustomer)
                'If .dr.HasRows Then
                '    If .dr.Read Then
                '        selectedLedgerType = .dr("ledger_type")
                '        Select Case .dr("ledger_type")
                '            Case "0"
                '                cbLedgerType.SelectedIndex = cbLedgerType.FindString("Charge")

                '            Case "1"
                '                cbLedgerType.SelectedIndex = cbLedgerType.FindString("Delivery")
                '        End Select
                '    End If
                'End If
            End If
            .con.Close()
            .dr.Close()
            .cmd.Dispose()
        End With
    End Sub
End Module
