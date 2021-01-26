Public Class frmSuplier

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
            Simpansupplier()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        ClearEntry()
    End Sub

    Private Sub txtIDSuplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIDSuplier.KeyDown
        If (e.KeyCode = Keys.Enter And txtIDSuplier.Text <> "") Then
            osupplier.CariSUPLIER(txtIDSuplier.Text)
            txtNamaSuplier.Text = osupplier.nama_suplier
            txtKodeSuplier.Text = osupplier.kode_suplier
            txtKontakPersonal.Text = osupplier.kontak_personal

        End If
    End Sub
    Private Sub ClearEntry()
        txtIDSuplier.Clear()
        txtKodeSuplier.Clear()
        txtNamaSuplier.Clear()
        txtKontakPersonal.Clear()
        txtIDSuplier.Focus()
    End Sub
    Private Sub TampilData()
        txtIDSuplier.Text = osupplier.idsuplier
        txtKodeSuplier.Text = osupplier.kode_suplier
        txtNamaSuplier.Text = osupplier.nama_suplier
        txtKontakPersonal.Text = osupplier.kontak_personal

    End Sub
    Private Sub Simpansupplier()
        osupplier.idsuplier = txtIDSuplier.Text
        osupplier.kode_suplier = txtKodeSuplier.Text
        osupplier.nama_suplier = txtNamaSuplier.Text
        osupplier.kontak_personal = txtKontakPersonal.Text
        osupplier.Simpan()
        reload()
        If (osupplier.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (osupplier.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub reload()
        osupplier.getAllData(DataGridView1)
    End Sub

    Private Sub frmSuplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            osupplier.CariSUPLIER(txtIDSuplier.Text)
            If (supplier_baru = False) Then
                TampilData()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub
    Private Sub frmSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
End Class