Imports System.Data.SqlClient
Public Class FrmClientes
    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        LimpiarCampos()

        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White

        ' Estilo para botones
        EstilizarBoton(btnGuardar)
        EstilizarBoton(btnActualizar)
        EstilizarBoton(btnEliminar)
        EstilizarBoton(btnCancelar)
        EstilizarBoton(btnCancelar)

        ' Estilo para TextBoxes
        EstilizarTextBox(txtNombre)
        EstilizarTextBox(txtRFC)
        EstilizarTextBox(txtCalle)
        EstilizarTextBox(txtColonia)
        EstilizarTextBox(txtCiudad)
        EstilizarTextBox(txtEstado)
        EstilizarTextBox(txtCP)
        EstilizarTextBox(txtDescuento)

        ' Cambiar color etiquetas (labels) si quieres
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label Then
                ctrl.ForeColor = Color.FromArgb(52, 58, 64) ' Gris oscuro Bootstrap
            End If
        Next
    End Sub

    Private Sub CargarClientes()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "SELECT * FROM Cliente"
        Dim da As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LimpiarCampos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtRFC.Clear()
        txtColonia.Clear()
        txtCiudad.Clear()
        txtEstado.Clear()
        txtCalle.Clear()
        txtCP.Clear()
        txtDescuento.Clear()


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNombre.Text = "" Or txtRFC.Text = "" Or txtDescuento.Text = "" Then
            MessageBox.Show("Por favorm completa los campos obligatorios")
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "INSERT INTO [dbo].[Cliente]([Nombre],[Rfc],[Calle],[Colonia],[Ciudad],[Estado],[CP],[Descuento]) VALUES (@Nombre, @RFC, @Calle, @Colonia, @Ciudad, @Estado, @CP, @Descuento)"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@RFC", txtRFC.Text)
        cmd.Parameters.AddWithValue("@Calle", txtCalle.Text)
        cmd.Parameters.AddWithValue("@Colonia", txtColonia.Text)
        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text)
        cmd.Parameters.AddWithValue("@Estado", txtEstado.Text)
        cmd.Parameters.AddWithValue("@CP", txtCP.Text)
        cmd.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento.Text))

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Cliente guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            CargarClientes()
        Catch ex As Exception
            MessageBox.Show("Error al guardar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtIdCliente.Text = fila.Cells("IdCliente").Value.ToString()
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtRFC.Text = fila.Cells("Rfc").Value.ToString()
            txtCalle.Text = fila.Cells("Calle").Value.ToString()
            txtColonia.Text = fila.Cells("Colonia").Value.ToString()
            txtCiudad.Text = fila.Cells("Ciudad").Value.ToString()
            txtEstado.Text = fila.Cells("Estado").Value.ToString()
            txtCP.Text = fila.Cells("CP").Value.ToString()
            txtDescuento.Text = fila.Cells("Descuento").Value.ToString()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdCliente.Text = "" Then
            MessageBox.Show("Selecciona un cliente para actaulizar")
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "UPDATE Cliente SET Nombre = @Nombre, Rfc = @RFC, Calle = @Calle, Colonia = @Colonia, Ciudad = @Ciudad, Estado = @Estado, CP = @CP, Descuento = @Descuento WHERE IdCliente = @IdCliente"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(txtIdCliente.Text))
        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@RFC", txtRFC.Text)
        cmd.Parameters.AddWithValue("@Calle", txtCalle.Text)
        cmd.Parameters.AddWithValue("@Colonia", txtColonia.Text)
        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text)
        cmd.Parameters.AddWithValue("@Estado", txtEstado.Text)
        cmd.Parameters.AddWithValue("@CP", txtCP.Text)
        cmd.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento.Text))

        Try
            con.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            con.Close()

            If filasAfectadas > 0 Then
                MessageBox.Show("Cliente actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                CargarClientes()
            Else
                MessageBox.Show("No se encontró el cliente para actualizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al actualizar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtIdCliente.Text = "" Then
            MessageBox.Show("Selecciona un cliente para eliminar")
            Exit Sub
        End If

        Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacion = DialogResult.No Then
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "DELETE FROM Cliente WHERE IdCliente = @IdCliente"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(txtIdCliente.Text))

        Try

            con.Open()
            Dim filasEliminadas As Integer = cmd.ExecuteNonQuery()
            con.Close()

            If filasEliminadas > 0 Then
                MessageBox.Show("Cliente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                CargarClientes()
            Else
                MessageBox.Show("No se encontró el cliente para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarCampos()
        DataGridView1.ClearSelection()
    End Sub

    Private Sub EstilizarBoton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(0, 123, 255)
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
    End Sub
    Private Sub EstilizarTextBox(txt As TextBox)
        txt.BorderStyle = BorderStyle.FixedSingle

    End Sub


End Class
