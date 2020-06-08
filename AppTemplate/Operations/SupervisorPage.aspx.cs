using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AppTemplate.Operations
{
    public partial class SupervisorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Ressuveyall> meterobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://102.133.238.166/PublishOutput/meter/");
            var consumeapi = hc.GetAsync("supervisor");
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
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

        }
    }
}