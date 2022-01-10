<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltrosUsuarios.ascx.vb" Inherits="Filtros_FiltrosUsuarios" %>

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
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass='form-control' Width="160px" AutoPostBack="True" DataSourceID="dsTipoUsuario"
                    DataTextField="nombre" DataValueField="codigo">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsTipoUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>" 
                    SelectCommand="TipoUsuarioTodosDdlSelProc" SelectCommandType="StoredProcedure">                    
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID='ddlUsuario' runat='server' CssClass='form-control' Width="160px" DataSourceID="dsUsuario"
                    DataTextField="nombre" DataValueField="codigo" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:CWEntregasEstandar %>"
                    SelectCommand="UsuarioDdlSelProc" SelectCommandType="StoredProcedure">
                    <SelectParameters>                        
                        <asp:ControlParameter ControlID="ddlTipoUsuario" Name="tipoUsuario" PropertyName="SelectedValue" Type="String" DefaultValue ="-1" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
<%--</div>--%>

