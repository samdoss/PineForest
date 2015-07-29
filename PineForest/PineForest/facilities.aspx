<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="facilities.aspx.cs" Inherits="PineForest.facilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Facilities</title>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">HOME</a></li>
        <li class="active"><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
        <li><a class="scroll" href="pinelogin.aspx">LOGIN</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" runat="server">
    <!---->
    <div class="main_bg">
        <div class="container">
            <div class="main">
                <ul class="service_list">
                    <li>
                    <div class="ser_img">
                        <a href="#">
                            <img src="images/ser_pic1.jpg" alt="" />
                            <span class="next"></span>
                        </a>
                    </div>
                    <a href="#">
                        <h3>Facilities / Services</h3>
                    </a>
                    <p class="para">
                        Home cooked traditional Cuisine<br>
                        Cable TV<br>
                        24 Hrs Hot water<br>
                        Veg. and Non veg. Cuisine<br>
                        Car parking area<br>
                        Rent a Car<br>
                        Ayurvedic Treatment<br>
                        Houseboat arrangment<br>
                    </p>
                    </li>
                    <li>
                        <div class="ser_img">
                            <a href="#">
                                <img src="images/ser_pic7.jpg" alt="" />
                                <span class="next"></span>
                            </a>
                        </div>
                        <a href="#">
                            <h3>BreakFast</h3>
                        </a>
                        <p class="para">  Quality Veg/Non veg breakfast will be provided. If there is any special requirement based on your taste preference, please inform us well in advance so that we can arrange that too.</p>
                    </li>
                    <div class="clear"></div>
                </ul>
                <div class="clear"></div>
            </div>
        </div>

        <div class="container">
            <div class="main">

                <h3>Other Services</h3>
                <p class="para">
                    We can arrange a tour package. Pick up from nearest railway station or airport. For 3 days to stay and local sight seeing, break fast (@ Deluxe room etc. @Rs. 13,000 Per couple).
                </p>
                <p class="para">
                    We can arrange for Honey Moon Couples for at Rs.15,000 Stay at Super Deluxe. (Free Cake, Flower Decoration, etc..)
                </p>
                <p class="para">
                    Private cars we will arrange with drivers for Sight Seeing upto 400 km.
                </p>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
