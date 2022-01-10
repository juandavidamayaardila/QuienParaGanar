Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Configuration
Imports Microsoft.VisualBasic

Namespace DataBase
    Public Class Conexion
        Public conn As SqlConnection
        Private sqlCommand As SqlCommand
        Private cadenaConexion As String



        ''' <summary>
        ''' Permite establecer una conexion  hacia la base de datos
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Function openConexion() As Boolean
        '    Try
        '        If conn.State = ConnectionState.Open Then
        '            Return True
        '        Else
        '            conn.ConnectionString = cadenaConexion
        '            conn.Open()
        '            Return True
        '        End If
        '    Catch ex As Exception
        '        Return False
        '    End Try


        'End Function
        'SE AGREGA ESTA NUEVA FORMA QUE SIEMPRE CIERRA Y CREA UNA NUEVA CONEXION
        Function openConexion() As Boolean

            If conn.State = ConnectionState.Open Then
                conn.Close()
                Return True
            End If

            Try
                conn.ConnectionString = cadenaConexion
                conn.Open()

            Catch ex As Exception
                Return False
            End Try


        End Function

        ''' <summary>
        ''' Permite  cerrar una conexion
        ''' a la base de datos
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function CloseConexion() As Boolean
            Try
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' permite obtener el objeto de conexion
        ''' a la base de datos
        ''' </summary>
        ''' <returns>objeto de conexion</returns>
        ''' <remarks></remarks>
        Public Function getConexionBD() As SqlConnection
            Try
                Return Me.conn
            Catch ex As Exception

                If String.IsNullOrEmpty(cadenaConexion) Then
                    Me.openConexion()
                    Return Me.conn
                Else
                    Return New SqlConnection

                End If
            End Try
        End Function

        ''' <summary>
        ''' Constructor de la Clase
        ''' </summary>
        ''' <param name="cadenaConexion"></param>
        ''' <remarks></remarks>
        Sub New(ByVal cadenaConexion As String)

            Me.cadenaConexion = cadenaConexion
            conn = New SqlConnection()
            sqlCommand = New SqlCommand()

        End Sub
    End Class
End Namespace
