Imports System.Data.SqlClient

Public Class FormProductos
    Private Sub FormProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarProductos()
        LimpiarCampos()

        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White


        EstilizarBoton(btnGuardar)
        EstilizarBoton(btnActualizar)
        EstilizarBoton(btnEliminar)
        EstilizarBoton(btnCancelar)


        EstilizarTextBox(txtNombre)
        EstilizarTextBox(txtPrecio)

    End Sub

    Private Sub CargarProductos()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "SELECT * FROM Producto"
        Dim da As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
            dgvProductos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error al cargar los productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub LimpiarCampos()

        txtNombre.Clear()
        txtPrecio.Clear()
        txtNombre.Focus()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNombre.Text = "" Or txtPrecio.Text = "" Then
            MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "INSERT INTO Producto (Nombre, Precio) VALUES (@Nombre, @Precio)"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text))

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            CargarProductos()
        Catch ex As Exception
            MessageBox.Show("Error al guardar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtPrecio.Text = fila.Cells("Precio").Value.ToString()
            txtNombre.Tag = fila.Cells("IdProducto").Value
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtNombre.Tag Is Nothing Then
            MessageBox.Show("Seleccione un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "UPDATE Producto SET Nombre = @Nombre, Precio = @Precio WHERE IdProducto = @IdProducto"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text))
        cmd.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(txtNombre.Tag))

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            CargarProductos()

            txtNombre.Tag = Nothing
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtNombre.Tag Is Nothing Then
            MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "DELETE FROM Producto WHERE IdProducto = @IdProducto"
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(txtNombre.Tag))

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            CargarProductos()
            txtNombre.Tag = Nothing
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarCampos()
        txtNombre.Tag = Nothing
    End Sub
    Private Sub EstilizarBoton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(0, 123, 255) ' Azul estilo Bootstrap
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
        ' Opcional: cambiar color al pasar el mouse
        AddHandler btn.MouseEnter, Sub(s, e2) btn.BackColor = Color.FromArgb(0, 105, 217)
        AddHandler btn.MouseLeave, Sub(s, e2) btn.BackColor = Color.FromArgb(0, 123, 255)
    End Sub
    Private Sub EstilizarTextBox(txt As TextBox)
        txt.BorderStyle = BorderStyle.FixedSingle

    End Sub
End Class