<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="PineLogin.aspx.cs" Inherits="PineForest.PineLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Booking</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
        <li class="active"><a class="scroll" href="PineLogin.aspx">LOGIN</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">

    <div class="contact-bg2">
        <div class="container">
            <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0" EnableViewState="true" ViewStateMode="Enabled" Visible="true">
                <asp:View ID="view1" runat="server">
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
                                    <td>                                        
                                        <asp:HiddenField ID="hfIpAddress" runat="server" />
                                        <asp:HiddenField ID="hfGeoLocation" runat="server" />
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnNewUser" Text="New User" runat="server" OnClick="btnNewUser_Click" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnSubmit" Text="Login" runat="server" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>


                </asp:View>
                <asp:View ID="view2" runat="server">
                    <div class="booking">
                        <h3>New User</h3>
                        <div class="col-md-8 booking-form" style="text-align: center;">
                            <table border="0" style="width: 100%; margin-left: 200px; height: 300px; max-height: 300px; min-height: 200px;">
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="lblEmailIDorMobileNo" Text="Email id / Mobile No:" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmailIDorMobileNo" Width="400px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnCreate" Text="Create Account" runat="server" OnClick="btnCreate_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="view3" runat="server">
                    <div class="booking">
                        <h3>Account Verification</h3>
                        <div class="col-md-8 booking-form" style="text-align: center;">
                            <table border="0" style="width: 100%; margin-left: 200px; height: 300px; max-height: 300px; min-height: 200px;">
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="lblAuthenticationCode" Text="Authentication Code:" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAuthenticationCode" Width="400px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnAuthenticationCode" Text="Create Account" runat="server" OnClick="btnAuthenticationCode_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
