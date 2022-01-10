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

Partial Class Reportes_ConsultaViaje
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
        gvDatos.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(gvDatos)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Documento.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        dsDatos.SelectParameters("fechaInicial").DefaultValue = filtros.fechaInicial
        dsDatos.SelectParameters("fechaFinal").DefaultValue = filtros.fechaFinal
        Dim busqueda As String = filtros.buscar

        If String.IsNullOrEmpty(busqueda) Then
            busqueda = -1
        End If

        dsDatos.SelectParameters("busqueda").DefaultValue = busqueda
        dsDatos.DataBind()

        gvDatos.DataBind()

    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exporta()
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim codViaje As String = ""
       
        codViaje = gvDatos.SelectedValue.ToString()

        mvGeneral.SetActiveView(vSecundaria)
        lblFacturas.Text = "Código Viaje" + " " + codViaje

        dsFacturas.SelectParameters("codViaje").DefaultValue = codViaje
        gvFacturas.DataBind()

    End Sub

    Protected Sub gvFacturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvFacturas.SelectedIndexChanged
        Dim codFactura As String = ""

        codFactura = gvFacturas.SelectedValue.ToString()

        mpPanelResumen.Show()
        lblNumdoc.Text = "Código Factura" + " " + codFactura

        dsDetalle.SelectParameters("codFactura").DefaultValue = codFactura
        gvdetalle.DataBind()

    End Sub
    Private GranValordetalleN As Double = 0
    Private GranValorDetalleB As Double = 0
    Protected Sub gvdetalle_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim filas As Integer = gvdetalle.Rows.Count

        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim valorB As String = e.Row.Cells(5).Text.ToString.Trim
                ' Dim ValorN As String = e.Row.Cells(6).Text.ToString.Trim.Replace("$", "").Replace(" ", "")

                GranValorDetalleB = (GranValorDetalleB + Convert.ToDouble(valorB))
                '  GranValordetalleN = (GranValordetalleN + Convert.ToDouble(ValorN))

            End If
            If (e.Row.RowType = DataControlRowType.Footer) Then
                e.Row.Cells(1).Text = "TOTAL"
                e.Row.Cells(3).Text = "Referencia: " & filas
                e.Row.Cells(5).Text = GranValorDetalleB
                ' e.Row.Cells(6).Text = GranValordetalleN.ToString("$ 0,0")
            End If
        Catch ex As Exception
            Dim resultado As String = ex.Message
        End Try

    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs)
        mvGeneral.SetActiveView(vPrincipal)
    End Sub

End Class
