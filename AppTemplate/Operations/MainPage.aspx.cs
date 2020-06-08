using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace AppTemplate.Operations

{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void GridView1_RowCreated(object sender,
        System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtmnumber.Text))
            //{
            //    msg.InnerText = "Found " + GridView1.Rows.Count +
            //        "Meter Number" + txtmnumber.Text + "'.";
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String district_login = Session["district"].ToString(); 

            //Super
            if (!IsPostBack)
            {
                if (Session["personRoleId"].ToString() == "1")
                {
                   string district_id = Session["district_drop"].ToString();
                    district.Text = district_id;
                    GridView4.Visible = true;
                    district.Visible = true;
                    district_change.Visible = true;
                    Login_Usename.Text = Session["username"].ToString();
                   string Username = Login_Usename.Text;
                }
                meterreplacent();
            }

            if (Session["personRoleId"].ToString() == "4")
            {
                //DataTable dt = new DataTable();
                GridView3.Visible = true;
                //ViewState["Old Meter Number"] = dt;
                Login_Usename.Text = Session["username"].ToString();
            }
            else
            if (Session["personRoleId"].ToString() == "7")
            {
                Login_Usename.Text = Session["username"].ToString();
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                Login_Usename.Text = Session["username"].ToString();
                GridView2.Visible = true;
                btnSelected.Visible = true;
                search_amount.Visible = true;
                Button1_Amount.Visible = true;
            }
            else
            if (Session["personRoleId"].ToString() == "6")
            {
                Login_Usename.Text = Session["username"].ToString();
                GridView1.Visible = true;
               
            }
            replaceQuick();
            NotWorkedOn();
            View_Cap();
           

            //btnsearch.Visible = btnsearch.Visible = User.IsInRole("4");
        }

        private void replaceQuick()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/refund/unescalated/all/{district_login}";



            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                Ressuveyall costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<Ressuveyall>>(serverResponse);

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();
                Label1.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
                else
                {

                }
            }
            
        }


        //Managers View to Approve and reject Meters for Replacement(QuickReplacement)
        private void NotWorkedOn()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/notworkedon/all/{district_login}";



            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                Ressuveyall costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<Ressuveyall>>(serverResponse);

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();
                Label1.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {

                    GridView2.DataSource = result;
                    GridView2.DataBind();
                }
                else
                {

                }
            }
        }

        private void View_Cap()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/notworkedon/all/{district_login}";



            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                Ressuveyall costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<Ressuveyall>>(serverResponse);

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();
                Label1.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    GridView3.DataSource = result;
                    GridView3.DataBind();
                }
                else
                {

                }
            }
            
        }
      
        private void meterreplacent()
        {
            if (Session["personRoleId"].ToString() == "1")
            {
                //Method to search the endpoint for the meter details
                var requestParameters = new Dictionary<string, string>();
                string district_id = Session["district_drop"].ToString();
                var url = $"http://52.176.53.54/miastaging/meter/admin/surveyedmeters/all/{district_id}";



                using (HttpClient client = new HttpClient())
                {
                    MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                    metereplace costomerInfor = null;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var serverResponse = response.Content.ReadAsStringAsync().Result;


                    var result = JsonConvert.DeserializeObject<List<metereplace>>(serverResponse);

                    meterDetailsResponse.status_code = response.StatusCode.ToString();
                    meterDetailsResponse.message = response.RequestMessage.ToString();
                    Label1.Text = meterDetailsResponse.status_code.ToString();

                    if (meterDetailsResponse.status_code.ToString() == "OK")
                    {
                        //append the details to the following textboxes in the form


                        GridView4.DataSource = result;
                        GridView4.DataBind();

                    }
                    else
                    {
                        //get the error message and show it in the alert dialog
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                    }
                }
            }
            

        }


        protected void searchTextBox_Leave(object sender, EventArgs e)
        {
        }

        



        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {
            if (Session["personRoleId"].ToString() == "4")
            {
                SearchMeter_FieldOFFicer();
                GridView3.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "7")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                SearchMeter_Manager();
                GridView2.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                SearchMeter_PreSupervisor();
                GridView4.Visible = true;
            }


        }

        private void CustomerInfo()
        {
            IEnumerable<metereplace> meterobj = null;
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);


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

                Label1.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    GridView5.DataSource = meterobj;
                    GridView5.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Meter not found......');", true);

                }

            }
        }
        private void SrearhMeter2()
        {
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                Ressuveyall meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                //meterDetails = JsonConvert.DeserializeObject<MeterDetials>(serverResponse);
                List<Ressuveyall> friends = JsonConvert.DeserializeObject<List<Ressuveyall>>(serverResponse);
                int numberOfPurchases = friends.Count();

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();

                Label1.Text = meterDetailsResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {


                    GridView5.DataSource = friends;
                    GridView5.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }

        private void SrearhMeter3()
        {
        }

            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataGridViewRow(object sender, EventArgs e)
        {

        }
        //protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        //{
        //    Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;
        //    Session["Custname"] = GridView1.SelectedRow.Cells[1].Text;
        //    Session["DigAddress"] = GridView1.SelectedRow.Cells[2].Text;
        //    Session["tele"] = GridView1.SelectedRow.Cells[3].Text;
        //    Session["NewMeter"] = GridView1.SelectedRow.Cells[4].Text;
        //    Session["Date"] = GridView1.SelectedRow.Cells[5].Text;
        //    Session["Accon"] = GridView1.SelectedRow.Cells[6].Text;
        //    Session["Phas"] = GridView1.SelectedRow.Cells[7].Text;
        //    Response.Redirect("ReplacementForm.aspx?someVal=1");
        //}
        //   protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        //{

        //        Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

        //        Response.Redirect("ReplacementForm.aspx?someVal=1");

        //}

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {


            if (Session["personRoleId"].ToString() == "7")
            {
                Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

                Response.Redirect("ReplacementForm.aspx?someVal=1");
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                Session["Oldmeter"] = GridView2.SelectedRow.Cells[0].Text;

                Response.Redirect("ReplacementForm.aspx?someVal=1");
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

                Response.Redirect("ReplacementForm.aspx?someVal=1");
            }


        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {

                if (Session["personRoleId"].ToString() == "7")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow gvRow = GridView1.Rows[index];
                    int rowindex = gvRow.RowIndex;

                    String meterNum = GridView1.Rows[rowindex].Cells[0].Text;
                    Approve(meterNum);


                }
                else if (Session["personRoleId"].ToString() == "2")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow gvRow = GridView2.Rows[index];
                    int rowindex = gvRow.RowIndex;

                    String meterNum = GridView2.Rows[rowindex].Cells[0].Text;
                    Approve(meterNum);
                }
                //else if (Session["personRoleId"].ToString() == "5")
                //{
                //    int index = Convert.ToInt32(e.CommandArgument);
                //    GridViewRow gvRow = GridView4.Rows[index];
                //    int rowindex = gvRow.RowIndex;

                //    String meterNum2 = GridView4.Rows[rowindex].Cells[0].Text;
                //    String newMeterNumber = GridView4.Rows[rowindex].Cells[9].Text;
                //    Approve_meterNum(meterNum2, newMeterNumber);
                //}


            }
            else if (e.CommandName == "Reject")
            {
                if (Session["personRoleId"].ToString() == "7")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow gvRow = GridView1.Rows[index];
                    int rowindex = gvRow.RowIndex;

                    String meterNum = GridView1.Rows[rowindex].Cells[0].Text;
                    Reject(meterNum);
                }
                else if (Session["personRoleId"].ToString() == "2")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow gvRow = GridView2.Rows[index];
                    int rowindex = gvRow.RowIndex;

                    String meterNum = GridView2.Rows[rowindex].Cells[0].Text;
                    Reject(meterNum);
                }
                else if (Session["personRoleId"].ToString() == "1")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow gvRow = GridView4.Rows[index];
                    int rowindex = gvRow.RowIndex;

                    String meterNum2 = GridView4.Rows[rowindex].Cells[0].Text;
                    Reject2(meterNum2);
                }
            }

            else if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = GridView4.Rows[index];
                int rowindex = gvRow.RowIndex;

                String SPN = GridView4.Rows[rowindex].Cells[6].Text;
                String Inspected_By = GridView4.Rows[rowindex].Cells[7].Text;
                String newMeter22 = GridView4.Rows[rowindex].Cells[9].Text;
                //Reject2(newMeter22);

            }
        }

        private void Approve(String meterNumber)
        {
            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", meterNumber);
            requestParameters.Add("SupervisionRemarks", "good" /*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            //requestParameters.Add("AmountRemaining", bal.Text);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }

        private void Approve_meterNum(String meterNumber2, String newMeterNumber, String SPN, String Inspected_By)
        {

            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/supervisor";
            requestParameters.Add("MeterNumber", meterNumber2);
            requestParameters.Add("SupervisionRemarks", newMeterNumber);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            requestParameters.Add("SupervisionSignature", SPN);
            requestParameters.Add("InspectedBy", Inspected_By);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }

        private void Reject(String meterNumber)
        {
            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", meterNumber);
            requestParameters.Add("SupervisionRemarks", "Check"/*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "NO");
            requestParameters.Add("ReasonForRejectingApproval", "Rejected");
            //requestParameters.Add("AmountRemaining", Amount_rem.Text);
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

        private void Reject2(String meterNumber2)
        {
            List<approval> responseList = new List<approval>();
            Response costomerInforResponse = new Response();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/supervisor";
            requestParameters.Add("MeterNumber", meterNumber2);
            requestParameters.Add("SupervisionRemarks", "Check"/*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "NO");
            requestParameters.Add("ReasonForRejectingApproval", "Rejected");
            //requestParameters.Add("AmountRemaining", Amount_rem.Text);
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

        protected void GridView4_RowCreated(object sender, EventArgs e)
        {

        }

        protected void GridView4_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }


        protected void GridView4_RowCommand1(object sender, EventArgs e)
        {

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
                if (Session["personRoleId"].ToString() == "4")
                {
                    GridView3.PageIndex = e.NewPageIndex;
                    GridView3.DataBind();
                }
                else if (Session["personRoleId"].ToString() == "7")
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    GridView1.DataBind();
                }
                else if (Session["personRoleId"].ToString() == "2")
                {
                    GridView2.PageIndex = e.NewPageIndex;
                    GridView2.DataBind();
                }
                else if (Session["personRoleId"].ToString() == "6")
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    GridView1.DataBind();
                }

        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataBind();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            GridView4.DataBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, EventArgs e)
        {
            GridView4.EditIndex = -1;
            meterreplacent();
        }
        protected void GridView4_RowCancelingEdit(object sender, EventArgs e)
        {
            GridView4.EditIndex = -1;
            meterreplacent();
        }

        protected void GridView1_RowEditing(object sender, EventArgs e)
        {
            Label oldmeter = (Label)GridView1.SelectedRow.Cells[0].FindControl("oldmeter");
            string oldmeterval = oldmeter.Text;
        }
        protected void GridView4_RowEditing(object sender, EventArgs e)
        {
            Label oldmeter = (Label)GridView1.SelectedRow.Cells[0].FindControl("oldmeter");
            string oldmeterval = oldmeter.Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView4.EditIndex = e.NewEditIndex;
            meterreplacent();


            //ShowData();
            //Label oldmeter = (Label)GridView1.SelectedRow.Cells[0].FindControl("oldmeter");
            //string oldmeterval = oldmeter.Text;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)


        {
        }
        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox newMeterNumber = GridView4.Rows[e.RowIndex].FindControl("txt_NewMeter") as TextBox;
            String assignedMeterNumber = newMeterNumber.Text;
            String meterNum2 = GridView4.Rows[e.RowIndex].Cells[0].Text;
            String newMeterNumber3 = GridView4.Rows[e.RowIndex].Cells[9].Text;
            String SPN = GridView4.Rows[e.RowIndex].Cells[6].Text;
            String Inspected_By = GridView4.Rows[e.RowIndex].Cells[7].Text;
            Approve_meterNum(meterNum2, assignedMeterNumber, SPN, Inspected_By);

        }
        protected void GridView1_RowUpdating(object sender, EventArgs e)
        {
        }

        protected void GridView4_RowUpdating(object sender, EventArgs e)
        {
        }

        protected void OnRowDataBound(object sender, EventArgs e)
        {
            //this.GridView1.Columns[0].Visible = false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            if (Session["personRoleId"].ToString() == "4")
            {
                ExportGridToExcel_View_Cap();
            }
            else
                if (Session["personRoleId"].ToString() == "7")
            {
                ExportGridToExcel_replaceQuick();
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                ExportGridToExcel_NotWorkedOn();
            }
            else
            if (Session["personRoleId"].ToString() == "6")
            {
                ExportGridToExcel_replaceQuick();
            }
            if (Session["personRoleId"].ToString() == "1")
            {
                ExportGridToExcel_meterreplacent();
            }
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

        private void ExportGridToExcel_replaceQuick()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "MTS" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);

            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        private void ExportGridToExcel_NotWorkedOn()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "MTS" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView2.GridLines = GridLines.Both;
            GridView2.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);

            GridView2.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        private void ExportGridToExcel_View_Cap()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "MTS" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView3.GridLines = GridLines.Both;
            GridView3.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);

            GridView3.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        private void ExportGridToExcel_meterreplacent()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "MTS" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView4.GridLines = GridLines.Both;
            GridView4.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);

            GridView4.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
       
        
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
            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)gr.FindControl("chkSelect");
                if (cb != null && cb.Checked)
                {

                }
            }
        }

        private void SearchMeter_Manager()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);
            using (HttpClient client = new HttpClient())
            {
                MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();
                Ressuveyall meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                meterDetails = JsonConvert.DeserializeObject<Ressuveyall>(serverResponse);
                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.Message = response.RequestMessage.ToString();


                var list = new List<Ressuveyall> { meterDetails };
                //Label2.Text = meterDetailsResponse.status_code.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView2.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataSource = list;
                    GridView2.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String errorMessage = meterDetailsResponse.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }

        private void SearchMeter_DCO_refundO()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);
            using (HttpClient client = new HttpClient())
            {
                MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();
                Ressuveyall meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                meterDetails = JsonConvert.DeserializeObject<Ressuveyall>(serverResponse);
                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.Message = response.RequestMessage.ToString();


                var list = new List<Ressuveyall> { meterDetails };
                //Label2.Text = meterDetailsResponse.status_code.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView1.Visible = false;
                    GridView1.DataSource = null;
                    GridView1.DataSource = list;
                    GridView1.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String errorMessage = meterDetailsResponse.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }
        private void SearchMeter_FieldOFFicer()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);
            using (HttpClient client = new HttpClient())
            {
                MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();
                Ressuveyall meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                meterDetails = JsonConvert.DeserializeObject<Ressuveyall>(serverResponse);
                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.Message = response.RequestMessage.ToString();


                var list = new List<Ressuveyall> { meterDetails };
                //Label2.Text = meterDetailsResponse.status_code.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView3.Visible = false;
                    GridView3.DataSource = null;
                    GridView3.DataSource = list;
                    GridView3.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String errorMessage = meterDetailsResponse.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }
      

        private void SearchMeter_PreSupervisor()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/info";
            requestParameters.Add("MeterNumber", txtmnumber.Text);
            using (HttpClient client = new HttpClient())
            {
                MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();
                metereplace meterDetails = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;

                meterDetails = JsonConvert.DeserializeObject<metereplace>(serverResponse);
                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.Message = response.RequestMessage.ToString();


                var list = new List<metereplace> { meterDetails };
                //Label2.Text = meterDetailsResponse.status_code.ToString();
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView4.Visible = false;
                    GridView4.DataSource = null;
                    GridView4.DataSource = list;
                    GridView4.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String errorMessage = meterDetailsResponse.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                }

            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {

            if (Session["personRoleId"].ToString() == "0")
            {
                SearchMeter_FieldOFFicer();
                GridView3.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "7")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                SearchMeter_Manager();
                GridView2.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                SearchMeter_PreSupervisor();
                GridView4.Visible = true;
            }



        }

        protected void District_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operations/Selete_District/District.aspx?someVal=1");
        }

        protected void Selected_Click(object sender, EventArgs e)
        {
            //string data = "";
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {

                        //string storid = row.Cells[1].Text;
                        //string storname = row.Cells[2].Text;
                        //string state = row.Cells[3].Text;
                        //data = data + storid + " ,  " + storname + " , " + state + "<br>";
                    }
                }
            }
            }

        protected void txtmnumber_Textamount(object sender, EventArgs e)
        {

        }

        protected void btnsearch_amount(object sender, EventArgs e)
        {
            SearchMeter_amount();
            GridView2.Visible = true;
            btnSelected.Visible = true;
        }

        private void SearchMeter_amount()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            requestParameters.Add("amount", search_amount.Text);
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/notworkedon/all/filter/{district_login}/{search_amount.Text}";

            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse meterDetailsResponse = new MeterDetialsResponse();
                Ressuveyall costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<Ressuveyall>>(serverResponse);
                

                meterDetailsResponse.status_code = response.StatusCode.ToString();
                meterDetailsResponse.message = response.RequestMessage.ToString();
                Label1.Text = meterDetailsResponse.status_code.ToString();

                //var list = new List<Ressuveyall> { costomerInfor };
                if (meterDetailsResponse.status_code.ToString() == "OK")
                {

                    GridView2.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataSource = result;
                    GridView2.DataBind();

                    
                }
                else
                {

                }
            }

            }
    }

}