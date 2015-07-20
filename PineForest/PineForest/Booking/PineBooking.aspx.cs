using PineForest.CommonLayer;
using PineForest.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest
{
    public partial class PineBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tblAvailableRooms.Visible = false;
                LoadDropdownListItem();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch{}
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

            if(Convert.ToInt32(roomNights).ToString() == "1")
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

        private void SendMailConfirmation(string customerMailID, string authenticationCode)
        {
            MailMessage _msg = new MailMessage();
            StringBuilder sbMail = new StringBuilder();
            _msg.From = new MailAddress("info@pineforestmunnar.com");

            // To Address
            _msg.To.Add(new MailAddress(customerMailID));
            // Subject
            _msg.Subject = "Welcome to PineForestMunnar.com";

            // Body
            sbMail.Append("Hi,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("We are happy to welcome you to the PineForestMunnar.com and are delighted to give you a login to PineForestMunnar Website.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Please use the below authentication code and activate the service.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Kindly login with your E-Mail id for");
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
            sbMail.Append("PineForestMunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            _msg.Body = sbMail.ToString();

            SendMessage(_msg);
        }

        private void SendMessage(MailMessage _msg)
        {            
            SmtpClient client = new SmtpClient();
            client.Send(_msg);
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

    }
}