<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="TiemposRutas.aspx.vb"
    Inherits="Reportes_TiemposRutas" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosCWEntregasEstandar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text=" Informe Tiempos Rutas"></asp:Label></small>
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
                    <asp:Label runat="server" Text=" Lista Tiempos Rutas"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="table-responsive table-scroll filtros">
                        <asp:GridView ID="gvhora" runat="server" AutoGenerateColumns="False" DataSourceID="dsListaHoraInicio"
                            CssClass="gvHeader filtrar hide-column" >
                            <Columns>
                                <asp:BoundField DataField="codViaje" HeaderText="Solicitud" SortExpression="codViaje" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechasolicitud" HeaderText="Fecha Solicitud" ReadOnly="True" SortExpression="fechaFactura" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="cedisolicitud" HeaderText="Centro de Operacion" ReadOnly="True" SortExpression="cedi" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="empresasolicitud" HeaderText="Empresa de Transporte" ReadOnly="True" SortExpression="empresa" ItemStyle-HorizontalAlign="Left" />



                                <asp:BoundField DataField="codEntregador" HeaderText="Cedula" ReadOnly="True" SortExpression="codEntregador" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="nombreEntregador" HeaderText="Conductor" ReadOnly="True" SortExpression="nombreEntregador" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaini" HeaderText="Inicio Ruta" ReadOnly="True" SortExpression="fechaini" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechafin" HeaderText="Fin Ruta" ReadOnly="True" SortExpression="fechafin" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="tiempoRuta" HeaderText="Tiempo Ruta" ReadOnly="True" SortExpression="tiempoRuta" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsListaHoraInicio" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                            SelectCommand="ListaTiemposRutaOrbisSelProc" SelectCommandType="StoredProcedure">
                 <SelectParameters>
                                        <asp:Parameter Name="fechaInicial" Type="String" />
                                        <asp:Parameter Name="fechaFinal" Type="String" />
                                        <asp:Parameter Name="regional" Type="String" />
                                        <asp:Parameter Name="jefe" Type="String" />
                                        <%--<asp:Parameter Name="entregador" Type="String" />--%>
                                        <asp:Parameter Name="codigousuario" Type="String" />
                                        <asp:Parameter Name="tipo" Type="String" />
                                        <asp:Parameter Name="busqueda" Type="String" />
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
