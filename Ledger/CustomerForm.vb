Public Class CustomerForm

    Public selectedCustomer As Integer = 0
    Public selectedCompanyStatus As Integer = 0
    Public selectedLedgerType As Integer = -1
    Public selectedBusinessType As Integer = 0

    Private Sub CustomerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        autocompleteCity()
        'loadCompanyStatus()

    End Sub

    Public Sub loadBusinessType()
        cbBusinessType.DataSource = Nothing
        cbBusinessType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Business Type")
        comboSource.Add(1, "Shop")
        comboSource.Add(2, "Paint Center")

        cbBusinessType.DataSource = New BindingSource(comboSource, Nothing)
        cbBusinessType.DisplayMember = "Value"
        cbBusinessType.ValueMember = "Key"

    End Sub

    Public Sub loadToUpdateInfo()

        Dim db As New DatabaseCon
        With db
            .selectByQuery("Select * from company where status <> 0 and ID = " & selectedCustomer)
            If .dr.Read Then
                Dim ID As Integer = CInt(.dr.GetValue(0))
                Dim customer As String = .dr.GetValue(1)
                Dim contact_person As String = .dr.GetValue(2)
                Dim address As String = If(.dr.GetValue(3) = "", " ", .dr.GetValue(3))
                Dim owner_name As String = If(.dr.GetValue(4) = "", " ", .dr.GetValue(4))
                Dim owner_address As String = If(.dr.GetValue(5) = "", " ", .dr.GetValue(5))
                Dim contact_number1 As String = If(.dr.GetValue(6) = "", " ", .dr.GetValue(6))
                Dim contact_number2 As String = If(.dr.GetValue(7) = "", " ", .dr.GetValue(7))
                Dim fax_tel As String = If(.dr.GetValue(8) = "", " ", .dr.GetValue(8))
                'Dim status As Integer = CInt(.dr.GetValue(9))
                'Dim created_at As Integer = CInt(.dr.GetValue(10))
                'Dim updated_at As String = .dr.GetValue(11)
                Dim city As String = If(.dr.GetValue(12) = "", " ", .dr.GetValue(12))
                Dim tin As String = If(.dr.GetValue(13) = "", " ", .dr.GetValue(13))
                Dim email As String = If(.dr.GetValue(14) = "", " ", .dr.GetValue(14))
                Dim company_status As Integer = CInt(.dr.GetValue(15))
                Dim company_status_result As String = ""
                Dim business_type As String = If(IsDBNull(.dr("business_type")), 0, .dr("business_type"))

                Select Case company_status
                    Case 0
                        company_status_result = "Rented"
                        cbCompanyStatus.SelectedIndex = 1
                    Case 1
                        company_status_result = "Owned"
                        cbCompanyStatus.SelectedIndex = 2
                End Select

                Dim ledger_type As String = If(IsDBNull(.dr("ledger_type")), "", .dr("ledger_type"))
                Select Case ledger_type
                    Case "0"
                        ledger_type = "Charge"
                        selectedLedgerType = 0
                    Case "1"
                        ledger_type = "Delivery"
                        selectedLedgerType = 1
                    Case Else
                        ledger_type = ""
                        selectedLedgerType = -1
                End Select

                txtCompany.Text = customer
                txtContactPerson.Text = contact_person
                txtAddress.Text = address
                txtOwner.Text = owner_name
                txtOwnerAddress.Text = owner_address
                txtContact1.Text = contact_number1
                txtContact2.Text = contact_number2
                txtFax.Text = fax_tel
                txtCity.Text = city
                txtTin.Text = tin
                txtEmail.Text = email

                If ledger_type = "" Then
                    selectedLedgerType = -1
                    cbLedgerType.SelectedIndex = 0
                Else
                    cbLedgerType.SelectedIndex = cbLedgerType.FindString(ledger_type)
                End If


                Select Case CInt(business_type)
                    Case 1
                        selectedBusinessType = 1
                        cbBusinessType.SelectedIndex = 1
                    Case 2
                        selectedBusinessType = 2
                        cbBusinessType.SelectedIndex = 2
                    Case Else
                        selectedBusinessType = 0
                        cbBusinessType.SelectedIndex = 0
                End Select


            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Public Sub loadCompanyStatus()
        cbCompanyStatus.DataSource = Nothing
        cbCompanyStatus.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Status")
        comboSource.Add(1, "Rented")
        comboSource.Add(2, "Owned")
        cbCompanyStatus.DataSource = New BindingSource(comboSource, Nothing)
        cbCompanyStatus.DisplayMember = "Value"
        cbCompanyStatus.ValueMember = "Key"

    End Sub

    Public Sub loadLedgerType()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(-1, "Select Ledger Type")
        comboSource.Add(0, "Charge")
        comboSource.Add(1, "Delivery")
        cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
        cbLedgerType.DisplayMember = "Value"
        cbLedgerType.ValueMember = "Key"
    End Sub


    Public Sub autocompleteCity()
        Dim MySource As New AutoCompleteStringCollection()

        With txtCity
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

    Private Sub saveData()
        Dim database As New DatabaseCon
        Try
            With database
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO company([company],[contact_person],[address],[owner_name],[owner_address],[contact_number1],[contact_number2],[fax_tel],[tin],[email],[city],status,[created_at],[updated_at],[company_status],[ledger_type],[business_type])" &
                "VALUES(@company,@contact_person,@address,@owner_name,@owner_address,@contact_number1,@contact_number2,@fax_tel,@tin,@email,@city,@st,@created_at,@updated_at,@company_status,@ledger_type,@business_type)"

                .cmd.Parameters.AddWithValue("@company", txtCompany.Text)
                .cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text)
                .cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                .cmd.Parameters.AddWithValue("@owner_name", txtOwner.Text)
                .cmd.Parameters.AddWithValue("@owner_address", txtOwnerAddress.Text)
                .cmd.Parameters.AddWithValue("@contact_number1", txtContact1.Text)
                .cmd.Parameters.AddWithValue("@contact_number2", txtContact2.Text)
                .cmd.Parameters.AddWithValue("@fax_tel", txtFax.Text)
                .cmd.Parameters.AddWithValue("@tin", txtTin.Text)
                .cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                .cmd.Parameters.AddWithValue("@city", txtCity.Text)
                .cmd.Parameters.AddWithValue("@st", 1)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date)
                .cmd.Parameters.AddWithValue("@company_status", selectedCompanyStatus)
                .cmd.Parameters.AddWithValue("@ledger_type", selectedLedgerType)
                .cmd.Parameters.AddWithValue("@business_type", selectedBusinessType)
                .cmd.Connection = database.con
                .cmd.ExecuteNonQuery()
                .con.Close()
                MsgBox("Save Successful", MsgBoxStyle.Information)

                'frmListEdger.lvEdger.Items.Clear()
                'frmListEdger.loadList("", "")
                clearFields()

                'frmCustomerList.loadList("")
                'frmCustomerList.populateComboLocation()
                Me.Close()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub updateData()
        Dim database As New DatabaseCon
        Dim dbupdateledger As New DatabaseCon
        Try

            database.cmd.CommandType = CommandType.Text
            database.cmd.CommandText = "UPDATE company SET [company]='" & txtCompany.Text & "',[contact_person]='" & txtContactPerson.Text & "',[address]='" & txtAddress.Text & "',[owner_name]='" & txtOwner.Text & "',[owner_address]='" & txtOwnerAddress.Text & "',[contact_number1]='" & txtContact1.Text & "', " &
                                        "[contact_number2]='" & txtContact2.Text & "',[fax_tel]='" & txtFax.Text & "', [tin]='" & txtTin.Text & "',[email]='" & txtEmail.Text & "',[city]='" & txtCity.Text & "',[company_status]=" & selectedCompanyStatus & ", [ledger_type] = " & selectedLedgerType & ", [business_type] = " & selectedBusinessType & " WHERE [ID] = " & Me.selectedCustomer
            database.cmd.Connection = database.con
            database.cmd.ExecuteNonQuery()

            database.cmd.CommandText = "UPDATE ledger set [ledger] = " & selectedLedgerType & " where [customer] = " & Me.selectedCustomer
            database.cmd.ExecuteNonQuery()
            'MsgBox(database.cmd.CommandText, MsgBoxStyle.Information)

            database.cmd.Dispose()
            database.con.Close()

            MsgBox("Customer Update Successfully", MsgBoxStyle.Information)
            clearFields()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub clearFields()
        txtCompany.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtContactPerson.Text = ""
        txtOwner.Text = ""
        txtOwnerAddress.Text = ""
        txtContact1.Text = ""
        txtContact2.Text = ""
        txtEmail.Text = ""

        txtFax.Text = ""
        txtTin.Text = ""

        If cbCompanyStatus.Items.Count > 0 Then
            cbCompanyStatus.SelectedIndex = 0
        End If

        If cbBusinessType.Items.Count > 0 Then
            cbBusinessType.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If validation() Then
                Exit Sub
            End If
            saveData()
            LedgerForm.getCustomerList("")
            LedgerList.autocompleteCustomer()
            CustomerList.load_customer_worker.RunWorkerAsync()
            clearFields()
            LedgerList.loadLedger("")
            LedgerList.getBusinessType()
        ElseIf btnSave.Text = "Update" Then
            'MsgBox(selectedLedgerType)
            'Exit Sub
            If validation() Then
                Exit Sub
            End If
            updateData()
            LedgerForm.getCustomerList("")
            LedgerList.autocompleteCustomer()
            CustomerList.load_customer_worker.RunWorkerAsync()
            clearFields()
            LedgerList.loadLedger("")
            LedgerList.getBusinessType()
        End If
    End Sub

    Private Function validation() As Boolean
        Dim err_ As Boolean = False
        If txtCompany.Text = "" Then
            txtCompany.Focus()
            txtCompany.BackColor = Color.Red
            MsgBox("Company fields required!", MsgBoxStyle.Critical)
            err_ = True
            Return err_
        End If

        'If txtContactPerson.Text = "" Then
        '    txtContactPerson.Focus()
        '    txtContactPerson.BackColor = Color.Red
        '    MsgBox("Contact person fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtOwner.Text = "" Then
        '    txtOwner.Focus()
        '    txtOwner.BackColor = Color.Red
        '    MsgBox("Owner name fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtOwnerAddress.Text = "" Then
        '    txtOwnerAddress.Focus()
        '    txtOwnerAddress.BackColor = Color.Red
        '    MsgBox("Owner address fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtAddress.Text = "" Then
        '    txtAddress.Focus()
        '    txtAddress.BackColor = Color.Red
        '    MsgBox("Address fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtCity.Text = "" Then
        '    txtCity.Focus()
        '    txtCity.BackColor = Color.Red
        '    MsgBox("City/Town fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtContact1.Text = "" Then
        '    txtContact1.Focus()
        '    txtContact1.BackColor = Color.Red
        '    MsgBox("Contact number 1 fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtFax.Text = "" Then
        '    txtFax.Focus()
        '    txtFax.BackColor = Color.Red
        '    MsgBox("Fax/Tel fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtTin.Text = "" Then
        '    txtTin.Focus()
        '    txtTin.BackColor = Color.Red
        '    MsgBox("TIN fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If txtEmail.Text = "" Then
        '    txtEmail.Focus()
        '    txtEmail.BackColor = Color.Red
        '    MsgBox("Email fields required!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        'If cbCompanyStatus.SelectedIndex = 0 Then
        '    cbCompanyStatus.Focus()
        '    cbCompanyStatus.BackColor = Color.Red
        '    MsgBox("Please select company status!", MsgBoxStyle.Critical)
        '    err_ = True
        '    Return err_
        'End If

        If cbLedgerType.SelectedIndex = 0 Then
            cbLedgerType.Focus()
            cbLedgerType.BackColor = Color.Red
            MsgBox("Ledger type fields required!", MsgBoxStyle.Critical)
            err_ = True
            Return err_
        End If
        If btnSave.Text = "Save" Then
            Dim db As New DatabaseCon
            With db
                If (.isExist("company", "company", Trim(txtCompany.Text))) Then
                    txtCompany.Focus()
                    txtCompany.BackColor = Color.Red
                    MsgBox(txtCompany.Text & " already exist!", MsgBoxStyle.Critical)
                    err_ = True
                    Return err_
                End If
            End With
        End If
        Return err_
    End Function

   
    Private Sub cbCompanyStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCompanyStatus.SelectedIndexChanged

        If cbCompanyStatus.SelectedIndex > -1 Then

            Dim key As String = DirectCast(cbCompanyStatus.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCompanyStatus.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCompanyStatus = key
            cbCompanyStatus.BackColor = Color.White

        End If
       
    End Sub

    Private Sub txtCompany_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompany.TextChanged
        If txtCompany.TextLength > 0 Then
            txtCompany.BackColor = Color.White
        End If
    End Sub

    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.TextChanged
        If txtAddress.TextLength > 0 Then
            txtAddress.BackColor = Color.White
        End If
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged
        If txtCity.TextLength > 0 Then
            txtCity.BackColor = Color.White
        End If
    End Sub

    Private Sub txtContactPerson_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactPerson.TextChanged
        If txtContactPerson.TextLength > 0 Then
            txtContactPerson.BackColor = Color.White
        End If
    End Sub

    Private Sub txtOwner_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOwner.TextChanged
        If txtOwner.TextLength > 0 Then
            txtOwner.BackColor = Color.White
        End If
    End Sub

    Private Sub txtOwnerAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOwnerAddress.TextChanged
        If txtOwnerAddress.TextLength > 0 Then
            txtOwnerAddress.BackColor = Color.White
        End If
    End Sub

    Private Sub txtContact1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContact1.TextChanged
        If txtContact1.TextLength > 0 Then
            txtContact1.BackColor = Color.White
        End If
    End Sub

    Private Sub txtContact2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContact2.TextChanged
        If txtContact2.TextLength > 0 Then
            txtContact2.BackColor = Color.White
        End If
    End Sub

    Private Sub txtFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFax.TextChanged
        If txtFax.TextLength > 0 Then
            txtFax.BackColor = Color.White
        End If
    End Sub

    Private Sub txtTin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTin.TextChanged
        If txtTin.TextLength > 0 Then
            txtTin.BackColor = Color.White
        End If
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged
        If txtEmail.TextLength > 0 Then
            txtEmail.BackColor = Color.White
        End If
    End Sub

    Private Sub txtCompany_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompany.Leave
        If txtCompany.Text.Length > 0 Then
            txtCompany.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCompany.Text.ToLower())
        End If
    End Sub

    Private Sub txtAddress_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.Leave
        If txtAddress.Text.Length > 0 Then
            txtAddress.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtAddress.Text.ToLower())
        End If
    End Sub

    Private Sub txtCity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.Leave
        If txtCity.Text.Length > 0 Then
            txtCity.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCity.Text.ToLower())
        End If
    End Sub

    Private Sub txtContactPerson_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactPerson.Leave
        If txtContactPerson.Text.Length > 0 Then
            txtContactPerson.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtContactPerson.Text.ToLower())
        End If
    End Sub

    Private Sub txtOwner_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOwner.Leave
        If txtOwner.Text.Length > 0 Then
            txtOwner.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtOwner.Text.ToLower())
        End If
    End Sub

    Private Sub txtOwnerAddress_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOwnerAddress.Leave
        If txtOwnerAddress.Text.Length > 0 Then
            txtOwnerAddress.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtOwnerAddress.Text.ToLower())
        End If
    End Sub


    Private Sub txtEmail_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.Leave
        If txtEmail.Text.Length > 0 Then
            txtEmail.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtEmail.Text.ToLower())
        End If
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedLedgerType = key
            cbLedgerType.BackColor = Color.White
        Else
            selectedLedgerType = -1
            cbLedgerType.SelectedIndex = 0
        End If

    End Sub

    Private Sub cbBusinessType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBusinessType.SelectedIndexChanged
        If cbBusinessType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBusinessType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBusinessType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBusinessType = key
            cbBusinessType.BackColor = Color.White
        Else
            selectedBusinessType = -1
            cbBusinessType.SelectedIndex = 0
        End If
    End Sub
End Class