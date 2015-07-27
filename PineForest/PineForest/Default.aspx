<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PineForest.Default" %>

<%@ Register TagPrefix="uc" TagName="banner" Src="~/UserControl/banner.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Home</title>
    <link href="../css/owl.carousel.css" rel="stylesheet">
    <script src="../js/owl.carousel.js"></script>
    <!-- requried-jsfiles-for owl -->
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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li class="active"><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
        <li><a class="scroll" href="pinelogin.aspx">LOGIN</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <uc:banner ID="banner1" runat="server" MinValue="1" MaxValue="10" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" runat="server">
    <!---strat-date-piker---->
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <script src="../js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker,#datepicker1").datepicker();
        });
    </script>
    <!---/End-date-piker---->
    <link type="text/css" rel="stylesheet" href="../css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="../css/JFFormStyle-1.css" />
    <script type="text/javascript" src="../js/JFCore.js"></script>
    <script type="text/javascript" src="../js/JFForms.js"></script>
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

    <br />
    <br />
    <br />

    <div class="rooms text-center">
        <div class="container">
            <h3>Our Room Types</h3>
            <div class="room-grids">
                <div class="col-md-4 room-sec">
                    <img src="roomimages/Room1.jpg" alt="" />
                    <h4>Room Type One</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
                    <img src="roomimages/Room2.jpg" alt="" />
                    <h4>Room Type Two</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
                    <img src="roomimages/Room3.jpg" alt="" />
                    <h4>Room Type Three</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
                <div class="col-md-4 room-sec">
                    <img src="roomimages/Room4.jpg" alt="" />
                    <h4>Room Type Four</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
                    <img src="roomimages/Room5.jpg" alt="" />
                    <h4>Room Type Five</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
                    <img src="roomimages/Room6.jpg" alt="" />
                    <h4>Room Type Six</h4>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
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
