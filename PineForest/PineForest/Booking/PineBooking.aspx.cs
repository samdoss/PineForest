using PineForest.CommonLayer;
using PineForest.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest
{
    public partial class PineBooking : System.Web.UI.Page
    {

        string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                             + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfLoginID.Value = Session["LoginID"].cxToString();
                hfEmailID.Value = Session["EmailID"].cxToString();
                hfMobileNo.Value = Session["MobileNumber"].cxToString();

                tblAvailableRooms.Visible = false;
                LoadDropdownListItem();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlRoomType.SelectedValue == "1")
                    imgRoomType.ImageUrl = "~//images//Economy.jpg";
                if (ddlRoomType.SelectedValue == "2")
                    imgRoomType.ImageUrl = "~//images//Deluxe.jpg";
                if (ddlRoomType.SelectedValue == "3")
                    imgRoomType.ImageUrl = "~//images//SuperDeluxe.jpg";


                lblMsgValidation.Text = "";
                tblAvailableRooms.Visible = false;
                lblAvailableRooms.Text = "";
                lblPerRoomPrice.Text = "";
                if (!FormValidation())
                {
                    return;
                }
                tblAvailableRooms.Visible = true;
                RoomCount();
                return;
            }
            catch { }
        }

        private int DaysCount()
        {
            int daysCount = 0;
            DateTime startdate;
            DateTime enddate;
            TimeSpan remaindate;
            startdate = DateTime.Parse(txtCheckInDate.Text).Date;
            enddate = DateTime.Parse(txtCheckOutDate.Text).Date;
            remaindate = enddate - startdate;
            if (remaindate != null)
            {
                daysCount = remaindate.TotalDays.cxToInt32();
                //string strva = "you have left with " + remaindate.TotalDays + "days.";
            }
            return daysCount;
        }

        private void LoadDropdownListItem()
        {
            PineBookingDL pineBookingObj = new PineBookingDL();
            ddlRoomType.Items.Clear();
            ddlRoomType.DataSource = pineBookingObj.GetRoomTypes().Tables[0];
            ddlRoomType.DataTextField = "RoomType";
            ddlRoomType.DataValueField = "RoomTypeID";
            ddlRoomType.DataBind();
            ddlRoomType.Items.Insert(0, "--Select One--");
            ddlRoomType.Items[0].Value = "";
        }

        private void RoomCount()
        {
            int roomCountAvailable = 0;
            lblPerRoomPrice.Text = "";

            PineBookingDL pineBookingObj = new PineBookingDL();
            roomCountAvailable = pineBookingObj.GetRoomTypesAvailableCount(Convert.ToInt32(ddlRoomType.SelectedValue));
            lblAvailableRooms.Text = roomCountAvailable.ToString();
            if (roomCountAvailable != 0)
            {

                ddlRoomsCount.Items.Clear();
                ddlRoomsCount.DataSource = FormRoomCountingDropdown(Convert.ToInt32(roomCountAvailable)).Tables[0];
                ddlRoomsCount.DataTextField = "RoomsCount";
                ddlRoomsCount.DataValueField = "RoomID";
                ddlRoomsCount.DataBind();
                ddlRoomsCount.Items.Insert(0, "--Select One--");
                ddlRoomsCount.Items[0].Value = "";
            }
            else
            {
                ddlRoomsCount.Items.Clear();
                ddlRoomsCount.DataSource = null;
                ddlRoomsCount.DataBind();
                ddlRoomsCount.Items.Insert(0, "--Select One--");
                ddlRoomsCount.Items[0].Value = "";
            }
            DataSet ds = new DataSet();
            DateTime startdate;
            DateTime enddate;
            startdate = DateTime.Parse(txtCheckInDate.Text).Date;
            enddate = DateTime.Parse(txtCheckOutDate.Text).Date;
            ds = pineBookingObj.GetRoomCostOnPeriodDaysByCheckInCheckOut(Convert.ToInt32(ddlRoomType.SelectedValue), Convert.ToDateTime(startdate), Convert.ToDateTime(enddate));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dRow = ds.Tables[0].Rows[0];
                int roomPriceID = Convert.ToInt32(dRow["RoomPriceID"]);
                lblPerRoomPrice.Text = Convert.ToString(dRow["Price"]);
                //roomCount = Convert.ToInt32(dRow["DiscountPercentage"]);
            }
        }

        private DataSet FormRoomCountingDropdown(int roomCount)
        {
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            DataColumn idCoulumn;
            DataColumn nameCoulumn;

            dt = new DataTable();
            idCoulumn = new DataColumn("RoomID", Type.GetType("System.Int32"));
            nameCoulumn = new DataColumn("RoomsCount", Type.GetType("System.String"));

            dt.Columns.Add(idCoulumn);
            dt.Columns.Add(nameCoulumn);

            for (int i = 1; i <= roomCount; i++)
            {
                dr = dt.NewRow();
                dr["RoomID"] = i;
                dr["RoomsCount"] = i.ToString();
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //{
            //    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
            //} 
            return ds;
        }


        private bool FormValidation()
        {
            try
            {
                bool rValue = true;
                string dtFormat = "MM/dd/yyyy";
                DateTime dTime = new DateTime();
                DateTime todayDate = new DateTime();
                DateTime dJTime = new DateTime();
                string sTodayDate;

                // Whether correct date format
                if (!Common.ValidateDate(txtCheckInDate.Text.ToString(), dtFormat))
                {
                    txtCheckInDate.Focus();
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<script>alert('" + "CheckIn Date - Incorrect format (mm/dd/yyyy)" + ".');");
                    //sb.Append("</script>");
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                    lblMsgValidation.Text = "CheckIn Date - Incorrect format (mm/dd/yyyy).";
                    rValue = false;
                }
                else if (!Common.ValidateDate(txtCheckOutDate.Text.ToString(), dtFormat))
                {
                    txtCheckOutDate.Focus();
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<script>alert('" + "CheckOut Date - Incorrect format (mm/dd/yyyy)" + ".');");
                    //sb.Append("</script>");
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                    lblMsgValidation.Text = "CheckOut Date - Incorrect format (mm/dd/yyyy).";
                    rValue = false;
                }
                else if (rValue)
                {
                    sTodayDate = Convert.ToString(DateTime.Now.ToString(dtFormat));
                    dTime = DateTime.ParseExact(txtCheckInDate.Text, dtFormat, null);
                    todayDate = DateTime.ParseExact(sTodayDate, dtFormat, null);
                    dJTime = DateTime.ParseExact(txtCheckOutDate.Text, dtFormat, null);
                    if (dTime < todayDate)
                    {
                        txtCheckInDate.Focus();
                        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //sb.Append("<script>alert('" + "CheckIn - Cannot Be Lesser Than Current Date" + ".');");
                        //sb.Append("</script>");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                        lblMsgValidation.Text = "CheckIn - Cannot Be Lesser Than Current Date.";
                        return rValue = false;
                    }
                    else if (dJTime < todayDate)
                    {
                        txtCheckInDate.Focus();
                        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //sb.Append("<script>alert('" + "CheckIn - Cannot Be Lesser Than Current Date" + ".');");
                        //sb.Append("</script>");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                        lblMsgValidation.Text = "CheckOut - Cannot Be Lesser Than Current Date.";
                        return rValue = false;
                    }
                    else if (dTime > dJTime)
                    {
                        txtCheckOutDate.Focus();
                        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //sb.Append("<script>alert('" + "CheckOut - Cannot Be Lesser Than Current Date" + ".');");
                        //sb.Append("</script>");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                        lblMsgValidation.Text = "CheckOut - Cannot Be Lesser Than " + txtCheckInDate.Text + "Date.";
                        return rValue = false;
                    }
                    else if (DaysCount() > 5)
                    {
                        txtCheckOutDate.Focus();
                        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //sb.Append("<script>alert('" + "CheckOut - Cannot Be Lesser Than Current Date" + ".');");
                        //sb.Append("</script>");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                        lblMsgValidation.Text = "Sorry! You cannot booked more than 5 days.";
                        return rValue = false;
                    }
                }

                return rValue;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PineBooking.aspx", "", "FormValidation", ex.Message, new PineConnection());
                return false;
            }
        }

        protected void btnContinueBooking_Click(object sender, EventArgs e)
        {
            lblPerRoomPerNightAmount.Text = lblPerRoomPrice.Text;

            int roomNights = DaysCount();
            int roomCount = Convert.ToInt32(ddlRoomsCount.SelectedValue);

            if (Convert.ToInt32(ddlRoomsCount.SelectedValue).ToString() == "1")
            {
                lblRoomsandNights.Text = Convert.ToInt32(ddlRoomsCount.SelectedValue).ToString() + "Room x";
            }
            else
            {
                lblRoomsandNights.Text = Convert.ToInt32(ddlRoomsCount.SelectedValue).ToString() + "Rooms x";
            }

            if (Convert.ToInt32(roomNights).ToString() == "1")
            {
                lblRoomsandNights.Text = lblRoomsandNights.Text + " " + roomNights + " " + "Night";
            }
            else
            {
                lblRoomsandNights.Text = lblRoomsandNights.Text + " " + roomNights + " " + "Nights";
            }

            int roomCountAmount = Convert.ToInt32(lblPerRoomPerNightAmount.Text) * roomCount;
            int roomCountandNightsAmount = Convert.ToInt32(roomCountAmount * roomNights);
            lblRoomsandNightsAmount.Text = roomCountandNightsAmount.ToString();
            lblFeesandTaxesAmount.Text = Convert.ToString(Convert.ToInt32(100) + Convert.ToInt32(roomCountandNightsAmount * 14 / 100));
            lblTotalAmountUPay.Text = Convert.ToString(Convert.ToInt32(lblRoomsandNightsAmount.Text) + Convert.ToInt32(lblFeesandTaxesAmount.Text));

            gvBookingRooms.AllowPaging = false;
            gvBookingRooms.AllowSorting = false;
            gvBookingRooms.BackColor = Color.AliceBlue;
            gvBookingRooms.BorderColor = Color.White;
            gvBookingRooms.ShowFooter = false;
            gvBookingRooms.ShowHeader = false;
            gvBookingRooms.AutoGenerateColumns = false;
            gvBookingRooms.EnableViewState = true;



            gvBookingRooms.DataSource = FormRoomCountingDropdown(Convert.ToInt32(ddlRoomsCount.SelectedValue)).Tables[0];
            gvBookingRooms.DataBind();

            mv1.ActiveViewIndex = 1;
        }

        private void SendmailtoAdmin(string customerMailID, string authenticationCode)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage sm = new MailMessage();
            smtpClient.Credentials = new System.Net.NetworkCredential("info@pineforestmunnar.com", "Mocha$55");
            smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            smtpClient.Port = 25;
            sm.To.Add(customerMailID);
            sm.Bcc.Add("info.pineforestmunnar@gmail.com");
            sm.IsBodyHtml = true;
            sm.From = new MailAddress("info@pineforestmunnar.com");
            sm.Subject = "Welcome to PineForestMunnar.com";
            StringBuilder sbMail = new StringBuilder();
            sbMail.Append("Dear Customer,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("We are happy to welcome you to the PineForestMunnar.com and are delighted to give you a login to PineForestMunnar Website.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Please use the below authentication code and activate the service.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Kindly login with your E-Mail id for ");
            sbMail.Append("information security reasons.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Please get back to us with your suggestions, comments and feedback to info@pineforestmunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Your Authentication code is given below to booking room in our website,");
            sbMail.Append(Environment.NewLine);

            sbMail.Append("http://pineforestmunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Authentication Code : " + authenticationCode);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Thank you,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Administrator");
            sbMail.Append(Environment.NewLine);
            sbMail.Append("PineForestMunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            //sm.Body += "<p><font face='Times New Roman' font-size='12'>Josh,</font></p>";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'>" + lblEmployeeName.Text + " needs leave on the following days.";

            //sm.Body += "<p>Kindly find below " + genderStr + " leave application details. Convey this to the Client and send me the response." + "<br /></font></p>";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'><table border=1 cellspacing=2 cellpadding=2><tr><td>S.No</td><td>Client</td><td>Employee Name</td>";
            //sm.Body += "<td>Date of Application</td><td>Leave Wanted From</td><td>Leave Wanted To</td><td>Total No. of Days</td>";
            //sm.Body += "<td>Reason</td><tr>";

            //if (hdfRole.Value.ToString() == "Administrator" || hdfRole.Value.ToString() == "HR")
            //{
            //    sm.Body += "<tr><td>1</td><td>&nbsp;</td><td>" + lblEmployeeName.Text + "</td>";
            //}
            //else
            //{
            //    if (Convert.ToInt32(hdfCompanyID.Value) == Convert.ToInt32(Company.ECGroupMT))
            //    {
            //        sm.Body += "<tr><td>1</td><td>&nbsp;</td><td>" + lblEmployeeName.Text + "</td>";
            //    }
            //    else
            //    {
            //        sm.Body += "<tr><td>1</td><td>" + ddlClient.SelectedItem.Text + "</td><td>" + lblEmployeeName.Text + "</td>";
            //    }
            //}


            //sm.Body += "<td>" + _currentDate.Date.ToShortDateString() + "</td><td>" + txtFromDate.Text + "</td><td>" + txtToDate.Text + "</td><td>" + hdfTotalDaysLeave.Value.ToString() + "</td>";
            //sm.Body += "<td>" + txtReasonforLeave.Text + "</td><tr></table><br /><br />";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'>Thank you, <br />Alice.";
            sm.IsBodyHtml = false;
            sm.Body = sbMail.ToString();

            sm.Priority = MailPriority.Normal;
            try
            {
                smtpClient.Send(sm);
            }
            catch (Exception ex)
            {
                String err_str = "Send Email Failed." + ex.Message;
            }
            smtpClient = null;
            sm = null;
        }

        protected void gvBookingRooms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[0].Visible = false;

                    Label lblRoomCountData = (Label)e.Row.FindControl("lblRoomCountData");
                    lblRoomCountData.Text = ((gvBookingRooms.PageIndex * gvBookingRooms.PageSize) + e.Row.RowIndex + 1).ToString();
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    // Hide Column Headers
                    e.Row.Cells[0].Visible = false;
                }
            }
            catch { }
        }

        protected void btnSubmitBooking_Click(object sender, EventArgs e)
        {
            if (!GridFormValidation())
            {
                return;
            }
            //int roomCount = Convert.ToInt32(ddlRoomsCount.SelectedValue);
            int roomNights = DaysCount();
            int roomNightsandAmountPerday = roomNights * lblPerRoomPrice.Text.cxToInt32();
            int feesandTax = Convert.ToInt32(100) + Convert.ToInt32(roomNightsandAmountPerday * 14 / 100);

            PineBookingDL bookingDL = new PineBookingDL();
            PineLoginDL loginDL = new PineLoginDL();

            for (int i = 0; i <= gvBookingRooms.Rows.Count - 1; i++)
            {
                string registrationCode = loginDL.GenerateAuthCode().cxToString();
                registrationCode = "" + "PFM" + registrationCode.ToUpper();
                registrationCode = registrationCode.Remove(10);
                registrationCode = registrationCode + DateTime.Now.Day + "" + DateTime.Now.Month + "";

                bookingDL.LoginID = hfLoginID.Value.cxToInt32();
                bookingDL.RegistrationID = registrationCode;
                bookingDL.BookingDate = DateTime.Now.Date;
                bookingDL.BookingFrom = Convert.ToDateTime(txtCheckInDate.Text);
                bookingDL.BookingTo = Convert.ToDateTime(txtCheckOutDate.Text);
                bookingDL.AdditionalBed = 0;
                bookingDL.Remarks = string.Empty;
                bookingDL.RoomTypeID = ddlRoomType.SelectedValue.cxToInt32();

                TextBox txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtBookingName");
                bookingDL.BookingName = txtBoxValue.Text;
                txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtCheckInTime");
                bookingDL.CheckInTime = txtBoxValue.Text;
                txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtCheckOutTime");
                bookingDL.CheckOutTime = txtBoxValue.Text;
                DropDownList ddlBoxValue = (DropDownList)gvBookingRooms.Rows[i].FindControl("ddlNoofAdults");
                bookingDL.NoofAdults = ddlBoxValue.SelectedValue.cxToInt32();
                ddlBoxValue = (DropDownList)gvBookingRooms.Rows[i].FindControl("ddlNoofChildrens");
                bookingDL.NoofChildrens = ddlBoxValue.SelectedValue.cxToInt32();
                txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtProofVerification");
                bookingDL.Proofverification = txtBoxValue.Text;
                txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtEmailID");
                bookingDL.EmailID = txtBoxValue.Text;
                txtBoxValue = (TextBox)gvBookingRooms.Rows[i].FindControl("txtPhoneNumber");
                bookingDL.PhoneNumber = txtBoxValue.Text;

                bookingDL.RoomNo = i + 1;
                bookingDL.AmountPerday = lblPerRoomPrice.Text.cxToInt32();
                bookingDL.Discount = 0;
                bookingDL.FeesandTax = feesandTax;
                bookingDL.TotalAmount = roomNightsandAmountPerday + feesandTax;
                bookingDL.PaidAmount = 0;
                bookingDL.IpAddress = "";
                bookingDL.GeoLocation = "";
                //bookingDL.PaymentDate = ;
                //bookingDL.PaymentByUsing = "";



                TransactionResult result;
                bookingDL.ScreenMode = ScreenMode.Add;
                result = bookingDL.Commit();

                //// Display the Status - Whether successfully saved or not
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append("<script>alert('" + result.Message.ToString() + ".');");
                //sb.Append("</script>");
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);

                // If successful get and display the saved Company
                if (result.Status == TransactionStatus.Success)
                {
                    //bookingDL.BookingID
                    mv1.ActiveViewIndex = 2;
                }

            }
        }

        private bool GridFormValidation()
        {
            try
            {
                bool rValue = true;

                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append("<script>alert('" + "CheckIn Date - Incorrect format (mm/dd/yyyy)" + ".');");
                //sb.Append("</script>");
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                //lblMsgValidation.Text = "CheckIn Date - Incorrect format (mm/dd/yyyy).";
                // rValue = false;

                for (int i = 0; i <= gvBookingRooms.Rows.Count - 1; i++)
                {
                    string IsEmptyString = string.Empty;
                    TextBox txtBookingName = (TextBox)gvBookingRooms.Rows[i].FindControl("txtBookingName");
                    IsEmptyString = txtBookingName.Text;

                    if (IsEmptyString == string.Empty)
                    {
                        lblBookingErrorMsg.Text = "Please Enter the Booking Name.";
                        return false;
                    }

                    TextBox txtProofVerification = (TextBox)gvBookingRooms.Rows[i].FindControl("txtProofVerification");
                    IsEmptyString = txtProofVerification.Text;

                    if (IsEmptyString == string.Empty)
                    {
                        lblBookingErrorMsg.Text = "Please Enter the ID Proof Verification.";
                        return false;
                    }

                    TextBox txtEmailID = (TextBox)gvBookingRooms.Rows[i].FindControl("txtEmailID");
                    IsEmptyString = txtEmailID.Text;

                    if (IsEmptyString == string.Empty)
                    {
                        lblBookingErrorMsg.Text = "Please Enter the valid EmailID.";
                        return false;
                    }
                    else if (!IsEmail(IsEmptyString))
                    {
                        lblBookingErrorMsg.Text = "EmailID is not valid.";
                        return false;
                    }

                    TextBox txtPhoneNumber = (TextBox)gvBookingRooms.Rows[i].FindControl("txtPhoneNumber");
                    IsEmptyString = txtPhoneNumber.Text;

                    if (IsEmptyString == string.Empty)
                    {
                        lblBookingErrorMsg.Text = "Please Enter the valid Phone Number.";
                        return false;
                    }
                }
                if (rValue)
                {
                    lblBookingErrorMsg.Text = "";
                }

                return rValue;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PineBooking.aspx", "", "GridFormValidation", ex.Message, new PineConnection());
                return false;
            }
        }

        public bool IsEmail(string email)
        {
            if (email != null)
                return Regex.IsMatch(email, MatchEmailPattern);
            else
                return false;
        }
    }
}