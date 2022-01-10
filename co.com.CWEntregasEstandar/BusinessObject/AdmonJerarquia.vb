Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports co.com.CWEntregasEstandar.DataBase
Imports co.com.CWEntregasEstandar.DataObject

Namespace BussinesObject

    Public Class AdmonJerarquia
        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion
        Dim filas As Integer = -1

        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion

        End Sub

        Function MuestraAsignados(ByVal codigo As Integer) As List(Of itemsCombo)
            Dim cmdTxt = "select usuario as codigo,nombre from usuariosnoel where tipousuario = 6 and usuario in (select Jefe de ventas from jerarquia where jefe=@codigo)"
            Dim listaAsignados As List(Of itemsCombo)
            listaAsignados = New List(Of itemsCombo)
            Dim asignados As itemsCombo

            Try
                comando = New SqlCommand()
                conexion = New DataBase.Conexion(_cadenaConexion)
                comando.Connection = conexion.getConexionBD()
                comando.CommandType = CommandType.Text
                comando.CommandText = cmdTxt
                comando.Parameters.AddWithValue("@codigo", codigo)
                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        asignados = New itemsCombo(reader("codigo"), reader("nombre"))
                        listaAsignados.Add(asignados)

                    End While
                    Return listaAsignados

                Else
                    Return (New List(Of itemsCombo))
                End If
            Catch ex As Exception
                Return (New List(Of itemsCombo))
            Finally
                conexion.CloseConexion()
            End Try
        End Function

        Function MuestraNoAsignados(ByVal codigo As Integer) As List(Of itemsCombo)
            Dim cmdTxt = "select usuario as codigo,nombre from usuariosnoel where tipousuario = 6 and usuario not in (select Jefe de ventas from jerarquia)"
            Dim listaAsignados As List(Of itemsCombo)
            listaAsignados = New List(Of itemsCombo)
            Dim asignados As itemsCombo

            Try
                comando = New SqlCommand()
                conexion = New DataBase.Conexion(_cadenaConexion)
                comando.Connection = conexion.getConexionBD()
                comando.CommandType = CommandType.Text
                comando.CommandText = cmdTxt
                comando.Parameters.AddWithValue("@codigo", codigo)
                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        asignados = New itemsCombo(reader("codigo"), reader("nombre"))
                        listaAsignados.Add(asignados)

                    End While
                    Return listaAsignados

                Else
                    Return (New List(Of itemsCombo))
                End If
            Catch ex As Exception
                Return (New List(Of itemsCombo))
            Finally
                conexion.CloseConexion()
            End Try
        End Function

    End Class

End Namespace
