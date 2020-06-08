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

namespace AppTemplate.AssignMeter
{
    public partial class AssignMeterContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                district();
            }
        }

        private string FixApiResponseString(string input)
        {
            input = input.Replace("\\", string.Empty);
            input = input.Trim('"');
            return input;
        }
        private void district()
        {
            var requestParameters = new Dictionary<string, string>();
            String district = "South Tema District";
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/plot/{district}";


            using (HttpClient client = new HttpClient())
            {
                MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
                //ploit_Drop costomerInfor = null;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                //var serverResponse = response.Content.ReadAsStringAsync().Result.AsEnumerable<String>();
                //Man4350
                var serverResponse = response.Content.ReadAsAsync<List<String>>().Result;

                //var content3 = serverResponse[0];

                List<String> plotList = new List<String>();
                //plotList=serverResponse.

                var content = response.Content;
                //var jsonResult = JsonConvert.DeserializeObject(serverResponse).ToString();
                //var result = JsonConvert.DeserializeObject<Ploit_Drop>(jsonResult);

                //var result = JsonConvert.DeserializeObject<List<ploit_Drop>>(serverResponse);


                costomerInforResponse.status_code = response.StatusCode.ToString();
                costomerInforResponse.message = response.RequestMessage.ToString();


                lblpopup.Text = costomerInforResponse.status_code.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (costomerInforResponse.status_code.ToString() == "OK")
                {
                    DropDown_ploit.DataSource = serverResponse;
                    //DropDown_ploit.DataTextField = serverResponse[1];
                    //DropDown_ploit.DataValueField = serverResponse[0];
                    DropDown_ploit.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }

            }
        }

        protected void old_meter_num0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void customer_nm_TextChanged(object sender, EventArgs e)
        {

        }

        protected void digital_add_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Plot_seach();
            GridView1.Visible = true;
        }

        private void Plot_seach()
        {
            //Method to search the endpoint for the meter details
            var requestParameters = new Dictionary<string, string>();
            String plot = DropDown_ploit.Text/*"03010340450302"*/;
            var url = $"http://52.176.53.54/miaproduction/meter/quick/replacement/search/approvedmeters/{plot}";



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
                lblpopup.Text = meterDetailsResponse.status_code.ToString();

                if (meterDetailsResponse.status_code.ToString() == "OK")
                {
                    //append the details to the following textboxes in the form
                   
                    GridView1.DataSource = null;
                    GridView1.DataSource = result;
                    GridView1.DataBind();

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('not created......');", true);

                }
            }

        }

        protected void DropDown_ploit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = DropDown_ploit.SelectedValue;
        }

       
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, EventArgs e)
        {

        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
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
                this.Plot_seach();

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

        
    }
}