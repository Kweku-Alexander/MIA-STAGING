using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Account.Logged_Users
{
    public partial class Logged_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personRoleId"].ToString() == "2")
            {
                Login_Usename.Text = Session["username"].ToString();
                GridView1.Visible = true;
            }
            All_loggedin();

        }


        private void All_loggedin()
        {
            IEnumerable<logged> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://52.176.53.54/miaproduction/api/login/admin/logged/users/all");
            var consumeapi = hc.GetAsync("all");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<logged>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobj = displayrecords.Result;
                GridView1.DataSource = meterobj;
                GridView1.DataBind();
            }

        }
        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ToEndTxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            CustomerInfo();
        }

        

        private void CustomerInfo()
        {
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/api/login/admin/logged/users/period";
            requestParameters.Add("startDate", Start_date.Text);
            requestParameters.Add("endDate", last_date.Text);


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                logged meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                //meterDetails = JsonConvert.DeserializeObject<MeterDetials>(serverResponse);
                List<logged> friends = JsonConvert.DeserializeObject<List<logged>>(serverResponse);
                int numberOfPurchases = friends.Count();

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();

                oldmeter.Text = meterDetailsResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {

                    GridView1.DataSource = null;
                    GridView1.DataSource = friends;
                    GridView1.DataBind();
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
        protected void StartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = Start_date.Text;
        }

        protected void EndDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = last_date.Text;
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

        protected void ExportToExcel(object sender, EventArgs e)
        {

        }
    }
}