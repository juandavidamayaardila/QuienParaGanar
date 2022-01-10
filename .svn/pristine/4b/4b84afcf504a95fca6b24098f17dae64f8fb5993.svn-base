<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminEmpresaTransportadora.aspx.vb"
    Inherits="Administracion_AdminEmpresaTransportadora" Title="CELUWEB"  %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/gestion.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Administraci&#243;n Empresa de Transporte"></asp:Label>
                </small>
            </h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Informaci&#243;n Empresa de Transporte"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class=" table-responsive">
                        <table style="margin: auto;">
                            <tr>                                
                                <td>
                                    <asp:Label runat="server" Text="Empresa de Transporte"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="validator" runat="server" ControlToValidate="txtDescripcion"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" />
                                    <asp:Button ID="btnModificar" runat="server" CausesValidation="False" Text="Modificar"
                                        Visible="False" CssClass="btn btn-success" />
                                    <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" Text="Eliminar"
                                        Visible="False" CssClass="btn btn-danger" />
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"
                                        CssClass="btn btn-primary" />  <asp:Button ID="btnExportar" runat="server" Text=" exportar" CssClass="btn btn-info" ValidationGroup="Exportar" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista Empresas de Transporte"></asp:Label>
                </div>
                <div class="table-responsive table-scroll filtros">
                    <asp:GridView ID="gvDatos" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="gvHeader filtrar hide-column" 
                        DataSourceID="dsDatos" EnableModelValidation="True" DataKeyNames="codigo">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" SelectImageUrl="~/Styles/icons/aceptar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="codigo" HeaderText="C&#243;digo" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripci&#243;n" SortExpression="descripcion" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" SelectCommand="EmpresaTransportadoraAdminSelProc"
                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>   <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
