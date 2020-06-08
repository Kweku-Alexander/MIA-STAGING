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

namespace AppTemplate.Account
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login_username.Text = Session["username"].ToString();
            role.Text = Session["personRole"].ToString();
            login_regionId.Text = Session["regionId"].ToString();
            login_region.Text = Session["region"].ToString();

            if (!IsPostBack)
            {

                IEnumerable<Role_Drop> meterobjJ = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://52.176.53.54/miastaging/api/login/admin/users/");
                var consumeapi = hc.GetAsync("roles");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayrecords = readdata.Content.ReadAsAsync<IList<Role_Drop>>();
                    //var displayrecords = readdata.Content.results;
                    //var displayrecords = readdata.Content.
                    displayrecords.Wait();
                    meterobjJ = displayrecords.Result;
                    droprole.DataSource = meterobjJ;
                    droprole.DataTextField = "Role";
                    droprole.DataValueField = "RoleId";
                    droprole.DataBind();
                }


                IEnumerable<fetchRoles> roleList = null;
                HttpClient fetchUserRolesClient = new HttpClient();
                fetchUserRolesClient.BaseAddress = new Uri("http://52.176.53.54/miastaging/api/login/admin/users/");
                var consumeFetchRolesApi = fetchUserRolesClient.GetAsync("all");
                consumeapi.Wait();

                var readAllUsersdata = consumeFetchRolesApi.Result;
                if (readAllUsersdata.IsSuccessStatusCode)
                {
                    var displayrecords = readAllUsersdata.Content.ReadAsAsync<IList<fetchRoles>>();
                    //var displayrecords = readdata.Content.results;
                    //var displayrecords = readdata.Content.
                    displayrecords.Wait();
                    roleList = displayrecords.Result;
                    GridView1.DataSource = roleList;
                    GridView1.DataBind();
                }

                district();
            }
        }

        private void Role()
        {
            IEnumerable<Role_Drop> meterobjJ = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://52.176.53.54/miastaging/api/login/admin/users/");
            var consumeapi = hc.GetAsync("role");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<Role_Drop>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobjJ = displayrecords.Result;
                droprole.DataSource = meterobjJ;
                droprole.DataTextField = "RoleID";
                droprole.DataValueField = "RoleId";
                droprole.DataBind();
            }
        }
            private void Region()
        {
            //IEnumerable<District_Drop> meterobjJ = null;
            //HttpClient hc = new HttpClient();
            //hc.BaseAddress = new Uri("http://52.176.53.54/PublishOutput/api/location/region/");
            //var consumeapi = hc.GetAsync("all");
            //consumeapi.Wait();

            //var readdata = consumeapi.Result;
            //if (readdata.IsSuccessStatusCode)
            //{
            //    var displayrecords = readdata.Content.ReadAsAsync<IList<District_Drop>>();
            //    //var displayrecords = readdata.Content.results;
            //    //var displayrecords = readdata.Content.
            //    displayrecords.Wait();
            //    meterobjJ = displayrecords.Result;
            //    drop_region.DataSource = meterobjJ;
            //    drop_region.DataTextField = "district";
            //    drop_region.DataValueField = "district";
            //    drop_region.DataBind();
            //}
        }

        private void district()
        {
            var requestParameters = new Dictionary<string, string>();
            String regionId = login_regionId.Text;
            var url = $"http://52.176.53.54/miastaging/api/location/district/{regionId}";


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


                Label1.Text = costomerInforResponse.status_code.ToString();

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

        private void Create()
        {
            List<createuser> responseList = new List<createuser>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/api/login/admin/user/create";
            requestParameters.Add("UserName", txt_createUsername.Text);
            requestParameters.Add("Telephone", txt_createTelephone.Text);
            requestParameters.Add("RoleId", droprole.SelectedValue);
            requestParameters.Add("CreatedBy", login_username.Text);
            requestParameters.Add("District", drop_district.SelectedValue);
            requestParameters.Add("Region", login_region.Text);
            requestParameters.Add("Role", droprole.SelectedValue);

            using (HttpClient client = new HttpClient())
            {
                createuser mresponse = new createuser();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                login_username.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                //Label1.Text= response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "OK")
                {
                    // url = "~/Operations/MainPage.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User Created......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = droprole.SelectedValue;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = drop_district.SelectedValue;
        }

        
        protected void btncreate_Click(object sender, EventArgs e)
        {
            Create();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}