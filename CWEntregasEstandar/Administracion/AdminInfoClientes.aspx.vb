Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Data
Imports co.com.CWEntregasEstandar
Imports System.IO

Partial Class Administracion_AdminInfoClientes
    Inherits Culture
    Private cadenaConexion As String
    Dim comando As SqlCommand
    Dim reader As SqlDataReader
    Dim conexion As Conexion
    Private inserted As Boolean
    Dim arrText As List(Of String)
    Dim t1 As DataTable = New Data.DataTable()
    Dim codigoUsuario As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()
        codigoUsuario = Session("codigousuario").ToString.Trim

        If Page.IsPostBack = False Then
            
        End If
    End Sub
    Sub cargarUsuarios()
        gvDatos.DataBind()
    End Sub

    Sub limpiarCampos()

        'txtNombre.Text = ""
        'txtPass.Text = ""
        'txtUsuario.Text = ""
        'ddlTipoUsuarios.SelectedValue = 1

    End Sub
    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            If (fuArchivo.HasFile) Then

                Dim Archivo As String = "CargueClientes " + DateTime.Now.ToString("ddMMyyyy") + "-" + fuArchivo.FileName

                Dim rutaArchivo As String = Server.MapPath("Maestras/")
                t1.Columns.Add("nitCliente", GetType(String))
                t1.Columns.Add("direccionCliente", GetType(String))
                t1.Columns.Add("telefonoCliente", GetType(String))
                t1.Columns.Add("emailCliente", GetType(String))

                'carga el archivo
                If UploadArchivo(Archivo) Then
                    ''lee el archivo 
                    LeerArchivo(rutaArchivo, Archivo)
                    If t1.Rows.Count > 0 Then
                        If ejecutaInserta(t1, codigoUsuario) Then
                            ScriptManager.RegisterStartupScript(up1, Me.GetType(), "Mensaje de Alerta", "alert('::Cargue Finalizado::');", True)
                        Else
                            ScriptManager.RegisterStartupScript(up1, Me.GetType(), "Mensaje de Alerta", "alert('::Cargue Finalizado::');", True)

                        End If
                    End If
                Else
                    lblError.Text = "Ocurrió un error al guardar el archivo adjunto."
                End If
            Else
                lblError.Text = "Seleccione un Archivo"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Function UploadArchivo(ByVal nombreArchivo As String) As Boolean
        Dim uploaded As Boolean = False

        Try

            Dim rutaArchivosAdjuntos As String = Server.MapPath("Maestras/")
            fuArchivo.SaveAs(rutaArchivosAdjuntos + nombreArchivo)
            uploaded = True
        Catch ex As Exception
            Dim errorex As String = ex.Message
            uploaded = False

        End Try

        Return uploaded
    End Function

    'lee el archivo 
    Public Sub LeerArchivo(ByVal rutaArchivo As String, ByVal nombreArchivo As String)
        Try
            'Dim objReader As New System.IO.StreamReader(rutaArchivo & nombreArchivo, System.Text.Encoding.UTF8)
            Dim objReader As New System.IO.StreamReader(rutaArchivo & nombreArchivo, Encoding.GetEncoding("iso-8859-1"))
            Dim sLine As String = ""
            Dim i As String = ""
            Dim nitCliente As String
            Dim dirCliente As String
            Dim telCliente As String
            Dim emailCliente As String
            arrText = New List(Of String)()

            While sLine IsNot Nothing
                sLine = objReader.ReadLine()

                i = i & 1
                If (i = 1) Then
                    Continue While
                End If

                If sLine IsNot Nothing Then
                    'nuevo
                    Dim delimiterChars As Char() = {";"}
                    Dim palabras() As String = sLine.Split(delimiterChars)

                    nitCliente = palabras(0)
                    If String.IsNullOrEmpty(nitCliente) Then
                        ScriptManager.RegisterStartupScript(up1, Me.GetType(), "Mensaje de Alerta", "alert('::NitCliente Obligatorio::');", True)
                    End If

                    dirCliente = palabras(1)
                    If String.IsNullOrEmpty(dirCliente) Then
                        ScriptManager.RegisterStartupScript(up1, Me.GetType(), "Mensaje de Alerta", "alert('::DireccionCliente Obligatorio::');", True)
                    End If

                    telCliente = palabras(2)
                    emailCliente = palabras(3)

                    t1.Rows.Add(nitCliente, dirCliente, telCliente, emailCliente)
                End If
            End While
            objReader.Close()
        Catch ex As Exception

        End Try
    End Sub

    'recorre el array y crea los registros
    Public Function ejecutaInserta(ByVal cadena As DataTable, ByVal codUsuario As String) As Boolean
        inserted = False

        Try
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(cadenaConexion)
            comando.Connection = conexion.getConexionBD()
            comando.CommandType = Data.CommandType.StoredProcedure
            comando.CommandText = "CargueClientesInsPro"
            comando.Parameters.AddWithValue("@product", cadena)
            comando.Parameters.AddWithValue("@codUsuario", codUsuario)
            conexion.openConexion()

            'inserted = True
            inserted = comando.ExecuteNonQuery() > 0

        Catch exe As Exception
            Dim mensaje As String = exe.Message
        Finally
            conexion.CloseConexion()
        End Try

        Return inserted
    End Function
    Protected Sub btnDescargarPlantilla_Click(sender As Object, e As EventArgs) Handles btnDescargarPlantilla.Click
        Dim rutaArchivo As String = Server.MapPath("~/Administracion/Plantillas/")
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=CargueInventarioTecnico.csv")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.[Default]
        Response.WriteFile(rutaArchivo & "CargueClientes.csv")
        Response.[End]()
    End Sub

    Protected Sub btnVerInfo_Click(sender As Object, e As EventArgs) Handles btnVerInfo.Click
        mvInformacion.SetActiveView(vSecundaria)
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
        Response.AddHeader("Content-Disposition", "attachment;filename=Inicio Labores.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        mvInformacion.SetActiveView(vPrincipal)
    End Sub
End Class
