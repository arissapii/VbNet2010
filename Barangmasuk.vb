Public Class Barangmasuk
    Dim strsql As String
    Dim info As String
    Private _idmasuk As System.String
    Private _nomor_faktur As System.String
    Private _kode_supplier As System.String
    Private _tanggal As System.String
    Private _nama_penerima As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idmasuk()
        Get
            Return _idmasuk
        End Get
        Set(ByVal value)
            _idmasuk = value
        End Set
    End Property
    Public Property nomor_faktur()
        Get
            Return _nomor_faktur
        End Get
        Set(ByVal value)
            _nomor_faktur = value
        End Set
    End Property
    Public Property kode_supplier()
        Get
            Return _kode_supplier
        End Get
        Set(ByVal value)
            _kode_supplier = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(ByVal value)
            _tanggal = value
        End Set
    End Property
    Public Property nama_penerima()
        Get
            Return _nama_penerima
        End Get
        Set(ByVal value)
            _nama_penerima = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (BARANGMASUK_baru = True) Then
            strsql = "Insert into BARANGMASUK(idmasuk,nomor_faktur,kode_supplier,tanggal,nama_penerima) values ('" & _idmasuk & "','" & _nomor_faktur & "','" & _kode_supplier & "','" & _tanggal & "','" & _nama_penerima & "')"
            info = "INSERT"
        Else
            strsql = "update BARANGMASUK set idmasuk='" & _idmasuk & "', nomor_faktur='" & _nomor_faktur & "', kode_supplier='" & _kode_supplier & "', tanggal='" & _tanggal & "', nama_penerima='" & _nama_penerima & "' where NOMOR_FAKTUR='" & _NOMOR_FAKTUR & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub CariBARANGMASUK(ByVal sIDMASUK As String)
        DBConnect()
        strsql = "SELECT * FROM BARANGMASUK WHERE IDMASUK='" & sIDMASUK & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            BARANGMASUK_baru = False
            DR.Read()
            idmasuk = Convert.ToString((DR("idmasuk")))
            nomor_faktur = Convert.ToString((DR("nomor_faktur")))
            kode_supplier = Convert.ToString((DR("kode_suplier")))
            nama_penerima = Convert.ToString((DR("nama_penerima")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            BARANGMASUK_baru = True
        End If
        DBDisconnect()
    End Sub

    Public Sub Hapus(ByVal sIDMASUK As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM BARANGMASUK WHERE IDMASUK='" & sIDMASUK & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM BARANGMASUK"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
