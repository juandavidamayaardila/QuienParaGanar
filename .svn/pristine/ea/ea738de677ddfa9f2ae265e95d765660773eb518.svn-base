Imports co.com.CWEntregasEstandar
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Partial Class Index
    Inherits System.Web.UI.Page
    Private login As Login
    Dim version As String = ""
    Dim ambiente As String = ""

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarVersion()
        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub bIngresar_Click(sender As Object, e As EventArgs) Handles bIngresar.Click
        Dim cadena As String
        Dim mensajelogeo As String
        Dim vector As Array
        Dim vectoPass As String = ""
        Dim cadenaconsulta As String = ""

        cadena = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        login = New Login()
        login.LoginCandenaConexion(cadena)

        mensajelogeo = login.Loginresultado(txtUsuario.Value.ToString(), txtClave.Value.ToString())

        vector = Split(mensajelogeo, ",")
        Response.Write(vector(0))

        If vector(0) = "OK" Then
            Session.Timeout = 60
            Session("usuario") = Me.txtUsuario.Value.ToString()
            Session("tipo") = vector(1)
            Session("codigousuario") = vector(2)

            If Session("tipo") = 6 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            ElseIf Session("tipo") = 1 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            ElseIf Session("tipo") = 2 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            ElseIf Session("tipo") = 3 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            ElseIf Session("tipo") = 4 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            ElseIf Session("tipo") = 5 Then
                Response.Redirect("Reportes/ConsultaViaje.aspx")
            End If

        Else
            Response.Write("<script>alert('Usuario o contraseña invalidos.')</script>")
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "swal('¡Advertencia!', '¡ Usuario o contraseña invalidos !', 'warning')", True)
        End If

    End Sub
End Class
