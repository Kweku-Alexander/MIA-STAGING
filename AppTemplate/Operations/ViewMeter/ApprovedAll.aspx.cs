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
using System.Drawing;

namespace AppTemplate.Operations.ViewMeter
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowCreated(object sender,
         System.Web.UI.WebControls.GridViewRowEventArgs e)
        { 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String district_login = Session["district"].ToString();

            txtmnumber.Attributes.Add("autocomplete",
               "off");
            Inspected_id.Attributes.Add("autocomplete",
                "off");
            plot_id.Attributes.Add("autocomplete",
               "off");


            if (Session["personRoleId"].ToString() == "7")
            {
                GridView1.Visible = true;
            }
            else
            if (Session["personRoleId"].ToString() == "6")
            {
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                string district_id = Session["district_drop"].ToString();
                GridView2.Visible = true;
            }

            replaceQuick();
            surveyedmeters();
        }

        private void replaceQuick()
        {
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/refund/approved/all/{district_login}";



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
                string done = meterDetailsResponse.status_code.ToString();

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

        private void surveyedmeters()
        {

            var requestParameters = new Dictionary<string, string>();
            string district_id = Session["district_drop"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/admin/approved/surveyedmeters/all/{district_id}";



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
                string done = meterDetailsResponse.status_code.ToString();

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
        


        protected void searchTextBox_Leave(object sender, EventArgs e)
        {
        }

        



        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {
            if (Session["personRoleId"].ToString() == "7")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
               
                SearchMeter_PreSupervisor();
                GridView2.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
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

            Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

            Response.Redirect("ReplacementForm.aspx?someVal=1");

        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View_Details")
            {


                //mpe.Show();
                //ViewFullDetial();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCancelingEdit(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, EventArgs e)
        {
            Label oldmeter = (Label)GridView1.SelectedRow.Cells[0].FindControl("oldmeter");
            string oldmeterval = oldmeter.Text;
        }
        protected void GridView1_RowUpdating(object sender, EventArgs e)
        {
        }

        protected void OnRowDataBound(object sender, EventArgs e)
        {
            //this.GridView1.Columns[0].Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["personRoleId"].ToString() == "0")
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            else
           if (Session["personRoleId"].ToString() == "7")
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            else
            if (Session["personRoleId"].ToString() == "6")
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            if (Session["personRoleId"].ToString() == "1")
            {
                GridView2.PageIndex = e.NewPageIndex;
                GridView2.DataBind();
            }

        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            
            if (Session["personRoleId"].ToString() == "6")
            {
                ExportGridview1();
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                ExportGridview2();
            }
        }
        
            private void ExportGridview1()
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ApprovedMetersExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.replaceQuick();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        private void ExportGridview2()
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ApprovedMetersExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView2.AllowPaging = false;
                this.surveyedmeters();

                GridView2.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView2.HeaderRow.Cells)
                {
                    cell.BackColor = GridView2.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView2.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView2.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView2.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GridView2.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
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

        private void SearchMeter_DCO_refundO()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/info";
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
        private void SearchMeter_PreSupervisor()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/surveyed";
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

        private void InspectedBy_Officer()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String OfficerName = Inspected_id.Text;
            var url = $"http://52.176.53.54/miastaging/meter/admin/approvedmeters/{OfficerName}";

           
          
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
                OK.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView2.Visible = false;
                    
                    GridView3.DataSource = result;
                    GridView3.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }

       
        protected void btnsearch_Click(object sender, EventArgs e)
        {

            if (Session["personRoleId"].ToString() == "7")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                SearchMeter_DCO_refundO();
                GridView1.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                SearchMeter_PreSupervisor();
                GridView2.Visible = true;
                GridView3.Visible = false;
                Butt_inset.Visible = false;
            }



        }

        protected void btnsearch_Flied(object sender, EventArgs e)
        {
            InspectedBy_Officer();
            GridView3.Visible = true;
            btnexp.Visible = false;
            Butt_inset.Visible = true;
        }

        protected void Inspected_TextChanged(object sender, EventArgs e)
        {
            InspectedBy_Officer();
            GridView2.Visible = true;
        }

        protected void ExportToExcel2(object sender, EventArgs e)
        {
            InspectedBy_ExportGridview2();
        }

        private void InspectedBy_ExportGridview2()
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

        protected void Plot_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Plot_seach()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String plot = plot_id.Text;
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/search/approvedmeters/{plot}";



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
                OK.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                    GridView2.Visible = false;
                    GridView3.DataSource = null;
                   GridView3.DataSource = result;
                    GridView3.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }
            }

            }

            protected void btnsearch_Plot(object sender, EventArgs e)
        {
            //Method to search the endpoint for the meter details
            Plot_seach();
            GridView3.Visible = true;
            btnexp.Visible = false;
            Butt_inset.Visible = true;

        }
    }
}