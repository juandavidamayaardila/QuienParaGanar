<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminMensajes.aspx.vb"
    Inherits="Administracion_AdminMensajes" Title="CELUWEB" %>

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
                    <asp:Label runat="server" Text="Administraci&#243;n de Mensajes"></asp:Label>
                </small>
            </h1>
            <div class="row">
                <div class="col-sm-4  col-xs-12">
                    <caption>
                        <br />
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <asp:Label runat="server" Text="Datos Mensaje"></asp:Label>
                            </div>
                            <div class="panel-body">
                                <div class=" table-responsive">
                                    <table style="margin: auto;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFechaIni" runat="server" Text=" Fecha Inicial"></asp:Label>
                                            </td>
                                            <td>
                                                <input id="txtFechaInicial" runat="server" class="form-control datetime" readonly type="text"> </input>
                                            </td>
                                            <td><i id="iconI" runat="server" aria-hidden="true" class="glyphicon glyphicon-calendar"></i></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final"></asp:Label>
                                            </td>
                                            <td>
                                                <input id="txtFechaFinal" runat="server" class="form-control datetime" readonly type="text"> </input>
                                            </td>
                                            <td><i id="iconF" runat="server" aria-hidden="true" class="glyphicon glyphicon-calendar"></i></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Mensaje"></asp:Label>
                                                : </td>
                                            <td>
                                                <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" Rows="4" TextMode="MultiLine" ValidationGroup="crear"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ControlToValidate="txtMensaje" ErrorMessage=" * "></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: center">
                                                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-success" Text="Crear" ValidationGroup="crear" />
                                                <asp:Button ID="btnModificar" runat="server" CausesValidation="False" CssClass="btn btn-success" Text="Modificar" Visible="False" />
                                                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn btn-primary" Text="Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </caption>
                </div>
                <div class="col-sm-8 col-xs-12">
                    <br />
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Asignaci&#243;n Conductores"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <table style="margin: auto;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRegional" runat="server" Text="Regional"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRegional" runat="server" CssClass='form-control' Width="160px" AutoPostBack="True" DataSourceID="dsRegional"
                                            DataTextField="nombre" DataValueField="codigo">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="dsRegional" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                            SelectCommand="RegionalDdlSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblJefe" runat="server" Text="Transportadora"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID='ddlJefe' runat='server' CssClass='form-control' Width="160px" DataSourceID="dsJefe"
                                            DataTextField="nombre" DataValueField="codigo" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="dsJefe" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                            SelectCommand="JefeDdlSelProc" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlRegional" Name="regional" PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnAceptarFiltros" runat="server" Text=" Aceptar " CssClass="btn btn-success" OnClick="btnAceptarFiltros_Click" />
                                        <asp:Button ID="btnCancelarFiltros" runat="server" Text=" Cancelar " CssClass="btn btn-primary" />
                                    </td>
                                </tr>
                            </table>
                            <h2 class="page-header" style="text-align: center">
                                <asp:Label runat="server" Text="Conductores"></asp:Label>
                            </h2>
                            <div class="table-responsive">
                                <asp:GridView ID="gvNoAsignados" runat="server" AutoGenerateColumns="False" AllowPaging="False" CssClass="gvHeader"
                                    DataSourceID="dsListaNoAsignados" EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Asignar">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chHeader" runat="server" Text ="Todos" onClick="javascript:selectAllGridView(this)" TextAlign ="Right" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbNoAsignados" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codigo" HeaderText=" Cedula" SortExpression="codigo" InsertVisible="False" ReadOnly="True" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="nombre" HeaderText=" Conductor" SortExpression="nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsListaNoAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                                    SelectCommand="EntregadoresNoAsigandosSelProc" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlRegional" Name="regional" Type="String" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="ddlJefe" Name="jefe" Type="String" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label runat="server" Text="Lista Usuarios"></asp:Label>
                    </div>
                    <div class="table-responsive table-scroll filtros">
                        <asp:GridView ID="gvDatos" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="gvHeader filtrar"
                            DataSourceID="dsDatos" EnableModelValidation="True" DataKeyNames="codigo" OnRowCommand="gvDatos_RowCommand">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" SelectImageUrl="~/Styles/icons/aceptar.png" ButtonType="Image" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="codigo" HeaderText="Id Mensaje" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="mensaje" HeaderText="Mensaje" SortExpression="mensaje" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="codEntregador" HeaderText="Cedula" SortExpression="Conductores" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                <asp:BoundField DataField="entregador" HeaderText="Conductor" SortExpression="entregador" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="fechaInicial" HeaderText="Fecha Inicial" SortExpression="fechaInicial" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaFinal" HeaderText="Fecha Final" SortExpression="fechaFinal" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="codUsuario" HeaderText="Cod. Usuario Web" SortExpression="codUsuario" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="Usuarioweb" HeaderText="Usuario Web" SortExpression="Usuarioweb" ItemStyle-HorizontalAlign="Right" />
                               
                                <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" CommandName="Eliminar"
                                            OnClientClick="return confirm('¿Está seguro de Eliminar el Registro?');" CssClass="eliminar"
                                            ToolTip="Eliminar" CommandArgument='<%#Eval("codigo")%>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" SelectCommand="MensajesAdminSelProc"
                            SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
