﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PineForest.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Home</title>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li class="active"><a class="scroll" href="Default.aspx">Home</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>        
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>        
        <li><a class="scroll" href="booking.aspx">BOOKING</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <div class="banner">
        <div class="banner-info text-center">
            <h3>
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
        </div>
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
                                    <option value="Economy">Economy room</option>
                                    <option value="Deluxe">Deluxe room</option>
                                    <option value="SuperDeluxe">Super Deluxe room</option>
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
                    <h4>Economy Room</h4>
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
                    <h4>Deluxe Room</h4>
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
                    <h4>Super Deluxe Room</h4>
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
                <img src="images/PricingTab.png" alt="" />
            </div>
        </div>
    </div>
</asp:Content>