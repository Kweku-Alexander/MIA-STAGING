using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Data;

namespace AppTemplate.Test5
{
    public partial class Test5i : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            IEnumerable<Test55> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://my-json-server.typicode.com/dziks/MetersApi/PreSurveyedlist");
            var consumeapi = hc.GetAsync("PreSurveyedlist");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<Test55>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobj = displayrecords.Result;
                GridView1.DataSource = meterobj;
                GridView1.DataBind();
            }

            if (Session["username"] != null)
            {
                //Label1.Text = Session["username"].ToString();
            }
            else
            {
                Response.Redirect("");
            }

        }

        protected void searchTextBox_Leave(object sender, EventArgs e)
        {


            //if (string.IsNullOrEmpty(txtmnumber.Text))
            //{
            //    (GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //}
            //else
            //{
            //    (GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber='{0}'", txtmnumber.Text);


            //}
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {


            //if (string.IsNullOrEmpty(txtmnumber.Text))
            //{
            //    (GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //}
            //else
            //{
            //    (GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber='{0}'", txtmnumber.Text);


            //}
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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["mid"] = GridView1.SelectedRow.Cells[0].Text;
            Session["cname"] = GridView1.SelectedRow.Cells[1].Text;
            Session["tel"] = GridView1.SelectedRow.Cells[2].Text;
            Session["Inspect"] = GridView1.SelectedRow.Cells[5].Text;


            Response.Redirect("superviorForm.aspx?someVal=1");
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
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
           /* (GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber LIKE '{0}%'", txtmnumber.Text)*/;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        //protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (GridView1.Rows.Count > 0)
        //    {
        //        System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
        //        GridView1.RenderControl(htmlWrite1);

        //        GridView1.AllowPaging = false;
        //        Search();
        //        sh.ExportToExcel(GridView1, "Report");
        //    }
        //}
    }
}