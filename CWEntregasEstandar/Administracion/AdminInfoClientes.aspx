<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminInfoClientes.aspx.vb"
    Inherits="Administracion_AdminInfoClientes" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosFechasBusqueda.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/gestion.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Administraci&#243;n Info Clientes"></asp:Label>
                </small>
            </h1>
            <asp:MultiView ID="mvInformacion" runat="server" ActiveViewIndex="0">
                <asp:View ID="vPrincipal" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Cargue Informaci&#243;n"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class=" table-responsive">
                                <table style="margin: auto;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFechaIni" runat="server" Text="Archivo: "></asp:Label>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fuArchivo" runat="server" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCargar" runat="server" Text="Cargar" ValidationGroup="cargue" OnClick="btnCargar_Click" CssClass="btn btn-primary" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDescargarPlantilla" runat="server" Text="Descargar Plantilla" CssClass="btn btn-primary" OnClick="btnDescargarPlantilla_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px"></td>
                                        <td style="height: 20px;">
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <caption>
                                        <br />
                                        <br />
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <br />
                                                <br />
                                                <asp:Button ID="btnVerInfo" runat="server" CausesValidation="False" CssClass="btn btn-info" Text="Ver Información" />
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                                <br />
                                <br />
                                <br />
                                <asp:Panel ID="panelErrores" runat="server" Visible="false" Width="250px">
                                    <br />
                                    <br />
                                    <b>Log de Errores:</b>
                                    <br />
                                    <br />
                                    <asp:GridView ID="gvErrores" runat="server" CellPadding="4" Font-Size="10px" ForeColor="#333333"
                                        GridLines="None" EmptyDataText="SIN ERRORES" CssClass="gvHeader" Width="40px">
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                </asp:View>
                <asp:View ID="vSecundaria" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Informaci&#243;n Clientes"></asp:Label>
                        </div>
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
                                                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning" />

                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive table-scroll filtros">
                            <asp:GridView ID="gvDatos" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="gvHeader filtrar hide-column" 
                                DataSourceID="dsDatos" EnableModelValidation="True" DataKeyNames="nitCliente">
                                <Columns>
                                    <asp:BoundField DataField="nitCliente" HeaderText="Nit Cliente" SortExpression="nitCliente" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="direccionCliente" HeaderText="Direcci&#243;n" SortExpression="direccionCliente" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="telefonoCliente" HeaderText="Tel&#233;fono" ReadOnly="True" SortExpression="telefonoCliente" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="emailCliente" HeaderText="Email" ReadOnly="True" SortExpression="emailCliente" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="codusuario" HeaderText="Usuario Cargue" ReadOnly="True" SortExpression="codusuario" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="fechaServer" HeaderText="Fecha Cargue" ReadOnly="True" SortExpression="fechaServer" ItemStyle-HorizontalAlign="Left" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                SelectCommand="ListaCargueClientesSelProc" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Name="fechaInicial" Type="String" />
                                    <asp:Parameter Name="fechaFinal" Type="String" />
                                    <asp:Parameter Name="busqueda" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCargar" />
            <asp:PostBackTrigger ControlID="btnDescargarPlantilla" />
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
