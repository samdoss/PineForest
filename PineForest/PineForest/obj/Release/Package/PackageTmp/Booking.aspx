<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="PineForest.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Booking</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li class="active"><a class="scroll" href="booking.aspx">BOOKING</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">
    <!---strat-date-piker---->
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script src="js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#cpContent_datepicker,#cpContent_datepicker1").datepicker();
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
    <div class="contact-bg2">
        <div class="container">
            <div class="booking">
                <h3>Booking</h3>
                <div class="col-md-8 booking-form">
                    <h5>NAME</h5>
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                    <h5>E-MAIL</h5>
                    <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                    <h5>PHONE</h5>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                    <h5>TIME</h5>
                    <asp:TextBox ID="txtTime" class="time" CssClass="time" runat="server"></asp:TextBox>
                    <h5>CHECK IN</h5>
                    <div class="book_date">
                        <input class="date" runat="server" id="datepicker" type="text" value="2/08/2013" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '2/08/2013';}" />
                    </div>
                    <h5>CHECK OUT</h5>
                    <div class="book_date">
                        <input class="date" runat="server" id="datepicker1" type="text" value="12/08/2015" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '12/08/2015';}" />
                    </div>
                    <h5 class="mem">MEMBERS</h5>
                    <input min="1" type="number" id="quantity" name="quantity" value="1" class="form-control input-small">
                    <h5>REQUIRED</h5>
                    <textarea value=""></textarea>
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" Text="Reset" runat="server" />
                </div>
                <div class="col-md-4 booking-news">
                    <%--<h4>Latest News</h4>			
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>			
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	
					<div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	--%>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
