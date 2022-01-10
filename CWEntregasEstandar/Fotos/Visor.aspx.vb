Imports System.Collections.Generic
Imports co.com.CWEntregasEstandar.DataObject
Imports co.com.CWEntregasEstandar.BussinesObject
Imports co.com.CWEntregasEstandar.DataBase
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web
Imports System.Globalization

Partial Class Fotos_Visor
    Inherits Culture

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                Dim codFoto As String = Request.QueryString("codFoto")
                dsDatos.SelectParameters("codFoto").DefaultValue = codFoto
                dlDatos.DataBind()
            Catch ex As Exception

            End Try
        Else
            '    ' eventos pagina
        End If
    End Sub


    Protected Function GetUrl(ByVal page As String) As String
        Dim splits As String() = Request.Url.AbsoluteUri.Split("/"c)
        If splits.Length >= 2 Then
            Dim url As String = splits(0) & "//"
            For i As Integer = 2 To splits.Length - 2
                url += splits(i)
                url += "/"
            Next
            Return url & page
        End If
        Return page
    End Function
End Class
