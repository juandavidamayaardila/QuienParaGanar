<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltrosFechas.ascx.vb" Inherits="Filtros_FiltrosFechas" %>

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
    </table>
<%--</div>--%>

