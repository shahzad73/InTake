using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class intake : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SearchCriteria"].ToString() == "")
            pnlbacktosearch.Visible = false;

        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        DBSpace.DBFunctionality.InitializeFormDropDownFields(DBFields, this, Context);


        DataRow dr = DBSpace.DBFunctionality.GetAndSetTableRecord("intake i, injury s, ReferralSources r ", "i.*, s.injury, r.ReferralSource", DBFields, this, " i.id=" + Request.QueryString["id"].ToString() + " and i.injuryid = s.id and r.id = i.ReferralSourceid", Context);


        if (dr["ReportRegionDMAID"].ToString() != "-1")
            lblDma.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("select dmaname from DMARegion where id = " + dr["ReportRegionDMAID"].ToString(), Context);

        if (dr["CountryID"].ToString() != "-1")
            Country.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("select country from country where id = " + dr["CountryID"].ToString(), Context);

        if (dr["MethodOfInitialContact"].ToString() != "-1")
            lblMethodOfInitialContact.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("select value from MethodOfInitialContact where id = " + dr["MethodOfInitialContact"].ToString(), Context);


        txttakenby.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("select firstname + ' ' + lastname from users where id = " + dr["TakenByUserID"].ToString(), Context);
        DateTime tt = DateTime.Parse(dr["DateTaken"].ToString());
        lbldatetaken.Text = string.Format("{0:M/d/yyyy}", tt);


        DataTable dt = DBSpace.DBFunctionality.GetDataTable("Select StatusTracking.*, users.firstname, users.lastname, status.status from StatusTracking, users, status Where users.id = StatusTracking.actiontakenbyuser and  StatusTracking.statusid = status.id  and InTakeID = " + Request.QueryString["id"].ToString() + " order by StatusChangeDate desc", Context);
        tblHistory.DataSource = dt;
        tblHistory.DataBind();

        if (Context.Session["RoleID"].ToString() == "1")
            pnlst.Visible = false;


        //get date of birth of the current person and show its age in year
        string dobtxt = "";
        if (dob.Text != "")
        {
            int age = 0;
            try
            {
                DateTime d1 = Convert.ToDateTime(dr["DateTaken"].ToString());
                age = new DateTime(d1.Subtract(Convert.ToDateTime(dob.Text)).Ticks).Year - 1;
                dobtxt = " (Age:" + age.ToString() + ")";
            }
            catch (Exception ex)
            { }
        }

        lblstat.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("Select status from status where id = " + dr["ReportCurrentStatusID"].ToString(), Context);
        if(dr["InjuryTypeID"].ToString() != "-1")
            PrimaryInjuryTypeText.Text = DBSpace.DBFunctionality.RunNumberScalarQuery("Select InjuryName from InjuryTypes where InjuryID = " + dr["InjuryTypeID"].ToString(), Context);
        

        dob.Text = dob.Text + dobtxt;
        litClientName.Text = fname.Text + " " + lname.Text + dobtxt;
    }
     




    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;


        itm = new DBItem("lblclass", "label", "injury", "string", false);
        lst.Add(itm);

        itm = new DBItem("lblreferral", "label", "ReferralSource", "string", false);
        lst.Add(itm);

        itm = new DBItem("ReffererSourcesNotes", "label", "ReffererSourcesNotes", "string", false);
        lst.Add(itm);
        
        itm = new DBItem("lblIsEgypt", "label", "isEgypt", "string", false);
        lst.Add(itm);

        itm = new DBItem("IsClientDeadListClaimants", "label", "IsClientDeadListClaimants", "string", false);
        lst.Add(itm);
        

        itm = new DBItem("fname", "label", "fname", "string", false);
        lst.Add(itm);
        itm = new DBItem("lname", "label", "lname", "string", false);
        lst.Add(itm);

        itm = new DBItem("gender", "label", "gender", "string", false);
        lst.Add(itm);

        itm = new DBItem("dob", "label", "dob", "string", false);
        lst.Add(itm);
        itm = new DBItem("email", "label", "email", "string", false);
        lst.Add(itm);
        itm = new DBItem("maritalstatus", "label", "maritalstatus", "string", false);
        lst.Add(itm);
        itm = new DBItem("spousename", "label", "spousename", "string", false);
        lst.Add(itm);
        itm = new DBItem("address1", "label", "address1", "string", false);
        lst.Add(itm);
        itm = new DBItem("address2", "label", "address2", "string", false);
        lst.Add(itm);
        itm = new DBItem("city", "label", "city", "string", false);
        lst.Add(itm);
        itm = new DBItem("Country", "label", "Country", "string", false);
        lst.Add(itm);
        itm = new DBItem("state", "label", "state", "string", false);
        lst.Add(itm);
        itm = new DBItem("zip", "label", "zip", "string", false);
        lst.Add(itm);
        itm = new DBItem("phone1", "label", "phone1", "string", false);
        lst.Add(itm);
        itm = new DBItem("phone2", "label", "phone2", "string", false);
        lst.Add(itm);
        itm = new DBItem("ssn", "label", "ssn", "string", false);
        lst.Add(itm);
        itm = new DBItem("isClientDead", "label", "isClientDead", "string", false);
        lst.Add(itm);




        itm = new DBItem("secondarycontactname", "label", "secondarycontactname", "string", false);
        lst.Add(itm);
        itm = new DBItem("secondarycontactaddress", "label", "secondarycontactaddress", "string", false);
        lst.Add(itm);
        itm = new DBItem("secondarycontactphone", "label", "secondarycontactphone", "string", false);
        lst.Add(itm);
        itm = new DBItem("secondarycontactrelationship", "label", "secondarycontactrelationship", "string", false);
        lst.Add(itm);



        itm = new DBItem("AccidentDate", "label", "AccidentDate", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentTime", "label", "AccidentTime", "string", false);
        lst.Add(itm);
        itm = new DBItem("Accidentampm", "label", "Accidentampm", "string", false);
        lst.Add(itm);
        itm = new DBItem("Accidentdrivername", "label", "Accidentdrivername", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentPassangerName", "label", "AccidentPassangerName", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentCollisionDesc", "label", "AccidentCollisionDesc", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentLocation", "label", "AccidentLocation", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentCity", "label", "AccidentCity", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentCountry", "label", "AccidentCountry", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentState", "label", "AccidentState", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentHelmet", "label", "AccidentHelmet", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentSeatBelt", "label", "AccidentSeatBelt", "string", false);
        lst.Add(itm);
        itm = new DBItem("AccidentEmployed", "label", "AccidentEmployed", "string", false);
        lst.Add(itm);



        itm = new DBItem("witness", "label", "witness", "string", false); lst.Add(itm);


        
        itm = new DBItem("ConversationwithAdverseDriver", "label", "ConversationwithAdverseDriver", "string", false); lst.Add(itm);



        itm = new DBItem("AccidentOtherAccidentReport", "label", "AccidentOtherAccidentReport", "string", false); lst.Add(itm); 
        itm = new DBItem("AccidentClientCited", "label", "AccidentClientCited", "string", false); lst.Add(itm); 
        itm = new DBItem("AccidentAdverseCited", "label", "AccidentAdverseCited", "string", false); lst.Add(itm); 
        itm = new DBItem("AccidentPropertyDamage", "label", "AccidentPropertyDamage", "string", false); lst.Add(itm);     //i change this field to photos   client want to delete this and add photos   so i just change the caption
        itm = new DBItem("AccidentPoliceAgencyName", "label", "AccidentPoliceAgencyName", "string", false); lst.Add(itm); 
        itm = new DBItem("AccidentPoliceReportNumber", "label", "AccidentPoliceReportNumber", "string", false); lst.Add(itm);




        itm = new DBItem("VehicleInfoYear", "label", "VehicleInfoYear", "string", false); lst.Add(itm); 
        itm = new DBItem("VehicleInfoMake", "label", "VehicleInfoMake", "string", false); lst.Add(itm); 
        itm = new DBItem("VehicalInfoModel", "label", "VehicalInfoModel", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleLienHolder", "label", "ClientVehicleLienHolder", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehiclePersonalProperty", "label", "ClientVehiclePersonalProperty", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleEstimatedMarketValue", "label", "ClientVehicleEstimatedMarketValue", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehiclePhotos", "label", "ClientVehiclePhotos", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleCurrentLocation", "label", "ClientVehicleCurrentLocation", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleBikeType", "label", "ClientVehicleBikeType", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleCustomPartsEquipment", "label", "ClientVehicleCustomPartsEquipment", "string", false); lst.Add(itm);
        itm = new DBItem("ClientVehicleDamageEstimate", "label", "ClientVehicleDamageEstimate", "string", false); lst.Add(itm); 



        itm = new DBItem("ClientInsuranceCompanyName", "label", "ClientInsuranceCompanyName", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancePolicyNumber", "label", "ClientInsurancePolicyNumber", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancePolicyEffectiveDate", "label", "ClientInsurancePolicyEffectiveDate", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancePolicyExpirationDate", "label", "ClientInsurancePolicyExpirationDate", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancClaimNumber", "label", "ClientInsurancClaimNumber", "string", false); lst.Add(itm);
        itm = new DBItem("ClientInsurancPolicyAdjusterName", "label", "ClientInsurancPolicyAdjusterName", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancAddress", "label", "ClientInsurancAddress", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancPhone", "label", "ClientInsurancPhone", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancFax", "label", "ClientInsurancFax", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancCollisionCoverage", "label", "ClientInsurancCollisionCoverage", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancComprehensiveCoverage", "label", "ClientInsurancComprehensiveCoverage", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancRentalCoverage", "label", "ClientInsurancRentalCoverage", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancMedPayAmount", "label", "ClientInsurancMedPayAmount", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancUninsuredPolicyLimit", "label", "ClientInsurancUninsuredPolicyLimit", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInsurancUnderInsuredPolicyLimit", "label", "ClientInsurancUnderInsuredPolicyLimit", "string", false); lst.Add(itm);


        itm = new DBItem("AlternateInsuranceCompanyName", "label", "AlternateInsuranceCompanyName", "string", false); lst.Add(itm); 
        itm = new DBItem("AlternateInsurancePolicyNumber", "label", "AlternateInsurancePolicyNumber", "string", false); lst.Add(itm); 
        itm = new DBItem("AlternateInsuranceAlternateUMUIMPolicyLimit", "label", "AlternateInsuranceAlternateUMUIMPolicyLimit", "string", false); lst.Add(itm);


        itm = new DBItem("AdverseDriverDriverName", "label", "AdverseDriverDriverName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverDrivePhone", "label", "AdverseDriverDrivePhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverDriveAddress", "label", "AdverseDriverDriveAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerName", "label", "AdverseDriverOwnerName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerPhone", "label", "AdverseDriverOwnerPhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerAddress", "label", "AdverseDriverOwnerAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleYear", "label", "AdverseDriverVehicleYear", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleMake", "label", "AdverseDriverVehicleMake", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleModel", "label", "AdverseDriverVehicleModel", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceName", "label", "AdverseDriverInsuranceName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsurancePolicyNumber", "label", "AdverseDriverInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceClaimNumber", "label", "AdverseDriverInsuranceClaimNumber", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceAdjusterName", "label", "AdverseDriverInsuranceAdjusterName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceAddress", "label", "AdverseDriverInsuranceAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsurancePhone", "label", "AdverseDriverInsurancePhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceFax", "label", "AdverseDriverInsuranceFax", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverRecordedStatement", "label", "AdverseDriverRecordedStatement", "string", false); lst.Add(itm);    



        itm = new DBItem("ClientInjuryClassificationSoftTissue", "label", "ClientInjuryClassificationSoftTissue", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInjuryClassificationRoadRash", "label", "ClientInjuryClassificationRoadRash", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInjuryClassificationFractures", "label", "ClientInjuryClassificationFractures", "string", false); lst.Add(itm); 
        itm = new DBItem("ClientInjuryClassificationHead", "label", "ClientInjuryClassificationHead", "string", false); lst.Add(itm);  
        itm = new DBItem("ClientInjuryClassificationOrganInjuries", "label", "ClientInjuryClassificationOrganInjuries", "string", false); lst.Add(itm); lst.Add(itm); 
        itm = new DBItem("ClientInjuryClassificationOther", "label", "ClientInjuryClassificationOther", "string", false); lst.Add(itm);
        itm = new DBItem("ClientInjuryClassificationAmputation", "label", "ClientInjuryClassificationAmputation", "string", false); lst.Add(itm);


        itm = new DBItem("ClientTreatmentTreatmenttoDate", "label", "ClientTreatmentTreatmenttoDate", "string", false); lst.Add(itm); itm = new DBItem("ClientTreatmentTreatmentFuture", "label", "ClientTreatmentTreatmentFuture", "string", false); lst.Add(itm);  itm = new DBItem("ClientTreatmentPreexistingConditions", "label", "ClientTreatmentPreexistingConditions", "string", false); lst.Add(itm); 


        itm = new DBItem("HealthInsuranceName", "label", "HealthInsuranceName", "string", false); lst.Add(itm); itm = new DBItem("HealthInsuranceAddress", "label", "HealthInsuranceAddress", "string", false); lst.Add(itm); itm = new DBItem("HealthInsurancePhone", "label", "HealthInsurancePhone", "string", false); lst.Add(itm); itm = new DBItem("HealthInsurancePolicyNumber", "label", "HealthInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("HealthInsuranceGroupNumber", "label", "HealthInsuranceGroupNumber", "string", false); lst.Add(itm);
        itm = new DBItem("HealthInsurancePolicyHolder", "label", "HealthInsurancePolicyHolder", "string", false); lst.Add(itm);
        itm = new DBItem("HealthInsuranceGroupName", "label", "HealthInsuranceGroupName", "string", false); lst.Add(itm);

        itm = new DBItem("ClientEmployername", "label", "ClientEmployername", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerAddress", "label", "ClientEmployerAddress", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerPhone", "label", "ClientEmployerPhone", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerJobTitle", "label", "ClientEmployerJobTitle", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerJobDesc", "label", "ClientEmployerJobDesc", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerRateOfPay", "label", "ClientEmployerRateOfPay", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerWorkMissed", "label", "ClientEmployerWorkMissed", "string", false); lst.Add(itm);
        itm = new DBItem("ClientEmployerNameOfSupervisor", "label", "ClientEmployerNameOfSupervisor", "string", false); lst.Add(itm);

        itm = new DBItem("PriorInsuranceClaimsDetails", "label", "PriorInsuranceClaimsDetails", "string", false); lst.Add(itm); 
        
        
        
        itm = new DBItem("CurrentPriorAttorneyName", "label", "CurrentPriorAttorneyName", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyFirm", "label", "CurrentPriorAttorneyFirm", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyAddress", "label", "CurrentPriorAttorneyAddress", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyPhone", "label", "CurrentPriorAttorneyPhone", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyWithDrawerReason", "label", "CurrentPriorAttorneyWithDrawerReason", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyAttorny", "label", "CurrentPriorAttorneyAttorny", "string", false); lst.Add(itm); 
        
        
        itm = new DBItem("AdditionalNotes", "label", "AdditionalNotes", "string", false); lst.Add(itm);


    }

}