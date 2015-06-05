<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="PineForest.Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Gallery</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">Home</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li class="active"><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li><a class="scroll" href="booking.aspx">BOOKING</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">

    <div class="main_bg">
        <div class="container">
            <center><img src="images/under_constr.jpg" /></center>
        </div>
    </div>
</asp:Content>
