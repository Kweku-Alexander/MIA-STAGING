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
    public partial class superviorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtmnuber.Text = Session["mid"].ToString();
            txtcname.Text= Session["cname"].ToString();
            txttel.Text = Session["tel"].ToString();
            Inspect_text.Text = Session["Inspect"].ToString();
            
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void Approve()
        {

            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }
            else
            {
                Response.Redirect("~/Account/LoginPage.aspx");
            }
            List<approval> responseList = new List<approval>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/PublishOutput/meter/supervisor";
            requestParameters.Add("MeterNumber", txtmnuber.Text);
            requestParameters.Add("SupervisionRemarks", txtsupervisorremark.Text);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            requestParameters.Add("AmountRemaining", "AmountRem");
            requestParameters.Add("AuthorizedBy", Label1.Text);
            using (HttpClient client = new HttpClient())
            {
                approval mresponse = new approval();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(requestParameters)).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                Label6.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                Label1.Text = response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    url = "~/Operations/MainPage.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile Updated......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }
        private void Reject()
        {
            List<reject> responseList = new List<reject>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/PublishOutput/meter/supervisor";
            requestParameters.Add("MeterNumber", txtmnuber.Text);
            requestParameters.Add("SupervisionRemarks", txtsupervisorremark.Text);
            requestParameters.Add("SupervisonApprovalStatus", "NO");
            requestParameters.Add("InspectedBy", Inspect_text.Text);
            requestParameters.Add("ReasonForRejectingApproval", "Rejected");
            requestParameters.Add("AuthorizedBy", "fhyghghgh");
            using (HttpClient client = new HttpClient())
            {
                reject mresponse = new reject();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(requestParameters)).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                Label6.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                Label1.Text = response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    url = "~/Operations/MainPage.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile Updated......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            Reject();
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operations/MainPage.aspx");
        }
    }
}