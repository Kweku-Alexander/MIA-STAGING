using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AppTemplate
{

    public class MeterDetailsResponse
    {
        public string status_code { get; set; }
        public string Message { get; set; }
    }
    public class MeterDetails
    {
        public string CustomerName { get; set; }
        public string MeterNumber { get; set; }
        public string Telephone { get; set; }
        public string TariffClass { get; set; }
        public string Phase { get; set; }
        public string LocationOfMeter { get; set; }

    }
    public class Role
    {
        public string username { get; set; }
        public string roleId { get; set; }

        public string role { get; set; }

        public string district { get; set; }
        public string region { get; set; }
    }
    public class Response
    {
        public string status_code { get; set; }
        public string message { get; set; }
    }

    public class MeterDetials
    {
        public string DisplayMeterID { get; set; }
        public string meterid { get; set; }
        public string Transaction_Date { get; set; }
       
        public string Purchasing_Amount { get; set; }

        public string VendingStation { get; set; }
        public string ReceiptNo { get; set; }
        public string userid { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string Name { get; set; }
    }

    public class Resend
    {
        public string Id { get; set; }
        public string MeterNumber { get; set; }
        public string AccountNumber { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }
        public string Amount { get; set; }
        public string Token { get; set; }
       
    }

    public class MeterDetialsResponse
    {
        public string status_code { get; set; }
       
        public string message { get; set; }
    }

    public class CostomerInfor
    {
        public string OldMeterNumber { get; set; }

        public string CustomerName { get; set; }
        public string NewMeterNumber { get; set; }
        public string Phase { get; set; }
        public string AccountNumber { get; set; }
        public string MeterLocation { get; set; }
        public string DateOfInstallation { get; set; }
        public string TariffClass { get; set; }
        public string MeterType { get; set; }
        public string TelephoneNumber { get; set; }
        public string District { get; set; }

        public string FinalReading { get; set; }
        public string PoleNumber { get; set; }

        public string Region { get; set; }
        public string MeterAddress { get; set; }
        public string MeterUserMobileNumber { get; set; }

        public string MeterUserName { get; set; }

        public string OfficerInCharge { get; set; }
        public string RemainingBalance { get; set; }
        public string ImageUrlOne { get; set; }
        public string ImageUrlTwo { get; set; }
        public string ImageUrlThree { get; set; }

        
    }

    public class autorefund
    {
        public string status_code { get; set; }
        public string message { get; set; }
    }

    public class refundlist
    {
        public string MeterNumber { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string Amount { get; set; }
        public string Token { get; set; }
        public string CreatedAt { get; set; }
    }
    public class Ressuveyall
    {
        public string ReasonForRejectingApproval { get; set; }
        
        public string status_code { get; set; }
        public string message { get; set; }
        public string OldMeterNumber { get; set; }
        //public string dmms { get; set; }
       // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string TelephoneNumber { get; set; }
        public string FinalReading { get; set; }
        public string NewMeterNumber { get; set; }
        public string NewCode { get; set; }

        public string AuthorizedBy { get; set; }
        
        public string SupervisorDate { get; set; }
        public string RemainingBalance { get; set; }
        
        public string District { get; set; }
        public string ImageUrlOne { get; set; }
        public string ImageUrlTwo { get; set; }
        public string ImageUrlThree { get; set; }

        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        //public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string ExtraRemarks { get; set; }
        public string MeterReading { get; set; }
        public string GeoCode { get; set; }
        public string Remarks { get; set; }
        public string DateOfVisit { get; set; }
        public string SupervisonApprovalStatus { get; set; }
        public string InspectedBy { get; set; }
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
        public string ImageThreeUrl { get; set; }

        public static implicit operator List<object>(Ressuveyall v)
        {
            throw new NotImplementedException();
        }
    }

    public class metereplace
    {

        public string status_code { get; set; }
        public string message { get; set; }
        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string MeterReading { get; set; }
        public string Remarks { get; set; }
        public string IsMeterFaulty { get; set; }
        public string DateOfVisit { get; set; }
        public string RemainingBalance { get; set; }
        public string TariffClass { get; set; }
        public string AuthorizedBy { get; set; }
        public string InspectedBy { get; set; }
        
        public string District { get; set; }
        public string GeoCode { get; set; }
        public string ExtraRemarks { get; set; }
        public string ImageUrlThree { get; set; }
        public string SupervisonApprovalStatus { get; set; }
        public string SupervisionRemarks { get; set; }
        public string SPN { get; set; }
        public string Phase { get; set; }
        public string ReasonForRejectingApproval { get; set; }       
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
        public string ImageThreeUrl { get; set; }




    }


    public class NotWorkedOn
    {

        public string status_code { get; set; }
        public string message { get; set; }
        public string OldMeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string TelephoneNumber { get; set; }
        public string FinalReading { get; set; }
        public string NewMeterNumber { get; set; }
        public string NewCode { get; set; }
        public string SupervisorDate { get; set; }
        public string RemainingBalance { get; set; }

        public string District { get; set; }
        public string ImageUrlOne { get; set; }
        public string ImageUrlTwo { get; set; }
        public string ImageUrlThree { get; set; }

        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        //public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string MeterReading { get; set; }
        public string GeoCode { get; set; }
        public string Remarks { get; set; }
        public string SupervisonApprovalStatus { get; set; }
        public string InspectedBy { get; set; }
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
        public string ImageThreeUrl { get; set; }




    }

    public class Test55
    {
        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string MeterReading { get; set; }
        public string GeoCode { get; set; }
        public string TariffClass { get; set; }
        public string Remarks { get; set; }
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }

    }


    public class New
    {
        public string CustomerName { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string OldMeterNumber { get; set; }
        public string NewMeterNumber { get; set; }
        public string MeterUserMobileNumber { get; set; }
        public string FinalReading { get; set; }
        public string AmountRemaining { get; set; }
        public string LengthOfCable { get; set; }
        public string ImageUrlOne { get; set; }
        public string ImageUrlTwo { get; set; }
        public string ImageUrlThree { get; set; }



    }


    public class Role_Drop
    { 
        public string RoleId { get; set; }
        public string Role { get; set; }

    }

    public class Region_Drop
    {
        public string regionId { get; set; }
        public string region { get; set; }

    }

    public class District_Drop
    {
        public string districtId { get; set; }
        public string district { get; set; }
        public string regionId { get; set; }
        
    }

    public class ploit_Drop
    {
       

    }

    public class createuser
    {
        public string status_code { get; set; }
        public string message { get; set; }
    }

    public class viewAll
    {
        public string status_code { get; set; }
        public string message { get; set; }
        public string OldMeterNumber { get; set; }
        public string NewMeterNumber { get; set; }
        public string CustomerName { get; set; }
        public string TelephoneNumber { get; set; }
    }
    public class fetchRoles
    {
        public string username { get; set; }
        public string roleId { get; set; }
    }

    public class approval
    {
        public string status_code { get; set; }
        public string message { get; set; }
    }

    public class reject
    {
        public string status_code { get; set; }
        public string message { get; set; }
    }
    public class approvedMeter
    {
        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string ExpectedLocation { get; set; }
        public string AuthorizedBy { get; set; }
        //public string ExpectedLocation { get; set; }
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
        public string ImageThreeUrl { get; set; }

        public string DigitalAddress { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string Rating { get; set; }
        public string MeterReading { get; set; }
        public string SizeOfCable { get; set; }
        //public string ExpectedLocation { get; set; }
        public string ServicePoleNumber { get; set; }
        public string TransformerNumber { get; set; }

        public string DateOfVisit { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string InspectedBy { get; set; }
        public string TariffClass { get; set; }
        public string GeoCode { get; set; }
        //public string ExpectedLocation { get; set; }
        public string IsMeterFaulty { get; set; }
        public string Remarks { get; set; }



        public string status_code { get; set; }
        public string message { get; set; }

    }

    public class rejectedMeter
    {
        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string CustomerName { get; set; }
        public string ExpectedLocation { get; set; }
        public string AuthorizedBy { get; set; }
        //public string ExpectedLocation { get; set; }
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
    }

    public class alluser
    {
        public string MeterNumber { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string roleId { get; set; }
    }

    public class logged
    {
        public string username { get; set; }
        //public string dmms { get; set; }
        // public List<MyTest> dmms { get; set; }
        public string roleId { get; set; }
        public string role { get; set; }
        public string district { get; set; }
        //public string ExpectedLocation { get; set; }
        public string region { get; set; }
        public string lastLogin { get; set; }
    }
}