<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="PineBooking.aspx.cs" Inherits="PineForest.PineBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <asp:HiddenField ID="hfLoginID" runat="server" Value="" />
    <asp:HiddenField ID="hfEmailID" runat="server" Value="" />
    <asp:HiddenField ID="hfMobileNo" runat="server" Value="" />
    <div class="contact-bg2">
        <div class="container">
            <div class="booking">
                <h3>Booking</h3>
                <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0" EnableViewState="true" ViewStateMode="Enabled" Visible="true">
                    <asp:View ID="view1" runat="server">
                        <div class="col-xs-12 booking-form">
                            <table border="0" style="border: medium; height: 30px; border-collapse: separate; border-spacing: 10px;">
                                <tr>
                                    <td colspan="7">
                                        <asp:Label ID="lblMsgValidation" runat="server" ForeColor="red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h5>Check-In</h5>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCheckInDate" Width="110px" CssClass="textarea" autocomplete="off" MaxLength="12"
                                            runat="server" TabIndex="11"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCheckInDate" runat="server" ValidationGroup="ValidateRoomBooking"
                                            ControlToValidate="txtCheckInDate" Display="none" ErrorMessage="Please Enter the Check-In Date"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:Panel ID="pnlCheckInDate" runat="server" CssClass="popupCalendarControl">
                                            <center>
                                        <cc1:CalendarExtender ID="ceCheckInDate" CssClass="MyCalendar" OnClientDateSelectionChanged="function(sender, e) {sender.hide();}"
                                            runat="server" TargetControlID="txtCheckInDate" />
                                    </center>
                                        </asp:Panel>
                                        <cc1:PopupControlExtender ID="pceCheckInDate" runat="server" TargetControlID="txtCheckInDate" PopupControlID="pnlCheckInDate"
                                            Position="Bottom" />
                                        <cc1:MaskedEditExtender ID="meeCheckInDate" runat="server" TargetControlID="txtCheckInDate" Mask="99/99/9999"
                                            MessageValidatorTip="true" CultureName="en-US" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                            ErrorTooltipEnabled="True" />
                                    </td>
                                    <td>
                                        <h5>Check-Out</h5>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCheckOutDate" Width="110px" CssClass="textarea" autocomplete="off" MaxLength="12"
                                            runat="server" TabIndex="11"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCheckOutDate" runat="server" ValidationGroup="ValidateRoomBooking"
                                            ControlToValidate="txtCheckOutDate" Display="none" ErrorMessage="Please Enter the Check-Out Date"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:Panel ID="pnlCheckOutDate" runat="server" CssClass="popupCalendarControl">
                                            <center>
                                        <cc1:CalendarExtender ID="ceCheckOutDate" CssClass="MyCalendar" OnClientDateSelectionChanged="function(sender, e) {sender.hide();}"
                                            runat="server" TargetControlID="txtCheckOutDate" />
                                    </center>
                                        </asp:Panel>
                                        <cc1:PopupControlExtender ID="pceCheckOutDate" runat="server" TargetControlID="txtCheckOutDate" PopupControlID="pnlCheckOutDate"
                                            Position="Bottom" />
                                        <cc1:MaskedEditExtender ID="meeCheckOutDate" runat="server" TargetControlID="txtCheckOutDate" Mask="99/99/9999"
                                            MessageValidatorTip="true" CultureName="en-US" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                            ErrorTooltipEnabled="True" />
                                    </td>
                                    <td>
                                        <h5>Room Type</h5>
                                    </td>
                                    <td style="vertical-align: middle;">
                                        <asp:DropDownList ID="ddlRoomType" AppendDataBoundItems="True" Width="300px" CssClass="Dropdownlist"
                                            runat="server" TabIndex="3">
                                            <asp:ListItem Value="">-- Select One --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvRoomType" runat="server" ValidationGroup="ValidateRoomBooking"
                                            ControlToValidate="ddlRoomType" Display="none" ErrorMessage="Please Select Room Type"
                                            SetFocusOnError="True">                                          
                                        </asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="vceRoomType" runat="server" TargetControlID="rfvRoomType"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td style="vertical-align: middle;">
                                        <asp:Button ID="btnSubmit" Text="Search" TabIndex="4" runat="server" ValidationGroup="ValidateRoomBooking" CausesValidation="true" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                            <table id="tblAvailableRooms" runat="server" border="0" style="border: medium; height: 30px; border-collapse: separate; border-spacing: 10px;">
                                <tr>
                                    <td style="min-width: 400px;">
                                        <asp:Image ID="imgRoomType" runat="server" Height="300px" Width="400px" ImageUrl="~/images/Economy.jpg" />
                                    </td>
                                    <td style="min-width: 50px;">&nbsp;
                                    </td>
                                    <td style="vertical-align: top;">
                                        <br />
                                        <h4><b>Available Rooms :</b>
                                            <asp:Label ID="lblAvailableRooms" runat="server" Text=""></asp:Label></h4>
                                        <br />
                                        <br />
                                        <h4><b>Price Per Day Rs. :</b>
                                            <asp:Label ID="lblPerRoomPrice" runat="server" Text=""></asp:Label></h4>
                                        <br />
                                        <br />
                                        <h4><b>No of Rooms :</b></h4>
                                        <asp:DropDownList ID="ddlRoomsCount" AppendDataBoundItems="True" Width="300px" CssClass="Dropdownlist"
                                            runat="server" TabIndex="3">
                                            <asp:ListItem Value="">-- Select One --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvRoomsCount" runat="server" ValidationGroup="ValidateRoomBooking2"
                                            ControlToValidate="ddlRoomsCount" Display="none" ErrorMessage="Please Select Rooms Count"
                                            SetFocusOnError="True">                                          
                                        </asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="vceRoomCount" runat="server" TargetControlID="rfvRoomsCount"></cc1:ValidatorCalloutExtender>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnContinueBooking" Text="Continue ..." TabIndex="4" runat="server" ValidationGroup="ValidateRoomBooking2" CausesValidation="true" OnClick="btnContinueBooking_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: right;">&nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </asp:View>
                    <asp:View ID="view2" runat="server">
                        <div class="col-xs-12 booking-form">
                            <table border="0" style="border: medium; height: 30px; border-collapse: separate; border-spacing: 10px;">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:GridView ID="gvBookingRooms" Width="100%" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="alt" BorderStyle="None"
                                            OnRowDataBound="gvBookingRooms_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="RoomID" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <table style="background-color: white; text-align: left; vertical-align: top; min-width: 700px">
                                                            <tr style="background-color: palegreen; text-align: left; vertical-align: middle; height: 50px;">
                                                                <td>
                                                                    <h4>&nbsp;&nbsp;Room&nbsp;<asp:Label ID="lblRoomCountData" runat="server" Text=""></asp:Label>&nbsp;Guest</h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="col-xs-12 booking-form">
                                                                        <table border="0" style="border: medium; height: 30px; border-collapse: separate; border-spacing: 10px;">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblBookingName" runat="server" Text="Booking Name"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="txtBookingName" Style="background-color: #f5f6b9" TabIndex="1" runat="server"></asp:TextBox>
                                                                                    <cc1:TextBoxWatermarkExtender ID="tbweBookingName" runat="server" Enabled="true" TargetControlID="txtBookingName" WatermarkText="*"></cc1:TextBoxWatermarkExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCheckInTime" runat="server" Text="Check In Time"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCheckInTime" TabIndex="2" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblCheckoutTime" runat="server" Text="Check Out Time"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCheckOutTime" TabIndex="3" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNoofAdults" runat="server" Text="No of Adults"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlNoofAdults" AppendDataBoundItems="True" Width="70px" CssClass="Dropdownlist"
                                                                                        runat="server" TabIndex="4">
                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblNoofChildrens" runat="server" Text="No of Childrens"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlNoofChildrens" AppendDataBoundItems="True" Width="70" CssClass="Dropdownlist"
                                                                                        runat="server" TabIndex="5">
                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblProofVerification" runat="server" Text="ID Proof"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="txtProofVerification" Style="background-color: #f5f6b9;" TabIndex="6" runat="server"></asp:TextBox>
                                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="true" TargetControlID="txtProofVerification" WatermarkText="* Mandatory"></cc1:TextBoxWatermarkExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblEmailID" runat="server" Text="Email ID"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="txtEmailID" Style="background-color: #f5f6b9;" TabIndex="6" runat="server"></asp:TextBox>
                                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="true" TargetControlID="txtEmailID" WatermarkText="* Mandatory"></cc1:TextBoxWatermarkExtender>
                                                                                    <cc1:FilteredTextBoxExtender ID="ftbetxtEmailID" runat="server" TargetControlID="txtEmailID"
                                                                                        FilterType="Custom" ValidChars="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_.@"
                                                                                        Enabled="True" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="txtPhoneNumber" Style="background-color: #f5f6b9;" MaxLength="10" TabIndex="6" runat="server"></asp:TextBox>
                                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="true" TargetControlID="txtPhoneNumber" WatermarkText="* Mandatory"></cc1:TextBoxWatermarkExtender>
                                                                                    <cc1:FilteredTextBoxExtender ID="ftbetxtPhoneNumber" runat="server" TargetControlID="txtPhoneNumber"
                                                                                        FilterType="Custom" ValidChars="1234567890"
                                                                                        Enabled="True" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td style="vertical-align: top; margin-top: 10px;">
                                        <table border="0" style="min-width: 300px; margin-top: 10px;">
                                            <tr style="background-color: hotpink; text-align: left; vertical-align: middle; height: 50px;">
                                                <td>
                                                    <h4><b>
                                                        <center>Booking Summary</center>
                                                    </b></h4>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table border="0" style="min-width: 300px;">
                                            <tr style="background-color: hotpink; text-align: left; vertical-align: middle; height: 50px;">
                                                <td colspan="2">
                                                    <h4><b>Fare Details</b></h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h5>&nbsp;&nbsp;Per room per night &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h5>
                                                </td>
                                                <td>
                                                    <img alt="Indian Rupee symbol.svg" src="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/10px-Indian_Rupee_symbol.svg.png" width="10" height="15" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/15px-Indian_Rupee_symbol.svg.png 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/20px-Indian_Rupee_symbol.svg.png 2x" data-file-width="512" data-file-height="754" />
                                                    <asp:Label ID="lblPerRoomPerNightAmount" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h5>&nbsp;&nbsp;<asp:Label ID="lblRoomsandNights" runat="server" Text="1 Room x 1 Night"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h5>
                                                </td>
                                                <td>
                                                    <img alt="Indian Rupee symbol.svg" src="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/10px-Indian_Rupee_symbol.svg.png" width="10" height="15" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/15px-Indian_Rupee_symbol.svg.png 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/20px-Indian_Rupee_symbol.svg.png 2x" data-file-width="512" data-file-height="754" />
                                                    <asp:Label ID="lblRoomsandNightsAmount" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h5>&nbsp;&nbsp;
                                                        <asp:Label ID="lblFeesandTaxes" runat="server" Text="Fees & Taxes(14 %)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h5>
                                                </td>
                                                <td>
                                                    <img alt="Indian Rupee symbol.svg" src="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/10px-Indian_Rupee_symbol.svg.png" width="10" height="15" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/15px-Indian_Rupee_symbol.svg.png 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/20px-Indian_Rupee_symbol.svg.png 2x" data-file-width="512" data-file-height="754" />
                                                    <asp:Label ID="lblFeesandTaxesAmount" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: silver; text-align: right; vertical-align: middle; height: 60px;">
                                                <td colspan="2">
                                                    <h4><b>You Pay &nbsp;&nbsp;
                                                        <img alt="Indian Rupee symbol.svg" src="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/10px-Indian_Rupee_symbol.svg.png" width="10" height="15" srcset="//upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/15px-Indian_Rupee_symbol.svg.png 1.5x, //upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Indian_Rupee_symbol.svg/20px-Indian_Rupee_symbol.svg.png 2x" data-file-width="512" data-file-height="754" /></b>
                                                        <asp:Label ID="lblTotalAmountUPay" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </h4>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="view3" runat="server">
                        <div class="col-xs-12 booking-form">
                            <h4>Thank you for booking in PineForestMunnar.com. You will receive a mail confirmation.</h4>
                        </div>
                    </asp:View>
                </asp:MultiView>

                <%--<div class="col-md-8 booking-form">
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
                </div>--%>
            </div>
        </div>
    </div>


</asp:Content>
