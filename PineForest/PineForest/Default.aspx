<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PineForest.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <title>Pine Forest Munnar | Home</title>

        <!-- Bootstrap core CSS -->
    <link href="bootstrap.min.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li class="active"><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>        
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>        
        <li><a class="scroll" href="booking.aspx">BOOKING</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">

    <style>
        /* use navbar-wrapper to wrap navigation bar, the purpose is to overlay navigation bar above slider */
        .navbar-wrapper {
            position: absolute;
            top: 20px;
            left: 0;
            width: 100%;
            height: 51px;
        }
        .navbar-wrapper > .container {
            padding: 0;
        }

        @media all and (max-width: 768px ){
            .navbar-wrapper {
                position: relative;
                top: 0px;
            }
        }
    </style>

    <div class="navbar-wrapper">
        <div class="container">

            <nav class="navbar navbar-inverse navbar-static-top" role="navigation" style="margin-bottom: 0px;">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <%--<a class="navbar-brand" href="http://www.jssor.com/index.html">Bootstrap Carousel</a>--%>
                    </div>
                   <%-- <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="http://www.jssor.com/index.html">Home</a></li>
                            <li><a href="http://www.jssor.com/demos/index.html">Demos</a></li>
                            <li><a href="http://www.jssor.com/skins/index.html">Skins</a></li>
                            <li><a href="http://www.jssor.com/development/index.html">Development</a></li>
                            <li><a href="http://www.jssor.com/download.html">Download</a></li>
                            <li><a href="http://www.jssor.com/support.html">Support</a></li>
                        </ul>
                    </div>--%>
                </div>
            </nav>

        </div>
    </div>

    <div style="min-height: 50px;">
    <%--<div class="banner">--%>

        <!-- Jssor Slider Begin -->
        <!-- To move inline styles to css file/block, please specify a class name for each element. --> 
        <!-- ================================================== -->
        <div id="slider1_container" style="display: none; position: relative; margin: 0 auto;
        top: 0px; left: 0px; width: 100%; height: 300; overflow: hidden;">
            <!-- Loading Screen -->
            <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block;
                top: 0px; left: 0px; width: 100%; height: 100%;">
                </div>
                <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center;
                top: 0px; left: 0px; width: 100%; height: 100%;">
                </div>
            </div>
            <!-- Slides Container -->
            <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 100%; height: 300px; overflow: hidden;">
                <div>
                    <img u="image" src2="img/1920/red.jpg" />
                </div>
                <div>
                    <img u="image" src2="img/1920/purple.jpg" />
                </div>
                <div>
                    <img u="image" src2="img/1920/blue.jpg" />
                </div>
            </div>
            
            <!--#region Bullet Navigator Skin Begin -->
            <!-- Help: http://www.jssor.com/development/slider-with-bullet-navigator-jquery.html -->
            <style>
                /* jssor slider bullet navigator skin 21 css */
                /*
                .jssorb21 div           (normal)
                .jssorb21 div:hover     (normal mouseover)
                .jssorb21 .av           (active)
                .jssorb21 .av:hover     (active mouseover)
                .jssorb21 .dn           (mousedown)
                */
                .jssorb21 {
                    position: absolute;
                }
                .jssorb21 div, .jssorb21 div:hover, .jssorb21 .av {
                    position: absolute;
                    /* size of bullet elment */
                    width: 19px;
                    height: 19px;
                    text-align: center;
                    line-height: 19px;
                    color: white;
                    font-size: 12px;
                    background: url(../img/b21.png) no-repeat;
                    overflow: hidden;
                    cursor: pointer;
                }
                .jssorb21 div { background-position: -5px -5px; }
                .jssorb21 div:hover, .jssorb21 .av:hover { background-position: -35px -5px; }
                .jssorb21 .av { background-position: -65px -5px; }
                .jssorb21 .dn, .jssorb21 .dn:hover { background-position: -95px -5px; }
            </style>
            <!-- bullet navigator container -->
            <div u="navigator" class="jssorb21" style="bottom: 26px; right: 6px;">
                <!-- bullet navigator item prototype -->
                <div u="prototype"></div>
            </div>
            <!--#endregion Bullet Navigator Skin End -->
            
            <!--#region Arrow Navigator Skin Begin -->
            <!-- Help: http://www.jssor.com/development/slider-with-arrow-navigator-jquery.html -->
            <style>
                /* jssor slider arrow navigator skin 21 css */
                /*
                .jssora21l                  (normal)
                .jssora21r                  (normal)
                .jssora21l:hover            (normal mouseover)
                .jssora21r:hover            (normal mouseover)
                .jssora21l.jssora21ldn      (mousedown)
                .jssora21r.jssora21rdn      (mousedown)
                */
                .jssora21l, .jssora21r {
                    display: block;
                    position: absolute;
                    /* size of arrow element */
                    width: 55px;
                    height: 55px;
                    cursor: pointer;
                    background: url(../img/a21.png) center center no-repeat;
                    overflow: hidden;
                }
                .jssora21l { background-position: -3px -33px; }
                .jssora21r { background-position: -63px -33px; }
                .jssora21l:hover { background-position: -123px -33px; }
                .jssora21r:hover { background-position: -183px -33px; }
                .jssora21l.jssora21ldn { background-position: -243px -33px; }
                .jssora21r.jssora21rdn { background-position: -303px -33px; }
            </style>
            <!-- Arrow Left -->
            <span u="arrowleft" class="jssora21l" style="top: 123px; left: 8px;">
            </span>
            <!-- Arrow Right -->
            <span u="arrowright" class="jssora21r" style="top: 123px; right: 8px;">
            </span>
            <!--#endregion Arrow Navigator Skin End -->
            <a style="display: none" href="http://www.jssor.com">Bootstrap Slider</a>
        </div>


       <%-- <div class="banner-info text-center">
           <%-- <h3>
                <label>Hello,</label>
                You've Reached</h3>
            <img src="images/pineforestmunnarbanner.png" alt="pine forest munnar">
            <span></span>
            <ul>
                <li><a class="scroll" href="#">HOTEL</a><i class="line"></i></li>
                <li><a class="scroll" href="#">Room Service</a><i class="line2"></i></li>
                <li><a class="scroll" href="#">FINE DINING</a></li>
                <div class="clearfix"></div>
            </ul>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" runat="server">
    <!---strat-date-piker---->
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script src="js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker,#datepicker1").datepicker();
        });
    </script>
    <!---/End-date-piker---->
    <link type="text/css" rel="stylesheet" href="css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="css/JFFormStyle-1.css" />
    <script type="text/javascript" src="js/JFCore.js"></script>
    <script type="text/javascript" src="js/JFForms.js"></script>
    <!-- Set here the key for your domain in order to hide the watermark on the web server -->
    <script type="text/javascript">
        (function () {
            JC.init({
                domainKey: ''
            });
        })();
    </script>
    <div class="online_reservation">
        <div class="b_room">
            <div class="booking_room">
                <div class="reservation">
                    <ul>
                        <li class="span1_of_1 left">
                            <h5>Arrival</h5>
                            <div class="book_date">
                                <form>
                                    <input class="date" id="datepicker" type="text" value="2/08/2013" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '2/08/2013';}">
                                </form>
                            </div>
                        </li>
                        <li class="span1_of_1 left">
                            <h5>Depature</h5>
                            <div class="book_date">
                                <form>
                                    <input class="date" id="datepicker1" type="text" value="22/08/2013" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '22/08/2013';}">
                                </form>
                            </div>
                        </li>
                        <li class="span1_of_1">
                            <h5>Room type</h5>
                            <!----------start section_room----------->
                            <div class="section_room">
                                <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                    <option value="STD">Standard Double Bed Room</option>
                                    <option value="SUP">Superior Double Bed Room</option>
                                    <option value="FAM">Family Room</option>
                                    <option value="Honey">Honeymoon Cottage</option>
                                </select>
                            </div>
                        </li>
                        <li class="span1_of_3">
                            <div class="date_btn">
                                <form>
                                    <input type="submit" value="View Prices" />
                                </form>
                            </div>
                        </li>
                        <div class="clearfix"></div>
                    </ul>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    
    <!---->
    <div class="package text-center">
        <div class="container">
            <h3>Book A Package</h3>
            <p>For all the guest we will provide free wifi, neat and clean atmosphere.</p>
            <!-- requried-jsfiles-for owl -->
            <link href="css/owl.carousel.css" rel="stylesheet">
            <script src="js/owl.carousel.js"></script>
            <script>
                $(document).ready(function () {
                    $("#owl-demo").owlCarousel({
                        items: 1,
                        lazyLoad: true,
                        autoPlay: true,
                        navigation: true,
                        navigationText: false,
                        pagination: false,
                    });
                });
            </script>
            <!-- //requried-jsfiles-for owl -->
            <div id="owl-demo" class="owl-carousel">
                <div class="item text-center image-grid">
                    <ul>
                        <li>
                            <img src="images/1.jpg" alt=""></li>
                        <li>
                            <img src="images/2.jpg" alt=""></li>
                        <li>
                            <img src="images/3.jpg" alt=""></li>
                    </ul>
                </div>
                <div class="item text-center image-grid">
                    <ul>
                        <li>
                            <img src="images/3.jpg" alt=""></li>
                        <li>
                            <img src="images/4.jpg" alt=""></li>
                        <li>
                            <img src="images/5.jpg" alt=""></li>
                    </ul>
                </div>
                <div class="item text-center image-grid">
                    <ul>
                        <li>
                            <img src="images/6.jpg" alt=""></li>
                        <li>
                            <img src="images/2.jpg" alt=""></li>
                        <li>
                            <img src="images/4.jpg" alt=""></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!---->
    <div class="rooms text-center">
        <div class="container">
            <h3>Our Room Types</h3>
            <div class="room-grids">
                <div class="col-md-4 room-sec">
                    <img src="images/Economy.jpg" alt="" />
                    <h4>Standard Double Bed Room</h4>
                    <div class="items">
                        <li><a href="#"><span class="img1"></span></a></li>
                        <li><a href="#"><span class="img2"></span></a></li>
                        <li><a href="#"><span class="img3"></span></a></li>
                        <li><a href="#"><span class="img4"></span></a></li>
                        <li><a href="#"><span class="img5"></span></a></li>
                        <li><a href="#"><span class="img6"></span></a></li>
                    </div>
                </div>
                <div class="col-md-4 room-sec">
                    <img src="images/Deluxe.jpg" alt="" />
                    <h4>Superior Double Bed Room</h4>
                    <div class="items">
                        <li><a href="#"><span class="img1"></span></a></li>
                        <li><a href="#"><span class="img2"></span></a></li>
                        <li><a href="#"><span class="img3"></span></a></li>
                        <li><a href="#"><span class="img4"></span></a></li>
                        <li><a href="#"><span class="img5"></span></a></li>
                        <li><a href="#"><span class="img6"></span></a></li>
                    </div>
                </div>
                <div class="col-md-4 room-sec">
                    <img src="images/FamilyRoom.jpg" alt="" />
                    <h4>Family Room</h4>
                    <div class="items">
                        <li><a href="#"><span class="img1"></span></a></li>
                        <li><a href="#"><span class="img2"></span></a></li>
                        <li><a href="#"><span class="img3"></span></a></li>
                        <li><a href="#"><span class="img4"></span></a></li>
                        <li><a href="#"><span class="img5"></span></a></li>
                        <li><a href="#"><span class="img6"></span></a></li>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <div>
                <%--<img src="images/PricingTab.png" alt="" />--%>
            </div>
        </div>
    </div>


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery-1.9.1.min.js"></script>
    <script src="bootstrap.min.js"></script>
    <script src="docs.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="ie10-viewport-bug-workaround.js"></script>

    <!-- jssor slider scripts-->
    <!-- use jssor.js + jssor.slider.js instead for development -->
    <!-- jssor.slider.mini.js = (jssor.js + jssor.slider.js) -->
    <script type="text/javascript" src="js/jssor.slider.mini.js"></script>
    <script>
        jQuery(document).ready(function ($) {

            var options = {
                $FillMode: 2,                                       //[Optional] The way to fill image in slide, 0 stretch, 1 contain (keep aspect ratio and put all inside slide), 2 cover (keep aspect ratio and cover whole slide), 4 actual size, 5 contain for large image, actual size for small image, default value is 0
                $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                $AutoPlayInterval: 4000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                $PauseOnHover: 1,                                   //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                $SlideEasing: $JssorEasing$.$EaseOutQuint,          //[Optional] Specifies easing for right to left animation, default value is $JssorEasing$.$EaseOutQuad
                $SlideDuration: 800,                               //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                //$SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                //$SlideHeight: 300,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                $DisplayPieces: 1,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                $ParkingPosition: 0,                                //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)

                $BulletNavigatorOptions: {                          //[Optional] Options to specify and enable navigator or not
                    $Class: $JssorBulletNavigator$,                 //[Required] Class to create navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 1,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $Lanes: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                    $SpacingX: 8,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                    $SpacingY: 8,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                    $Orientation: 1,                                //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                    $Scale: false                                   //Scales bullets navigator or not while slider scale
                },

                $ArrowNavigatorOptions: {                           //[Optional] Options to specify and enable arrow navigator or not
                    $Class: $JssorArrowNavigator$,                  //[Requried] Class to create arrow navigator instance
                    $ChanceToShow: 1,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 2,                                 //[Optional] Auto center arrows in parent container, 0 No, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1                                       //[Optional] Steps to go for each navigation request, default value is 1
                }
            };

            //Make the element 'slider1_container' visible before initialize jssor slider.
            $("#slider1_container").css("display", "block");
            var jssor_slider1 = new $JssorSlider$("slider1_container", options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizes
            function ScaleSlider() {
                var bodyWidth = document.body.clientWidth;
                if (bodyWidth)
                    jssor_slider1.$ScaleWidth(Math.min(bodyWidth, 1920));
                else
                    window.setTimeout(ScaleSlider, 30);
            }
            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    </script>

</asp:Content>
