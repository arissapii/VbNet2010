Public Class frmBarang
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanBarang()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub txtkodebarang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodebarang.KeyDown
        If (e.KeyCode = Keys.Enter And txtkodebarang.Text <> "") Then
            obarang.Caribarang(txtkodebarang.Text)
            txtnamabarang.Text = obarang.nama_barang
            txtstok.Text = obarang.stok
        End If
    End Sub
    Private Sub ClearEntry()
        txtidbarang.Clear()
        txtkodebarang.Clear()
        txtnamabarang.Clear()
        txtstok.Clear()
        txtkodebarang.Focus()
    End Sub
    Private Sub TampilData()
        txtidbarang.Text = obarang.idbarang
        txtkodebarang.Text = obarang.kode_barang
        txtnamabarang.Text = obarang.nama_barang
        txtstok.Text = obarang.stok
    End Sub
    Private Sub SimpanBarang()
        obarang.idbarang = txtidbarang.Text
        obarang.kode_barang = txtkodebarang.Text
        obarang.nama_barang = txtnamabarang.Text
        obarang.stok = txtstok.Text
        obarang.Simpan()
        reload()
        If (obarang.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (obarang.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub reload()
        obarang.getAllData(DataGridView1)
    End Sub

    Private Sub frmBarang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            obarang.CariBARANG(txtkodebarang.Text)
            If (Barang_baru = False) Then
                TampilData()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub frmBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub

End Class