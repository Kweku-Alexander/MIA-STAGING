using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTemplate.CaptureInfo
{
    public partial class captureInfo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void SearchMeter()
        {
            {
                //Method to search the endpoint for the meter details
                var requestParameters = new Dictionary<string, string>();
                var url = "http://52.176.53.54/miastaging/meter/quick/replacement/surveyed";
                requestParameters.Add("MeterNumber", search_txt.Text);
                using (HttpClient client = new HttpClient())
                {
                    MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();
                    MeterDetails meterDetails = null;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(requestParameters),
                                      System.Text.Encoding.UTF8, "application/json")).Result;
                    var serverResponse = response.Content.ReadAsStringAsync().Result;

                    meterDetails = JsonConvert.DeserializeObject<MeterDetails>(serverResponse);
                    meterDetailsResponse.status_code = response.StatusCode.ToString();
                    meterDetailsResponse.Message = response.RequestMessage.ToString();

                    //Label2.Text = meterDetailsResponse.status_code.ToString();
                    if (meterDetailsResponse.status_code.ToString() == "OK")
                    {
                        //append the details to the following textboxes in the form
                        cusName_txt.Text = meterDetails.CustomerName;
                        telephone_txt.Text = meterDetails.Telephone;
                        tarifClassDrop.Text = meterDetails.TariffClass;
                        oldMeterNumber_txt.Text = meterDetails.MeterNumber;
                        phase_drop.Text = meterDetails.Phase;

                        if (meterDetails.LocationOfMeter == "")
                        {
                            locOfMeterDrop.Text = "choose";
                        }
                        else
                        {
                            locOfMeterDrop.Text = meterDetails.LocationOfMeter;
                        }

                    }
                    else
                    {
                        //get the error message and show it in the alert dialog
                        meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                        String errorMessage = meterDetailsResponse.Message;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);

                    }

                }
            }
        }

        private void CaptureInformation()
        {

            String region_login = Session["region"].ToString();
            String district_login = Session["district"].ToString();
            String Name_login = Session["username"].ToString();

            //submit a formdate to the API endpoint
            List<createuser> responseList = new List<createuser>();
            MeterDetailsResponse meterDetailsResponse = new MeterDetailsResponse();

            var requestParameters = new Dictionary<string, string>();
            MultipartFormDataContent form = new MultipartFormDataContent();

            var url = "http://52.176.53.54/miastaging/meter/quick/replacement/post";
            form.Add(new StringContent(cusName_txt.Text), "CustomerName");
            form.Add(new StringContent(telephone_txt.Text), "TelephoneNumber");
            form.Add(new StringContent(oldMeterNumber_txt.Text), "OldMeterNumber");
            form.Add(new StringContent(newMeterNumber_txt.Text), "NewMeterNumber");
            form.Add(new StringContent(finalReading_txt.Text), "FinalReading");
            form.Add(new StringContent(phase_drop.Text), "Phase");
            form.Add(new StringContent(len_cable_txt.Text), "LengthOfCable");
            //form.Add(new StringContent(locOfMeterDrop.Text), "MeterLocation");
            //form.Add(new StringContent(location_txt.Text), "District");
            form.Add(new StringContent(tarifClassDrop.Text), "TariffClass");
            form.Add(new StringContent(balance_txt.Text), "RemainingBalance");
            form.Add(new StringContent(region_login), "Region");
            form.Add(new StringContent(district_login), "District");
            form.Add(new StringContent(Name_login), "0fficerInCharge");
            //form.Add(new StringContent("100"), "OldCode");
            //form.Add(new StringContent("200"), "NewCode");

            //FIRST CHECK FOR IMAGE 1
            //check if the file upload controller has a file
            if (FileUpload1.HasFile == false)
            {
                Console.WriteLine(FileUpload1.FileName);
            }
            else
            {
                //second check
                //check if it is an image and not anything else
                if (IsValidImage(FileUpload1.FileName))
                {
                    //get the file name of the first image and save to the server first
                    String fileUploadname1 = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileUploadname1));
                    String fullPathOfImage1 = Server.MapPath("~/Uploads/" + FileUpload1.FileName);

                    //get the same files saved in the Uploads folder and submit 
                    FileStream imageUpload1 = File.OpenRead(fullPathOfImage1);
                    form.Add(new StreamContent(imageUpload1), "fileUpload", Path.GetFileName(fullPathOfImage1));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File 1 is not an Image');", true);
                }


            }

            //FIRST CHECK FOR IMAGE 2
            //check if the file upload controller has a file
            if (FileUpload2.HasFile == false)
            {
                Console.WriteLine(FileUpload2.FileName);
            }
            else
            {
                //second check
                //check if it is an image and not anything else
                if (IsValidImage(FileUpload2.FileName))
                {
                    //get the file name of the second image and save to the server first
                    String fileUploadname2 = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileUploadname2));
                    String fullPathOfImage2 = Server.MapPath("~/Uploads/" + FileUpload2.FileName);

                    //get the same files saved in the Uploads folder and submit 
                    FileStream imageUpload2 = File.OpenRead(fullPathOfImage2);
                    form.Add(new StreamContent(imageUpload2), "fileUpload", Path.GetFileName(fullPathOfImage2));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File 2 is not an Image');", true);
                }


            }



            //FIRST CHECK FOR IMAGE 3
            //check if the file upload controller has a file
            if (FileUpload3.HasFile == false)
            {
                Console.WriteLine(FileUpload3.FileName);
            }
            else
            {
                //second check
                //check if it is an image and not anything else
                if (IsValidImage(FileUpload3.FileName))
                {
                    //get the file name of the third image and save to the server first
                    String fileUploadname3 = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                    FileUpload3.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileUploadname3));
                    String fullPathOfImage3 = Server.MapPath("~/Uploads/" + FileUpload3.FileName);

                    //get the same files saved in the Uploads folder and submit 
                    FileStream imageUpload3 = File.OpenRead(fullPathOfImage3);
                    form.Add(new StreamContent(imageUpload3), "fileUpload", Path.GetFileName(fullPathOfImage3));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File 3 is not an Image');", true);
                }


            }

            using (HttpClient client = new HttpClient())
            {
                createuser mresponse = new createuser();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpResponseMessage response = client.PostAsync(url, form).Result;
                var serverResponse = response.Content.ReadAsStringAsync().Result;


                mresponse.status_code = response.StatusCode.ToString();
                mresponse.message = response.RequestMessage.ToString();
                responseList.Add(mresponse);

                //Label1.Text = mresponse.status_code.ToString();
                //responseList.Add(mresponse);

                //Label1.Text = response.StatusCode.ToString();

                //Label1.Text= response.StatusCode.ToString();
                if (mresponse.status_code.ToString() == "Created")
                {
                    //get the success message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String successMessage = meterDetailsResponse.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + successMessage + "'); ", true);


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + successMessage + "');", true);


                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + successMessage + "'); document.location.href='captureInfo.aspx';", true);

                }
                else
                {
                    //get the error message and show it in the alert dialog
                    meterDetailsResponse = JsonConvert.DeserializeObject<MeterDetailsResponse>(serverResponse);
                    String errorMessage = meterDetailsResponse.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + errorMessage + "');", true);


                }

            }
        }

        private bool IsValidImage(string fileName)
        {
            Regex regex = new Regex(@"(.*?)\.(JPG|JPEG|PNG|GIF|BMP)$", RegexOptions.IgnoreCase);
            return regex.IsMatch(fileName);
        }

        protected void capture_info_btn_Click(object sender, EventArgs e)
        {
            CaptureInformation();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('successMessage'); document.location.href='captureInfo.aspx';", true);
            //Response.Redirect("~/CaptureInfo/captureInfo.aspx?someVal=1");

        }

        protected void search_txt_TextChanged(object sender, EventArgs e)
        {
            SearchMeter();
        }

        protected void phase_drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = phase_drop.SelectedValue;
        }

        protected void tarifClassDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = tarifClassDrop.SelectedValue;
        }

        protected void locOfMeterDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = locOfMeterDrop.SelectedValue;
        }

        protected void cusName_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}