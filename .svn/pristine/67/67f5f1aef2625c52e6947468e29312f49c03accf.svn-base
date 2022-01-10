Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.BussinesObject


Public Class Login

    Dim cadenaConexion As String
    Dim reader As SqlDataReader
    Sub LoginCandenaConexion(ByVal cadenaConexion As String)
        Me.cadenaConexion = cadenaConexion
    End Sub

    Function Loginresultado(ByVal usuario As String, ByVal clave As String) As String
        Dim oco As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection()
        Dim parametrosalida As String
        Dim comando As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()

        oco.ConnectionString = cadenaConexion
        comando.Connection = oco
        comando.CommandType = System.Data.CommandType.StoredProcedure
        comando.CommandText = "validarusuario"

        Try
            oco.Open()
            comando.Parameters.AddWithValue("@Usuario", usuario)
            comando.Parameters.AddWithValue("@Clave", clave)
            comando.Parameters.Add("@Resultado", System.Data.SqlDbType.NVarChar, 50)
            comando.Parameters.Add("@tipousuario", System.Data.SqlDbType.NVarChar, 50)
            comando.Parameters.Add("@codigousuario", System.Data.SqlDbType.NVarChar, 50)
            comando.Parameters("@Resultado").Direction = System.Data.ParameterDirection.Output
            comando.Parameters("@tipousuario").Direction = System.Data.ParameterDirection.Output
            comando.Parameters("@codigousuario").Direction = System.Data.ParameterDirection.Output

            comando.ExecuteNonQuery()

            If comando.Parameters(2).Value.ToString().Equals("OK") Then
                'Return "OK"
                parametrosalida = comando.Parameters("@Resultado").Value.ToString() + "," + comando.Parameters("@tipousuario").Value.ToString() + "," + comando.Parameters("@codigousuario").Value.ToString()
            Else
                parametrosalida = ""
            End If

            Return parametrosalida

        Catch ex As Exception
            Return "Error de Conexion"
        Finally
            oco.Close()

        End Try

        Return "Usuario o contraseña invalidos."

    End Function

    Function VerificarUrl(ByVal tipoUsuario As Integer, ByVal url As String) As Boolean
        Dim disponible As Boolean = False
        Dim oco As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection()

        Try
            Dim comando As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()

            oco.ConnectionString = cadenaConexion
            comando.Connection = oco
            comando.CommandType = System.Data.CommandType.StoredProcedure
            comando.CommandText = "ValidaAccesoUrlSelProc"
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario)
            comando.Parameters.AddWithValue("@url", url)
            oco.Open()
            reader = comando.ExecuteReader()
            If reader.Read Then
                disponible = CBool(reader("disponible"))
            End If

        Catch ex As Exception
            Return False
        Finally
            oco.Close()
        End Try

        Return disponible

    End Function
End Class
