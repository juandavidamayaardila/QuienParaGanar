Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class CausalesBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1
        Dim causal As Causales

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function ingresaCausal(ByVal causal As Causales) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "IngresarCausalInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@descripcion", causal._descripcion)
                comando.Parameters.AddWithValue("@tipo", causal._tipo)

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

        Public Function obtenerDatosCausal(ByVal codigo As String) As Causales

            causal = New Causales()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "CausalXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    causal._codigo = reader("causalGestion").ToString()
                    causal._descripcion = reader("DescripcionGestion").ToString()
                    causal._tipo = reader("tipoCausal").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return causal
        End Function

        Function modificarCausal(ByVal causal As Causales) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ActualizarCausalUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", causal._codigo)
                comando.Parameters.AddWithValue("@descripcion", causal._descripcion)
                comando.Parameters.AddWithValue("@tipo", causal._tipo)

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

        Function elimimarCausal(ByVal codigo As String)
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "EliminarCausalDelProc"
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
