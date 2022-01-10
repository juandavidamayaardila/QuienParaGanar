Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports System.Data.SqlClient
Partial Class Administracion_AdminMensajes
    Inherits Culture
    Private cadenaConexion As String
    Private mensaje As Mensajes
    Private mensajeBO As MensajeBO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        If Page.IsPostBack = False Then
            txtFechaInicial.Value = Convert.ToDateTime(Date.Now).ToString().Substring(0, 10)
            txtFechaFinal.Value = Convert.ToDateTime(Date.Now).ToString().Substring(0, 10)
            cargarDatos()
        End If
    End Sub

    Protected Sub ddlRegional_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRegional.SelectedIndexChanged
        dsJefe.DataBind()
        ddlJefe.DataBind()
    End Sub

    Sub cargarDatos()
        dsDatos.DataBind()
        gvDatos.DataBind()
    End Sub

    Sub limpiarCampos()

        txtMensaje.Text = ""

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        mensajeBO = New MensajeBO(cadenaConexion)
        mensaje = New Mensajes()
        Dim resultado As Boolean = False
        Dim cont As Integer = 0
        Dim codEntregador As String
        Dim codigoUsuario As String = Session("codigousuario").ToString.Trim

        mensaje._mensaje = txtMensaje.Text
        mensaje._fechaInicial = txtFechaInicial.Value
        mensaje._fechaFinal = txtFechaFinal.Value


        For Each row As GridViewRow In gvNoAsignados.Rows()

            Dim texto As CheckBox = CType(row.FindControl("cbNoAsignados"), CheckBox)

            If texto.Checked Then
                cont = cont + 1
            End If
        Next

        If cont <> 0 Then

            For Each row As GridViewRow In gvNoAsignados.Rows()

                Dim texto As CheckBox = CType(row.FindControl("cbNoAsignados"), CheckBox)

                If texto.Checked Then

                    codEntregador = row.Cells(1).Text.ToString()
                    mensaje._entregador = codEntregador
                    resultado = mensajeBO.ingresaMensaje(mensaje, codigoUsuario)

                End If

            Next

            If resultado = True Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Finalizado !', '¡Registro Almacenado !', 'success')", True)

                cargarDatos()
                limpiarCampos()
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            End If

        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Advertencia !', '¡Debe seleccionar un usuario para realizar esta operación !', 'warning')", True)
        End If

    End Sub

    Protected Sub gvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim codigo As String = ""

        codigo = gvDatos.SelectedValue.ToString()
        Session("codMensaje") = codigo
        mensaje = New Mensajes()
        mensajeBO = New MensajeBO(cadenaConexion)

        mensaje = mensajeBO.obtenerDatosMensaje(codigo)

        If String.IsNullOrEmpty(codigo) = False Then

            txtMensaje.Text = mensaje._mensaje
            txtFechaInicial.Value = mensaje._fechaInicial
            txtFechaFinal.Value = mensaje._fechaFinal

            btnModificar.Visible = True
            btnCrear.Visible = False

        End If
    End Sub
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        mensajeBO = New MensajeBO(cadenaConexion)
        mensaje = New Mensajes()
        Dim resultado As Boolean = False
        Dim existe As Boolean = False
        Dim codMensaje As String = ""
        Dim cont As Integer = 0
        Dim codEntregador As String

        codMensaje = Session("codMensaje").ToString()

        mensaje._mensaje = txtMensaje.Text
        mensaje._fechaInicial = txtFechaInicial.Value
        mensaje._fechaFinal = txtFechaFinal.Value
        mensaje._usuario = Session("codigousuario").ToString.Trim


        For Each row As GridViewRow In gvNoAsignados.Rows()

            Dim texto As CheckBox = CType(row.FindControl("cbNoAsignados"), CheckBox)

            If texto.Checked Then
                cont = cont + 1
            End If
        Next

        If cont <> 0 Then


            For Each row As GridViewRow In gvNoAsignados.Rows()

                Dim texto As CheckBox = CType(row.FindControl("cbNoAsignados"), CheckBox)

                If texto.Checked Then

                    codEntregador = row.Cells(1).Text.ToString()
                    mensaje._entregador = codEntregador
                    resultado = mensajeBO.modificarMensaje(codMensaje, mensaje)

                End If

            Next
        End If



        If resultado = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Actualizado !', 'success')", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡ Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
        End If

        limpiarCampos()
        Session("codMensaje") = ""
        Session.Remove("codMensaje")

        btnModificar.Visible = False
        btnCrear.Visible = True

        cargarDatos()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        limpiarCampos()
        Session("codMensaje") = ""
        Session.Remove("codMensaje")

        btnModificar.Visible = False
        btnCrear.Visible = True
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        cargarDatos()
    End Sub

    Protected Sub gvDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        mensajeBO = New MensajeBO(cadenaConexion)
        Dim codMensaje As Integer = Convert.ToInt32(e.CommandArgument.ToString())
        Session("codMensaje") = codMensaje

        ''Evento del boton de eliminar
        If e.CommandName = "Eliminar" Then

            If Not mensajeBO.elimimarMensaje(codMensaje) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Error!', '¡Ha ocurrido un error en la transacción, por favor intentar nuevamente !', 'error')", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Finalizado !', '¡ Registro Eliminado !', 'success')", True)
            End If

            limpiarCampos()

            btnModificar.Visible = False
            btnCrear.Visible = True
            cargarDatos()

        End If
        
    End Sub

    Protected Sub btnAceptarFiltros_Click(sender As Object, e As EventArgs)
        cargarNoAsignados()
    End Sub

    Sub cargarNoAsignados()
        dsListaNoAsignados.DataBind()
        gvNoAsignados.DataBind()
    End Sub

End Class
