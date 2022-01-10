Partial Public Class Filtros_FiltrosFechas
    Inherits System.Web.UI.UserControl

    Private regionalSel As String = "-1"
    Private jefeSel As String = "-1"
    Private entregadorSel As String = "-1"


    Public Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim codigoUsuario As String = Session("codigousuario").ToString.Trim
            Dim tipoUsuario As String = Session("tipo").ToString.Trim

            txtFechaInicial.Value = Convert.ToDateTime(Date.Now).ToString().Substring(0, 10)
            txtFechaFinal.Value = Convert.ToDateTime(Date.Now).ToString().Substring(0, 10)
           

        End If
    End Sub
    Public Function fechaInicial() As String
        Dim fechaI As String

        fechaI = Format(Convert.ToDateTime(txtFechaInicial.Value), "yyyyMMdd")

        Return fechaI
    End Function

    Public Function fechaFinal() As String
        Dim fechaF As String

        fechaF = Format(Convert.ToDateTime(txtFechaFinal.Value), "yyyyMMdd")

        Return fechaF
    End Function
End Class
