Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web

Partial Class Reportes_UsabilidadMovil
    Inherits Culture

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

        End If
    End Sub

    Sub exporta()
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form As HtmlForm = New HtmlForm
        gvhora.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(gvhora)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Inicio Labores.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        dsListaHoraInicio.SelectParameters("fechaInicial").DefaultValue = filtros.fechaInicial
        dsListaHoraInicio.SelectParameters("fechaFinal").DefaultValue = filtros.fechaFinal
        dsListaHoraInicio.DataBind()

        gvhora.DataBind()
    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exporta()
    End Sub
End Class
