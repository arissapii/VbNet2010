Public Class frmBmasuk

    Private Sub txtKodeSuplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodeSuplier.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oBM.CariBARANGMASUK(txtKodeSuplier.Text)
            If (barangmasuk_baru = False) Then
                TampilData()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub
    Private Sub ClearEntry()
        txtIDMasuk.Clear()
        txtKodeSuplier.Clear()
        txtnomorfaktur.Clear()
        txtNamaPenerima.Clear()
        txtKodeSuplier.Focus()
    End Sub
    Private Sub TampilData()
        txtIDMasuk.Text = oBM.idmasuk
        txtKodeSuplier.Text = oBM.kode_supplier
        txtNomorFaktur.Text = oBM.nomor_faktur
        txtNamaPenerima.Text = oBM.nama_penerima
    End Sub
    Private Sub SimpanBarangMasuk()
        oBM.idmasuk = txtIDMasuk.Text
        oBM.nomor_faktur = txtNomorFaktur.Text
        oBM.kode_supplier = txtKodeSuplier.Text
        oBM.nama_penerima = txtNamaPenerima.Text
        oBM.Simpan()
        reload()
        If (oBM.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oBM.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub reload()
        oBM.getAllData(DataGridView1)
    End Sub

    Private Sub btnSimpan_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        SimpanBarangMasuk()
    End Sub

    Private Sub btnHapus_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        ClearEntry()
    End Sub

    Private Sub frmBmasuk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oBM.CariBARANGMASUK(txtIDMasuk.Text)
            If (barangmasuk_baru = False) Then
                TampilData()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub frmBmasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
End Class