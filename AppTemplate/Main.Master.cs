using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Usename.Text = Session["username"].ToString();


                if (Session["personRoleId"].ToString() == "4")
                {
                    role_id_label.Text = Session["personRole"].ToString();
                }
                else if (Session["personRoleId"].ToString()=="7")
                {
                    role_id_label.Text = Session["personRole"].ToString();
                    
                }
                else if (Session["personRoleId"].ToString() == "2")
                {
                    role_id_label.Text = Session["personRole"].ToString();
                }
                else if (Session["personRoleId"].ToString() == "6")
                {
                    role_id_label.Text = Session["personRole"].ToString();
                }
                else if (Session["personRoleId"].ToString() == "1")
                {
                    role_id_label.Text = Session["personRole"].ToString();
                }


            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void sitemap1_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            //Check for Roles or users here
            //for Field Officer
            if (Session["personRoleId"].ToString() == "4")

            {
                if (e.Item.Text == "Account" || e.Item.Text == "Manager" || e.Item.Text == "Supervisor" || e.Item.Text == "Refund Meters" || e.Item.Text == "Report")
                {
                    e.Item.Parent.ChildItems.Remove(e.Item);
                }
            }
            //for DCO
            else if (Session["personRoleId"].ToString() == "7")
            {
                if (e.Item.Text == "Account" || e.Item.Text == "Approved Meters" || e.Item.Text == "Rejected Meters" || e.Item.Text == "Manager" || e.Item.Text == "Report")
                {
                    e.Item.Parent.ChildItems.Remove(e.Item);
                }
            }
            //for D Manager
            else if (Session["personRoleId"].ToString() == "2")
            {
                if (e.Item.Text == "Capture Info" || e.Item.Text == "Supervisor" || e.Item.Text == "Refund Meters" || e.Item.Text == "Report")
                {
                    e.Item.Parent.ChildItems.Remove(e.Item);
                }
            }
            //for Refound office
            else if (Session["personRoleId"].ToString() == "6")
            {
                if (e.Item.Text == "Capture Info" || e.Item.Text == "Account" || e.Item.Text == "Manager" || e.Item.Text == "Approved Meters" || e.Item.Text == "Rejected Meters" || e.Item.Text == "Report")
                {
                    e.Item.Parent.ChildItems.Remove(e.Item);
                }
            }
            else if (Session["personRoleId"].ToString() == "1")
            {
                if (e.Item.Text == "Capture Info" || e.Item.Text == "Account" || e.Item.Text == "Report" || e.Item.Text == "Escalated Meters" || e.Item.Text == "Manager" || e.Item.Text == "Refund Meters")
                {
                    e.Item.Parent.ChildItems.Remove(e.Item);
                }
            }

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();
            Response.Redirect("~/LoginPage2.aspx");
        }
    }
}