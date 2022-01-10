Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Datas
Imports co.com.CWEntregasEstandar
Imports System
Imports System.Configuration

Namespace BussinesObject
    Public Class GeneralBO
        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim comando1 As SqlCommand
        Dim reader1 As SqlDataReader
        Dim conexion1 As Conexion
        Dim comando2 As SqlCommand
        Dim reader2 As SqlDataReader
        Dim conexion2 As Conexion

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion

        End Sub

        Public Function fotosNovedades(ByVal codFoto As String, ByVal resultado As Boolean) As Byte()
            comando = New SqlCommand()
            Dim foto As Byte() = Nothing

            conexion = New DataBase.Conexion(_cadenaConexion)
            comando.Connection = conexion.getConexionBD()

            Try
                comando.CommandText = "FotosNovedadSelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codFoto", codFoto)
                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then

                    While reader.Read()
                        foto = CType(reader("foto"), Byte())
                        resultado = True
                    End While
                End If

            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return foto

        End Function


        'InsertarEncabezadoPresupuesto
        Function fotoHabeasData(ByVal documento As String, ByVal resultado As Boolean) As Byte()
            Dim foto As Byte()
            Dim resp As Integer = 0

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "BuscaFotoHabeasDataSelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@documento", documento)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        foto = reader("imagen")
                        resultado = True
                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return foto
        End Function

    End Class

End Namespace
