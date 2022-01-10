Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports System.Xml
Imports co.com.CWEntregasEstandar.DataBase
Partial Class menu
    Inherits System.Web.UI.MasterPage

    Dim cadena As String
    Dim version As String = ""
    Dim ambiente As String = ""
    Dim mHtml As String = ""
    Dim url As String = String.Empty
    Dim urlData As String() = Nothing
    Dim last As String = String.Empty
    Dim comando As SqlCommand
    Dim conexion As Conexion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tipo As String = Session("tipo")
        Dim usuario As String = Session("codigousuario")

        url = Request.Url.AbsoluteUri
        urlData = url.Split("/")
        last = urlData.Last()
        Session("url") = last

        Session.Timeout = 300
        Server.ScriptTimeout = 300

        If Session("usuario") = "" Then
            Response.Redirect("~/index.aspx")
        End If

        cadena = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()
        registroUsoWeb(usuario, last)
        crearMenu(tipo, usuario)
        CargarVersion()

        If Not Page.IsPostBack Then
        End If

    End Sub

    Private Sub crearMenu(ByVal tipo As Integer, ByVal codigoUsuario As String)
        Dim dtMenuItems As New DataTable()
        'Se invoca al procedimiento almacenado
        Dim daMenu As New SqlDataAdapter("ObtenerOpcionesMenu", cadena)
        daMenu.SelectCommand.Parameters.AddWithValue("@tipousuario", tipo)
        daMenu.SelectCommand.Parameters.AddWithValue("@codigoUsuario", codigoUsuario)
        daMenu.SelectCommand.Parameters.AddWithValue("@LENGUAJE", Session("lang").ToString())
        Dim sesLang As String = Session("lang").ToString()
        daMenu.SelectCommand.CommandType = CommandType.StoredProcedure
        daMenu.Fill(dtMenuItems)

        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'Esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then

                If String.IsNullOrEmpty(drMenuItem("url").ToString()) Then
                    mHtml = mHtml + "<li> <a><img src=" + drMenuItem("icono") + " /></i>&nbsp;" + drMenuItem("descripcion").ToString() + "<span class='fa fa-chevron-down'></span></a> </a> "
                Else
                    If drMenuItem("descripcion").Equals("Salir") Or drMenuItem("descripcion").Equals("Exit") Then
                        mHtml = mHtml + "<li > <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("Url").ToString()) + "'> <img src=" + drMenuItem("icono") + " /> &nbsp;" + drMenuItem("descripcion").ToString() + "</a> "
                    Else
                        mHtml = mHtml + "<li> <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("url").ToString()) + "'>" + drMenuItem("descripcion").ToString() + "</a>"
                    End If
                End If

                AddMenuItem(drMenuItem("MenuId").ToString(), dtMenuItems)
                mHtml = mHtml + "</li>"
            End If
        Next

        menuHtml.Text = mHtml
    End Sub
    Private Sub AddMenuItem(ByVal MenuId As String, ByVal dtMenuItems As Data.DataTable)
        Dim con As Integer = 0

        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            If drMenuItem("PadreId").ToString.Equals(MenuId) AndAlso Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then

                If con = 0 Then
                    mHtml = mHtml + "<ul class='nav child_menu'>"
                End If
                If String.IsNullOrEmpty(drMenuItem("url").ToString()) Then
                    mHtml = mHtml + "<li> <a><i class='" + drMenuItem("icono") + "'></i>&nbsp;" + drMenuItem("descripcion").ToString() + "<span class='fa fa-chevron-down'></span></a> </a> "
                Else
                    mHtml = mHtml + "<li > <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("Url").ToString()) + "'>" + drMenuItem("descripcion").ToString() + "</a> "
                End If

                con += 1
                'Llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(drMenuItem("MenuId").ToString(), dtMenuItems)
                mHtml = mHtml + "</li>"
            End If
        Next

        If con > 0 Then
            mHtml = mHtml + "</ul>"
        End If

    End Sub
    Private Sub CargarVersion()
        Try
            Dim xDoc As New XmlDocument()
            xDoc.Load(Server.MapPath("~/App_Data/AppConfig.xml"))

            Dim versionTag As XmlNodeList = xDoc.GetElementsByTagName("version")
            Dim lista As XmlNodeList = DirectCast(versionTag(0), XmlElement).GetElementsByTagName("WebVersion")

            For Each nodo As XmlElement In lista
                version = nodo.GetAttribute("value")
            Next

            lista = DirectCast(versionTag(0), XmlElement).GetElementsByTagName("Enviroment")
            For Each nodo As XmlElement In lista
                ambiente = nodo.GetAttribute("value")
            Next
        Catch ex As Exception
            Dim [error] As String = ex.Message
        End Try
    End Sub

    Function registroUsoWeb(ByVal codUsuario As String, ByVal modulo As String) As Boolean

        Dim ingreso As Boolean = False
        comando = New SqlCommand()
        conexion = New Conexion(cadena)

        Try

            comando.CommandText = "UsoWebInsProc"
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexion.getConexionBD

            comando.Parameters.AddWithValue("@codUsuario", codUsuario)
            comando.Parameters.AddWithValue("@modulo", modulo)

            conexion.openConexion()
            ingreso = comando.ExecuteNonQuery() > 0
            ingreso = True

        Catch ex As Exception
            Dim errorT As String = ex.Message

        Finally

            conexion.CloseConexion()

        End Try

        Return ingreso

    End Function

End Class