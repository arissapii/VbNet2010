Imports System.Data.OracleClient
Imports DevComponents.DotNetBar
Imports System.Security.Cryptography
Module MyMod
    Public cldMasuk As New frmBmasuk()
    Public cldKeluar As New frmBkeluar()
    Public cldBarang As New frmBarang()
    Public cldSuplier As New frmSuplier()

    Public menu_Masuk As Boolean
    Public menu_Keluar As Boolean
    Public menu_Barang As Boolean
    Public menu_Suplier As Boolean

    Public mycommand As New System.Data.OracleClient.OracleCommand
    Public myadapter As New System.Data.OracleClient.OracleDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OracleClient.OracleDataReader
    Public SQL As String
    Public conn As New System.Data.OracleClient.OracleConnection
    Public cn As New Connection

    'Table1 User
    '--------------------------------
    Public user_baru As Boolean
    Public oUser As New User
    '--------------------------------
    'Tabel Login
    '--------------------------------
    Public login_valid As Boolean
    Public nobukti As Double
    '--------------------------------
    'Tabel Barang
    '--------------------------------
    Public Barang_baru As Boolean
    Public obarang As New Barang
    '--------------------------------
    'Tabel Barangkeluar
    '--------------------------------
    Public barangkeluar_baru As Boolean
    Public barangkeluar_detail_baru As Boolean
    Public oBK As New BarangKeluar
    '--------------------------------
    'Tabel Barangmasuk
    '--------------------------------
    Public barangmasuk_baru As Boolean
    Public barangmasuk_detail_baru As Boolean
    Public oBM As New Barangmasuk
    '--------------------------------
    'Tabel Supplier
    '--------------------------------
    Public supplier_baru As Boolean
    Public osupplier As New Suplier
    '--------------------------------
    Public kodesupp As Double
    Public R As Random = New Random
    Public TotalTab As Integer = 0
    Public x As Integer

    Public Sub DBConnect()
        cn.DataSource = "xe"
        cn.UserID = "arissapii"
        cn.Password = "123"
        cn.Connect()
    End Sub

    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function
    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)

    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public Function getNomorBukti()
        Dim res As Double
        res = R.Next(1000000, 9999999)
        Return res
    End Function
End Module
