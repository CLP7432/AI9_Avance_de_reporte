Imports System.Data.SqlClient

Public Class FormRegistrarVenta
    Private descuentoCliente As Decimal = 0.0D
    Private dtDetalle As New DataTable()

    Private Sub FormRegistrarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = DateTime.Now
        CargarClientes()
        CargarVendedores()
        CargarProductos()

        CrearTablaDetalle()
        dgvDetalleVenta.DataSource = dtDetalle

        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White

        ' Estilizar botones
        EstilizarBoton(btnAgregarProducto)
        EstilizarBoton(btnFinalizarVenta)

        ' Estilizar TextBoxes y ComboBoxes
        EstilizarTextBox(txtPrecio)
        EstilizarTextBox(txtSubtotal)
        EstilizarTextBox(txtDescuento)
        EstilizarTextBox(txtTotal)
        EstilizarComboBox(cmbCliente)
        EstilizarComboBox(cmbVendedor)
        EstilizarComboBox(cmbProducto)

        ' Opcional: personalizar DataGridView
        EstilizarDataGridView(dgvDetalleVenta)
    End Sub
    Private Sub CrearTablaDetalle()
        dtDetalle.Columns.Clear()
        dtDetalle.Columns.Add("IdProducto", GetType(Integer))
        dtDetalle.Columns.Add("NombreProducto", GetType(String))
        dtDetalle.Columns.Add("Cantidad", GetType(Integer))
        dtDetalle.Columns.Add("Precio", GetType(Decimal))
        dtDetalle.Columns.Add("Subtotal", GetType(Decimal))
        dtDetalle.Columns.Add("Total", GetType(Decimal))
    End Sub
    Private Sub CargarClientes()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim cmd As New SqlCommand("SELECT IdCliente, Nombre FROM Cliente", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dtClientes As New DataTable()

        Try
            da.Fill(dtClientes)
            cmbCliente.DataSource = dtClientes
            cmbCliente.DisplayMember = "Nombre"
            cmbCliente.ValueMember = "IdCliente"
            cmbCliente.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarVendedores()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim cmd As New SqlCommand("SELECT IdVendedor, Nombre FROM Vendedor", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dtVendedores As New DataTable()

        Try
            da.Fill(dtVendedores)
            cmbVendedor.DataSource = dtVendedores
            cmbVendedor.DisplayMember = "Nombre"
            cmbVendedor.ValueMember = "IdVendedor"
            cmbVendedor.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar vendedores: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarProductos()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim cmd As New SqlCommand("SELECT IdProducto, Nombre, Precio FROM Producto", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dtProductos As New DataTable()

        Try
            da.Fill(dtProductos)
            cmbProducto.DataSource = dtProductos
            cmbProducto.DisplayMember = "Nombre"
            cmbProducto.ValueMember = "IdProducto"
            cmbProducto.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try
    End Sub
    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        Try
            If cmbCliente.SelectedValue IsNot Nothing AndAlso TypeOf cmbCliente.SelectedValue Is Integer Then
                Dim idCliente As Integer = CInt(cmbCliente.SelectedValue)
                ObtenerDescuentoCliente(idCliente)
                ActualizarTotales() ' Por si ya hay productos en la tabla
            Else
                descuentoCliente = 0D
            End If
        Catch ex As Exception
            MessageBox.Show("Error al obtener descuento del cliente: " & ex.Message)
        End Try
    End Sub
    Private Sub ObtenerDescuentoCliente(idCliente As Integer)
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim cmd As New SqlCommand("SELECT Descuento FROM Cliente WHERE IdCliente = @IdCliente", con)
        cmd.Parameters.AddWithValue("@IdCliente", idCliente)

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                descuentoCliente = Convert.ToDecimal(reader("Descuento")) / 100D ' Convertir a decimal porcentaje
            Else
                descuentoCliente = 0D
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error obteniendo descuento: " & ex.Message)
            descuentoCliente = 0D
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        Try
            If cmbProducto.SelectedValue IsNot Nothing AndAlso TypeOf cmbProducto.SelectedValue Is Integer Then
                Dim row As DataRowView = DirectCast(cmbProducto.SelectedItem, DataRowView)
                Dim precio As Decimal = Convert.ToDecimal(row("Precio"))
                txtPrecio.Text = precio.ToString("F2")
            Else
                txtPrecio.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar producto: " & ex.Message)
        End Try
    End Sub
    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        If cmbProducto.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un producto")
            Exit Sub
        End If

        If numCantidad.Value <= 0 Then
            MessageBox.Show("Ingrese una cantidad válida")
            Exit Sub
        End If

        Dim idProd As Integer = CInt(cmbProducto.SelectedValue)
        Dim nombreProd As String = cmbProducto.Text
        Dim cantidad As Integer = CInt(numCantidad.Value)
        Dim precio As Decimal = Decimal.Parse(txtPrecio.Text)

        Dim subtotal As Decimal = cantidad * precio
        Dim descuento As Decimal = subtotal * descuentoCliente
        Dim total As Decimal = subtotal - descuento

        ' Agregar fila a DataTable
        dtDetalle.Rows.Add(idProd, nombreProd, cantidad, precio, subtotal, total)

        ActualizarTotales()
    End Sub
    Private Sub ActualizarTotales()
        Dim subtotalGeneral As Decimal = 0D
        Dim totalGeneral As Decimal = 0D
        Dim descuentoTotal As Decimal = 0D

        For Each row As DataRow In dtDetalle.Rows
            subtotalGeneral += Convert.ToDecimal(row("Subtotal"))
            totalGeneral += Convert.ToDecimal(row("Total"))
        Next

        descuentoTotal = subtotalGeneral - totalGeneral

        txtSubtotal.Text = subtotalGeneral.ToString("F2")
        txtDescuento.Text = descuentoTotal.ToString("F2")
        txtTotal.Text = totalGeneral.ToString("F2")
    End Sub

    Private Sub btnFinalizarVenta_Click(sender As Object, e As EventArgs) Handles btnFinalizarVenta.Click
        If dtDetalle.Rows.Count = 0 Then
            MessageBox.Show("Agrega productos antes de finalizar la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmbCliente.SelectedIndex = -1 Or cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un cliente y un vendedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        con.Open()
        Dim tran As SqlTransaction = con.BeginTransaction()

        Try
            ' Insertar la venta y obtener el nuevo IdVenta generado
            Dim sqlVenta As String = "INSERT INTO Venta (Fecha, IdCliente, IdVendedor, Subtotal, Descuento, Total) " &
                                "VALUES (@Fecha, @IdCliente, @IdVendedor, @Subtotal, @Descuento, @Total); " &
                                "SELECT SCOPE_IDENTITY()"

            Dim cmdVenta As New SqlCommand(sqlVenta, con, tran)
            cmdVenta.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmdVenta.Parameters.AddWithValue("@IdCliente", cmbCliente.SelectedValue)
            cmdVenta.Parameters.AddWithValue("@IdVendedor", cmbVendedor.SelectedValue)
            cmdVenta.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(txtSubtotal.Text))
            cmdVenta.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento.Text))
            cmdVenta.Parameters.AddWithValue("@Total", Convert.ToDecimal(txtTotal.Text))

            Dim idVenta As Integer = Convert.ToInt32(cmdVenta.ExecuteScalar())

            ' Insertar cada detalle con el IdVenta obtenido
            Dim sqlDetalle As String = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, Precio, Subtotal, Total) " &
                                  "VALUES (@IdVenta, @IdProducto, @Cantidad, @Precio, @Subtotal, @Total)"

            For Each row As DataRow In dtDetalle.Rows
                Dim cmdDetalle As New SqlCommand(sqlDetalle, con, tran)
                cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta)
                cmdDetalle.Parameters.AddWithValue("@IdProducto", row("IdProducto"))
                cmdDetalle.Parameters.AddWithValue("@Cantidad", row("Cantidad"))
                cmdDetalle.Parameters.AddWithValue("@Precio", row("Precio"))
                cmdDetalle.Parameters.AddWithValue("@Subtotal", row("Subtotal"))
                cmdDetalle.Parameters.AddWithValue("@Total", row("Total"))

                cmdDetalle.ExecuteNonQuery()
            Next

            tran.Commit()
            MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiar controles después de guardar
            dtDetalle.Rows.Clear()
            txtSubtotal.Clear()
            txtDescuento.Clear()
            txtTotal.Clear()
            cmbCliente.SelectedIndex = -1
            cmbVendedor.SelectedIndex = -1
            cmbProducto.SelectedIndex = -1
            txtPrecio.Clear()
            numCantidad.Value = 1
            dtpFecha.Value = DateTime.Now

        Catch ex As Exception
            tran.Rollback()
            MessageBox.Show("Error al registrar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub EstilizarBoton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(0, 123, 255)
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
        AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(0, 105, 217)
        AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(0, 123, 255)
    End Sub

    Private Sub EstilizarTextBox(txt As TextBox)
        txt.BorderStyle = BorderStyle.FixedSingle
        txt.BackColor = Color.White
    End Sub
    Private Sub EstilizarComboBox(cmb As ComboBox)
        cmb.FlatStyle = FlatStyle.Flat
        cmb.BackColor = Color.White
        cmb.Font = New Font("Segoe UI", 10)
    End Sub
    Private Sub EstilizarDataGridView(dgv As DataGridView)
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.RowHeadersVisible = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.GridColor = Color.LightGray
        dgv.BackgroundColor = Color.White
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 10)
    End Sub
End Class