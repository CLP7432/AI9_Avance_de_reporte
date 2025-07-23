Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class RepoorteCliente
    Private Sub RepoorteCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Cadena de conexión
        Dim conexion As New SqlConnection("Data Source=DESKTOP-1SVOBB8;Initial Catalog=Pventa;User ID=sa;Password=MarcoUriel@030681;TrustServerCertificate=True")

        ' 2. Consulta
        Dim consulta As String = "SELECT * FROM Cliente"

        ' 3. Adaptador y DataTable
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim dataSet As New DataSet()
        adaptador.Fill(dataSet, "Cliente")

        ' 4. Crear origen de datos para el reporte
        Dim origen As New ReportDataSource("DataSetCliente", dataSet.Tables("Cliente"))

        ' 5. Limpiar fuentes previas
        Me.ReportViewer1.LocalReport.DataSources.Clear()

        ' 6. Asignar el reporte RDLC
        Me.ReportViewer1.LocalReport.ReportPath = "ReporteCliente.rdlc"

        ' 7. Asignar el origen de datos
        Me.ReportViewer1.LocalReport.DataSources.Add(origen)

        ' 8. Refrescar
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class

