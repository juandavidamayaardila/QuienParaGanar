<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltrosJerarquias.ascx.vb" Inherits="Filtros_FiltrosJerarquias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"  %> 
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
                <asp:Label ID="lblRegional" runat="server" Text="Regional"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlRegional" runat="server" CssClass='form-control' Width="160px" AutoPostBack="True" DataSourceID="dsRegional"
                    DataTextField="nombre" DataValueField="codigo">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsRegional" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" 
                    SelectCommand="RegionalDdlSelProc" SelectCommandType="StoredProcedure">                    
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblJefe" runat="server" Text="Transportadora"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID='ddlJefe' runat='server' CssClass='form-control' Width="160px" DataSourceID="dsJefe"
                    DataTextField="nombre" DataValueField="codigo" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsJefe" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                    SelectCommand="JefeDdlSelProc" SelectCommandType="StoredProcedure">
                    <SelectParameters>                        
                        <asp:ControlParameter ControlID="ddlRegional" Name="regional" PropertyName="SelectedValue" Type="String" DefaultValue ="-1" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEntregador" runat="server" Text="Conductor"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlEntregarores" runat="server" CssClass='form-control' Width="160px" DataSourceID="dsEntregadores" DataTextField="nombre" DataValueField="codigo">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsEntregadores" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" SelectCommand="EntregadoresDdlSelProc" SelectCommandType="StoredProcedure">
                    <SelectParameters>                       
                        <asp:ControlParameter ControlID="ddlRegional" Name="Regional" PropertyName="SelectedValue" Type="String" DefaultValue ="-1" />
                        <asp:ControlParameter ControlID="ddlJefe" Name="jefe" PropertyName="SelectedValue" Type="String" DefaultValue ="-1" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
<%--</div>--%>

