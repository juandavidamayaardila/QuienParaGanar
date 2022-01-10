<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="DetalleGestionParcial.aspx.vb"
    Inherits="Reportes_DetalleGestionParcial" Title="CELUWEB" %>

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
                    <asp:Label runat="server" Text="Gesti&#243;n Parcial"></asp:Label></small>
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
                    <asp:Label runat="server" Text="Lista Detalle Gesti&#243;n Parcial"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="table-responsive table-scroll filtros">
                        <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" DataSourceID="dsDatos"
                            CssClass="gvHeader filtrar">
                            <Columns>
                                <asp:BoundField DataField="solicitud" HeaderText="Solicitud" ReadOnly="True" SortExpression="solicitud" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaviaje" HeaderText="Fecha Solicitud" ReadOnly="True" SortExpression="fechaFactura" ItemStyle-HorizontalAlign="Left" />

                                 <asp:BoundField DataField="codViaje" HeaderText="Viaje" SortExpression="codViaje" ItemStyle-HorizontalAlign="Left" />
                                  <asp:BoundField DataField="placaviaje" HeaderText="Placa" SortExpression="placaviaje" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="peso" HeaderText="Peso Viaje" SortExpression="peso" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="unidadpeso" HeaderText="Unidad Peso" SortExpression="unidadpeso" ItemStyle-HorizontalAlign="Left" />

                                
                                <asp:BoundField DataField="codFactura" HeaderText="Factura" SortExpression="codFactura" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaFactura" HeaderText="Fecha Factura" ReadOnly="True" SortExpression="fechaFactura" ItemStyle-HorizontalAlign="Left" />
                                  <asp:BoundField DataField="descripciontipofactura" HeaderText="Tipo Factura" SortExpression="descripciontipofactura" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="volumenFactura" HeaderText="Peso Factura" SortExpression="volumenFactura" ItemStyle-HorizontalAlign="Left" />


                                  <asp:BoundField DataField="codCliente" HeaderText="Nit" ReadOnly="True" SortExpression="codCliente" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" ReadOnly="True" SortExpression="nombreCliente" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="direccionCliente" HeaderText="Direccion" SortExpression="direccionCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="ciudadCliente" HeaderText="Ciudad" SortExpression="ciudadCliente" ItemStyle-HorizontalAlign="Left" />

                                 <asp:BoundField DataField="fechaGestion" HeaderText="Fecha Gesti&#243;n" ReadOnly="True" SortExpression="fechaGestion" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="codProducto" HeaderText="Cod.Producto" ReadOnly="True" SortExpression="codProducto" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="descripcionProducto" HeaderText="Producto" ReadOnly="True" SortExpression="descripcionProducto" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="cantProgramada" HeaderText="Cant.Programada" ReadOnly="True" SortExpression="cantProgramada" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="cantidadGestionada" HeaderText="Cant.Gestionada" ReadOnly="True" SortExpression="cantidadGestionada" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="DescripcionGestion" HeaderText="Causal" ReadOnly="True" SortExpression="DescripcionGestion" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="codEntregador" HeaderText="Cedula" ReadOnly="True" SortExpression="codEntregador" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="nombreEntregador" HeaderText="Conductor" ReadOnly="True" SortExpression="nombreEntregador" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="notaEntrega" HeaderText="Nota Entrega" ReadOnly="True" SortExpression="notaEntrega" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaNota" HeaderText="Fecha Nota" ReadOnly="True" SortExpression="fechaNota" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="negocio" HeaderText="Negocio" ReadOnly="True" SortExpression="negocio" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="cedi" HeaderText="Centro de Operacion" ReadOnly="True" SortExpression="cedi" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="empresa" HeaderText="Empresa de Transporte" ReadOnly="True" SortExpression="empresa" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="fechaServer" HeaderText="Fecha Server" ReadOnly="True" SortExpression="fechaServer" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                            SelectCommand="ListaDetalleGestioOrbisSelProc" SelectCommandType="StoredProcedure">
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
