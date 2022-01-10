Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class AdminUsuariosBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1
        Dim usuario As AdminUsuarios

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion
        End Sub

        Function verificaUsuario(ByVal usuario As String) As Boolean

            Dim cmdTxt = "select * from usuarios where codUsuario = @codigo"

            Try
                comando = New SqlCommand()
                conexion = New DataBase.Conexion(_cadenaConexion)
                comando.Connection = conexion.getConexionBD()

                comando.CommandType = CommandType.Text
                comando.CommandText = cmdTxt
                comando.Parameters.AddWithValue("@codigo", usuario)
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

        Function ingresaUsuario(ByVal nombre As String, ByVal tipoUsuario As Integer, ByVal usuario As String, ByVal password As String, ByVal cedi As String, ByVal empresaTransp As String) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "IngresarUsuarioInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@tuser", tipoUsuario)
                comando.Parameters.AddWithValue("@usario", usuario)
                comando.Parameters.AddWithValue("@pass", password)
                comando.Parameters.AddWithValue("@cedi", cedi)
                comando.Parameters.AddWithValue("@empresaTransp", empresaTransp)
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

        Public Function obtenerDatosUsuario(ByVal codigo As String) As AdminUsuarios

            usuario = New AdminUsuarios()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "UsuarioXcodigoSelPro"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                comando.Parameters.AddWithValue("@codigo", codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.Read() Then

                    usuario._codigo = reader("codUsuario").ToString()
                    usuario._nombre = reader("nombreUsuario").ToString()
                    usuario._tipoUsuario = reader("codTipoUsuario").ToString()
                    usuario._password = reader("clave").ToString()
                    usuario._idUsuario = reader("idUsuario").ToString()
                    usuario._cedi = reader("codCedi").ToString()
                    usuario._empresaT = reader("codEmpresa").ToString()

                End If

            Catch ex As Exception
                Dim [error] As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return usuario
        End Function

        Function modificarUsuario(ByVal nombre As String, ByVal tipoUsuario As Integer, ByVal usuario As String, ByVal password As String, ByVal codigo As String, ByVal cedi As String, ByVal empresaTransp As String) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ActualizarUsuarioUpdProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@tuser", tipoUsuario)
                comando.Parameters.AddWithValue("@usuario", usuario)
                comando.Parameters.AddWithValue("@pass", password)
                comando.Parameters.AddWithValue("@codigo", codigo)
                comando.Parameters.AddWithValue("@cedi", cedi)
                comando.Parameters.AddWithValue("@empresaTransp", empresaTransp)
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
                comando.CommandText = "EliminarUsuarioDelProc"
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
        Function ingresarJerarquia(ByVal codJefe As String, ByVal codUsuario As String, ByVal jerarquiaUsuario As String) As Boolean

            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "AsignaJerarquiaUsuariosInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codJefe", codJefe)
                comando.Parameters.AddWithValue("@codUsuario", codUsuario)
                comando.Parameters.AddWithValue("@tipoUsuario", jerarquiaUsuario)
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

        Function validarJerarquia(ByVal codigo As String) As Boolean
            Dim ingreso As Boolean = False
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)
            Try
                comando.CommandText = "ValidarJerarquiaSelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", codigo)
                conexion.openConexion()

                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        ingreso = True
                    End While
                End If


            Catch ex As Exception
                Dim errorT As String = ex.Message

            Finally
                conexion.CloseConexion()
            End Try

            Return ingreso
        End Function

        Function validarTipoVendedor(ByVal usuario As String) As Boolean

            Dim cmdTxt = "select top 1 * from vendedores where codigo = @codigo and tipoVenta = '1'"

            Try
                comando = New SqlCommand()
                conexion = New DataBase.Conexion(_cadenaConexion)
                comando.Connection = conexion.getConexionBD()

                comando.CommandType = CommandType.Text
                comando.CommandText = cmdTxt
                comando.Parameters.AddWithValue("@codigo", usuario)
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

    End Class

End Namespace
