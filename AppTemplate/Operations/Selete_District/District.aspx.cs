using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;

namespace AppTemplate.Operations.Selete_District
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string regionId = Session["regionId"].ToString();

            if (!IsPostBack)
            {
                district();
            }
        }
        private void district()
        {
            var requestParameters = new Dictionary<string, string>();
            string regionId = Session["regionId"].ToString();
            var url = $"http://52.176.53.54/miaproduction/api/location/district/{regionId}";


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                District_Drop costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<District_Drop>>(serverResponse);

                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();


                string status = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    drop_district.DataSource = result;
                    drop_district.DataTextField = "district";
                    drop_district.DataValueField = "district";
                    drop_district.DataBind();

                    //meterobjJ = displayrecords.Result;
                    //droprole.DataSource = meterobjJ;
                    //droprole.DataTextField = "Role";
                    //droprole.DataValueField = "Role";
                    //droprole.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Session["district_drop"] = drop_district.Text;
            Response.Redirect("~/Operations/MainPage.aspx?someVal=1");
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = drop_district.SelectedValue;
        }
    }
}