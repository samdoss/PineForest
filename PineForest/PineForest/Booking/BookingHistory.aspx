<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="BookingHistory.aspx.cs" Inherits="PineForest.BookingHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
     <title>Pine Forest Munnar | Booking History</title>
    <link type="text/css" rel="stylesheet" href="../css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="../css/JFFormStyle-1.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
     <ul>
        <ul>
            <li><a class="scroll" href="../Booking/PineBooking.aspx">BOOKING</a></li>
            <li class="active"><a class="scroll" href="../Booking/BookingHistory.aspx">TRANSACTIONS</a></li>
            <li><a class="scroll" href="../Booking/logout.aspx">LOGOUT</a></li>
        </ul>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">
</asp:Content>
