Partial Public Class Filtros_FiltrosJerarquias
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

            dsJefe.DataBind()
            ddlJefe.DataBind()

            dsEntregadores.DataBind()
            ddlEntregarores.DataBind()

        End If
    End Sub

    Protected Sub ddlRegional_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRegional.SelectedIndexChanged
        dsJefe.DataBind()
        ddlJefe.DataBind()
    End Sub

    Protected Sub ddlJefe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlJefe.SelectedIndexChanged
        dsEntregadores.DataBind()
        ddlEntregarores.DataBind()
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

    Public Property regional() As String
        Get
            Return ddlRegional.SelectedValue
        End Get
        Set(value As String)
            ddlRegional.SelectedValue = value
        End Set
    End Property

    Public Property jefe() As String
        Get
            Return ddlJefe.SelectedValue
        End Get
        Set(value As String)
            ddlJefe.SelectedValue = value
        End Set
    End Property

    Public Property entregador() As String
        Get
            Return ddlEntregarores.SelectedValue
        End Get
        Set(value As String)
            ddlEntregarores.SelectedValue = value
        End Set
    End Property
End Class
