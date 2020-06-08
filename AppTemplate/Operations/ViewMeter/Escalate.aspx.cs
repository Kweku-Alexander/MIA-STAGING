using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.Operations.ViewMeter
{
    public partial class WebForm2 : System.Web.UI.Page
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
            escalate();
        }

        private void escalate()
        {

            var requestParameters = new Dictionary<string, string>();
            String district_login = Session["district"].ToString();
            var url = $"http://52.176.53.54/miastaging/meter/quick/replacement/admin/refund/escalated/all/{district_login}";



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

        private void Approve()
        {

            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }
            else
            {
                Response.Redirect("~/Account/LoginPage.aspx");
            }

            //oldmeter.Text  = GridView1.SelectedRow.Cells[0].Text;

            List<approval> responseList = new List<approval>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", "P08150040"  /*oldmeter.Text*/);
            requestParameters.Add("SupervisionRemarks", "good" /*txtsupervisorremark.Text*/);
            requestParameters.Add("SupervisonApprovalStatus", "YES");
            requestParameters.Add("ReasonForRejectingApproval", "Approved");
            requestParameters.Add("AmountRemaining", "50");
            requestParameters.Add("AuthorizedBy",/* Label1.Text*/ "jon");
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

        private void Reject()
        {
            oldmeter.Text = GridView1.SelectedRow.Cells[0].Text;

            List<approval> responseList = new List<approval>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/quick/replacement/admin/approverefund";
            requestParameters.Add("MeterNumber", oldmeter.Text);
            //requestParameters.Add("SupervisionRemarks", txtsupervisorremark.Text);
            //requestParameters.Add("SupervisonApprovalStatus", "YES");
            //requestParameters.Add("ReasonForRejectingApproval", "Approved");
            //requestParameters.Add("AmountRemaining", "AmountRem");
            //requestParameters.Add("AuthorizedBy", Label1.Text);
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
            Approve();

            //Session["Oldmeter"] = GridView1.SelectedRow.Cells[0].Text;

            //Response.Redirect("Replacement_Manager.aspx?someVal=1");


        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View_Details")
            {

                mpe.Show();
                //ViewFullDetial();
            }


            if (e.CommandName == "Reject")
            {

                Approve();
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
            this.escalate();

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