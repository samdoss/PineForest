<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="PineLogin.aspx.cs" Inherits="PineForest.PineLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Login</title>
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
                                        <asp:TextBox ID="txtLogin" MaxLength="300" Width="400px" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="ftbeLogin" runat="server" TargetControlID="txtLogin"
                                            FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                            Enabled="True" />
                                        <cc1:ValidatorCalloutExtender ID="vceLogin" runat="server" TargetControlID="rfvLogin"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfIpAddress" runat="server" />
                                        <asp:HiddenField ID="hfGeoLocation" runat="server" />
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnSubmit" Text="Login" runat="server" ValidationGroup="ValidateLogin" CausesValidation="true" OnClick="btnSubmit_Click" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnNewUser" Text="New User" runat="server" OnClick="btnNewUser_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label Style="color: red; font-size: small;" ID="lblLoginMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: left">
                                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ValidationGroup="ValidateLogin"
                                            ControlToValidate="txtLogin" Display="None" ErrorMessage="Please Enter the EmailID/MobileNo" SetFocusOnError="True">
                                            <%--<li style="list-style-type: circle">
                                                <asp:Label ID="lblLoginValidation" runat="server" ForeColor="red" Text="Please Enter the EmailID/MobileNo"></asp:Label></li>--%>
                                        </asp:RequiredFieldValidator>
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
                                        <cc1:FilteredTextBoxExtender ID="fteEmailIDorMobileNo" runat="server" TargetControlID="txtEmailIDorMobileNo"
                                            FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                            Enabled="True" />
                                        <cc1:ValidatorCalloutExtender ID="vceEmailIDorMobileNo" runat="server" TargetControlID="rfvEmailIDorMobileNo"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnCreate" Text="Create Account" runat="server" ValidationGroup="ValidateEmailIDorMobileNo" CausesValidation="true" OnClick="btnCreate_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label Style="color: red; font-size: small;" ID="lblNewUserMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: left">
                                        <asp:RequiredFieldValidator ID="rfvEmailIDorMobileNo" runat="server" ValidationGroup="ValidateEmailIDorMobileNo"
                                            ControlToValidate="txtEmailIDorMobileNo" Display="None" ErrorMessage="Please Enter the EmailID/MobileNo" SetFocusOnError="True">
                                            <%--<li style="list-style-type: circle">
                                                <asp:Label ID="lblLoginValidation" runat="server" ForeColor="red" Text="Please Enter the EmailID/MobileNo"></asp:Label></li>--%>
                                        </asp:RequiredFieldValidator>
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
                                        <asp:HiddenField ID="hfLoginID" runat="server" Visible="false" Value="0" />
                                        <asp:Label ID="lblAuthenticationCode" Text="Authentication Code:" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAuthenticationCode" Width="400px" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="fteAuthenticationCode" runat="server" TargetControlID="txtAuthenticationCode"
                                            FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                            Enabled="True" />
                                        <cc1:ValidatorCalloutExtender ID="vceAuthenticationCode" runat="server" TargetControlID="rfvAuthenticationCode"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:Button ID="btnAuthenticationCode" Text="Authentication Code" runat="server" OnClick="btnAuthenticationCode_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <p style="color: red; font-size: small;">you will receive mail or sms to enter the authentication code.</p>
                                        <asp:Label ID="lblShowAuthenticationMsg" style="color: red; font-size: small;" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: left">
                                        <asp:RequiredFieldValidator ID="rfvAuthenticationCode" runat="server" ValidationGroup="ValidateAuthenticationCode"
                                            ControlToValidate="txtAuthenticationCode" Display="None" ErrorMessage="Please Enter the Authentication Code" SetFocusOnError="True">                                           
                                        </asp:RequiredFieldValidator>
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
