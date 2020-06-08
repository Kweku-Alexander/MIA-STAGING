using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Login.Stock
{
    public partial class LoginPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            txt_username.Attributes.Add("autocomplete",
               "off");
          txt_password.Attributes.Add("autocomplete",
              "off");

        }

        private void CustomerInfo()
        {
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/api/login/user";
            requestParameters.Add("username", txt_username.Text);
            requestParameters.Add("password", txt_password.Text);

            //String dco = "jack";
            //String pass = "jac3193";
            //txt_username.Text = dco;
            //txt_password.Text = pass;


            using (HttpClient client = new HttpClient())
            {
                Response costomerInforResponse = new Response();
                Role costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                costomerInfor = JsonConvert.DeserializeObject<Role>(serverResponse);
                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();



                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    if (costomerInfor.roleId==null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Username/Password Incorrect'); document.location.href='LoginPage2.aspx';", true);

                    }
                    else
                    {
                        Session["username"] = costomerInfor.username;
                        Session["personRoleId"] = costomerInfor.roleId.ToString();
                        Session["region"] = costomerInfor.region.ToString();
                        Session["district"] = costomerInfor.district.ToString();



                        if (costomerInfor.roleId.ToString() == "4")
                        {
                            String personRole = "Back Officer";
                            Session["personRole"] = personRole;

                            Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
                        }

                        else if (costomerInfor.roleId.ToString() == "7")
                        {
                            String personRole = "DCO";
                            Session["personRole"] = personRole;


                            //Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
                            Response.Redirect("~/Operations/MainPage.aspx?someVal=1");

                        }



                        else if (costomerInfor.roleId.ToString() == "2")
                        {
                            String personRole = "District Manager";
                            Session["personRole"] = personRole;
                            if (costomerInfor.region == "Tema")
                            {
                                String regionId = "10003001";
                                Session["regionId"] = regionId;

                            }
                            //Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
                            Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
                        }


                        else if (costomerInfor.roleId.ToString() == "6")
                        {

                            String personRole = "Refund Officer";
                            Session["personRole"] = personRole;
                            Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
                        }
                        else if (costomerInfor.roleId.ToString() == "1")
                        {

                            String personRole = "Pre-Survey Supervisor";
                            Session["personRole"] = personRole;
                            if (costomerInfor.region == "Tema")
                            {
                                String regionId = "10003001";
                                Session["regionId"] = regionId;

                            }
                            Response.Redirect("~/Operations/Selete_District/District.aspx?someVal=1");
                        }
                        else if (costomerInfor.roleId.ToString() == "")
                        {
                            //get the error message and show it in the alert dialog
                            costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                            String errorMessage = costomerInforResponse.message;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + errorMessage + "'); document.location.href='LoginPage2.aspx';", true);

                        }
                    }

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    costomerInforResponse = JsonConvert.DeserializeObject<Response>(serverResponse);
                    String errorMessage = costomerInforResponse.message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + errorMessage + "'); document.location.href='LoginPage2.aspx';", true);


                }

            }
        }
        

        protected void btn_login_Click(object sender, EventArgs e)
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (bb == true)
            {
                //loginApi();
                CustomerInfo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Internet connection is not available');", true);
            }
        }

        protected void txt_password_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}