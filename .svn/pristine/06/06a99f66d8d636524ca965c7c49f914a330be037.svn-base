<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminUsuarios.aspx.vb"
    Inherits="Administracion_AdminUsuarios" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/gestion.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Administraci&#243;n de Usuarios"></asp:Label>
                </small>
            </h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Perfil Usuario"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class=" table-responsive">
                        <table style="margin: auto;">
                            <tr>
                                <td rowspan="6">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Styles/images/usuarioV.png" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Nombre"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="validator" runat="server" ControlToValidate="txtNombre"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Usuario"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Password:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPass" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Tipo Usuario"></asp:Label>:
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlTipoUsuarios" runat="server" DataSourceID="dsTiposUsuarios" DataTextField="descripcion" AutoPostBack="true"
                                        DataValueField="codigo" CssClass='form-control' Width="196px" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">--SELECCIONE--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsTiposUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                        SelectCommand="TipoUsuarioDdlSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCedi" runat="server" Text="Centro Distribuci&#243;n:" Visible="false"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlCedi" runat="server" DataSourceID="dsCedi" DataTextField="descripcion" Visible="false"
                                        DataValueField="codigo" CssClass='form-control' Width="196px" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">--SELECCIONE--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsCedi" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                        SelectCommand="CentroDistribucionDdlSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmpresaTransp" runat="server" Text="Empresa de Transporte:" Visible="false"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlEmpresaTrasnp" runat="server" DataSourceID="dsEmpresaTransp" DataTextField="descripcion" Visible="false"
                                        DataValueField="codigo" CssClass='form-control' Width="196px" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">--SELECCIONE--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsEmpresaTransp" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                        SelectCommand="EmpresaTransportadoraDdlSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
                                        CssClass="btn btn-primary" />
                                    <asp:Button ID="btnExportar" runat="server" Text=" exportar" CssClass="btn btn-info" ValidationGroup="Exportar" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista de Usuarios"></asp:Label>
                </div>
                <div class="table-responsive table-scroll filtros">
                    <asp:GridView ID="gvUsuarios" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="gvHeader filtrar hide-column" 
                        DataSourceID="dsUsuarios" EnableModelValidation="True" DataKeyNames="codigo">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" SelectImageUrl="~/Styles/icons/aceptar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                            <%--<asp:BoundField DataField="codigo" HeaderText="C&#243;digo" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Right" />--%>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="tipoUsuario" HeaderText="Tipo Usuario" SortExpression="tipoUsuario" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="cedi" HeaderText="Centro Distribucion" SortExpression="cedi" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="empresaTransp" HeaderText="Empresa Transp" SortExpression="empresaTransp" ItemStyle-HorizontalAlign="Left" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" SelectCommand="UsuariosAdminSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
