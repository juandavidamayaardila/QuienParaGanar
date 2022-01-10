<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminEntregadores.aspx.vb"
    Inherits="Administracion_AdminEntregadores" Title="CELUWEB"  %>

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
                    <asp:Label runat="server" Text="Administraci&#243;n de Conductores"></asp:Label>
                </small>
            </h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Perfil Conductor"></asp:Label>
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
                                    <asp:Label runat="server" Text="Usuario(Cedula)"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Tel&#233;fono"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTelefono"
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
                                <td>Email:</td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator
                                        ID="revEmail"
                                        runat="server"
                                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ControlToValidate="txtEmail"
                                        Font-Size="18"
                                        ErrorMessage="*"
                                        ForeColor="red">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEstado" runat="server" Text="Activo"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chbEstado" runat="server" />
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
                                        CssClass="btn btn-primary" />  <asp:Button ID="btnExportar" runat="server" Text=" exportar " ValidationGroup="Exportar" CssClass="btn btn-info" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista Usuarios"></asp:Label>
                </div>
                <div class="table-responsive table-scroll filtros">
                    <asp:GridView ID="gvUsuarios" runat="server"  AutoGenerateColumns="False" CssClass="gvHeader filtrar hide-column" 
                        DataSourceID="dsUsuarios" EnableModelValidation="True" DataKeyNames="codigo">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" SelectImageUrl="~/Styles/icons/aceptar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="codigo" HeaderText="Cedula" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="telefono" HeaderText="T&#233;lefono" SortExpression="telefono" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="clave" HeaderText="Password" SortExpression="clave" ItemStyle-HorizontalAlign="Right" />
                            <asp:TemplateField HeaderText="Activo" SortExpression="Activo"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkgbActivo" runat="server" Checked='<%# Bind("Activo") %> ' Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"  SelectCommand="EntregadoresAdminSelProc" 
                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>   <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
