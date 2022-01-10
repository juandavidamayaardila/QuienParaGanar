Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class EmpresaTransportadoraBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1
        Dim empresa As EmpresaTransportadora

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function ingresarEmpresaTransportadora(ByVal empresa As EmpresaTransportadora) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EmpresaTransportadoraInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@descripcion", empresa._descripcion)

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

        Public Function obtenerDatosEmpresaTransportadora(ByVal codigo As String) As EmpresaTransportadora

            empresa = New EmpresaTransportadora()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EmpresaTransportadoraXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    empresa._codigo = reader("codEmpresa").ToString()
                    empresa._descripcion = reader("nombreEmpresa").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return empresa
        End Function

        Function modificarEmpresaTransportadora(ByVal empresa As EmpresaTransportadora) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EmpresaTransportadoraUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", empresa._codigo)
                comando.Parameters.AddWithValue("@descripcion", empresa._descripcion)

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

        Function elimimarEmpresaTransportadora(ByVal codigo As String)
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EmpresaTransportadoraDelProc"
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
