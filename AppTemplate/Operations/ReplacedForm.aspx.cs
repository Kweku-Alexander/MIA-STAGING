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
    public partial class ReplacedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Text = Session["mid"].ToString();
            Label8.Text = Session["cname"].ToString();
            Label9.Text = Session["tel"].ToString();
            Label10.Text = Session["tele"].ToString();
            //Label10.Text = Session["tele"].ToString();
            //Label16.Text = Session["username"].ToString();

        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void Approve()
        {
            List<createuser> responseList = new List<createuser>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/refund/customer";
            requestParameters.Add("MeterNumber", Label7.Text);
            requestParameters.Add("Token", tokenBox.Text);
            requestParameters.Add("CustomerName", Label8.Text);
            requestParameters.Add("SupervisorName", Label16.Text);
            requestParameters.Add("CustomerPhoneNumber", Label10.Text);


            using (HttpClient client = new HttpClient())
            {
                createuser mresponse = new createuser();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                Label4.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                //Label1.Text= response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "OK")
                {
                    // url = "~/Operations/MainPage.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Token sent successful......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not sent......');", true);

                }

            }
            
        }
        
        protected void btnreject_Click(object sender, EventArgs e)
        {
            //Reject();
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operations/ReplacedMeter.aspx");
        }
    }
}