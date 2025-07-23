Imports System.Data.SqlClient

Public Class FormVendedores
    Private Sub FormVendedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"c
        CargarVendedores()
        LimpiarCampos()

        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White


        EstilizarBoton(btnGuardar)
        EstilizarBoton(btnActualizar)
        EstilizarBoton(btnEliminar)
        EstilizarBoton(btnCancelar)

        EstilizarTextBox(txtNombre)
        EstilizarTextBox(txtUsuario)
        EstilizarTextBox(txtPassword)

    End Sub
    Private Sub CargarVendedores()
        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "SELECT * FROM Vendedor"
        Dim da As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)
            dgvVendedores.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error al cargar los vendedores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtUsuario.Clear()
        txtPassword.Clear()
        txtNombre.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNombre.Text = "" Or txtUsuario.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "INSERT INTO Vendedor (Nombre, Usuario, Password) VALUES (@Nombre, @Usuario, @Password)"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text)
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Vendedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarVendedores()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al guardar el vendedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub dgvVendedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVendedores.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvVendedores.Rows(e.RowIndex)


            txtId.Text = fila.Cells("IdVendedor").Value.ToString()
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtUsuario.Text = fila.Cells("Usuario").Value.ToString()
            txtPassword.Text = fila.Cells("Password").Value.ToString()


        End If
    End Sub
    Private Sub dgvVendedores_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvVendedores.CellFormatting
        If dgvVendedores.Columns(e.ColumnIndex).Name = "Password" AndAlso e.Value IsNot Nothing Then
            Dim length As Integer = e.Value.ToString().Length
            e.Value = New String("*"c, length)
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdVendedor.Text = "" Then
            MessageBox.Show("Por favor, seleccione un vendedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtNombre.Text = "" Or txtUsuario.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "UPDATE Vendedor SET Nombre = @Nombre, Usuario = @Usuario, Password = @Password WHERE IdVendedor = @IdVendedor"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@IdVendedor", Convert.ToInt32(txtIdVendedor.Text))
        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text)
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text)

        Try
            con.Open()
            Dim filaAfectadas As Integer = cmd.ExecuteNonQuery()
            con.Close()
            If filaAfectadas > 0 Then
                MessageBox.Show("Vendedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                CargarVendedores()
            Else
                MessageBox.Show("No se actualizó ningún registro. Verifica el ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el vendedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtId.Text = "" Then
            MessageBox.Show("Por favor, seleccione un vendedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este vendedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacion = DialogResult.No Then Exit Sub

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "DELETE FROM Vendedor WHERE IdVendedor = @IdVendedor"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@IdVendedor", Convert.ToInt32(txtId.Text))

        Try
            con.Open()
            Dim filasEliminadas As Integer = cmd.ExecuteNonQuery()
            con.Close()

            If filasEliminadas > 0 Then
                MessageBox.Show("Vendedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                CargarVendedores()
            Else
                MessageBox.Show("No se eliminó ningún registro. Verifica el ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el vendedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarCampos()
        dgvVendedores.ClearSelection()
    End Sub
    Private Sub EstilizarBoton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(0, 123, 255) ' Azul Bootstrap
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
        AddHandler btn.MouseEnter, Sub(s, e2) btn.BackColor = Color.FromArgb(0, 105, 217)
        AddHandler btn.MouseLeave, Sub(s, e2) btn.BackColor = Color.FromArgb(0, 123, 255)
    End Sub
    Private Sub EstilizarTextBox(txt As TextBox)
        txt.BorderStyle = BorderStyle.FixedSingle

    End Sub
End Class