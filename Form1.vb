Public Class Form1

    Private Sub btnMasuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasuk.Click
        If (menu_Masuk = False) Then
            BikinMenu(cldMasuk, TabControl1, "Barang Masuk")
            menu_Masuk = True
        Else
            x = getTabIndex(TabControl1, "Barang Masuk")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        If (menu_Keluar = False) Then
            BikinMenu(cldKeluar, TabControl1, "Barang Keluar")
            menu_Keluar = True
        Else
            x = getTabIndex(TabControl1, "Barang Keluar")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnLaporan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarang.Click
        If (menu_Barang = False) Then
            BikinMenu(cldBarang, TabControl1, "Barang")
            menu_Barang = True
        Else
            x = getTabIndex(TabControl1, "Barang")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        End
    End Sub

    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If


        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Masuk") Then
            menu_Masuk = False
        ElseIf (itemToRemove.ToString = "Keluar") Then
            menu_Keluar = False
        ElseIf (itemToRemove.ToString = "Laporan") Then
            menu_Barang = False
        ElseIf (itemToRemove.ToString = "Suplier") Then
            menu_Suplier = False
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub

    Private Sub btnSuplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuplier.Click
        If (menu_Suplier = False) Then
            BikinMenu(cldSuplier, TabControl1, "Suplier")
            menu_Suplier = True
        Else
            x = getTabIndex(TabControl1, "Suplier")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub
End Class
