<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" Title="CELUWEB"  %> 

<!DOCTYPE html >
<html lang="es">
<head id="Head1" runat="server">
    <title>Celuweb S.A.S</title>
    <meta charset="utf-8">
    <!-- Mobile viewport optimized: h5bp.com/viewport -->
    <meta name="viewport" content="width=device-width">

    <!-- CSS -->
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap/dist/css/bootstrap.css" />
    <link href="Styles/css/styles.css" rel="Stylesheet" rev="stylesheet" />

    <!--Scripts-->
    <script src="http://code.jquery.com/jquery-3.3.1.min.js" type="text/javascript"></script>
 <%--   <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>--%>
    <script src="Styles/js/Funciones.js" type="text/javascript"></script>
    <script src="Styles/bootstrap/js/bootstrap.js" type="text/javascript"></script>

</head>
<body>
    <div class="row">
        <div class="col-lg-6" style="max-height: 640px; padding-left: 0px; padding-right: 0px;">
            <div class="col-md-12">
                <form id="form2" runat="server">
                    <div class="col-md-12" style="margin-top: 20px;">
                        <div class="col-md-4 col-md-push-4" style="text-align: center">
                            <img src="Styles/images/logoini-CWEntregasEstandar.png" width="246px" height="230px" />
                        </div>
                    </div>
                    <div class="col-md-12" style="margin-top: 40px;">
                        <div class="col-md-6 col-md-push-3" style="text-align: center">
                            <div class="col-md-6" style="background-image: url(Styles/images/login-CWEntregasEstandar.png); background-repeat: no-repeat; text-align: center; width: auto; height: 100px;">
                                <div class="col-md-4" style="text-align: left;">
                                    <input id="txtUsuario" runat="server" type="text" name="username" required="required" placeholder="usuario" style="width: 270px; margin-top: 1px; border:none;">
                                </div>
                                <div class="col-lg-12">
                                    <br />
                                    <br />
                                </div>
                                <div class="col-md-4" style="text-align: left;">
                                    <input id="txtClave" runat="server" type="password" name="password" required="required" placeholder="password" style="width: 270px; margin-top: 10px; border:none;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-4 col-md-push-4" style="text-align: center">
                            <br />
                            <br />
                            <asp:ImageButton ID="bIngresar" runat="server" ImageUrl="Styles/images/ingresarLogin.png" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="col-lg-6" style="max-height: 642px; padding-left: 0px; padding-right: 0px;">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" style="max-height: inherit">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <li data-target="#myCarousel" data-slide-to="3"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox" style="max-height: inherit;">
                    <div class="item active" style="max-height: inherit; background-size: cover;">
                        <img src="Styles/images/fondo_login.png" alt="Facebook" class="img-responsive" style="background-size: cover;">
                    </div>
                    <div class="item">
                        <img src="Styles/images/fondo_login.png" alt="Geolocalisacion" class="img-responsive" style="background-size: cover;">
                    </div>
                    <div class="item">
                        <img src="Styles/images/fondo_login.png" alt="Pedir" class="img-responsive" style="background-size: cover;">
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>
</body>
</html>
