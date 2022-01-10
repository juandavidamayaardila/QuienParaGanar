Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web
Partial Class Administracion_AdminEmpresaTransportadora
    Inherits Culture
    Private cadenaConexion As String
    Private empresa As EmpresaTransportadora
    Private empresaBO As EmpresaTransportadoraBO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        If Page.IsPostBack = False Then
            cargarUsuarios()
        End If
    End Sub
    Sub cargarUsuarios()
        gvDatos.DataBind()
    End Sub

    Sub limpiarCampos()

        txtDescripcion.Text = ""

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        empresaBO = New EmpresaTransportadoraBO(cadenaConexion)
        empresa = New EmpresaTransportadora()
        Dim resultado As Boolean = False
        Dim existe As Boolean = False

        empresa._descripcion = txtDescripcion.Text

        resultado = empresaBO.ingresarEmpresaTransportadora(empresa)

        If resultado = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Finalizado!', '¡ Registro Almacenado!', 'success')", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
        End If

        limpiarCampos()

        cargarUsuarios()

    End Sub

    Protected Sub gvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim codigo As String = ""

        codigo = gvDatos.SelectedValue.ToString()
        Session("codigo") = codigo
        empresa = New EmpresaTransportadora()
        empresaBO = New EmpresaTransportadoraBO(cadenaConexion)

        empresa = empresaBO.obtenerDatosEmpresaTransportadora(codigo)

        If String.IsNullOrEmpty(codigo) = False Then

            txtDescripcion.Text = empresa._descripcion

            btnEliminar.Visible = True
            btnModificar.Visible = True
            btnCrear.Visible = False

        End If
    End Sub
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click

        empresaBO = New EmpresaTransportadoraBO(cadenaConexion)
        empresa = New EmpresaTransportadora()
        Dim resultado As Boolean = False
        Dim existe As Boolean = False
        Dim codigo As String = ""

        codigo = gvDatos.SelectedValue.ToString()

        empresa._codigo = codigo
        empresa._descripcion = txtDescripcion.Text

        resultado = empresaBO.modificarEmpresaTransportadora(empresa)

        If resultado = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado!', '¡ Registro Almacenado!', 'success')", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True

        cargarUsuarios()
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        empresaBO = New EmpresaTransportadoraBO(cadenaConexion)
        Dim codigo As String
        Dim resultado As Boolean = False

        codigo = Session("codigo").ToString()

        If String.IsNullOrEmpty(codigo) = False Then

            resultado = empresaBO.elimimarEmpresaTransportadora(codigo)

            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Elinimado !', 'success')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia!', '¡  Ha ocurrido un error en la transacción, por favor intentar nuevamente  !', 'warning')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        cargarUsuarios()

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        cargarUsuarios()
    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exporta()
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

End Class
