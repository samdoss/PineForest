using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblMessagebox.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SendmailtoAdmin();
            SendmailtoCustomer();

            txtName.Text = "";
            txtEmailID.Text = "";
            txtComment.Text = "";
            txtUserPhoneNumber.Text = "";
            lblMessagebox.Text = "Thank you. Your request sent to our support.";
        }

        /// <summary>
        /// Get current user ip address.
        /// </summary>
        /// <returns>The IP Address</returns>
        private string GetUserIPAddress()
        {
            var context = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/getuserip.php");
            context = context.Replace("<html>\r\n<head>\r\n</head>\r\n<body>\r\nIP", "");
            context = context.Replace("IP\r\n</body>\r\n</html>", "");
            string ip = context;
            var geoContext = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/index.php");
                        
            return ip;
        }

        /// <summary>
        /// Get current user ip address.
        /// </summary>
        /// <returns>The IP Address</returns>
        private string GetGeoLocation()
        {
            var geoContext = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/geolocation.php");

            string getLongutitudeLattitude = geoContext;
            string getGeoLocation = geoContext;
            return getGeoLocation;
        }


        private string GetClientDetailsFromhtml(string urlValue)
        {
            string uri = string.Empty;
            // This is where we will send it

            //string httpUrl = Page.Request.Url.OriginalString;
            //httpUrl = httpUrl.Replace("PineLogin.aspx", "GetClientDetails.html");

            uri = urlValue;
            try
            {
                // This is what we are sending sample, don't remove or change
                string post_data = "";
                // create a request
                HttpWebRequest request = (HttpWebRequest)
                                         WebRequest.Create(uri);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";

                // turn our request string into a byte stream
                byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

                // this is important - make sure you specify type this way
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                // grab te response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var consoleString = (new StreamReader(response.GetResponseStream()).ReadToEnd());
                var consoleStatusString = (response.StatusCode);
                return consoleString;
            }
            catch { }

            return uri;
        }

        private void SendmailtoAdmin()
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage sm = new MailMessage();
            smtpClient.Credentials = new System.Net.NetworkCredential("info@pineforestmunnar.com", "Mocha$55");
            smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            smtpClient.Port = 25;
            sm.To.Add("samdoss@live.com");
            sm.To.Add("info@pineforestmunnar.com");
            sm.To.Add("pineforestmunnar@gmail.com");
            sm.Bcc.Add("johnmalar@hotmail.com");
            sm.Bcc.Add("info.pineforestmunnar@gmail.com");
            sm.IsBodyHtml = true;
            sm.From = new MailAddress("info@pineforestmunnar.com");
            sm.Subject = "Welcome to PineForestMunnar.com";
            StringBuilder sbMail = new StringBuilder();
            sbMail.Append("Dear PineForestMunnar,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Customer FeedBack From the PineForestMunnar Website.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Name : " + txtName.Text);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Email ID : " + txtEmailID.Text);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Phone no : " + txtUserPhoneNumber.Text);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Comment : " + txtComment.Text);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Geo Location : " + GetGeoLocation());
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("User IP Address : " + GetUserIPAddress());
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Thanks & Regards,");
            sbMail.Append(Environment.NewLine);

            sbMail.Append("http://pineforestmunnar.com");
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

        private void SendmailtoCustomer()
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage sm = new MailMessage();
            smtpClient.Credentials = new System.Net.NetworkCredential("info@pineforestmunnar.com", "Mocha$55");
            smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            smtpClient.Port = 25;
            sm.To.Add(txtEmailID.Text);
            sm.Bcc.Add("johnmalar@hotmail.com");
            sm.Bcc.Add("info.pineforestmunnar@gmail.com");
            sm.IsBodyHtml = true;
            sm.From = new MailAddress("info@pineforestmunnar.com");
            sm.Subject = "Welcome to PineForestMunnar.com";
            StringBuilder sbMail = new StringBuilder();
            sbMail.Append("Dear " + txtName.Text + ",");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Thank you for your contact PineForestMunnar Support.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("We will get back to you soon.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Thanks & Regards,");
            sbMail.Append(Environment.NewLine);

            sbMail.Append("http://pineforestmunnar.com");
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
    }
}