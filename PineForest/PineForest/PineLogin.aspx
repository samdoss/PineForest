﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="PineLogin.aspx.cs" Inherits="PineForest.PineLogin" %>

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
    <div class="contact-bg2">
        <div class="container">
            <div class="booking">
                <h3>Login</h3>
                <div class="col-md-8 booking-form" style="text-align: center;">
                    <table border="0" style="width: 100%; margin-left: 200px; height: 300px; max-height: 300px; min-height: 200px;">
                        <tr>
                            <td style="width: 250px">
                                <asp:Label ID="lblLogin" Text="Email id / Mobile No:" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLogin" Width="400px" runat="server"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Button ID="btnNewUser" Text="New User" runat="server" OnClick="btnNewUser_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSubmit" Text="Login" runat="server" OnClick="btnSubmit_Click" />
                            </td>

                        </tr>
                    </table>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
