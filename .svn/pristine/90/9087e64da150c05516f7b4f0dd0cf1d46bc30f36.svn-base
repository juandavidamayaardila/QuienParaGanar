<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="AdminJerarquia.aspx.vb" Inherits="Administracion_AdminJerarquia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/gestion.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Administraci&#243;n Jerarqu&#237;as"></asp:Label>
                </small>
            </h1>
            <div class="col-sm-4  col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label runat="server" Text="Seleccionar Jerarqu&#237;a"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <table style="margin: auto;">
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Asignar"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: center;">
                                        <asp:Button ID="btnJerarquiaRegionalJefe" runat="server" Text=" Regional <=> Transportadora " CssClass="btn btn-primary" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Asignar"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: center;">
                                        <asp:Button ID="btnJerarquiaJefeVendedor" runat="server" Text="Transportadora <=> Entregador" CssClass="btn btn-primary" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-sm-8 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label runat="server" Text="Asignaci&#243;n"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <table style="margin: auto;">
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Usuario"></asp:Label>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" AutoPostBack="True"
                                        DataTextField="nombre" DataValueField="codigo" DataSourceID="dsUsuarioJerarquia">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsUsuarioJerarquia" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"  
                                        SelectCommand="UsuarioJerarquiaDdlSelProc" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Name="jerarquiaUsuario" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                        <div class="col-sm-6 col-xs-12">
                            <h2 class="page-header" style="text-align: center">
                                <asp:Label runat="server" Text="Asignados"></asp:Label>
                            </h2>
                            <div style="text-align: center">
                                <asp:Button ID="btnQuitarAsignacion" runat="server" CssClass="btn btn-primary" Text="Quitar Asignaci&#243;n" Enabled="false" />
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvAsignados" runat="server" AutoGenerateColumns="False" CssClass="gvHeader"
                                    AllowPaging="False" DataSourceID="dsListaAsignados" EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Asignar">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chHeader" runat="server" onClick="javascript:selectAllGridView(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbMarcarAsignados" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codigo" HeaderText=" codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="nombre" HeaderText=" nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Left" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsListaAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" 
                                    SelectCommand="ListaJerarquiAsignadaSelProc" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="codigo" Type="String" />
                                        <asp:Parameter Name="tipoJerarquia" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="col-sm-6 col-xs-12">
                            <h2 class="page-header" style="text-align: center">
                                <asp:Label runat="server" Text="No Asignados"></asp:Label>
                            </h2>
                            <div style="text-align: center">
                                <asp:Button ID="btnAprobarAsignacion" runat="server" CssClass="btn btn-primary" Text="Aprobar Asignaciones" Enabled="false" />
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvNoAsignados" runat="server" AutoGenerateColumns="False" AllowPaging="False" CssClass="gvHeader"
                                     DataSourceID="dsListaNoAsignados" EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Asignar">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chHeader" runat="server" onClick="javascript:selectAllGridView(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbMarcarNoAsignados" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codigo" HeaderText=" codigo" SortExpression="codigo" InsertVisible="False" ReadOnly="True" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField DataField="nombre" HeaderText=" nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsListaNoAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" 
                                    SelectCommand="ListaJerarquiNoAsignadaSelProc" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="codigo" Type="String" />
                                        <asp:Parameter Name="tipoJerarquia" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
