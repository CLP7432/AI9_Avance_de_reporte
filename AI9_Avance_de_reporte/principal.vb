Imports System.Windows.Forms

Public Class principal

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New FrmClientes()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub




    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ToolsMenu_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendedoresToolStripMenuItem.Click
        Dim frm As New FormVendedores()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frm As New FormProductos()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub RegistrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVentaToolStripMenuItem.Click
        Dim frm As New FormRegistrarVenta()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub


    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim frm As New FrmClientes()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.WhiteSmoke
        Me.Font = New Font("Segoe UI", 10)

        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.Text = "Sistema de Punto de Venta"


        Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)


        Label1.Text = "SISTEMA DE PUNTO DE VENTA"
        Label1.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(52, 58, 64)
        Label1.TextAlign = ContentAlignment.MiddleCenter
        Label1.AutoSize = False
        Label1.Dock = DockStyle.Top
        Label1.Height = 60





        EstilizarBoton(btnClientes, Color.FromArgb(0, 123, 255))          ' Azul
        EstilizarBoton(btnVendedores, Color.FromArgb(40, 167, 69))       ' Verde
        EstilizarBoton(btnProductos, Color.FromArgb(255, 193, 7))        ' Amarillo
        EstilizarBoton(btnregistrarVentas, Color.FromArgb(108, 117, 125)) ' Gris


    End Sub
    Private Sub EstilizarBoton(boton As Button, colorFondo As Color)
        boton.BackColor = colorFondo
        boton.FlatStyle = FlatStyle.Flat
        boton.FlatAppearance.BorderSize = 0
        boton.ForeColor = Color.White
        boton.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        boton.Cursor = Cursors.Hand
    End Sub

    Private Sub btnVendedores_Click(sender As Object, e As EventArgs) Handles btnVendedores.Click
        Dim frm As New FormVendedores()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)

        frm.Show()
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim frm As New FrmClientes()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim frm As New FormProductos()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub

    Private Sub btnregistrarVentas_Click(sender As Object, e As EventArgs) Handles btnregistrarVentas.Click
        Dim frm As New FormRegistrarVenta()
        frm.MdiParent = Me
        MostrarControlesPrincipal(False)

        AddHandler frm.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)
        frm.Show()
    End Sub


    Private Sub MostrarControlesPrincipal(visible As Boolean)

        Label1.Visible = visible
        btnClientes.Visible = visible
        btnVendedores.Visible = visible
        btnProductos.Visible = visible
        btnregistrarVentas.Visible = visible


        PictureBox1.Visible = visible
        GroupBox1.Visible = visible
        GroupBox2.Visible = visible
        GroupBox3.Visible = visible
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub btnClie_Click(sender As Object, e As EventArgs) Handles btnClie.Click
        Dim reporte As New RepoorteCliente()
        reporte.MdiParent = Me

        MostrarControlesPrincipal(False)

        AddHandler reporte.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)

        reporte.Show()
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        Dim reporte As New ReporteProducto()
        reporte.MdiParent = Me

        MostrarControlesPrincipal(False)

        AddHandler reporte.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)

        reporte.Show()
    End Sub

    Private Sub btnVendedor_Click(sender As Object, e As EventArgs) Handles btnVendedor.Click
        Dim reporte As New ReporteVendedor()
        reporte.MdiParent = Me

        MostrarControlesPrincipal(False)

        AddHandler reporte.FormClosed, Sub(s, args) MostrarControlesPrincipal(True)

        reporte.Show()
    End Sub
End Class
