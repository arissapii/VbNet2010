Public Class Barang
    Dim strsql As String
    Dim info As String
    Private _idbarang As System.Decimal
    Private _kode_barang As System.String
    Private _nama_barang As System.String
    Private _satuan As System.Decimal
    Private _stok As System.Decimal
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idbarang()
        Get
            Return _idbarang
        End Get
        Set(ByVal value)
            _idbarang = value
        End Set
    End Property
    Public Property kode_barang()
        Get
            Return _kode_barang
        End Get
        Set(ByVal value)
            _kode_barang = value
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
    Public Property stok()
        Get
            Return _stok
        End Get
        Set(ByVal value)
            _stok = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (BARANG_baru = True) Then
            strsql = "Insert into BARANG(idbarang,kode_barang,nama_barang,satuan,stok) values ('" & _idbarang & "','" & _kode_barang & "','" & _nama_barang & "','" & _satuan & "','" & _stok & "')"
            info = "INSERT"
        Else
            strsql = "update BARANG set idbarang='" & _idbarang & "', kode_barang='" & _kode_barang & "', nama_barang='" & _nama_barang & "', satuan='" & _satuan & "', stok='" & _stok & "' where KODE_BARANG='" & _KODE_BARANG & "'"
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
    Public Sub CariBARANG(ByVal sIDBARANG As String)
        DBConnect()
        strsql = "SELECT * FROM BARANG WHERE IDBARANG='" & sIDBARANG & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            BARANG_baru = False
            DR.Read()
            idbarang = Convert.ToString((DR("idbarang")))
            kode_barang = Convert.ToString((DR("kode_barang")))
            nama_barang = Convert.ToString((DR("nama_barang")))
            stok = Convert.ToString((DR("stok")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            BARANG_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDBARANG As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM BARANG WHERE IDBARANG='" & sIDBARANG & "'"
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
            strsql = "SELECT * FROM BARANG"
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
