<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PineForest.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Contact US</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li class="active"><a class="scroll" href="contact.aspx">CONTACT US</a></li>
        <li><a class="scroll" href="pinelogin.aspx">LOGIN</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">
    <!---->
    <div class="contact-bg">
        <div class="container">
            <div class="contact-us">
                <div class="contact-us_left">
                    <div class="contact-us_info">
                        <h3 class="style">Find Us Here</h3>
                        <div class="map">
                            <small>
                                <a href='https://goo.gl/maps/0wtOV' target='b'>
                                    <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d62852.41895442583!2d77.0926512!3d10.0764413!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3b070a69e121de61%3A0xe0b369073211c416!2sMunnar-Kumily+Hwy%2C+Devikulam%2C+Kerala+685613!5e0!3m2!1sen!2sin!4v1430188874372" width="400" height="300" frameborder="0" style="border: 0"></iframe>
                                    View Larger Map</a></small>
                        </div>
                    </div>
                    <div class="company_address">
                        <h3 class="style">Hotel Information :</h3>
                        <p>Pine Forest Residence,</p>
                        <p>Munnar - Kumily Road, Devikulam</p>
                        <p>Postal Code : 685 613</p>
                        <p>India</p>
                        <p>Phone 1:(+91) 949 573 0984</p>
                        <p>Phone 2:(+91) 944 732 5677</p>
                        <p>Email: <a href="mailto:info@PineForestMunnar.com">info@PineForestMunnar.com</a></p>
                        <p>Follow on: <a href="https://www.facebook.com/profile.php?id=100009440173669">Facebook</a>, <a href="#">Twitter</a></p>
                    </div>
                </div>
                <div class="contact_right">
                    <div class="contact-form">
                        <h3 class="style">Contact Us</h3>

                        <div>
                            <span>
                                <label>NAME</label></span>
                            <span>
                                <asp:TextBox ID="txtName" CssClass="textbox" MaxLength="100" runat="server" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ValidationGroup="ContactUsValid"
                                    ControlToValidate="txtName" Display="None" ErrorMessage="Please Enter the Name" SetFocusOnError="True">                                            
                                </asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="ftbeName" runat="server" TargetControlID="txtName"
                                    FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                    Enabled="True" />
                                <cc1:ValidatorCalloutExtender ID="vceName" runat="server" Width="20px" TargetControlID="rfvName"></cc1:ValidatorCalloutExtender>

                            </span>
                        </div>
                        <div>
                            <span>
                                <label>E-MAIL</label></span>
                            <span>
                                <asp:TextBox ID="txtEmailID" CssClass="textbox" MaxLength="150" runat="server" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ValidationGroup="ContactUsValid"
                                    ControlToValidate="txtEmailID" Display="None" ErrorMessage="Please Enter the EmailID" SetFocusOnError="True">                                            
                                </asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="freEmailID" runat="server" TargetControlID="txtEmailID"
                                    FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                    Enabled="True" />
                                <cc1:ValidatorCalloutExtender ID="vceEmailID" Width="20px" runat="server" TargetControlID="rfvEmailID"></cc1:ValidatorCalloutExtender>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>MOBILE</label></span>
                            <span>
                                <asp:TextBox ID="txtUserPhoneNumber" MaxLength="50" CssClass="textbox" runat="server" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUserPhoneNumber" runat="server" ValidationGroup="ContactUsValid"
                                    ControlToValidate="txtUserPhoneNumber" Display="None" ErrorMessage="Please Enter the Phone Number" SetFocusOnError="True">                                            
                                </asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="fteUserPhoneNumber" runat="server" TargetControlID="txtUserPhoneNumber"
                                    FilterType="Custom" ValidChars="1234567890+"
                                    Enabled="True" />
                                <cc1:ValidatorCalloutExtender ID="vceUserPhoneNumber" runat="server" TargetControlID="rfvUserPhoneNumber"></cc1:ValidatorCalloutExtender>

                            </span>
                        </div>
                        <div>
                            <span>
                                <label>COMMENT / MESSAGE</label></span>
                            <span>
                                <asp:TextBox ID="txtComment" Rows="4" MaxLength="500" TextMode="MultiLine" CssClass="textbox" runat="server" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvComment" runat="server" ValidationGroup="ContactUsValid"
                                    ControlToValidate="txtComment" Display="None" ErrorMessage="Please Enter the Comment" SetFocusOnError="True">                                            
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="vceComment" runat="server" TargetControlID="rfvComment"></cc1:ValidatorCalloutExtender>
                            </span>
                        </div>
                        <div>
                            <asp:Button ID="btnSubmit" Text="Submit us" ValidationGroup="ContactUsValid" runat="server" OnClick="btnSubmit_Click" />                            
                        </div>
                        <div>
                            <asp:Label ID="lblMessagebox" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <!---->
</asp:Content>
