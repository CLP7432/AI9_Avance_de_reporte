<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(principal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnVendedores = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnregistrarVentas = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnVendedor = New System.Windows.Forms.Button()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.btnClie = New System.Windows.Forms.Button()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.WindowsMenu, Me.VentasToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1095, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem1})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.VendedoresToolStripMenuItem, Me.ProductosToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(72, 20)
        Me.WindowsMenu.Text = "Catalogos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'VendedoresToolStripMenuItem
        '
        Me.VendedoresToolStripMenuItem.Name = "VendedoresToolStripMenuItem"
        Me.VendedoresToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.VendedoresToolStripMenuItem.Text = "Vendedores"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarVentaToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.VentasToolStripMenuItem.Text = " Venta"
        '
        'RegistrarVentaToolStripMenuItem
        '
        Me.RegistrarVentaToolStripMenuItem.Name = "RegistrarVentaToolStripMenuItem"
        Me.RegistrarVentaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RegistrarVentaToolStripMenuItem.Text = "Registrar Venta"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1095, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Bienvenido a mi Super UNIDEH"
        '
        'btnClientes
        '
        Me.btnClientes.Location = New System.Drawing.Point(25, 24)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(75, 23)
        Me.btnClientes.TabIndex = 10
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnVendedores
        '
        Me.btnVendedores.Location = New System.Drawing.Point(137, 24)
        Me.btnVendedores.Name = "btnVendedores"
        Me.btnVendedores.Size = New System.Drawing.Size(75, 23)
        Me.btnVendedores.TabIndex = 11
        Me.btnVendedores.Text = "Vendedores"
        Me.btnVendedores.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.Location = New System.Drawing.Point(256, 24)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(75, 23)
        Me.btnProductos.TabIndex = 12
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnProductos)
        Me.GroupBox1.Controls.Add(Me.btnVendedores)
        Me.GroupBox1.Controls.Add(Me.btnClientes)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 74)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registrar"
        '
        'btnregistrarVentas
        '
        Me.btnregistrarVentas.Location = New System.Drawing.Point(111, 19)
        Me.btnregistrarVentas.Name = "btnregistrarVentas"
        Me.btnregistrarVentas.Size = New System.Drawing.Size(109, 23)
        Me.btnregistrarVentas.TabIndex = 14
        Me.btnregistrarVentas.Text = "Registrar Ventas"
        Me.btnregistrarVentas.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnregistrarVentas)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 67)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Registro"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(490, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(405, 126)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnVendedor)
        Me.GroupBox3.Controls.Add(Me.btnProducto)
        Me.GroupBox3.Controls.Add(Me.btnClie)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 305)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(365, 104)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reportes"
        '
        'btnVendedor
        '
        Me.btnVendedor.Location = New System.Drawing.Point(229, 42)
        Me.btnVendedor.Name = "btnVendedor"
        Me.btnVendedor.Size = New System.Drawing.Size(79, 23)
        Me.btnVendedor.TabIndex = 2
        Me.btnVendedor.Text = "Vendedores"
        Me.btnVendedor.UseVisualStyleBackColor = True
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(114, 42)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnProducto.TabIndex = 1
        Me.btnProducto.Text = "Productos"
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'btnClie
        '
        Me.btnClie.Location = New System.Drawing.Point(16, 42)
        Me.btnClie.Name = "btnClie"
        Me.btnClie.Size = New System.Drawing.Size(75, 23)
        Me.btnClie.TabIndex = 0
        Me.btnClie.Text = "Clientes"
        Me.btnClie.UseVisualStyleBackColor = True
        '
        'principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 453)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "principal"
        Me.Text = "principal"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VendedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnVendedores As Button
    Friend WithEvents btnProductos As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnregistrarVentas As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnClie As Button
    Friend WithEvents btnProducto As Button
    Friend WithEvents btnVendedor As Button
End Class
