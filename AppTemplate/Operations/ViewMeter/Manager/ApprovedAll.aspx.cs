﻿using Newtonsoft.Json;
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

namespace AppTemplate.Operations.ViewMeter.Manager
{
    public partial class WebForm1 : System.Web.UI.Page
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
            else
            if (Session["personRoleId"].ToString() == "7")
            {
                GridView1.Visible = true;
            }
            else if (Session["personRoleId"].ToString() == "2")
            {
                GridView1.Visible = true;
            }
            else
            if (Session["personRoleId"].ToString() == "6")
            {
                GridView1.Visible = true;
            }
            if (Session["personRoleId"].ToString() == "1")
            {
                GridView2.Visible = true;
            }

            replaceQuick();
            Approved();
        }

       

        private void Approved()
        {
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/admin/approved/surveyedmeters/all/{district_login}";



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

        
        
        //private void ViewFullDetial()
        //{
        //    //oldmeter.Text = Session["Oldmeter"].ToString();

        //    var requestParameters = new Dictionary<string, string>();
        //    var url = "http://52.176.53.54/PublishOutput/meter/quick/replacement/info";
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
        }



        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {

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



        protected void ExportToExcel(object sender, EventArgs e)
        {

            if (Session["personRoleId"].ToString() == "2")
            {
                replaceQuick();
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
                this.Approved();

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
            if (Session["personRoleId"].ToString() == "4")
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            if (Session["personRoleId"].ToString() == "5")
            {
                GridView2.PageIndex = e.NewPageIndex;
                GridView2.DataBind();
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
    }
}