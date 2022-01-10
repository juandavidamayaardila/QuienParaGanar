Imports System
Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Services.Protocols

<WebService()> <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> <System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete : Inherits WebService

    Public Sub AutoComplete()
    End Sub

    <WebMethod()> Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
        If count = 0 Then
            count = 10
        End If
        Dim dt As DataTable = GetRecords(prefixText)
        Dim items As List(Of String) = New List(Of String)(count)
        Dim j As Integer = 0
        If dt.Rows.Count - 1 < count Then
            j = dt.Rows.Count - 1
        Else
            j = count
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim strName As String = dt.Rows(i)(0).ToString()
            items.Add(strName)
        Next
        Return items.ToArray()
    End Function
    <WebMethod()> Public Function GetRecords(ByVal strName As String) As DataTable
        Dim strConn As String = ConfigurationManager.ConnectionStrings("CWEntregasEstandar").ConnectionString
        Dim con As New SqlConnection(strConn)
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("@Name", strName)
        cmd.CommandText = "Select ltrim(rtrim(codigo))+' - '+ltrim(rtrim(descripcion)) from referencias where (descripcion like '%'+@Name+'%' or codigo like '%'+@Name+'%') group by codigo,descripcion"
        Dim objDs As New DataSet()
        Dim dAdapter As New SqlDataAdapter()
        dAdapter.SelectCommand = cmd
        con.Open()
        dAdapter.Fill(objDs)
        con.Close()
        Return objDs.Tables(0)
    End Function


End Class
