<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltrosCWEntregasEstandar.ascx.vb" Inherits="Filtros_FiltrosCWEntregasEstandar" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<div class=" table-responsive">--%>
<table style="margin: auto;">
    <tr>
        <td>
            <asp:Label ID="lblFechaIni" runat="server" Text=" Fecha Inicial"></asp:Label>
        </td>
        <td>
            <input type="text" class="form-control datetime" id="txtFechaInicial" runat="server" readonly>
        </td>
        <td>
            <i class="glyphicon glyphicon-calendar" aria-hidden="true" id="iconI" runat="server"></i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final"></asp:Label>
        </td>
        <td>
            <input type="text" class="form-control datetime" id="txtFechaFinal" runat="server" readonly>
        </td>
        <td>
            <i class="glyphicon glyphicon-calendar" aria-hidden="true" id="iconF" runat="server"></i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblRegional" runat="server" Text="Centro de Operacion"></asp:Label>
        </td>
        <td colspan="2">
            <asp:DropDownList ID="ddlRegional" runat="server" CssClass='form-control' Width="160px" AutoPostBack="True" DataSourceID="dsRegional"
                DataTextField="nombre" DataValueField="codigo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsRegional" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                SelectCommand="CediDdlSelProc" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="tipousuario" Type="String" SessionField="tipo" />
                    <asp:SessionParameter Name="codigousuario" Type="String" SessionField="codigousuario" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblJefe" runat="server" Text="Empresa de Transporte"></asp:Label>
        </td>
        <td colspan="2">
            <asp:DropDownList ID='ddlJefe' runat='server' CssClass='form-control' Width="160px" DataSourceID="dsJefe"
                DataTextField="nombre" DataValueField="codigo" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsJefe" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                SelectCommand="EmpresaDdlSelProc" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="tipousuario" Type="String" SessionField="tipo" />
                    <asp:SessionParameter Name="codigousuario" Type="String" SessionField="codigousuario" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>:
        </td>
        <td>
            <asp:TextBox ID="txtBuscar" runat="server" CssClass='form-control'></asp:TextBox>
        </td>
    </tr>
</table>
<%--</div>--%>

