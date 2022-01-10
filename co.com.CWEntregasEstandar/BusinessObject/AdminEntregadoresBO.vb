Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class AdminEntregadoresBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function verificaUsuario(ByVal codUsuario As String) As Boolean

            Try
                comando = New SqlCommand()
                conexion = New DataBase.Conexion(_cadenaConexion)
                comando.Connection = conexion.getConexionBD()

                comando.CommandText = "VerificaEntregadorSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codEntregador", codUsuario)
                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            Finally
                conexion.CloseConexion()
            End Try

        End Function

        Function ingresaUsuario(ByVal entregador As AdminEntregadores) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "IngresarEntregadorInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", entregador._codigo)
                comando.Parameters.AddWithValue("@nombre", entregador._nombre)
                comando.Parameters.AddWithValue("@telefono", entregador._telefono)
                comando.Parameters.AddWithValue("@email", entregador._email)
                comando.Parameters.AddWithValue("@pass", entregador._clave)
                comando.Parameters.AddWithValue("@activo", entregador._activo)

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

        Public Function obtenerDatosEntragador(ByVal codigo As String) As AdminEntregadores

            Dim entregador As AdminEntregadores = New AdminEntregadores()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EntregardorXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    entregador._codigo = reader("codEntregador").ToString()
                    entregador._nombre = reader("nombreEntregador").ToString()
                    entregador._telefono = reader("telefonoEntregador").ToString()
                    entregador._email = reader("emailEntregador").ToString()
                    entregador._clave = reader("clave").ToString()
                    entregador._activo = reader("activo").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return entregador
        End Function

        Function modificarUsuario(ByVal entregador As AdminEntregadores) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ActualizarEntregadorUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", entregador._codigo)
                comando.Parameters.AddWithValue("@nombre", entregador._nombre)
                comando.Parameters.AddWithValue("@telefono", entregador._telefono)
                comando.Parameters.AddWithValue("@email", entregador._email)
                comando.Parameters.AddWithValue("@pass", entregador._clave)
                comando.Parameters.AddWithValue("@activo", entregador._activo)
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

        Function elimimarUsuario(ByVal codigo As String)
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "eliminarEntregadorDelProc"
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
