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
    public partial class Ploit_District : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login_district.Text = Session["district"].ToString();
            district();
        }
        private void district()
        {
            
            var requestParameters = new Dictionary<string, string>();
            HttpClient hc = new HttpClient();
            String district = "Tema North";
            var url = $"http://52.176.53.54/miaproduction/meter/quick/replacement/plot/{district}";




            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                ploit_Drop costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                //var ploit = JsonConvert.DeserializeObject<List<ploit_Drop>>(serverResponse);
                var ploit = (List<ploit_Drop>)JsonConvert.DeserializeObject(serverResponse, serverResponse.GetType()) ;
               

                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();


                Label4.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    Ploit_list.DataSource = ploit;
                    Ploit_list.DataTextField = "";
                    Ploit_list.DataValueField = "";
                    Ploit_list.DataBind();
                } 
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }

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
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
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

        protected void Ploit_Change(object sender, EventArgs e)
        {

        }

        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

        }
    }
}