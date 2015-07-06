<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PineForest.Default" %>

<%@ Register TagPrefix="uc" TagName="banner" Src="~/UserControl/banner.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Home</title>
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
    <uc:banner ID="banner1" runat="server" MinValue="1" MaxValue="10" />
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
                            <h5>From Date</h5>
                            <div class="book_date">

                                <input id="datepicker" type="text" value="2/08/2015" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '2/08/2015';}" />

                            </div>
                        </li>
                        <li class="span1_of_1 left">
                            <h5>To Date
                            </h5>
                            <div class="book_date">

                                <input class="date" id="datepicker1" type="text" value="12/08/2015" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '12/08/2015';}" />

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
                                <asp:Button ID="btnSubmit" Text="View Available" runat="server" OnClick="btnSubmit_Click" />                          
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
</asp:Content>
