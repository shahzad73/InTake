using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SearchCriteria"] = "";    //reset search critera so that intake form do not show back to search button

        if (Request.QueryString["op"] != null)
        {
            if (Request.QueryString["op"] == "logout")
            {
                Context.Session["UserID"] = null;
                Response.Redirect("login.aspx"); 
            }

            if (Request.QueryString["op"] == "NewInTake")
            {
                string s = DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen("Insert into InTake(DateTaken, TakenByUserID, ReportCurrentStatusID, ReportRegionDMAID, isNewlyCreated, injuryid, CountryID, ReferralSourceID, isEgypt) values('" + DateTime.Now.ToString() + "', " + Session["UserID"].ToString() + ", 1, -1, 1, 2, 1, -1, 'No')", Context);
                DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen("Insert into StatusTracking(StatusChangeDate, InTakeID, StatusID, ActionTakenByUser) values('" + DateTime.Now.ToString() +"', " + s + ", 1, " + Session["UserID"].ToString() + ")", Context);
                Response.Redirect("intakeedit.aspx?id=" + s + "&sec=1");
            }
            if (Request.QueryString["op"] == "duplicate")
            {
                string s = DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen("Insert into InTake(DateTaken, TakenByUserID, ReportCurrentStatusID, isNewlyCreated, ReportRegionDMAID, InjuryID, CountryID, fname, lname, dob, email, maritalstatus, spousename, address1, address2, city, state, zip, phone1, phone2, ssn, secondarycontactname, secondarycontactaddress, secondarycontactphone, secondarycontactrelationship, AccidentDate, AccidentTime, Accidentampm, Accidentdrivername, AccidentPassangerName, AccidentCollisionDesc, AccidentLocation, AccidentCity, AccidentState, AccidentHelmet, AccidentSeatBelt, AccidentEmployed, ConversationwithAdverseDriver, AccidentOtherAccidentReport, AccidentClientCited, AccidentAdverseCited, AccidentPropertyDamage, AccidentPoliceAgencyName, AccidentPoliceReportNumber, VehicleInfoYear, VehicleInfoMake, VehicalInfoModel, VehicleInfoType, ClientInsuranceCompanyName, ClientInsurancePolicyNumber, ClientInsurancePolicyEffectiveDate, ClientInsurancePolicyExpirationDate, ClientInsurancClaimNumber, ClientInsurancPolicyAdjusterName, ClientInsurancAddress, ClientInsurancPhone, ClientInsurancFax, ClientInsurancCollisionCoverage, ClientInsurancComprehensiveCoverage, ClientInsurancRentalCoverage, ClientInsurancMedPayAmount, ClientInsurancUninsuredPolicyLimit, ClientInsurancUnderInsuredPolicyLimit, AlternateInsuranceCompanyName, AlternateInsurancePolicyNumber, AlternateInsuranceAlternateUMUIMPolicyLimit, AdverseDriverDriverName, AdverseDriverDrivePhone, AdverseDriverDriveAddress, AdverseDriverOwnerName, AdverseDriverOwnerPhone, AdverseDriverOwnerAddress, AdverseDriverVehicleYear, AdverseDriverVehicleMake, AdverseDriverVehicleModel, AdverseDriverInsuranceName, AdverseDriverInsurancePolicyNumber, AdverseDriverInsuranceClaimNumber, AdverseDriverInsuranceAdjusterName, AdverseDriverInsuranceAddress, AdverseDriverInsurancePhone, AdverseDriverInsuranceFax, ClientInjuryClassificationSoftTissue, ClientInjuryClassificationRoadRash, ClientInjuryClassificationFractures, ClientInjuryClassificationHead, ClientInjuryClassificationTrauma, ClientInjuryClassificationOrganInjuries, ClientInjuryClassificationDeath, ClientInjuryClassificationOther, ClientTreatmentTreatmenttoDate, ClientTreatmentTreatmentFuture, ClientTreatmentPreexistingConditions, HealthInsuranceName, HealthInsuranceAddress, HealthInsurancePhone, HealthInsurancePolicyNumber, HealthInsuranceGroupNumber, ClientEmployername, ClientEmployerAddress, ClientEmployerPhone, ClientEmployerJobTitle, ClientEmployerJobDesc, ClientEmployerRateOfPay, ClientEmployerWorkMissed, PriorInsuranceClaimsDetails, CurrentPriorAttorneyName, CurrentPriorAttorneyFirm, CurrentPriorAttorneyAddress, CurrentPriorAttorneyPhone, CurrentPriorAttorneyWithDrawerReason, CurrentPriorAttorneyAttorny, AdditionalNotes, LastUpdated, ReferralSourceID, isEgypt, isClientDead, allfields, AccidentCountry, country, witness, ReffererSourcesNotes, IsClientDeadListClaimants, gender, MethodOfInitialContact, ClientVehicleLienHolder, ClientVehicleCustomPartsEquipment, ClientVehiclePersonalProperty, ClientVehicleDamageEstimate, ClientVehicleEstimatedMarketValue, ClientVehiclePhotos, ClientVehicleCurrentLocation, ClientVehicleBikeType, AdverseDriverRecordedStatement, HealthInsurancePolicyHolder, HealthInsuranceGroupName, ClientEmployerNameOfSupervisor) (Select '" + DateTime.Now.ToString() + "', " + Session["UserID"].ToString() + ", ReportCurrentStatusID, 0, ReportRegionDMAID, InjuryID, CountryID, fname, lname, dob, email, maritalstatus, spousename, address1, address2, city, state, zip, phone1, phone2, ssn, secondarycontactname, secondarycontactaddress, secondarycontactphone, secondarycontactrelationship, AccidentDate, AccidentTime, Accidentampm, Accidentdrivername, AccidentPassangerName, AccidentCollisionDesc, AccidentLocation, AccidentCity, AccidentState, AccidentHelmet, AccidentSeatBelt, AccidentEmployed, ConversationwithAdverseDriver, AccidentOtherAccidentReport, AccidentClientCited, AccidentAdverseCited, AccidentPropertyDamage, AccidentPoliceAgencyName, AccidentPoliceReportNumber, VehicleInfoYear, VehicleInfoMake, VehicalInfoModel, VehicleInfoType, ClientInsuranceCompanyName, ClientInsurancePolicyNumber, ClientInsurancePolicyEffectiveDate, ClientInsurancePolicyExpirationDate, ClientInsurancClaimNumber, ClientInsurancPolicyAdjusterName, ClientInsurancAddress, ClientInsurancPhone, ClientInsurancFax, ClientInsurancCollisionCoverage, ClientInsurancComprehensiveCoverage, ClientInsurancRentalCoverage, ClientInsurancMedPayAmount, ClientInsurancUninsuredPolicyLimit, ClientInsurancUnderInsuredPolicyLimit, AlternateInsuranceCompanyName, AlternateInsurancePolicyNumber, AlternateInsuranceAlternateUMUIMPolicyLimit, AdverseDriverDriverName, AdverseDriverDrivePhone, AdverseDriverDriveAddress, AdverseDriverOwnerName, AdverseDriverOwnerPhone, AdverseDriverOwnerAddress, AdverseDriverVehicleYear, AdverseDriverVehicleMake, AdverseDriverVehicleModel, AdverseDriverInsuranceName, AdverseDriverInsurancePolicyNumber, AdverseDriverInsuranceClaimNumber, AdverseDriverInsuranceAdjusterName, AdverseDriverInsuranceAddress, AdverseDriverInsurancePhone, AdverseDriverInsuranceFax, ClientInjuryClassificationSoftTissue, ClientInjuryClassificationRoadRash, ClientInjuryClassificationFractures, ClientInjuryClassificationHead, ClientInjuryClassificationTrauma, ClientInjuryClassificationOrganInjuries, ClientInjuryClassificationDeath, ClientInjuryClassificationOther, ClientTreatmentTreatmenttoDate, ClientTreatmentTreatmentFuture, ClientTreatmentPreexistingConditions, HealthInsuranceName, HealthInsuranceAddress, HealthInsurancePhone, HealthInsurancePolicyNumber, HealthInsuranceGroupNumber, ClientEmployername, ClientEmployerAddress, ClientEmployerPhone, ClientEmployerJobTitle, ClientEmployerJobDesc, ClientEmployerRateOfPay, ClientEmployerWorkMissed, PriorInsuranceClaimsDetails, CurrentPriorAttorneyName, CurrentPriorAttorneyFirm, CurrentPriorAttorneyAddress, CurrentPriorAttorneyPhone, CurrentPriorAttorneyWithDrawerReason, CurrentPriorAttorneyAttorny, AdditionalNotes, LastUpdated, ReferralSourceID, isEgypt, isClientDead, allfields, AccidentCountry, country, witness, ReffererSourcesNotes, IsClientDeadListClaimants, gender, MethodOfInitialContact, ClientVehicleLienHolder, ClientVehicleCustomPartsEquipment, ClientVehiclePersonalProperty, ClientVehicleDamageEstimate, ClientVehicleEstimatedMarketValue, ClientVehiclePhotos, ClientVehicleCurrentLocation, ClientVehicleBikeType, AdverseDriverRecordedStatement, HealthInsurancePolicyHolder, HealthInsuranceGroupName, ClientEmployerNameOfSupervisor from intake where id = " + Request.QueryString["id"].ToString() + ")", Context);
                DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen("Insert into StatusTracking(StatusChangeDate, InTakeID, StatusID, ActionTakenByUser) values('" + DateTime.Now.ToString() + "', " + s + ", 1, " + Session["UserID"].ToString() + ")", Context);
                Response.Redirect("intakeedit.aspx?id=" + s + "&sec=1");
            }
        }


        listing111.SetSortIDForListingScreen = " LastUpdated DESC ";
        listing111.SetOrderByForListingScreen = " Order By LastUpdated DESC";
        listing111.SetListingTitle = "Recently Accessed Records";
        listing111.SetCriteriaForListingAndInitializeListing = " Where isNewlyCreated = 0 and ReportCurrentStatusID not in(8,10) ";  // must be called in the last


        if (Context.Session["RoleID"] == null)
            Response.Redirect("login.aspx");


        //roles table contains 4 roles  
        //1	Author	System User         
        //2	Editor	System Administrator
        //3	Admin	Administrator       
        //4	Super	Super Admin         

        if (Context.Session["RoleID"].ToString() == "1" || Context.Session["RoleID"].ToString() == "2" || Context.Session["RoleID"].ToString() == "3")   //editor autors admin cannot manage this list  only super user can do so.
             p1.Visible = false;

        if (Context.Session["RoleID"].ToString() == "1" || Context.Session["RoleID"].ToString() == "2")     //editor author cannot do this    only  admin and super admin can do this
            p2.Visible = false;

    }
}