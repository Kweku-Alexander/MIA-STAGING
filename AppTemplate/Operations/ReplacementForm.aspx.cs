using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Operations
{
    public partial class ReplamentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            OldMet.Text = Session["Oldmeter"].ToString();

            //for D Manager
            if (Session["personRoleId"].ToString() == "2")
            {
                Login_Usename.Text = Session["username"].ToString();
                approve_btn.Visible = true;
                reject_btn.Visible = true;
                Reasonid.Visible = true;
                Reason_message.Visible = true;


            }
            //for DCO
            else if (Session["personRoleId"].ToString() == "7")
            {
                Login_Usename.Text = Session["username"].ToString();
                refund_btn.Visible = true;
                tele.ReadOnly = false;
                //resend_btn.Visible = true;
                Amount_rem.ReadOnly = false;
            }
            //for Refund Officer
            else if (Session["personRoleId"].ToString() == "6")
            {
                Login_Usename.Text = Session["username"].ToString();
                refund_btn.Visible = true;
                //resend_btn.Visible = true;
                escalate_btn.Visible = true;
                
            }


            CustomerInfo();
            SearchMeter();


            if (Session["username"] != null)
            {
                Usename2.Text = Session["username"].ToString();
                if (Session["personRoleId"].ToString() == "7")
                {
                    Login_Usename.Text = Session["username"].ToString();
                    escalate_btn.Enabled = false;
                }
                else if (Session["personRoleId"].ToString() == "2")
                {
                    Login_Usename.Text = Session["username"].ToString();
                    escalate_btn.Enabled = false;
                    refund_btn.Enabled = false;
                    resend_btn.Enabled = false;
                   
                }
            }
            else
            {
                Response.Redirect("~/Account/LoginPage.aspx");
            }

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        // Search meter in Ecash
        private void SearchMeter()
        {
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/ecash/transactions";
            requestParameters.Add("MeterNumber", OldMet.Text);


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                MeterDetials meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                //meterDetails = JsonConvert.DeserializeObject<MeterDetials>(serverResponse);
                List<MeterDetials> friends = JsonConvert.DeserializeObject<List<MeterDetials>>(serverResponse);
                int numberOfPurchases = friends.Count();

                no_of_purchases_txt.Text = numberOfPurchases.ToString();

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();

                Label4.Text = meterDetailsResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {


                    GridView1.DataSource = friends;
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }
       
        private void CustomerInfo()
        {
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", OldMet.Text);


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                CostomerInfor costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                costomerInfor = JsonConvert.DeserializeObject<CostomerInfor>(serverResponse);
                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();

                Label4.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    old_meter_num.Text = costomerInfor.OldMeterNumber;
                    new_meter_num.Text = costomerInfor.NewMeterNumber;
                    phase.Text = costomerInfor.Phase;
                    customer_nm.Text = costomerInfor.CustomerName;
                    Acc_num.Text = costomerInfor.AccountNumber;
                    traff_class.Text = costomerInfor.TariffClass;
                    tele.Text = costomerInfor.TelephoneNumber;
                    remain_bal.Text = costomerInfor.RemainingBalance;
                    Amount_rem.Text = costomerInfor.RemainingBalance;
                    digital_add.Text = costomerInfor.MeterLocation;
                    meter_type.Text = costomerInfor.MeterType;
                    dateofvist.Text = costomerInfor.DateOfInstallation;
                    Image1.ImageUrl = costomerInfor.ImageUrlOne;
                    Image2.ImageUrl = costomerInfor.ImageUrlTwo;
                    Image3.ImageUrl = costomerInfor.ImageUrlThree;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Meter not found......');", true);

                }

            }
        }
        protected void searchTextBox_Leave(object sender, EventArgs e)
        {



        }

        private void refund()
        {
            String district_login = Session["district"].ToString();
            String region_login = Session["region"].ToString();

            List<autorefund> responseList = new List<autorefund>();
            Response costomerInforResponse = new Response();


            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/admin/automatic/refund/customer";
            requestParameters.Add("MeterNumber", old_meter_num.Text);
            requestParameters.Add("AccountNumber", Acc_num.Text);
            requestParameters.Add("Amount", Amount_rem.Text);
            requestParameters.Add("CustomerName", customer_nm.Text);
            requestParameters.Add("CustomerPhoneNumber", tele.Text);
            requestParameters.Add("SupervisorName", Login_Usename.Text);
            requestParameters.Add("District", district_login);
            requestParameters.Add("Region", region_login);

            using (HttpClient client = new HttpClient())
            {
                autorefund mresponse = new autorefund();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;
                String mass = serverResponse;

               mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                lblpopup.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                //Label1.Text= response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "OK")
                {
                    // url = "~/Operations/MainPage.aspx";

                    //costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                    String Message = costomerInforResponse.message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + mass + "'); document.location.href='MainPage.aspx';", true);
                } 
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + mass + "'); document.location.href='MainPage.aspx';", true);


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sorry Remaining Balance not sent......');", true);

                }


            }

        }

        private async System.Threading.Tasks.Task resendAsync()
        {

            var requestParameters = new Dictionary<string, string>();
            String meterNumber = OldMet.Text;
            var url = $"http://52.176.53.54/miastaging/meter/admin/automatic/refund/{meterNumber}";
            //requestParameters.Add("MeterNumber", OldMet.Text);

            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                Resend costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                costomerInforResponse.status_code = response.StatusCode.ToString();
              

                Label4.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    if (costomerInfor == null)
                    {
                        String responseMessage = await response.Content.ReadAsStringAsync();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + responseMessage + "'); document.location.href='ReplacementForm.aspx';", true);
                    }
                    else
                    {
                        costomerInfor = JsonConvert.DeserializeObject<Resend>(serverResponse);
                        Label8.Text = costomerInfor.Id;
                        Label2.Text = costomerInfor.MeterNumber;
                        Label3.Text = costomerInfor.AccountNumber;
                        Label1.Text = costomerInfor.CustomerName;
                        Label5.Text = costomerInfor.CustomerPhoneNumber;
                        Amount.Text = costomerInfor.Amount;
                        Label6.Text = costomerInfor.Token;


                    }


                }
                else
                {
                    costomerInforResponse = JsonConvert.DeserializeObject<MeterDetialsResponse>(serverResponse);
                    String errorMessage = costomerInforResponse.message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }

        private void resend_Main()
        {
            var requestParameters = new Dictionary<string, string>();
            String ID = OldMet.Text;
            var url = $"http://52.176.53.54/miastaging/meter/admin/automatic/refund/customer/resend/{ID}";


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                Resend costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                costomerInfor = JsonConvert.DeserializeObject<Resend>(serverResponse);
                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();

                Label4.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    costomerInforResponse = JsonConvert.DeserializeObject<MeterDetialsResponse>(serverResponse);
                    String errorMessage = costomerInforResponse.message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }
                else
                {
                    costomerInforResponse = JsonConvert.DeserializeObject<MeterDetialsResponse>(serverResponse);
                    String errorMessage = costomerInforResponse.message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }

        private void Approve()
        {
            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", old_meter_num.Text);
            requestParameters.Add("SupervisionRemarks", "good" /*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            requestParameters.Add("AmountRemaining", Amount_rem.Text);
            requestParameters.Add("AuthorizedBy", Login_Usename.Text);
            using (HttpClient client = new HttpClient())
            {
                approval mresponse = new approval();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(requestParameters)).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                lblpopup.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                lblpopup.Text = response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    url = "~/Operations/MainPage.aspx";
                 
                    costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                    String Message = costomerInforResponse.message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message + "'); document.location.href='MainPage.aspx';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An error has occurred.');", true);

                }

            }
        }
        protected void approve_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void Reject()
        {
            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", old_meter_num.Text);
            requestParameters.Add("SupervisionRemarks", "Check"/*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "NO");
            requestParameters.Add("ReasonForRejectingApproval", Reason_message.Text);
            requestParameters.Add("AmountRemaining", Amount_rem.Text);
            requestParameters.Add("AuthorizedBy", Login_Usename.Text);
            using (HttpClient client = new HttpClient())
            {
                approval mresponse = new approval();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(requestParameters)).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                lblpopup.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                lblpopup.Text = response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    url = "~/Operations/MainPage.aspx";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile Updated......');", true);

                    costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                    String Message = costomerInforResponse.message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message + "'); document.location.href='MainPage.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }
        protected void reject_Click(object sender, EventArgs e)
        {
            Reject();
        }
        protected void btn_refund_Click(object sender, EventArgs e)
        {

            int count = 0;
            count++;
            //add your code here

            if (count == 1)
            {
                refund();
                refund_btn.Enabled = false;
            }

        }

        protected void btnResend_Click(object sender, EventArgs e)
        {
            mpe.Show();
            
        }

        protected void RESEND(object sender, EventArgs e)
        {

            resend_Main();

        }

        protected void btnEscalate_Click(object sender, EventArgs e)
        {
            EscalatdBy();
        }


        private void EscalatdBy()
        {

            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/refund/escalate";
            requestParameters.Add("MeterNumber", old_meter_num.Text);
            requestParameters.Add("EscalatedBy", Login_Usename.Text);
            using (HttpClient client = new HttpClient())
            {
                approval mresponse = new approval();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(requestParameters)).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                lblpopup.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                lblpopup.Text = response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    url = "~/Operations/MainPage.aspx";
                    costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                    String Message = costomerInforResponse.message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message + "'); document.location.href='MainPage.aspx';", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An error has occurred.');", true);

                }

            }
        }

        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {

            /*(GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber LIKE '{0}%'", txtmnumber.Text)*/
            ;


        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataGridViewRow(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowUpdating(object sender, EventArgs e)
        {
        }

        protected void OnRowDataBound(object sender, EventArgs e)
        {
            //this.GridView1.Columns[0].Visible = false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            
        }

        //protected void searchTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtmnumber.Text))
        //    {
        //        (txtmnumber.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        //    }
        //    else
        //    {
        //        (txtmnumber.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name='{0}'", txtmnumber.Text);
        //    }
        //}

       
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //(GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber LIKE '{0}%'", txtmnumber.Text);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void Button_click(object sender, EventArgs e)
        {
            
        }
    }
 

}
