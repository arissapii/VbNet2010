Public Class frmBkeluar

    Private Sub txtnomorbukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnomorbukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtnomorbukti.Text <> "") Then
            oBK.CariBARANGKELUAR(txtnomorbukti.Text)
            txtnamastafftoko.Text = oBK.namastaff_toko
            txtnamastaffgudang.Text = oBK.namastaff_gudang
        End If
    End Sub
    Private Sub ClearEntry()
        txtidkeluar.Clear()
        txtnamastafftoko.Clear()
        txtnomorbukti.Clear()
        txtnamastaffgudang.Clear()
        txtnamastafftoko.Focus()
    End Sub
    Private Sub TampilData()
        txtidkeluar.Text = oBK.idkeluar
        txtnamastafftoko.Text = oBK.nomor_bukti
        txtnomorbukti.Text = oBK.namastaff_toko
        txtnamastaffgudang.Text = oBK.namastaff_gudang
    End Sub
    Private Sub SimpanBarangKeluar()
        oBK.idkeluar = txtidkeluar.Text
        oBK.nomor_bukti = txtnomorbukti.Text
        oBK.namastaff_toko = txtnamastafftoko.Text
        oBK.namastaff_gudang = txtnamastaffgudang.Text
        oBK.nama_barang = txtnamabarang.Text
        oBK.jumlah = txtjumlah.Text
        oBK.Simpan()
        reload()
        If (oBK.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oBK.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub

    Private Sub reload()
        oBK.getAllData(DataGridView1)
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        SimpanBarangKeluar()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        ClearEntry()
    End Sub

    Private Sub frmBkeluar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oBK.CariBARANGKELUAR(txtidkeluar.Text)
            If (barangkeluar_baru = False) Then
                TampilData()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub
    Private Sub frmBkeluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload()

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class