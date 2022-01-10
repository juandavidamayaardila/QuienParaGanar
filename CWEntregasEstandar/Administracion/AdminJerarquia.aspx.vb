Imports co.com.CWEntregasEstandar
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject

Partial Class Administracion_AdminJerarquia
    Inherits Culture

    Private cadenaConexion As String
    Private jerarquiaUsuario As Integer = 0
    Private tipoJerarquia As Integer = 0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub btnJerarquiaRegionalJefe_Click(sender As Object, e As EventArgs) Handles btnJerarquiaRegionalJefe.Click
        Session("jerarquiaUsuario") = 2
        Session("tipoJerarquia") = 3

        dsUsuarioJerarquia.SelectParameters("jerarquiaUsuario").DefaultValue = Session("jerarquiaUsuario").ToString.Trim
        ddlUsuario.DataBind()

        mostrarAsignados(Session("tipoJerarquia").ToString.Trim)
        mostrarNoAsignados(Session("tipoJerarquia").ToString.Trim)

        btnQuitarAsignacion.Enabled = True
        btnAprobarAsignacion.Enabled = True
    End Sub

    Protected Sub btnJerarquiaJefeVendedor_Click(sender As Object, e As EventArgs) Handles btnJerarquiaJefeVendedor.Click
        Session("jerarquiaUsuario") = 3
        Session("tipoJerarquia") = 4

        dsUsuarioJerarquia.SelectParameters("jerarquiaUsuario").DefaultValue = Session("jerarquiaUsuario").ToString.Trim
        ddlUsuario.DataBind()

        mostrarAsignados(Session("tipoJerarquia").ToString.Trim)
        mostrarNoAsignados(Session("tipoJerarquia").ToString.Trim)
        btnQuitarAsignacion.Enabled = True
        btnAprobarAsignacion.Enabled = True
    End Sub

    Sub mostrarAsignados(tipoJerarquia As String)
        Dim usuario As String = ddlUsuario.SelectedValue.ToString()

        dsListaAsignados.SelectParameters("codigo").DefaultValue = usuario
        dsListaAsignados.SelectParameters("tipoJerarquia").DefaultValue = tipoJerarquia
        gvAsignados.DataBind()
    End Sub

    Sub mostrarNoAsignados(tipoJerarquia As String)

        Dim usuario As String = ddlUsuario.SelectedValue.ToString()

        dsListaNoAsignados.SelectParameters("codigo").DefaultValue = usuario
        dsListaNoAsignados.SelectParameters("tipoJerarquia").DefaultValue = tipoJerarquia
        gvNoAsignados.DataBind()

    End Sub

    Protected Sub ddlUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUsuario.SelectedIndexChanged
        mostrarAsignados(Session("tipoJerarquia").ToString.Trim)
        mostrarNoAsignados(Session("tipoJerarquia").ToString.Trim)
    End Sub

    Protected Sub btnQuitarAsignacion_Click(sender As Object, e As EventArgs) Handles btnQuitarAsignacion.Click
        Dim lista As List(Of String)
        lista = New List(Of String)()

        For Each row As GridViewRow In gvAsignados.Rows()

            Dim texto As CheckBox = CType(row.FindControl("cbMarcarAsignados"), CheckBox)
            Dim transaccion As String = ""

            If texto.Checked Then

                Dim usuario As String = row.Cells(1).Text.ToString()

                If Session("jerarquiaUsuario") = 2 Then
                    transaccion = "delete jerarquiaUsuarios where CodUsuario='" + RTrim(LTrim(usuario)) + "'"
                ElseIf Session("jerarquiaUsuario") = 3 Then
                    transaccion = "delete jerarquiaUsuarios where CodUsuario='" + RTrim(LTrim(usuario)) + "'"
                End If

                If (String.IsNullOrEmpty(transaccion) = False) Then
                    lista.Add(transaccion)
                End If
            End If
        Next

        If lista.Count > 0 Then
            actualizarAsignados(lista)
        End If
    End Sub
    Function actualizarAsignados(ByVal listaTransacciones As List(Of String)) As Boolean

        Using conexion As New Data.SqlClient.SqlConnection(cadenaConexion)
            conexion.Open()
            Dim comando As Data.SqlClient.SqlCommand = conexion.CreateCommand()
            Dim transaction As Data.SqlClient.SqlTransaction
            ' inicializar la transaccion
            transaction = conexion.BeginTransaction("TransaccionEncuestas")
            comando.Connection = conexion
            comando.Transaction = transaction
            Try

                For Each transaccion As String In listaTransacciones
                    comando.CommandType = Data.CommandType.Text
                    comando.CommandText = transaccion
                    comando.ExecuteNonQuery()

                Next
                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                Return False

            Finally
                conexion.Close()
                mostrarAsignados(Session("tipoJerarquia").ToString.Trim)
                mostrarNoAsignados(Session("tipoJerarquia").ToString.Trim)

            End Try

        End Using

    End Function

    Protected Sub btnAprobarAsignacion_Click(sender As Object, e As EventArgs) Handles btnAprobarAsignacion.Click

        Dim usuariosBO As AdminUsuariosBO = New AdminUsuariosBO(cadenaConexion)
        Dim resultado As Boolean = False
        Dim existeJerarquia As Boolean = False

        If Session("jerarquiaUsuario") = 2 Then
            Dim existe As Integer = 0

            For Each row As GridViewRow In gvNoAsignados.Rows()

                Dim texto As CheckBox = CType(row.FindControl("cbMarcarNoAsignados"), CheckBox)
                Dim transaccion As String = ""

                If texto.Checked Then
                    existeJerarquia = usuariosBO.validarJerarquia(row.Cells(1).Text.ToString())

                    If existeJerarquia = False Then
                        existe = 1
                    End If
                End If
            Next

            If existe = 0 Then
                For Each row As GridViewRow In gvNoAsignados.Rows()

                    Dim texto As CheckBox = CType(row.FindControl("cbMarcarNoAsignados"), CheckBox)
                    Dim transaccion As String = ""

                    If texto.Checked Then
                        Dim codJefe As String = ddlUsuario.SelectedValue.ToString()
                        Dim codUsuario As String = row.Cells(1).Text.ToString()

                        resultado = usuariosBO.ingresarJerarquia(codJefe, codUsuario, Session("jerarquiaUsuario").ToString())

                    End If
                Next
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡ Advertencia !', '¡ Usuario no Registra !', 'warning')", True)
            End If

        ElseIf Session("jerarquiaUsuario") = 3 Then
            For Each row As GridViewRow In gvNoAsignados.Rows()

                Dim texto As CheckBox = CType(row.FindControl("cbMarcarNoAsignados"), CheckBox)
                Dim transaccion As String = ""

                If texto.Checked Then
                    Dim usuario1 As String = ddlUsuario.SelectedValue.ToString()
                    Dim usuario2 As String = row.Cells(1).Text.ToString()

                    resultado = usuariosBO.ingresarJerarquia(usuario1, usuario2, Session("jerarquiaUsuario").ToString())

                End If
            Next
        End If

        mostrarAsignados(Session("tipoJerarquia").ToString.Trim)
        mostrarNoAsignados(Session("tipoJerarquia").ToString.Trim)
    End Sub
End Class
