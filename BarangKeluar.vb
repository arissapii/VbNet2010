Public Class BarangKeluar
    Dim strsql As String
    Dim info As String
    Private _idkeluar As System.Decimal
    Private _nomor_bukti As System.Decimal
    Private _namastaff_toko As System.String
    Private _namastaff_gudang As System.String
    Private _nama_barang As System.String
    Private _jumlah As System.Decimal
    Private _tanggal As System.DateTime
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idkeluar()
        Get
            Return _idkeluar
        End Get
        Set(ByVal value)
            _idkeluar = value
        End Set
    End Property
    Public Property nomor_bukti()
        Get
            Return _nomor_bukti
        End Get
        Set(ByVal value)
            _nomor_bukti = value
        End Set
    End Property
    Public Property namastaff_toko()
        Get
            Return _namastaff_toko
        End Get
        Set(ByVal value)
            _namastaff_toko = value
        End Set
    End Property
    Public Property namastaff_gudang()
        Get
            Return _namastaff_gudang
        End Get
        Set(ByVal value)
            _namastaff_gudang = value
        End Set
    End Property
    Public Property nama_barang()
        Get
            Return _nama_barang
        End Get
        Set(ByVal value)
            _nama_barang = value
        End Set
    End Property
    Public Property jumlah()
        Get
            Return _jumlah
        End Get
        Set(ByVal value)
            _jumlah = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (BARANGKELUAR_baru = True) Then
            strsql = "Insert into BARANGKELUAR(idkeluar,nomor_bukti,namastaff_toko,namastaff_gudang,nama_barang,jumlah,tanggal) values ('" & _idkeluar & "','" & _nomor_bukti & "','" & _namastaff_toko & "','" & _namastaff_gudang & "','" & _nama_barang & "','" & _jumlah & "','" & _tanggal & "')"
            info = "INSERT"
        Else
            strsql = "update BARANGKELUAR set idkeluar='" & _idkeluar & "', nomor_bukti='" & _nomor_bukti & "', namastaff_toko='" & _namastaff_toko & "', namastaff_gudang='" & _namastaff_gudang & "', nama_barang='" & _nama_barang & "', jumlah='" & _jumlah & "', tanggal='" & _tanggal & "' where NOMOR_BUKTI='" & _NOMOR_BUKTI & "'"
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
    Public Sub CariBARANGKELUAR(ByVal sIDKELUAR As String)
        DBConnect()
        strsql = "SELECT * FROM BARANGKELUAR WHERE IDKELUAR='" & sIDKELUAR & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            BARANGKELUAR_baru = False
            DR.Read()
            idkeluar = Convert.ToString((DR("idkeluar")))
            nomor_bukti = Convert.ToString((DR("nomor_bukti")))
            namastaff_toko = Convert.ToString((DR("namastaff_toko")))
            namastaff_gudang = Convert.ToString((DR("namastaff_gudang")))
            nama_barang = Convert.ToString((DR("nama_barang")))
            jumlah = Convert.ToString((DR("jumlah")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            BARANGKELUAR_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDKELUAR As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM BARANGKELUAR WHERE IDKELUAR='" & sIDKELUAR & "'"
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
            strsql = "SELECT * FROM BARANGKELUAR"
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
