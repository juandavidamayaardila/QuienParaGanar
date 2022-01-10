Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class MensajeBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1
        Dim mensaje As Mensajes

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function ingresaMensaje(ByVal mensaje As Mensajes, ByVal codUsuario As String) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "IngresarMensajesInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@mensaje", mensaje._mensaje)
                comando.Parameters.AddWithValue("@fechaInicial", Convert.ToDateTime(mensaje._fechaInicial))
                comando.Parameters.AddWithValue("@fechaFinal", Convert.ToDateTime(mensaje._fechaFinal))
                comando.Parameters.AddWithValue("@codUsuario", codUsuario)
                comando.Parameters.AddWithValue("@codEntregador", mensaje._entregador)

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

        Public Function obtenerDatosMensaje(ByVal codigo As String) As Mensajes

            mensaje = New Mensajes()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "MensajeXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    mensaje._entregador = reader("codEntregador").ToString()
                    mensaje._fechaInicial = reader("fechaInicial").ToString()
                    mensaje._fechaFinal = reader("fechaFinal").ToString()
                    mensaje._guia = reader("guiaMensaje").ToString()
                    mensaje._mensaje = reader("mensaje").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return mensaje
        End Function

        Function modificarMensaje(ByVal codMensaje As String, ByVal mensaje As Mensajes) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ActualizarMensajeUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codMensaje", codMensaje)
                comando.Parameters.AddWithValue("@mensaje", mensaje._mensaje)
                comando.Parameters.AddWithValue("@fechaInicial", Convert.ToDateTime(mensaje._fechaInicial))
                comando.Parameters.AddWithValue("@fechaFinal", Convert.ToDateTime(mensaje._fechaFinal))
                comando.Parameters.AddWithValue("@codUsuario", mensaje._usuario)
                comando.Parameters.AddWithValue("@codEntregador", mensaje._entregador)
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

        Function elimimarMensaje(ByVal codigo As String)
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "eliminarMensajeDelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", codigo)
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

End Namespace
