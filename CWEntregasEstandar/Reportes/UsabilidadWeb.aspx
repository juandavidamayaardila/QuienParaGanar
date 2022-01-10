<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="UsabilidadWeb.aspx.vb" 
    Inherits="Reportes_UsabilidadWeb" Title="CELUWEB"  %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" 
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"  %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosUsuarios.ascx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Informe Uso Web"></asp:Label></small>
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
                    <asp:Label runat="server" Text=" Lista Uso Web"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="table-responsive table-scroll filtros">
                        <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" DataSourceID="dsDatos"
                            CssClass="gvHeader filtrar hide-column" >
                            <Columns>
                                <asp:BoundField DataField="codUsuario" HeaderText="Cod.Usuario" SortExpression="codUsuario" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" SortExpression="nombreUsuario" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="moduloWeb" HeaderText="M&#243;dulo Web" ReadOnly="True" SortExpression="moduloWeb" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="fechaUsabilidad" HeaderText="Fecha Ingreso" ReadOnly="True" SortExpression="fechaUsabilidad" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                            SelectCommand="ListaUsabilidadWebSelProc" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="fechaInicial" Type="String" />
                                <asp:Parameter Name="fechaFinal" Type="String" />                              
                                <asp:Parameter Name="tipoUsuario" Type="String" />
                                <asp:Parameter Name="usuario" Type="String"/>
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
