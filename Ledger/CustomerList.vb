Public Class CustomerList
    Public selectedID As Integer = 0
    Private Sub CustomerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCustomer("")
        autocompleteCustomer()
        autocompleteCity()
    End Sub

    Public Sub autocompleteCustomer()
        Dim MySource As New AutoCompleteStringCollection()

        With txtCustomer
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim customer As New DatabaseCon
        With customer
            .selectByQuery("Select distinct company from company  where status <> 0")
            While .dr.Read
                MySource.Add(.dr.GetValue(0))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub autocompleteCity()
        Dim MySource As New AutoCompleteStringCollection()

        With txtLocation
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        MySource.Add("Alaminos")
        MySource.Add("Angeles")
        MySource.Add("Antipolo")
        MySource.Add("Bacolod")
        MySource.Add("Bacoor")
        MySource.Add("Bago")
        MySource.Add("Baguio")
        MySource.Add("Bais")
        MySource.Add("Balanga")
        MySource.Add("Batac")
        MySource.Add("Batangas City")
        MySource.Add("Bayawan")
        MySource.Add("Baybay")
        MySource.Add("Bayugan")
        MySource.Add("Biñan")
        MySource.Add("Bislig")
        MySource.Add("Bogo")
        MySource.Add("Borongan")
        MySource.Add("Butuan")
        MySource.Add("Cabadbaran")
        MySource.Add("Cabanatuan")
        MySource.Add("Cabuyao")
        MySource.Add("Cadiz")
        MySource.Add("Cagayan de Oro")
        MySource.Add("Calamba")
        MySource.Add("Calapan")
        MySource.Add("Calbayog")
        MySource.Add("Caloocan")
        MySource.Add("Candon")
        MySource.Add("Canlaon")
        MySource.Add("Carcar")
        MySource.Add("Catbalogan")
        MySource.Add("Cavite City")
        MySource.Add("Cebu City")
        MySource.Add("Cotabato City")
        MySource.Add("Dagupan")
        MySource.Add("Danao")
        MySource.Add("Dapitan")
        MySource.Add("Dasmariñas")
        MySource.Add("Davao City")
        MySource.Add("Digos")
        MySource.Add("Dipolog")
        MySource.Add("Dumaguete")
        MySource.Add("El Salvador")
        MySource.Add("Escalante")
        MySource.Add("Gapan")
        MySource.Add("General Santos")
        MySource.Add("General Trias")
        MySource.Add("Gingoog")
        MySource.Add("Guihulngan")
        MySource.Add("Himamaylan")
        MySource.Add("Ilagan")
        MySource.Add("Iligan")
        MySource.Add("Iloilo City")
        MySource.Add("Imus")
        MySource.Add("Iriga")
        MySource.Add("Isabela")
        MySource.Add("Kabankalan")
        MySource.Add("Kidapawan")
        MySource.Add("Koronadal")
        MySource.Add("La Carlota")
        MySource.Add("Lamitan")
        MySource.Add("Laoag")
        MySource.Add("Lapu‑Lapu")
        MySource.Add("Las Piñas")
        MySource.Add("Legazpi")
        MySource.Add("Ligao")
        MySource.Add("Lipa")
        MySource.Add("Lucena")
        MySource.Add("Maasin")
        MySource.Add("Mabalacat")
        MySource.Add("Makati")
        MySource.Add("Malabon")
        MySource.Add("Malaybalay")
        MySource.Add("Malolos")
        MySource.Add("Mandaluyong")
        MySource.Add("Mandaue")
        MySource.Add("Manila")
        MySource.Add("Marawi")
        MySource.Add("Marikina")
        MySource.Add("Masbate City")
        MySource.Add("Mati")
        MySource.Add("Meycauayan")
        MySource.Add("Muñoz")
        MySource.Add("Muntinlupa")
        MySource.Add("Naga")
        MySource.Add("Navotas")
        MySource.Add("Olongapo")
        MySource.Add("Ormoc")
        MySource.Add("Oroquieta")
        MySource.Add("Ozamiz")
        MySource.Add("Pagadian")
        MySource.Add("Palayan")
        MySource.Add("Panabo")
        MySource.Add("Parañaque")
        MySource.Add("Pasay")
        MySource.Add("Pasig")
        MySource.Add("Passi")
        MySource.Add("Puerto Princesa")
        MySource.Add("Quezon City")
        MySource.Add("Roxas")
        MySource.Add("Sagay")
        MySource.Add("Samal")
        MySource.Add("San Carlos")
        MySource.Add("San Fernando")
        MySource.Add("San Jose")
        MySource.Add("San Jose del Monte")
        MySource.Add("San Juan")
        MySource.Add("San Pablo")
        MySource.Add("San Pedro")
        MySource.Add("Santa Rosa")
        MySource.Add("Santiago")
        MySource.Add("Silay")
        MySource.Add("Sipalay")
        MySource.Add("Sorsogon City")
        MySource.Add("Surigao City")
        MySource.Add("Tabaco")
        MySource.Add("Tabuk")
        MySource.Add("Tacloban")
        MySource.Add("Tacurong")
        MySource.Add("Tagaytay")
        MySource.Add("Tagbilaran")
        MySource.Add("Taguig")
        MySource.Add("Tagum")
        MySource.Add("Talisay")
        MySource.Add("Tanauan")
        MySource.Add("Tandag")
        MySource.Add("Tangub")
        MySource.Add("Tanjay")
        MySource.Add("Tarlac City")
        MySource.Add("Tayabas")
        MySource.Add("Toledo")
        MySource.Add("Trece Martires")
        MySource.Add("Tuguegarao")
        MySource.Add("Urdaneta")
        MySource.Add("Valencia")
        MySource.Add("Valenzuela")
        MySource.Add("Victorias")
        MySource.Add("Vigan")
        MySource.Add("Zamboanga City")


        'Dim customer As New DatabaseCon
        'With customer
        '    .selectByQuery("Select distinct company from company  where status <> 0")
        '    While .dr.Read
        '        MySource.Add(.dr.GetValue(0))

        '    End While
        '    .cmd.Dispose()
        '    .dr.Close()
        '    .con.Close()
        'End With
    End Sub

    Public Sub loadCustomer(ByVal query As String)
        dgvCustomer.Rows.Clear()
        Try
            Dim db As New DatabaseCon
            With db
                If query = "" Then
                    .selectByQuery("SELECT * from company where status <> 0 order by id desc")
                Else
                    .selectByQuery(query)
                End If
                If .dr.HasRows = False Then
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    MsgBox("No record found!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                While .dr.Read
                    Dim ID As Integer = CInt(.dr.GetValue(0))
                    Dim customer As String = .dr.GetValue(1)
                    Dim contact_person As String = If(.dr.GetValue(2) = "", " ", .dr.GetValue(2))
                    Dim address As String = If(.dr.GetValue(3) = "", " ", .dr.GetValue(3))
                    Dim owner_name As String = If(.dr.GetValue(4) = "", " ", .dr.GetValue(4))
                    Dim owner_address As String = If(IsDBNull(.dr.GetValue(5)), " ", .dr.GetValue(5))

                    Dim contact_number1 As String = If(.dr.GetValue(6) = "", " ", .dr.GetValue(6))
                    Dim contact_number2 As String = If(Trim(.dr.GetValue(7)) = "", " ", .dr.GetValue(7))
                    Dim fax_tel As String = If(Trim(.dr.GetValue(8)) = "", " ", .dr.GetValue(8))
                    'Dim status As Integer = CInt(.dr.GetValue(9))
                    'Dim created_at As Integer = CInt(.dr.GetValue(10))
                    'Dim updated_at As String = .dr.GetValue(11)
                    Dim city As String = If(.dr.GetValue(12) = "", " ", .dr.GetValue(12))
                    Dim tin As String = If(Trim(.dr.GetValue(13)) = "", " ", .dr.GetValue(13))
                    Dim email As String = If(Trim(.dr.GetValue(14)) = "", " ", .dr.GetValue(14))
                    Dim company_status As Integer = CInt(.dr.GetValue(15))

                    Dim company_status_result As String = ""

                    Select Case company_status
                        Case 0
                            company_status_result = ""
                        Case 1
                            company_status_result = "Rented"
                        Case 2
                            company_status_result = "Owned"
                    End Select
                    Dim row As String() = New String() {ID, customer, contact_person, address, city, owner_name, owner_address, contact_number1, contact_number2, fax_tel, tin, email, company_status_result}
                    dgvCustomer.Rows.Add(row)

                End While

                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " SIRA SIRA", MsgBoxStyle.Critical)
        End Try

    End Sub

    

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        CustomerForm.btnSave.Text = "Save"
        CustomerForm.loadCompanyStatus()
        CustomerForm.loadLedgerType()
        CustomerForm.clearFields()
        CustomerForm.ShowDialog()

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If dgvCustomer.SelectedRows.Count = 1 Then
            CustomerForm.btnSave.Text = "Update"
            CustomerForm.selectedCustomer = Me.selectedID
            CustomerForm.loadCompanyStatus()
            CustomerForm.loadLedgerType()
            CustomerForm.loadToUpdateInfo()
            CustomerForm.ShowDialog()
        Else

            MsgBox("Please select one customer to update!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub dgvCustomer_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomer.CellClick
        If dgvCustomer.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvCustomer.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgvCustomer.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvCustomer.SelectedRows(0).Cells(0).Value)
            Dim yesno As Integer = MsgBox("Are you sure you want to delete this record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            If yesno = MsgBoxResult.Yes Then
                Dim db As New DatabaseCon
                db.update_where("company", selectedID, "status", 0)
                db.cmd.Dispose()
                db.con.Close()
                loadCustomer("")
                MsgBox("Record deleted", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Please select one record you want to delete", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Dim query As String = "SELECT * from company where status <> 0"

        If Trim(txtCustomer.Text).Length > 0 Then
            query = query & " and company like '%" & txtCustomer.Text & "%'"
        End If

        If Trim(txtLocation.Text).Length > 0 Then
            query = query & " and city like '%" & txtLocation.Text & "%'"
        End If
        query = query & " order by id desc"
        loadCustomer(query)

    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub txtShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShowAll.Click
        loadCustomer("")
    End Sub

    Private Sub dgvCustomer_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCustomer.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgvCustomer.ClearSelection()
            dgvCustomer.Rows(e.RowIndex).Selected = True
            VIew.Show(Cursor.Position)
        End If
    End Sub

    Private Sub VIew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIew.Click
        btnUpdate.PerformClick()
    End Sub

    Private Sub txtCustomer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyUp
        If txtCustomer.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtCustomer.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCustomer.Text.ToLower())
        End If
    End Sub

    Private Sub txtLocation_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyUp
        If txtLocation.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtLocation.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtLocation.Text.ToLower())
        End If
    End Sub
End Class