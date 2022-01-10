Imports System
Imports System.Data

Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Drawing.Imaging
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Data.SqlClient
Partial Class Fotos_ImageCode
    Inherits System.Web.UI.Page

    Dim cadenaConexion As String
    Dim comando As SqlCommand
    Dim reader As SqlDataReader
    Dim cadenaConexionIntegracion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()
            Catch ex As Exception
            End Try

            Dim codigoMedicion As String = Request.QueryString("codigo").ToString()

            If Not String.IsNullOrEmpty(codigoMedicion) Then
                Dim strQuery As String = "SELECT top 1 foto FROM Fotos WHERE codFotoUnica ='" + codigoMedicion + "'; "


                Dim cmd As New SqlCommand(strQuery)
                Dim con As New SqlConnection(cadenaConexion)
                Dim sda As New SqlDataAdapter()
                cmd.CommandType = CommandType.Text
                Dim dt As New DataTable()
                cmd.Connection = con
                Try
                    con.Open()
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                Catch
                    dt = Nothing
                Finally
                    con.Close()
                    sda.Dispose()
                    con.Dispose()
                End Try
                If dt IsNot Nothing Then
                    Dim bytes As System.Byte() = dt.Rows(0)("foto")
                    ' Dim rotaImagen() As Byte = formatea(bytes)
                    Response.Buffer = True
                    Response.Charset = ""
                    Response.Cache.SetCacheability(HttpCacheability.NoCache)
                    Response.ContentType = "image/png"
                    Response.AddHeader("content-disposition", "attachment;filename=Imagen_" & codigoMedicion & ".png")
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                End If
            End If
        End If
    End Sub
    Public Shared Function ConvertImageToByteArray(ByVal _image As System.Drawing.Image, ByVal _formatImage As ImageFormat) As Byte()
        Dim ImageByte As Byte()

        Try
            Using ms As New MemoryStream()
                _image.Save(ms, _formatImage)
                ImageByte = ms.ToArray()
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return ImageByte
    End Function
    Private Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Dim strConnString As [String] = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
End Class

