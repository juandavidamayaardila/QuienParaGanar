<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="ConsultaViaje.aspx.vb"
    Inherits="Reportes_ConsultaViaje" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosFechasBusqueda.ascx" %>
<script runat="server">  
   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Información Solicitud"></asp:Label></small>
            </h1>
            <asp:MultiView runat="server" ID="mvGeneral" ActiveViewIndex="0">
                <asp:View runat="server" ID="vPrincipal">
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
                            <asp:Label runat="server" Text="Lista de Viajes"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive table-scroll filtros">
                                <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" DataSourceID="dsDatos"
                                    CssClass="gvHeader filtrar hide-column"  EnableModelValidation="True" DataKeyNames="codViaje">
                                    <Columns>
                                        <asp:CommandField HeaderText="Ver Detalle" ShowSelectButton="True" SelectImageUrl="~/Styles/icons/listar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="solicitud" HeaderText="Solicitud" ReadOnly="True" SortExpression="solicitud" ItemStyle-HorizontalAlign="Left" />
                                       	<asp:BoundField DataField="codViaje" HeaderText="Viaje" SortExpression="codViaje" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="fechaViaje" HeaderText="Fecha" SortExpression="fechaViaje" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="placaViaje" HeaderText="Placa" ReadOnly="True" SortExpression="placaViaje" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="documentos" HeaderText="Documentos" ReadOnly="True" SortExpression="documentos" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="clientes" HeaderText="Clientes" ReadOnly="True" SortExpression="clientes" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="peso" HeaderText="Peso" ReadOnly="True" SortExpression="peso" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="unidadPeso" HeaderText="Unidad" ReadOnly="True" SortExpression="unidadPeso" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="codentregador" HeaderText="Conductor" ReadOnly="True" SortExpression="codentregador" ItemStyle-HorizontalAlign="Left" />
                                       <asp:BoundField DataField="fechaServer" HeaderText="Fecha Server" ReadOnly="True" SortExpression="fechaServer" ItemStyle-HorizontalAlign="Left" />
                                         <asp:BoundField DataField="cedi" HeaderText="Centro de Operacion" ReadOnly="True" SortExpression="cedi" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="empresa" HeaderText="Empresa de Transporte" ReadOnly="True" SortExpression="empresa" ItemStyle-HorizontalAlign="Left" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                    SelectCommand="ListaConsultaViajeSelProc" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="fechaInicial" Type="String" />
                                        <asp:Parameter Name="fechaFinal" Type="String" />
                                        <asp:Parameter Name="busqueda" Type="String"  />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="vSecundaria">
                    <div style="text-align: center">
                        <asp:Label ID="lblFacturas" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Facturas Viaje"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" DataSourceID="dsFacturas"
                                    CssClass="gvHeader" EnableModelValidation="True" DataKeyNames="codFactura">
                                    <Columns>
                                        <asp:CommandField HeaderText="Ver Detalle" ShowSelectButton="True" SelectImageUrl="~/Styles/icons/listar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="codViaje" HeaderText="Viaje" SortExpression="codViaje" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="codFactura" HeaderText="Factura" SortExpression="codFactura" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="codTipoFactura" HeaderText="Tipo Factura" ReadOnly="True" SortExpression="codTipoFactura" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="fechaFactura" HeaderText="Fecha Factura" ReadOnly="True" SortExpression="fechaFactura" ItemStyle-HorizontalAlign="Left" />
                                        <%--<asp:BoundField DataField="valor" HeaderText="Valor" ReadOnly="True" SortExpression="valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:C0}" />--%>
                                        <asp:BoundField DataField="ordenPedido" HeaderText="Orden Pedido" ReadOnly="True" SortExpression="ordenPedido" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="codCliente" HeaderText="Nit" ReadOnly="True" SortExpression="codCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" ReadOnly="True" SortExpression="nombreCliente" ItemStyle-HorizontalAlign="Left" />
                                       <%-- <asp:BoundField DataField="razonSocialCliente" HeaderText="Raz&#243;n Social" ReadOnly="True" SortExpression="razonSocialCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="nitCliente" HeaderText="Nit" ReadOnly="True" SortExpression="nitCliente" ItemStyle-HorizontalAlign="Left" />
                                        --%><asp:BoundField DataField="direccionCliente" HeaderText="Direcci&#243;n" ReadOnly="True" SortExpression="direccionCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="ciudadCliente" HeaderText="Ciudad" ReadOnly="True" SortExpression="ciudadCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="telefonoCliente" HeaderText="Tel&#233;fono" ReadOnly="True" SortExpression="telefonoCliente" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="notaEntrega" HeaderText="Nota Entrega" ReadOnly="True" SortExpression="notaEntrega" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="fechaNota" HeaderText="Fecha Nota" ReadOnly="True" SortExpression="fechaNota" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="negocio" HeaderText="Negocio" ReadOnly="True" SortExpression="negocio" ItemStyle-HorizontalAlign="Left" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsFacturas" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                    SelectCommand="ListaFacturasSelProc" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="codViaje" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <br />
                            <table style="margin: auto;">
                                <tr>
                                    <td colspan="3">
                                        <div style="text-align: center">
                                            <asp:Button ID="btnVolver" runat="server" Text=" Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
            <asp:Panel ID="panelResumen" runat="server" CssClass="modalPopUp">
                <div>
                    <asp:Button ID="bCloseResumen" runat="server" CausesValidation="false" CssClass="buttonPopUp" />
                </div>
                <div style="text-align: center">
                    <asp:Label ID="lblNumdoc" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label runat="server" Text="Detalle Factura"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:GridView ID="gvdetalle" runat="server" AutoGenerateColumns="False" CssClass="gvHeader" DataSourceID="dsDetalle" EnableModelValidation="True"
                                ShowFooter="true" Width="100%" OnRowDataBound="gvdetalle_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="codFactura" HeaderText="Factura" ReadOnly="True" SortExpression="codFactura" ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField DataField="fechaDetalle" HeaderText="Fecha" ReadOnly="True" SortExpression="fechaDetalle" ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField DataField="codProducto" HeaderText="Cod.Producto" SortExpression="codProducto" ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField DataField="descripcionProducto" HeaderText="Descripcion" SortExpression="descripcionProducto" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="pesoProducto" HeaderText="Peso" SortExpression="pesoProducto" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" ItemStyle-HorizontalAlign="Left" />
                                    <%--<asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="right" />--%>
                                </Columns>
                                <FooterStyle CssClass="gvHeader-footer" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="dsDetalle" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" SelectCommand="ListaDetalleFacSelProc"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Name="codFactura" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:HiddenField ID="hfShowResumen" runat="server" />
            <asp:HiddenField ID="hfHideResumen" runat="server" />
            <cc1:ModalPopupExtender ID="mpPanelResumen" runat="server" PopupControlID="panelResumen"
                TargetControlID="hfShowResumen" BackgroundCssClass="FondoModal" CancelControlID="hfHideResumen">
            </cc1:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
