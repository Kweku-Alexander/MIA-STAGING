using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Password_reset()
        {
            List<createuser> responseList = new List<createuser>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/api/login/admin/reset/password";
            requestParameters.Add("UserName", txt_createUsername.Text);
            

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Created......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorret Password......');", true);

                }

            }
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Password_reset();
        }
    }
}