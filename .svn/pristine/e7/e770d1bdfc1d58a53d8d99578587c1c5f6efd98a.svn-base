<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="Visor.aspx.vb" Inherits="Fotos_Visor" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CP" TagName="Filtros" Src="~/Filtros/FiltrosCWEntregasEstandar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista de Fotos"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:DataList ID="dlDatos" runat="server" DataSourceID="dsDatos">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="450px" Width="380px" ImageUrl='<%# Eval("codFotoUnica", GetUrl("ImageCode.aspx?codigo={0}"))%>' />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                            SelectCommand="ListaFotosSelProc" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="codFoto" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

