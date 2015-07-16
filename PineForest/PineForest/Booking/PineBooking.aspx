<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="PineBooking.aspx.cs" Inherits="PineForest.PineBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Booking</title>
    <link type="text/css" rel="stylesheet" href="../css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="../css/JFFormStyle-1.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <ul>
            <li class="active"><a class="scroll" href="../Booking/PineBooking.aspx">BOOKING</a></li>
            <li><a class="scroll" href="../Booking/BookingHistory.aspx">TRANSACTIONS</a></li>
            <li><a class="scroll" href="../Booking/logout.aspx">LOGOUT</a></li>
        </ul>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">

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
            </div>
        </div>
    </div>


</asp:Content>
