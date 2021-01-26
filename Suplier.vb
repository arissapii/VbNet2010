Public Class Suplier
    Dim strsql As String
    Dim info As String
    Private _idsuplier As System.Decimal
    Private _kode_suplier As System.String
    Private _nama_suplier As System.String
    Private _kontak_personal As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idsuplier()
        Get
            Return _idsuplier
        End Get
        Set(ByVal value)
            _idsuplier = value
        End Set
    End Property
    Public Property kode_suplier()
        Get
            Return _kode_suplier
        End Get
        Set(ByVal value)
            _kode_suplier = value
        End Set
    End Property
    Public Property nama_suplier()
        Get
            Return _nama_suplier
        End Get
        Set(ByVal value)
            _nama_suplier = value
        End Set
    End Property
    Public Property kontak_personal()
        Get
            Return _kontak_personal
        End Get
        Set(ByVal value)
            _kontak_personal = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (supplier_baru = True) Then
            strsql = "Insert into SUPLIER(idsuplier,kode_suplier,nama_suplier,kontak_personal) values ('" & _idsuplier & "','" & _kode_suplier & "','" & _nama_suplier & "','" & _kontak_personal & "')"
            info = "INSERT"
        Else
            strsql = "update SUPLIER set idsuplier='" & _idsuplier & "', kode_suplier='" & _kode_suplier & "', nama_suplier='" & _nama_suplier & "', kontak_personal='" & _kontak_personal & "' where IDSUPLIER='" & _idsuplier & "'"
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
    Public Sub CariSUPLIER(ByVal sIDSUPLIER As String)
        DBConnect()
        strsql = "SELECT * FROM SUPLIER WHERE IDSUPLIER='" & sIDSUPLIER & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            supplier_baru = False
            DR.Read()
            idsuplier = Convert.ToString((DR("idsuplier")))
            kode_suplier = Convert.ToString((DR("kode_suplier")))
            nama_suplier = Convert.ToString((DR("nama_suplier")))
            kontak_personal = Convert.ToString((DR("kontak_personal")))

        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            supplier_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sIDSUPLIER As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM SUPLIER WHERE IDSUPLIER='" & sIDSUPLIER & "'"
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
            strsql = "SELECT * FROM SUPLIER"
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
