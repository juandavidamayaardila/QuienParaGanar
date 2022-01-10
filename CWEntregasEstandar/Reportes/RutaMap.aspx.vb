Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Globalization
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Partial Class Reportes_RutaMap
    Inherits System.Web.UI.Page

    Public urlWeb As String = ""
    Public localizacion As String = ""
    Public resumen As String = ""
    Public imagenGPS As String = ""
    Public centro As String = ""
    Dim comando As SqlCommand
    Dim reader As SqlDataReader
    Dim conexion As Conexion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                Session.Timeout = 500

                Dim solicitud As String = Request.QueryString("sol")
                Dim conductor As String = Request.QueryString("con")
                Dim fecha As String = Request.QueryString("fe")

                Dim coordenadas As List(Of CoordenadaMapa) = New List(Of CoordenadaMapa)


                Dim cadenaConexion As String
                cadenaConexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()


                coordenadas = traeCoordenadas(solicitud, conductor, fecha)

                Dim cadenaCoordenadas As String = ""
                Dim cadenaDescribe As String = ""
                Dim cuenta As Integer = 1
                If coordenadas.Count > 0 Then

                    For Each datos As CoordenadaMapa In coordenadas

                        Dim latitudGPS As String = datos._latitud
                        Dim longitudGPS As String = datos._longitud
                        Dim fechaGPS As String = datos._fechacoordenada

                        Dim cedula As String = datos._cedula
                        Dim conductorGps As String = datos._conductor
                        Dim tipocoordenada As String = datos._tipocoordenada
                        Dim solicitudGps As String = datos._solicitud
                        Dim nit As String = datos._nit
                        Dim cliente As String = datos._cliente
                        Dim direccion As String = datos._direccion
                        Dim ciudad As String = datos._ciudad



                        'SOBRE
                        'DETALLE

                        If tipocoordenada = 2 Then '1 de seguimiento
                            cadenaCoordenadas = cadenaCoordenadas + "['Coordenada Capturada " + fechaGPS + "'," + latitudGPS.Replace(",", ".") + "," + longitudGPS.Replace(",", ".") + ",1,'gps/gps.png'],"

                            cadenaDescribe = cadenaDescribe + "['<b>Tipo Coordenada:</b> Seguimiento <br/>  <b>Solicitud:</b>" + solicitudGps + "<br/>  <b>Cedula:</b>" + cedula + " <br/> <b>Conductor:</b>" + conductorGps + " <br/> <b>Fecha:</b>" + fechaGPS + "'],"
                        Else '1 de cliente
                            cadenaCoordenadas = cadenaCoordenadas + "['Coordenada Capturada " + fechaGPS + "'," + latitudGPS.Replace(",", ".") + "," + longitudGPS.Replace(",", ".") + ",1,'gps/gps2.png'],"

                            cadenaDescribe = cadenaDescribe + "['<b>Tipo Coordenada:</b> Cliente <br/>  <b>Solicitud:</b>" + solicitudGps + "<br/>  <b>Cedula:</b>" + cedula + " <br/> <b>Conductor:</b>" + conductorGps + " <br/> <b>Nit:</b>" + nit + " <br/> <b>Cliente:</b>" + cliente + " <br/> <b>Direccion:</b>" + direccion + " <br/> <b>Ciudad:</b>" + ciudad + " <br/> <b>Fecha:</b>" + fechaGPS + "'],"
                        End If


                        'If tipocoordenada = 2 Then '1 de seguimiento
                        '    cadenaDescribe = cadenaDescribe + "['Coordenada " + cuenta.ToString() + "<br/>  <b>Tipo Coordenada:</b> Seguimiento <br/>  <b>Solicitud:</b>" + solicitudGps + "<br/>  <b>Cedula:</b>" + cedula + " <br/> <b>Conductor:</b>" + conductorGps + "'],"
                        'Else '1 de cliente
                        '    cadenaDescribe = cadenaDescribe + "['Coordenada " + cuenta.ToString() + "<br/>  <b>Tipo Coordenada:</b> Cliente <br/>  <b>Solicitud:</b>" + solicitudGps + "<br/>  <b>Cedula:</b>" + cedula + " <br/> <b>Conductor:</b>" + conductorGps + " <br/> <b>Nit:</b>" + nit + " <br/> <b>Cliente:</b>" + cliente + " <br/> <b>Direccion:</b>" + direccion + " <br/> <b>Ciudad:</b>" + ciudad + "'],"
                        'End If

                        localizacion = cadenaCoordenadas.Substring(0, cadenaCoordenadas.Length - 1)
                        resumen = cadenaDescribe.Substring(0, cadenaDescribe.Length - 1)
                        If String.IsNullOrEmpty(centro) Then
                            imagenGPS = "gps/gps.png"
                            centro = "new google.maps.LatLng(" + latitudGPS.Replace(",", ".") + "," + longitudGPS.Replace(",", ".") + "),"
                        End If
                        cuenta = cuenta + 1
                    Next
                End If

                Dim prueba As String = cadenaCoordenadas
            Else
                '    ' eventos pagina
            End If


        Catch ex As Exception

        End Try
    End Sub
    Function traeCoordenadas(ByVal solicitud As String, ByVal conductor As String, ByVal fecha As String) As List(Of CoordenadaMapa)

        Dim coordenadas As List(Of CoordenadaMapa) = New List(Of CoordenadaMapa)

        Try
            comando = New SqlCommand()

            conexion = New Conexion(ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString())
            comando.Connection = conexion.getConexionBD
            comando.CommandType = Data.CommandType.StoredProcedure

            comando.CommandText = "ListaCoordenadasRutaMapaSelProc"

            comando.Parameters.AddWithValue("@solicitud", solicitud.Trim())
            comando.Parameters.AddWithValue("@codentregador", conductor.Trim())
            comando.Parameters.AddWithValue("@fecha", fecha.Trim())

            conexion.openConexion()
            reader = comando.ExecuteReader()

            While reader.Read

                Dim coordenada As CoordenadaMapa = New CoordenadaMapa
                coordenada._fechacoordenada = reader("fechaCoordenada").ToString()
                coordenada._latitud = reader("latitud").ToString()
                coordenada._longitud = reader("longitud").ToString()
                coordenada._cedula = reader("Cedula").ToString()
                coordenada._conductor = reader("Conductor").ToString()
                coordenada._tipocoordenada = reader("tipocoordenada").ToString()
                coordenada._solicitud = reader("Solicitud").ToString()
                coordenada._nit = reader("Nit").ToString()
                coordenada._cliente = reader("Cliente").ToString()
                coordenada._direccion = reader("Direccion").ToString()
                coordenada._ciudad = reader("Ciudad").ToString()
                coordenadas.Add(coordenada)

            End While

            Return coordenadas

        Catch ex As Exception
            Return coordenadas
        Finally
            conexion.CloseConexion()
        End Try
    End Function

End Class
