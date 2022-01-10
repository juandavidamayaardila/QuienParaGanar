Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataBase

Public Class Informes
    Dim _cadenaConexion As String
    Dim comando As SqlCommand
    Dim reader As SqlDataReader
    Dim conexion As Conexion
    Dim filas As Integer = -1
    Dim ds As System.Data.DataSet
    Dim cadenaConexion As String

    Sub CandenaConexion(ByVal cadenaConexion As String)
        Me.cadenaConexion = cadenaConexion
    End Sub

    Function EjecutaConsultas(ByVal consulta As String) As Boolean
        Dim cadenaconexion = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ToString()

        Using conexionx As New Data.SqlClient.SqlConnection(cadenaconexion)
            conexionx.Open()
            Dim comando As Data.SqlClient.SqlCommand = conexionx.CreateCommand()
            Dim transaction As Data.SqlClient.SqlTransaction
            ' inicializar la transaccion
            transaction = conexionx.BeginTransaction("TransaccionEncuestas")
            comando.Connection = conexionx
            comando.Transaction = transaction
            Try
                comando.CommandType = Data.CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()

                transaction.Commit()
                Return True
            Catch ex As Exception
                transaction.Rollback()
                Return False
            Finally
                conexionx.Close()
            End Try

        End Using
    End Function
End Class
