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
Partial Class Reportes_gestionTotal
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

        Try


            dsDatos.SelectParameters("fechaInicial").DefaultValue = filtros.fechaInicial
            dsDatos.SelectParameters("fechaFinal").DefaultValue = filtros.fechaFinal
            dsDatos.SelectParameters("regional").DefaultValue = filtros.regional
            dsDatos.SelectParameters("jefe").DefaultValue = filtros.jefe
            '   dsDatos.SelectParameters("entregador").DefaultValue = filtros.entregador
            Dim busqueda As String = filtros.buscar

            If String.IsNullOrEmpty(busqueda) Then
                busqueda = -1
            End If

            dsDatos.SelectParameters("codigousuario").DefaultValue = Session("codigousuario").ToString.Trim
            dsDatos.SelectParameters("tipo").DefaultValue = Session("tipo").ToString.Trim

            dsDatos.SelectParameters("busqueda").DefaultValue = busqueda
            dsDatos.DataBind()

            gvDatos.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exporta()
    End Sub
    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim codFoto As String = ""
        Dim foto As Byte() = Nothing
        Dim cadenaconexion As String = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()
        Dim generalBO As GeneralBO = New GeneralBO(cadenaconexion)
        Dim resultado As Boolean = False
        codFoto = gvDatos.SelectedValue.ToString()
        foto = generalBO.fotosNovedades(codFoto, resultado)

        If foto Is Nothing Then
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "swal('¡Advertencia!', '¡ No existe imagen para este Código !', 'warning')", True)
        Else
            mpPanelResumen.Show()
            Dim fotografia As String = Convert.ToBase64String(foto)
            image.Src = "data:image/jpg;base64," & fotografia
        End If

    End Sub

    Protected Sub dsDatos_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles dsDatos.Selecting
        e.Command.CommandTimeout = 9000
    End Sub

End Class


