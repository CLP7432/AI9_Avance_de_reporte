Imports System.Data.SqlClient

Public Class ReporteVendedor
    Private Sub ReporteVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.LocalReport.ReportPath = "ReporteVendedor.rdlc"

        ' Crear y abrir la conexión
        Dim conexion As New SqlClient.SqlConnection("Data Source=DESKTOP-1SVOBB8;Initial Catalog=Pventa;User ID=sa;Password=MarcoUriel@030681;TrustServerCertificate=True")
        conexion.Open()

        ' Llenar el DataSet
        Dim adaptador As New SqlClient.SqlDataAdapter("SELECT * FROM Vendedor", conexion)
        Dim ds As New DataSet()
        adaptador.Fill(ds, "Vendedor")

        ' Configurar el ReportViewer
        Dim fuente As New Microsoft.Reporting.WinForms.ReportDataSource("DataSetVendedor", ds.Tables("Vendedor"))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(fuente)

        ' Refrescar el reporte
        Me.ReportViewer1.RefreshReport()

        ' Cerrar la conexión
        conexion.Close()
    End Sub
End Class