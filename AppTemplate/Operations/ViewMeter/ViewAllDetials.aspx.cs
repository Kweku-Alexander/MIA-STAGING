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
    public partial class ViewAllDetials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Text = Session["mid"].ToString();

            List<viewAll> responseList = new List<viewAll>();

            var requestParameters = new Dictionary<string, string>();
            var url = "http://52.176.53.54/miaproduction/meter/refund/customer";
            requestParameters.Add("MeterNumber", Label7.Text);


            using (HttpClient client = new HttpClient())
            {
                viewAll mresponse = new viewAll();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                  System.Text.Encoding.UTF8, "application/json")).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();

                Label4.Text = mresponse.status_code.ToString();
                responseList.Add(mresponse);

                //Label1.Text= response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "OK")
                {
                    // url = "~/Operations/MainPage.aspx";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Token sent successful......');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not sent......');", true);

                }
            }
                //Label8.Text = Session["MeterNumb"].ToString();
                //Label7.Text = Session["CustomerN"].ToString();
                //Label9.Text = Session["ExpectedLoc"].ToString();
                //Label10.Text = Session["AuthBy"].ToString();
                //Label11.Text = Session["DigAddress"].ToString();
                //Label13.Text = Session["Rat"].ToString();
                //Label15.Text = Session["MeterRead"].ToString();
                //Label18.Text = Session["SizeOfCab"].ToString();
                //Label30.Text = Session["ServicePoleNum"].ToString();
                //Label20.Text = Session["TransformerNum"].ToString();
                //Label22.Text = Session["DateOfVis"].ToString();
                //Label31.Text = Session["InspectBy"].ToString();
                //Label25.Text = Session["TarifClas"].ToString();
                //Label27.Text = Session["GeoCod"].ToString();
                //Label32.Text = Session["IsMeterFault"].ToString();
                //Label33.Text = Session["Rmark"].ToString();

            }

            protected void btnapprove_Click(object sender, EventArgs e)
        {
            //Approve();
        }

        
       
        protected void btnreject_Click(object sender, EventArgs e)
        {
            //Reject();
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operations/ViewMeter/ApprovedMeters.aspx");
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataGridViewRow(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["mid"] = GridView1.SelectedRow.Cells[5].Text;

            Response.Redirect("ViewMeter/ViewAllDetials.aspx?someVal=1");
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
    }

}
