<%@ Page Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="RutaMap.aspx.vb" Inherits="Reportes_RutaMap" Title="CELUWEB" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="AjaxControlToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?key=AIzaSyCRhaw7cdOLMx4Ex0azfJv4_vuouHxg9s8'></script>
    <AjaxControlToolkit:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label ID="Label1" runat="server" Text=" Mapa Ruta Conductor"></asp:Label></small>
            </h1>
            <div style="width: 100%; height: 50px; text-align: center; background-color: gray">
                <center><table style="color:white;font-weight:bold"><tr style="padding-top:5px;"><td><img src="Gps/gps.png" /></td><td>Coordenadas de Seguimiento</td><td><img src="Gps/gps2.png" /></td><td>Coordenadas de Cliente</td></tr></table></center>
            </div>
            <%--            <div class="panel panel-default">

                <div class="panel-body">--%>
            <div style="width: 100%; text-align: center;">
                <center>
                  <div id="map" style="width: 100%; height: 500px;">

                        <script type="text/javascript">
                            var locations =  [<%=me.localizacion%>    ];        
                            // Info Window Content
                            var infoWindowContent = [ <%=me.resumen%>  ];
                            //imagen
    
                            var image = {
                                url: '../reportes/gps/gps.png',
                                // This marker is 20 pixels wide by 32 pixels tall.
                                size: new google.maps.Size(37, 51),
                                // The origin for this image is 0,0.
                                origin: new google.maps.Point(0,0),
                                // The anchor for this image is the base of the flagpole at 0,32.
                                anchor: new google.maps.Point(0, 51)
                            };
      
                            var map = new google.maps.Map(document.getElementById('map'), {
                                zoom: 14,
                                center: <%=me.centro%> //new google.maps.LatLng(6.2530899, -75.5759593),
                                    mapTypeId: google.maps.MapTypeId.ROADMAP
                            });

                            var infowindow = new google.maps.InfoWindow({
                                content: "",
                                maxWidth: 550 ,
                                maxHeight: 550
                            });

                            var marker, i;

                            for (i = 0; i < locations.length; i++) {  
    

    
                                marker = new google.maps.Marker({
                                    position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                                    icon: locations[i][4],
                                    map: map,
                                    title:locations[i][0] ,
                                    zIndex: locations[i][3]
                                });

                                google.maps.event.addListener(marker, 'click', (function(marker, i) {
                                    return function() {
                                        infowindow.setContent(infoWindowContent[i][0]);
                                        infowindow.open(map, marker);
                                    }
                                })(marker, i));
                            }
                        </script>

                    </div>
               </center>
            </div>
            <%--     </div>
            </div>--%>
        </ContentTemplate>

    </AjaxControlToolkit:UpdatePanel>
</asp:Content>
