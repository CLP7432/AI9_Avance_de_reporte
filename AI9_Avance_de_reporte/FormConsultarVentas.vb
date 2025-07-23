Imports System.Data.SqlClient

Public Class FormConsultarVentas
    Private Sub FormConsultarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpInicio.Value = DateTime.Now.AddMonths(-1)
        dtpFin.Value = DateTime.Now

        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White

        EstilizarBoton(btnBuscar)
        EstilizarDateTimePicker(dtpInicio)
        EstilizarDateTimePicker(dtpFin)
        EstilizarDataGridView(dgvVentas)
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpInicio.Value > dtpFin.Value Then
            MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim con As New SqlConnection(My.Settings.Conexion)
        Dim sql As String = "
            SELECT 
                v.IdVenta, v.Fecha, c.Nombre AS Cliente, ven.Nombre AS Vendedor, 
                dv.IdProducto, p.Nombre AS Producto, dv.Cantidad, dv.Precio, dv.Subtotal, dv.Total
            FROM Venta v
            INNER JOIN Cliente c ON v.IdCliente = c.IdCliente
            INNER JOIN Vendedor ven ON v.IdVendedor = ven.IdVendedor
            INNER JOIN DetalleVenta dv ON v.IdVenta = dv.IdVenta
            INNER JOIN Producto p ON dv.IdProducto = p.IdProducto
            WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
            ORDER BY v.Fecha, v.IdVenta"

        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@FechaInicio", dtpInicio.Value.Date)
        cmd.Parameters.AddWithValue("@FechaFin", dtpFin.Value.Date.AddDays(1).AddSeconds(-1)) ' Hasta el final del día

        Try
            con.Open()
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvVentas.DataSource = dt
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error al consultar las ventas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EstilizarBoton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(0, 123, 255)
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10)
        btn.Cursor = Cursors.Hand
        AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(0, 105, 217)
        AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(0, 123, 255)
    End Sub
    Private Sub EstilizarDateTimePicker(dtp As DateTimePicker)
        dtp.Font = New Font("Segoe UI", 10)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = "yyyy-MM-dd"
        dtp.CalendarForeColor = Color.Black
        dtp.CalendarMonthBackground = Color.White
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