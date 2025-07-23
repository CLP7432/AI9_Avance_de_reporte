Public Class ReporteProducto
    Private Sub ReporteProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.LocalReport.ReportPath = "ReporteProducto.rdlc"

        ' Crear y abrir la conexión
        Dim conexion As New SqlClient.SqlConnection("Data Source=DESKTOP-1SVOBB8;Initial Catalog=Pventa;User ID=sa;Password=MarcoUriel@030681;TrustServerCertificate=True")
        conexion.Open()

        ' Llenar el DataSet
        Dim adaptador As New SqlClient.SqlDataAdapter("SELECT * FROM Producto", conexion)
        Dim ds As New DataSet()
        adaptador.Fill(ds, "Producto")

        ' Configurar el ReportViewer
        Dim fuente As New Microsoft.Reporting.WinForms.ReportDataSource("DataSetProducto", ds.Tables("Producto"))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(fuente)

        ' Refrescar el reporte
        Me.ReportViewer1.RefreshReport()

        ' Cerrar la conexión
        conexion.Close()
    End Sub


End Class