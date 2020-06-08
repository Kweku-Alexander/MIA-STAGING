using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;



using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace AppTemplate.Operations
{
    public partial class ReplacedMeter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<New> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://52.176.53.54/PublishOutput/meter/replacement/admin/all");
            var consumeapi = hc.GetAsync("all");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<New>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobj = displayrecords.Result;
                GridView7.DataSource = meterobj;
                GridView7.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmnumber.Text))
            {
                (GridView7.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (GridView7.DataSource as DataTable).DefaultView.RowFilter = string.Format("OldMeterNumber='{0}'", txtmnumber.Text);

            }
        }


        protected void txtmnumber_TextChanged(object sender, EventArgs e)
        {

            //(GridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MeterNumber LIKE '{0}%'", txtmnumber.Text);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["mid"] = GridView7.SelectedRow.Cells[0].Text;
            Session["cname"] = GridView7.SelectedRow.Cells[1].Text;
            Session["tel"] = GridView7.SelectedRow.Cells[2].Text;
            Session["tele"] = GridView7.SelectedRow.Cells[5].Text;
            Response.Redirect("ReplacedForm.aspx?someVal=1");
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
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        private void ExportGridToExcel()
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
            GridView7.GridLines = GridLines.Both;
            GridView7.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);

            GridView7.RenderControl(htmltextwrtter);

            Response.Write(strwritter.ToString());
            Response.End();

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
