using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Data;

namespace AppTemplate.Operations
{
    public partial class DetialsModelWeb : System.Web.UI.Page
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
            //IEnumerable<Ressuveyall> meterobj = null;
            //HttpClient hc = new HttpClient();
            //hc.BaseAddress = new Uri("http://52.176.53.54/PublishOutput/meter/admin/surveyedmeters/");
            //var consumeapi = hc.GetAsync("all");
            //consumeapi.Wait();

            //var readdata = consumeapi.Result;
            //if (readdata.IsSuccessStatusCode)
            //{
            //    var displayrecords = readdata.Content.ReadAsAsync<IList<Ressuveyall>>();
            //    //var displayrecords = readdata.Content.results;
            //    //var displayrecords = readdata.Content.
            //    displayrecords.Wait();
            //    meterobj = displayrecords.Result;
            //    GridView1.DataSource = meterobj;
            //    GridView1.DataBind();
            //}

            //if (Session["username"] != null)
            //{
            //    //Label1.Text = Session["username"].ToString();
            //}
            //else
            //{
            //    Response.Redirect("");
            //}

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            IEnumerable<Ressuveyall> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://52.176.53.54/PublishOutput/meter/admin/surveyedmeters/");
            var consumeapi = hc.GetAsync("all");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<Ressuveyall>>();
                //var displayrecords = readdata.Content.results;
                //var displayrecords = readdata.Content.
                displayrecords.Wait();
                meterobj = displayrecords.Result;
                GridView1.DataSource = meterobj; 
                GridView1.DataBind();
            }

            mpe.Show();
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
           
        }
    }
}