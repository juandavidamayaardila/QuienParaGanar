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

Partial Class Administracion_AdminEntregadores
    Inherits Culture
    Private cadenaConexion As String
    Private entregador As AdminEntregadores
    Private entregadorBO As AdminEntregadoresBO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        If Page.IsPostBack = False Then
            cargarUsuarios()
        End If
    End Sub
    Sub cargarUsuarios()
        gvUsuarios.DataBind()
    End Sub

    Sub limpiarCampos()

        txtNombre.Text = ""
        txtCodigo.Text = ""
        txtTelefono.Text = ""
        txtPass.Text = ""
        txtEmail.Text = ""
        chbEstado.Checked = False

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        entregadorBO = New AdminEntregadoresBO(cadenaConexion)
        entregador = New AdminEntregadores()
        Dim resultado As Boolean = False
        Dim existe As Boolean = False

        entregador._codigo = txtCodigo.Text
        entregador._nombre = txtNombre.Text
        entregador._telefono = txtTelefono.Text
        entregador._email = txtEmail.Text
        entregador._clave = txtPass.Text
        
        If chbEstado.Checked = True Then
            entregador._activo = "1"

        Else
            entregador._activo = "0"
        End If


        existe = entregadorBO.verificaUsuario(txtCodigo.Text)

        If existe = True Then
            limpiarCampos()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia !', '¡ Ya existe un Entregador con ese código !', 'warning')", True)
        Else

            resultado = entregadorBO.ingresaUsuario(entregador)

            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Almacenado !', 'success')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If

            limpiarCampos()

            cargarUsuarios()
        End If

    End Sub

    Protected Sub gvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvUsuarios.SelectedIndexChanged
        Dim codigo As String = ""

        codigo = gvUsuarios.SelectedValue.ToString()
        Session("codUsuario") = codigo
        entregador = New AdminEntregadores()
        entregadorBO = New AdminEntregadoresBO(cadenaConexion)

        entregador = entregadorBO.obtenerDatosEntragador(codigo)

        If String.IsNullOrEmpty(codigo) = False Then

            txtNombre.Text = entregador._nombre
            txtCodigo.Text = entregador._codigo
            txtTelefono.Text = entregador._telefono
            txtEmail.Text = entregador._email
            txtPass.Text = entregador._clave
            Dim estado As String = entregador._activo

            If estado = 1 Then
                chbEstado.Checked = True
            Else
                chbEstado.Checked = False
            End If

            btnEliminar.Visible = True
            btnModificar.Visible = True
            btnCrear.Visible = False
            txtCodigo.ReadOnly = True

        End If
    End Sub
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        entregadorBO = New AdminEntregadoresBO(cadenaConexion)
        entregador = New AdminEntregadores()
        Dim resultado As Boolean = False
        Dim existe As Boolean = False
        Dim codigo As String = ""

        codigo = gvUsuarios.SelectedValue.ToString()

        entregador._codigo = codigo
        entregador._nombre = txtNombre.Text
        entregador._telefono = txtTelefono.Text
        entregador._email = txtEmail.Text
        entregador._clave = txtPass.Text
        Dim estado As String = "0"
        If chbEstado.Checked = True Then
            estado = "1"
        End If
        entregador._activo = estado

        resultado = entregadorBO.modificarUsuario(entregador)

        If resultado = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Almacenado !', 'success')", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtCodigo.ReadOnly = False

        cargarUsuarios()
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        entregadorBO = New AdminEntregadoresBO(cadenaConexion)
        Dim codigo As String
        Dim resultado As Boolean = False

        codigo = Session("codUsuario").ToString()

        If String.IsNullOrEmpty(codigo) = False Then
            resultado = entregadorBO.elimimarUsuario(codigo)
            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Eliminado !', 'success')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡  Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia !', '¡ Debe seleccionar un usuario para realizar esta operación !', 'warning')", True)
        End If

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtCodigo.ReadOnly = False
        cargarUsuarios()

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        limpiarCampos()

        btnEliminar.Visible = False
        btnModificar.Visible = False
        btnCrear.Visible = True
        txtCodigo.ReadOnly = False
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvUsuarios.PageIndexChanging
        gvUsuarios.PageIndex = e.NewPageIndex
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
