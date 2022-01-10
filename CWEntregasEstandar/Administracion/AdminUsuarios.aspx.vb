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


Partial Class Administracion_AdminUsuarios
    Inherits Culture
    Private cadenaConexion As String
    Private usuario As AdminUsuarios
    Private usuarioBO As AdminUsuariosBO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        If Page.IsPostBack = False Then
            ddlTipoUsuarios.DataBind()
            ddlCedi.DataBind()
            ddlEmpresaTrasnp.DataBind()
            cargarUsuarios()
        End If
    End Sub
    Sub cargarUsuarios()
        gvUsuarios.DataBind()
    End Sub

    Sub limpiarCampos()

        txtNombre.Text = ""
        txtPass.Text = ""
        txtUsuario.Text = ""
        ddlTipoUsuarios.SelectedValue = -1
        ddlCedi.SelectedValue = -1
        ddlEmpresaTrasnp.SelectedValue = -1
        lblCedi.Visible = False
        ddlCedi.Visible = False
        lblEmpresaTransp.Visible = False
        ddlEmpresaTrasnp.Visible = False

    End Sub

    Protected Sub gvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvUsuarios.SelectedIndexChanged

        lblCedi.Visible = False
        ddlCedi.Visible = False
        lblEmpresaTransp.Visible = False
        ddlEmpresaTrasnp.Visible = False

        Dim codigo As String = ""

        codigo = gvUsuarios.SelectedValue.ToString()
        usuario = New AdminUsuarios()
        usuarioBO = New AdminUsuariosBO(cadenaConexion)

        usuario = usuarioBO.obtenerDatosUsuario(codigo)

        If String.IsNullOrEmpty(codigo) = False Then
            Dim cedi As String = usuario._cedi
            Dim empresaT As String = usuario._empresaT

            If cedi <> "-1" Then
                lblCedi.Visible = True
                ddlCedi.Visible = True
            End If

            If empresaT <> "-1" Then
                lblEmpresaTransp.Visible = True
                ddlEmpresaTrasnp.Visible = True
            End If

            txtNombre.Text = usuario._nombre
            txtUsuario.Text = usuario._codigo
            txtPass.Text = usuario._password
            ddlTipoUsuarios.SelectedValue = usuario._tipoUsuario
            ddlCedi.SelectedValue = Convert.ToInt32(usuario._cedi)
            ddlEmpresaTrasnp.SelectedValue = Convert.ToInt32(usuario._empresaT)

            btnEliminar.Visible = True
            btnModificar.Visible = True
            btnCrear.Visible = False
            txtUsuario.ReadOnly = True
        End If
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim usuariosBO As AdminUsuariosBO = New AdminUsuariosBO(cadenaConexion)
        Dim resultado As Boolean = False
        Dim existe As Boolean = False
        Dim cedi As String = String.Empty
        Dim empresaTransp As String = String.Empty

        cedi = ddlCedi.SelectedValue.ToString()
        empresaTransp = ddlEmpresaTrasnp.SelectedValue.ToString()

        If cedi = "-1" Then
            cedi = String.Empty
        End If
        If empresaTransp = "-1" Then
            empresaTransp = String.Empty
        End If

        existe = usuariosBO.verificaUsuario(txtUsuario.Text)

        If existe = True Then
            limpiarCampos()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia !','¡ Ya existe un usuario con ese código !', 'warning')", True)
        Else

            resultado = usuariosBO.ingresaUsuario(txtNombre.Text, Convert.ToInt32(ddlTipoUsuarios.SelectedValue.ToString()), txtUsuario.Text, txtPass.Text, cedi, empresaTransp)

            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Finalizado!', '¡ Registro Almacenado !', 'success')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If

            txtNombre.Text = ""
            txtPass.Text = ""
            txtUsuario.Text = ""

            cargarUsuarios()
        End If

    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim usuariosBO As AdminUsuariosBO = New AdminUsuariosBO(cadenaConexion)
        Dim resultado As Boolean = False
        Dim existe As Boolean = False
        Dim codigo As String = ""
        Dim cedi As String = String.Empty
        Dim empresaTransp As String = String.Empty

        cedi = ddlCedi.SelectedValue.ToString()
        empresaTransp = ddlEmpresaTrasnp.SelectedValue.ToString()

        If cedi = "-1" Then
            cedi = String.Empty
        End If
        If empresaTransp = "-1" Then
            empresaTransp = String.Empty
        End If

        codigo = gvUsuarios.SelectedValue.ToString()

        resultado = usuariosBO.modificarUsuario(txtNombre.Text, Convert.ToInt32(ddlTipoUsuarios.SelectedValue.ToString()), txtUsuario.Text, txtPass.Text, codigo, cedi, empresaTransp)

        If resultado = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Almacenado !', 'success')", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtUsuario.ReadOnly = False
        cargarUsuarios()
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim usuariosBO As AdminUsuariosBO = New AdminUsuariosBO(cadenaConexion)
        Dim codigo As String
        Dim resultado As Boolean = False

        codigo = gvUsuarios.SelectedValue.ToString()

        If String.IsNullOrEmpty(codigo) = False Then
            resultado = usuariosBO.elimimarUsuario(codigo)
            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Almacenado !', 'success')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia!', '¡ Debe seleccionar un usuario para realizar esta operación !', 'warning')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtUsuario.ReadOnly = False
        cargarUsuarios()

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtUsuario.ReadOnly = False
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvUsuarios.PageIndexChanging
        gvUsuarios.PageIndex = e.NewPageIndex
        cargarUsuarios()
    End Sub

    Protected Sub ddlTipoUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoUsuarios.SelectedIndexChanged
        Dim tipoUsuario As Integer = ddlTipoUsuarios.SelectedValue

        If tipoUsuario = 3 Then
            lblCedi.Visible = True
            ddlCedi.Visible = True
            lblEmpresaTransp.Visible = False
            ddlEmpresaTrasnp.Visible = False

        ElseIf tipoUsuario = 5 Then
            lblCedi.Visible = True
            ddlCedi.Visible = True
            lblEmpresaTransp.Visible = True
            ddlEmpresaTrasnp.Visible = True

        ElseIf tipoUsuario = 6 Then
            lblEmpresaTransp.Visible = True
            ddlEmpresaTrasnp.Visible = True
            lblCedi.Visible = False
            ddlCedi.Visible = False

        ElseIf tipoUsuario = 1 Or tipoUsuario = 2 Then
            lblCedi.Visible = False
            ddlCedi.Visible = False
            lblEmpresaTransp.Visible = False
            ddlEmpresaTrasnp.Visible = False

        End If

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
        gvUsuarios.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(gvUsuarios)
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
