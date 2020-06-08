using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Operations.ViewMeter
{
    public partial class RejectedMeters : System.Web.UI.Page
    {
        protected void GridView1_RowCreated(object sender,
       System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            
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
                string district_id = Session["district_drop"].ToString();
                GridView2.Visible = true;
            }


            replaceQuick();
            Reject();

        }
        private void replaceQuick()
        {
            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/refund/unaprroved/all/{district_login}";



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

        private void Reject()
        {
            var requestParameters = new Dictionary<string, string>();
            string district_id = Session["district_drop"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/admin/unapproved/surveyedmeters/all/{district_id}";



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
        

        private void Approve()
        {
            List<approval> responseList = new List<approval>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", oldmeter.Text);
            requestParameters.Add("SupervisionRemarks", "good" /*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            requestParameters.Add("AmountRemaining", bal.Text);
            requestParameters.Add("AuthorizedBy", Label1.Text);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile Updated......');", true);
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

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", meterNumber);
            requestParameters.Add("SupervisionRemarks", "Check"/*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "NO");
            requestParameters.Add("ReasonForRejectingApproval", "Rejected");
            requestParameters.Add("AmountRemaining", bal.Text);
            requestParameters.Add("AuthorizedBy", Label1.Text);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile Updated......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error......');", true);

                }

            }
        }

        private void Grid_meter()
        {

        }

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

        private void MeterNumber()
        {
        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {





            Approve();
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            //if (e.CommandName == "View_Details")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow gvRow = GridView1.Rows[index];
            //    int rowindex = gvRow.RowIndex;

            //    String meterNum = GridView1.Rows[rowindex].Cells[0].Text;
            //    ViewFullDetial(meterNum);

            //    mpe.Show();
            //}

        }

        protected void GridView1_PageIndexChanging(object sender, EventArgs e)
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

        protected void btnexp_Click(object sender, EventArgs e)
        {
           
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
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView2.AllowPaging = false;
                this.Reject(); 

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
    }

}