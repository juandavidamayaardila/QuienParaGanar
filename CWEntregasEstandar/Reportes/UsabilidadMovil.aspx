<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="UsabilidadMovil.aspx.vb"
    Inherits="Reportes_UsabilidadMovil" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosFechas.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Informe Uso M&#243;vil"></asp:Label></small>
            </h1>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class=" table-responsive">
                        <CP:Filtros ID="filtros" runat="server" />
                        <table style="margin: auto;">
                            <tr>
                                <td colspan="3">
                                    <div style="text-align: center">
                                        <asp:Button ID="btnAceptar" runat="server" Text=" aceptar" CssClass="btn btn-primary" />
                                        <asp:Button ID="btnExportar" runat="server" Text=" exportar" CssClass="btn btn-info" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text=" Lista Uso M&#243;vil"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="table-responsive table-scroll filtros">
                        <asp:GridView ID="gvhora" runat="server" AutoGenerateColumns="False" DataSourceID="dsListaHoraInicio"
                            CssClass="gvHeader filtrar hide-column" >
                            <Columns>
                                <asp:BoundField DataField="codUsuario" HeaderText="Cedula" SortExpression="codUsuario" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="nombreEntregador" HeaderText="Conductor" SortExpression="nombreEntregador" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="moduloMovil" HeaderText="M&#243;dulo M&#243;vil" ReadOnly="True" SortExpression="moduloMovil" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaUsabilidad" HeaderText="fechaUsabilidad" ReadOnly="True" SortExpression="fechaUsabilidad" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsListaHoraInicio" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                            SelectCommand="ListaUsabilidadMovilOrbisSelProc" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="fechaInicial" Type="String" />
                                <asp:Parameter Name="fechaFinal" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
