Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class CentroDistribucionBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1
        Dim cedi As CentroDistribucion

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function ingresaCentroDistribucion(ByVal cedi As CentroDistribucion) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "IngresarCentroDistribucionInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@descripcion", cedi._descripcion)

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

        Public Function obtenerDatosCedi(ByVal codigo As String) As CentroDistribucion

            cedi = New CentroDistribucion()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "CentroDistribucionXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    cedi._codigo = reader("codCedi").ToString()
                    cedi._descripcion = reader("nombreCedi").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return cedi
        End Function

        Function modificarCedi(ByVal cedi As CentroDistribucion) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ActualizarCediUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", cedi._codigo)
                comando.Parameters.AddWithValue("@descripcion", cedi._descripcion)

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

        Function elimimarCedi(ByVal codigo As String)
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EliminarCediDelProc"
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
