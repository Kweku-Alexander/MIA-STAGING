using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Operations.Resend_Refund
{
    public partial class Resend_refund : System.Web.UI.Page
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
            if (Session["personRoleId"].ToString() == "0")
            {
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                Refund_List();
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "6")
            {
                GridView1.Visible = true;
               
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                GridView1.Visible = true;
            }
            Refund_List();
        }

        private void Refund_List()
        {
            IEnumerable<refundlist> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://52.176.53.54/miaproduction/meter/admin/automatic/refund/all");
            var consumeapi = hc.GetAsync("all");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<refundlist>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobj = displayrecords.Result;
                GridView1.DataSource = meterobj;
                GridView1.DataBind();
                
            }


        }
        private void SearchCustomers2()
        {
            DataTable dtUsers = (DataTable)ViewState["NEWGRID"];
            DataView dvUsers = new DataView(dtUsers);
            dvUsers.RowFilter = "MeterNumber like '%" + txtSearch.Text + "%' ";
            GridView1.DataSource = dvUsers;
            GridView1.DataBind();
        }
             
        private void SearchCustomers()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT * FROM vw_Accommodation1";
                    if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    {
                        sql += " WHERE MeterNumber LIKE '%' + @MeterNumber + '%'";
                        cmd.Parameters.AddWithValue("@MeterNumber", txtSearch.Text.Trim());
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
        //private void ViewFullDetial()
        //{
        //    //oldmeter.Text = Session["Oldmeter"].ToString();

        //    var requestParameters = new Dictionary<string, string>();
        //    var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/info";
        //    requestParameters.Add("MeterNumber", "P10002005"/*oldmeter.Text*/);


        //    using (HttpClient client = new HttpClient())
        //    {
        //        MeterDetialsResponse costomerInforResponse = new MeterDetialsResponse();
        //        CostomerInfor costomerInfor = null;
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //        HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
        //                          System.Text.Encoding.UTF8, "application/json")).Result;
        //        var serverResponse = response.Content.ReadAsStringAsync().Result;

        //        costomerInfor = JsonConvert.DeserializeObject<CostomerInfor>(serverResponse);
        //        costomerInforResponse.status_code = response.StatusCode.ToString();
        //        costomerInforResponse.message = response.RequestMessage.ToString();

        //        lblpopup.Text = costomerInforResponse.status_code.ToString();

        //        //Label1.Text= response.StatusCode.ToString();
        //        if (costomerInforResponse.status_code.ToString() == "OK")
        //        {
        //            old_meter_num.Text = costomerInfor.OldMeterNumber;
        //            new_meter_num.Text = costomerInfor.NewMeterNumber;
        //            phase.Text = costomerInfor.Phase;
        //            customer_nm.Text = costomerInfor.CustomerName;
        //            Acc_num.Text = costomerInfor.AccountNumber;
        //            traff_class.Text = costomerInfor.TariffClass;
        //            tele.Text = costomerInfor.TelephoneNumber;
        //            remain_bal.Text = costomerInfor.RemainingBalance;
        //            pole_number.Text = costomerInfor.PoleNumber;
        //            digital_add.Text = costomerInfor.MeterLocation;
        //            meter_type.Text = costomerInfor.MeterType;
        //            district.Text = costomerInfor.District;
        //            region.Text = costomerInfor.Region;
        //            meter_address.Text = costomerInfor.MeterAddress;
        //            meter_Mob.Text = costomerInfor.MeterUserMobileNumber;
        //            meter_used.Text = costomerInfor.MeterUserName;
        //            officer_charge.Text = costomerInfor.OfficerInCharge;
        //            dateofvist.Text = costomerInfor.DateOfInstallation;
        //            Final.Text = costomerInfor.FinalReading;
        //            Image1.ImageUrl = costomerInfor.ImageUrlOne;
        //            Image2.ImageUrl = costomerInfor.ImageUrlTwo;
        //            Image3.ImageUrl = costomerInfor.ImageUrlThree;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Meter not found......');", true);

        //        }

        //    }
        //}


        protected void searchTextBox_Leave(object sender, EventArgs e)
        {
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //SearchCustomers();
            SearchCustomers2();
        }



        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers2();
            /*(GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber LIKE '{0}%'", txtmnumber.Text)*/
            ;
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

            Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

            Response.Redirect("ReplacementForm.aspx?someVal=1");

        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View_Details")
            {
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

        protected void btnexp_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
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

        private void ExportGridToExcel()
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Charset = "";
            //string FileName = "MTS" + DateTime.Now + ".xls";
            //StringWriter strwritter = new StringWriter();
            //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //GridView1.GridLines = GridLines.Both;
            //GridView1.HeaderStyle.Font.Bold = true;
            ////GridView1.RenderControl(htmltextwrtter);

            //GridView1.RenderControl(htmltextwrtter);
            //Response.Write(strwritter.ToString());
            //Response.End();

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Refund_List();

        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers();
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
    }
    //protected void CheckBoxList1_TextChanged(object sender, EventArgs e)
    //{
    //    //loop all checkboxlist items
    //    foreach (ListItem item in CheckBoxList1.Items)
    //    {
    //        if (item.Selected == true)
    //        {
    //            //loop all the gridview columns
    //            for (int i = 0; i < GridView1.Columns.Count; i++)
    //            {
    //                //check if the names match and hide the column
    //                if (GridView1.HeaderRow.Cells[i].Text == item.Value)
    //                {
    //                    GridView1.Columns[i].Visible = false;
    //                }
    //            }
    //        }
    //    }
    //}
}