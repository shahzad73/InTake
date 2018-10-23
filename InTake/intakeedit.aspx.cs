using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class intakeedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Context.Request.QueryString["sec"] == "13")
            btn.Visible = false;
        


        if (Context.Session["RoleID"].ToString() == "1")
        {
            string st = DBSpace.DBFunctionality.RunNumberScalarQuery("select DateTaken from intake where id =" + Request.QueryString["id"].ToString(), Context);
            DateTime ddd = DateTime.Parse(st);
            TimeSpan diff = DateTime.Today - ddd;
            if (diff.Days > 1) 
                Response.Redirect("intake.aspx?id=" + Request.QueryString["id"].ToString());
        }

        if(Context.Request.QueryString["sec"] == "1")
            pnlsavepre.Visible = false;

        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        if (IsPostBack == false)
        {
            DBSpace.DBFunctionality.InitializeFormDropDownFields(DBFields, this, Context);
            //set some default values
            country.SelectedIndex = country.Items.IndexOf(country.Items.FindByText("USA"));
            AccidentCountry.SelectedIndex = AccidentCountry.Items.IndexOf(AccidentCountry.Items.FindByText("USA"));
            drdma.SelectedIndex = drdma.Items.IndexOf(drdma.Items.FindByText("Phoenix"));
            drclass.SelectedIndex = drclass.Items.IndexOf(drclass.Items.FindByText("Motorcycle"));
            gender.SelectedIndex = gender.Items.IndexOf(gender.Items.FindByText("Male"));


            DropDownList dr = null;

            if (Request.QueryString["sec"].ToString() == "1")
            {
                drInjuryTypeID.Items.Insert(0, new ListItem("Please Select", "Please Select"));

                dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "drrefer");
                dr.Items.Insert(0, new ListItem("", "-1"));
            }

            if (Request.QueryString["sec"].ToString() == "5")
            {
                dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "drInjuryTypeID");
                dr.Items.Insert(0, new ListItem("", "-1"));
            }

            if (Request.QueryString["sec"].ToString() == "2")
            {
                dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "state");
                dr.Items.Insert(0, new ListItem("Please Select", "  "));
            }
            if (Request.QueryString["sec"].ToString() == "4")
            {
                dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "AccidentState");
                dr.Items.Insert(0, new ListItem("Please Select", "  "));
            }


            if (Request.QueryString["sec"].ToString() == "4" || Request.QueryString["sec"].ToString() == "6")
            {

                if (Request.QueryString["sec"].ToString() == "4")
                {
                    VehicleInfoMake.Items.Insert(0, new ListItem("Please Select", "Please Select"));
                    ClientVehicleBikeType.Items.Insert(0, new ListItem("Please Select", "Please Select"));
                    dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "VehicleInfoYear");
                }
                if( Request.QueryString["sec"].ToString() == "6")
                    dr = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "AdverseDriverVehicleYear");

                //dr.Items.Add(new ListItem("",""));
                int d = int.Parse( DateTime.Now.Year.ToString() );
                d = d + 2;
                dr.Items.Add(new ListItem("", "")); 
                for(int zz = d; zz>=1960; zz--) 
                    dr.Items.Add(new ListItem(zz.ToString(), zz.ToString()));
            }

            if(Request.QueryString["id"].ToString() != null)
                DBSpace.DBFunctionality.GetAndSetTableRecord("intake", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
        }


    }




    protected void btn1_Click(object sender, EventArgs e)
    {
        if (CheckFormValidations() == false)
            return;

        SaveFormInfo();
        
        int sec = int.Parse(Request.QueryString["sec"].ToString());
        sec = sec + 1;

        if(sec == 14)
            Response.Redirect("intake.aspx?sec=" + Request.QueryString["sec"].ToString() + "&id=" + Request.QueryString["id"].ToString());

        Response.Redirect("intakeedit.aspx?sec=" + sec.ToString() + "&id=" + Request.QueryString["id"].ToString());
    }


    protected void btnbak_Click(object sender, EventArgs e)
    {

        if (CheckFormValidations() == false)
            return;

        SaveFormInfo();

        int sec = int.Parse(Request.QueryString["sec"].ToString());
        sec = sec - 1;

        if (sec == 0)
            Response.Redirect("intake.aspx?sec=1&id=" + Request.QueryString["id"].ToString());

        Response.Redirect("intakeedit.aspx?sec=" + sec.ToString() + "&id=" + Request.QueryString["id"].ToString());
    }




    protected bool CheckFormValidations()
    {

        if (Request.QueryString["sec"].ToString() == "1")
        {
            if (drrefer.SelectedIndex == 0 || drrefer.Text == "")
            {
                drefererffreg.Text = "Please make a selection";
                return false;
            }

            if(zip.Text == "")
            {
                lblZipError.Text = "Enter Zip Code";
                return false;
            }
        }

        if (Request.QueryString["sec"].ToString() == "4")
        {
            if (VehicleInfoMake.SelectedIndex == 0)
            {
                lblvehicleinfomakeerror.Text = "Please make a selection";
                return false;
            }
            else
                lblvehicleinfomakeerror.Text = "";


            if (ClientVehicleBikeType.SelectedIndex == 0)
            {
                lblerrorbiketypemake.Text = "Please make a selection";
                return false;
            }
            else
                lblerrorbiketypemake.Text = "";
        }


        if (Request.QueryString["sec"].ToString() == "5")
        {
            if( ClientInjuryClassificationSoftTissue.Text != "" || ClientInjuryClassificationRoadRash.Text != "" ||   ClientInjuryClassificationFractures.Text != "" ||   ClientInjuryClassificationHead.Text != "" ||    ClientInjuryClassificationOrganInjuries.Text != "" ||    ClientInjuryClassificationOther.Text != "")
            {
                if(drInjuryTypeID.SelectedValue == "-1")
                {
                    lblErrorSelectInjury.Text = "Please select injury type";
                    return false;
                }
            }

            if (ClientInjuryClassificationSoftTissue.Text == "" && ClientInjuryClassificationRoadRash.Text == "" && ClientInjuryClassificationFractures.Text == "" && ClientInjuryClassificationHead.Text == "" && ClientInjuryClassificationOrganInjuries.Text == "" && ClientInjuryClassificationOther.Text == "")
            {
                if (drInjuryTypeID.SelectedValue != "-1")
                    drInjuryTypeID.SelectedValue = "-1";
            }
        }

        return true;
    }



    protected void btn3_Click(object sender, EventArgs e)
    {
        if (CheckFormValidations() == false)
            return;

        SaveFormInfo();
        Response.Redirect("intake.aspx?sec=" + Request.QueryString["sec"].ToString() + "&id=" + Request.QueryString["id"].ToString());
    }


    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("intake.aspx?sec=" + Request.QueryString["sec"].ToString() + "&id=" + Request.QueryString["id"].ToString());
    }


    private void SaveFormInfo()
    {

        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);
        DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("intake", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);



        DataRow dr = DBSpace.DBFunctionality.GetSingleRecordFromATable("Select * from intake where id = " + Request.QueryString["id"].ToString(), Context);

        if (dr["isNewlyCreated"].ToString() == "1")
        {
            DBSpace.DBFunctionality.RunNonQuery("Update Intake Set isNewlyCreated = 0, LastUpdated = '" + DateTime.Now.ToString() + "' Where id=" + Request.QueryString["id"].ToString(), Context);
            string cnt1 = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from intake where isNewlyCreated = 0 and ReportCurrentStatusID = 1", Context);
            //DBSpace.DBFunctionality.RunNonQuery("Update Status set NoOfFormsInThisList = " + cnt1 + " where id = 1", Context);
        }
        else
            DBSpace.DBFunctionality.RunNonQuery("Update Intake Set isNewlyCreated = 0, LastUpdated = '" + DateTime.Now.ToString() + "' Where id=" + Request.QueryString["id"].ToString(), Context);

        string sss = "";
        sss = sss + " " + dr["email"].ToString();
        sss = sss + " " + dr["spousename"].ToString();
        sss = sss + " " + dr["address1"].ToString();
        sss = sss + " " + dr["address2"].ToString();
        sss = sss + " " + dr["city"].ToString();
        sss = sss + " " + dr["zip"].ToString();
        sss = sss + " " + dr["phone1"].ToString();
        sss = sss + " " + dr["phone2"].ToString();
        sss = sss + " " + dr["ssn"].ToString();
        sss = sss + " " + dr["secondarycontactname"].ToString();
        sss = sss + " " + dr["secondarycontactaddress"].ToString();
        sss = sss + " " + dr["secondarycontactphone"].ToString();
        sss = sss + " " + dr["secondarycontactrelationship"].ToString();
        sss = sss + " " + dr["Accidentdrivername"].ToString();
        sss = sss + " " + dr["AccidentPassangerName"].ToString();
        sss = sss + " " + dr["AccidentCollisionDesc"].ToString();
        sss = sss + " " + dr["AccidentLocation"].ToString();
        sss = sss + " " + dr["AccidentCity"].ToString();
        sss = sss + " " + dr["AccidentState"].ToString();
        sss = sss + " " + dr["witness"].ToString();
        sss = sss + " " + dr["ConversationwithAdverseDriver"].ToString();
        sss = sss + " " + dr["AccidentPoliceAgencyName"].ToString();
        sss = sss + " " + dr["AccidentPoliceReportNumber"].ToString();
        sss = sss + " " + dr["ClientInsuranceCompanyName"].ToString();
        sss = sss + " " + dr["ClientInsurancePolicyNumber"].ToString();
        sss = sss + " " + dr["ClientInsurancClaimNumber"].ToString();
        sss = sss + " " + dr["ClientInsurancPolicyAdjusterName"].ToString();
        sss = sss + " " + dr["ClientInsurancAddress"].ToString();
        sss = sss + " " + dr["ClientInsurancPhone"].ToString();
        sss = sss + " " + dr["ClientInsurancFax"].ToString();
        sss = sss + " " + dr["ClientInsurancCollisionCoverage"].ToString();
        sss = sss + " " + dr["AlternateInsuranceCompanyName"].ToString();
        sss = sss + " " + dr["AlternateInsurancePolicyNumber"].ToString();
        sss = sss + " " + dr["AlternateInsuranceAlternateUMUIMPolicyLimit"].ToString();
        sss = sss + " " + dr["AdverseDriverDriverName"].ToString();
        sss = sss + " " + dr["AdverseDriverDrivePhone"].ToString();
        sss = sss + " " + dr["AdverseDriverDriveAddress"].ToString();
        sss = sss + " " + dr["AdverseDriverOwnerName"].ToString();
        sss = sss + " " + dr["AdverseDriverOwnerPhone"].ToString();
        sss = sss + " " + dr["AdverseDriverOwnerAddress"].ToString();
        sss = sss + " " + dr["AdverseDriverInsuranceName"].ToString();
        sss = sss + " " + dr["AdverseDriverInsurancePolicyNumber"].ToString();
        sss = sss + " " + dr["AdverseDriverInsuranceClaimNumber"].ToString();
        sss = sss + " " + dr["AdverseDriverInsuranceAdjusterName"].ToString();
        sss = sss + " " + dr["AdverseDriverInsuranceAddress"].ToString();
        sss = sss + " " + dr["AdverseDriverInsurancePhone"].ToString();
        sss = sss + " " + dr["AdverseDriverInsuranceFax"].ToString();
        sss = sss + " " + dr["HealthInsuranceName"].ToString();
        sss = sss + " " + dr["HealthInsuranceAddress"].ToString();
        sss = sss + " " + dr["HealthInsurancePhone"].ToString();
        sss = sss + " " + dr["HealthInsurancePolicyNumber"].ToString();
        sss = sss + " " + dr["HealthInsuranceGroupNumber"].ToString();
        sss = sss + " " + dr["ClientEmployername"].ToString();
        sss = sss + " " + dr["ClientEmployerAddress"].ToString();
        sss = sss + " " + dr["ClientEmployerPhone"].ToString();
        sss = sss + " " + dr["ClientEmployerJobTitle"].ToString();
        sss = sss + " " + dr["ClientEmployerJobDesc"].ToString();
        sss = sss + " " + dr["ClientEmployerRateOfPay"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyName"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyFirm"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyAddress"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyPhone"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyWithDrawerReason"].ToString();
        sss = sss + " " + dr["CurrentPriorAttorneyAttorny"].ToString();
        sss = sss + " " + dr["AdditionalNotes"].ToString();

        sss = sss.Replace("'", "''");

        DBSpace.DBFunctionality.RunNonQuery("update intake set allfields = '" + sss + "' where id = " + Request.QueryString["id"].ToString(), Context);
    }



    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;

        if (Request.QueryString["sec"].ToString() == "1")
        {
            itm = new DBItem("fname", "textbox", "fname", "string", false);
            lst.Add(itm);
            itm = new DBItem("lname", "textbox", "lname", "string", false);
            lst.Add(itm);
            itm = new DBItem("email", "textbox", "email", "string", false);
            lst.Add(itm);
            itm = new DBItem("phone1", "textbox", "phone1", "string", false);
            lst.Add(itm);
            itm = new DBItem("phone2", "textbox", "phone2", "string", false);
            lst.Add(itm);

            itm = new DBItem("gender", "dropbox", "gender", "string", false);
            lst.Add(itm);

            itm = new DBItem("drdma", "dropbox", "ReportRegionDMAID", "int", false);
            itm.TableBound = "DMARegion";
            itm.TableBoundIDColumn = "id";
            itm.TableBoundTextFieldColumn = "dmaname";
            lst.Add(itm);

            itm = new DBItem("drMethodOfInitialContact", "dropbox", "MethodOfInitialContact", "int", false);
            itm.TableBound = "MethodOfInitialContact";
            itm.TableBoundIDColumn = "id";
            itm.TableBoundTextFieldColumn = "value";
            lst.Add(itm);

            itm = new DBItem("drclass", "dropbox", "injuryid", "int", false);
            itm.TableBound = "injury";
            itm.TableBoundIDColumn = "id";
            itm.TableBoundTextFieldColumn = "injury";
            lst.Add(itm);

            itm = new DBItem("drrefer", "dropbox", "ReferralSourceid", "int", false);
            itm.TableBound = "ReferralSources";
            itm.TableBoundIDColumn = "id";
            itm.TableBoundTextFieldColumn = "ReferralSource";
            lst.Add(itm);

            itm = new DBItem("ReffererSourcesNotes", "textbox", "ReffererSourcesNotes", "string", false);
            lst.Add(itm);

            itm = new DBItem("isEgypt", "dropbox", "isEgypt", "string", false);
            lst.Add(itm);

            drNotCLient.Attributes["onChange"] = "ShowHideListClaimants();";

            itm = new DBItem("dob", "textbox", "dob", "string", false);
            lst.Add(itm);
            itm = new DBItem("maritalstatus", "dropbox", "maritalstatus", "string", false);
            lst.Add(itm);
            itm = new DBItem("spousename", "textbox", "spousename", "string", false);
            lst.Add(itm);
            itm = new DBItem("address1", "textbox", "address1", "string", false);
            lst.Add(itm);
            itm = new DBItem("address2", "textbox", "address2", "string", false);
            lst.Add(itm);
            itm = new DBItem("city", "textbox", "city", "string", false);
            lst.Add(itm);

            itm = new DBItem("country", "dropbox", "CountryID", "int", false);
            itm.TableBound = "country";
            itm.TableBoundIDColumn = "id";
            itm.TableBoundTextFieldColumn = "country";
            lst.Add(itm);

            itm = new DBItem("state", "dropbox", "state", "string", false);
            itm.TableBound = "state";
            itm.TableBoundIDColumn = "city";
            itm.TableBoundTextFieldColumn = "city";
            lst.Add(itm);

            itm = new DBItem("zip", "textbox", "zip", "string", false);
            lst.Add(itm);
            itm = new DBItem("ssn", "textbox", "ssn", "string", false);
            lst.Add(itm);

            itm = new DBItem("drNotCLient", "dropbox", "isClientDead", "string", false);
            lst.Add(itm);

            itm = new DBItem("IsClientDeadListClaimants", "textbox", "IsClientDeadListClaimants", "string", false);
            lst.Add(itm);

            lblText.Text = "Client Information";

            lblText.Text = "Intake Memo";
            Panel1.Visible = true;
        }


        if (Request.QueryString["sec"].ToString() == "2")
        {
            itm = new DBItem("secondarycontactname", "textbox", "secondarycontactname", "string", false);
            lst.Add(itm);
            itm = new DBItem("secondarycontactaddress", "textbox", "secondarycontactaddress", "string", false);
            lst.Add(itm);
            itm = new DBItem("secondarycontactphone", "textbox", "secondarycontactphone", "string", false);
            lst.Add(itm);
            itm = new DBItem("secondarycontactrelationship", "textbox", "secondarycontactrelationship", "string", false);
            lst.Add(itm);

            lblText.Text = "Secondary Contact";
            Panel2.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "3")
        {

            itm = new DBItem("AccidentDate", "textbox", "AccidentDate", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentTime", "textbox", "AccidentTime", "string", false);
            lst.Add(itm);
            itm = new DBItem("Accidentampm", "dropbox", "Accidentampm", "string", false);
            lst.Add(itm);
            itm = new DBItem("Accidentdrivername", "textbox", "Accidentdrivername", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentPassangerName", "textbox", "AccidentPassangerName", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentCollisionDesc", "textbox", "AccidentCollisionDesc", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentLocation", "textbox", "AccidentLocation", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentCity", "textbox", "AccidentCity", "string", false);
            lst.Add(itm);

            itm = new DBItem("AccidentCountry", "dropbox", "AccidentCountry", "string", false);
            itm.TableBound = "country";
            itm.TableBoundIDColumn = "country";
            itm.TableBoundTextFieldColumn = "country";
            lst.Add(itm);

            itm = new DBItem("AccidentState", "dropbox", "AccidentState", "string", false);
            itm.TableBound = "state";
            itm.TableBoundIDColumn = "city";
            itm.TableBoundTextFieldColumn = "city";
            lst.Add(itm);

            
            itm = new DBItem("AccidentHelmet", "dropbox", "AccidentHelmet", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentSeatBelt", "dropbox", "AccidentSeatBelt", "string", false);
            lst.Add(itm);
            itm = new DBItem("AccidentEmployed", "dropbox", "AccidentEmployed", "string", false);
            lst.Add(itm);


            itm = new DBItem("AccidentOtherAccidentReport", "dropbox", "AccidentOtherAccidentReport", "string", false);
            lst.Add(itm); itm = new DBItem("AccidentClientCited", "dropbox", "AccidentClientCited", "string", false);
            lst.Add(itm); itm = new DBItem("AccidentAdverseCited", "dropbox", "AccidentAdverseCited", "string", false);
            lst.Add(itm); itm = new DBItem("AccidentPropertyDamage", "dropbox", "AccidentPropertyDamage", "string", false);       //i change this field to photos   client want to delete this and add photos y/n  so i just change the caption
            lst.Add(itm); itm = new DBItem("AccidentPoliceAgencyName", "textbox", "AccidentPoliceAgencyName", "string", false);
            lst.Add(itm); itm = new DBItem("AccidentPoliceReportNumber", "textbox", "AccidentPoliceReportNumber", "string", false); lst.Add(itm);

            itm = new DBItem("witness", "textbox", "witness", "string", false); lst.Add(itm);

            itm = new DBItem("ConversationwithAdverseDriver", "textbox", "ConversationwithAdverseDriver", "string", false); lst.Add(itm);

            lblText.Text = "Accident Details";
            Panel3.Visible = true;
        }




        if (Request.QueryString["sec"].ToString() == "4")
        {
            itm = new DBItem("VehicleInfoYear", "dropbox", "VehicleInfoYear", "string", false); lst.Add(itm);

            itm = new DBItem("VehicleInfoMake", "dropbox", "VehicleInfoMake", "string", false); 
            itm.TableBound = "Vehicle";
            itm.TableBoundIDColumn = "vehicle";
            itm.TableBoundTextFieldColumn = "vehicle";
            lst.Add(itm);

            itm = new DBItem("VehicalInfoModel", "textbox", "VehicalInfoModel", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehicleLienHolder", "dropbox", "ClientVehicleLienHolder", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehiclePersonalProperty", "textbox", "ClientVehiclePersonalProperty", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehicleEstimatedMarketValue", "textbox", "ClientVehicleEstimatedMarketValue", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehiclePhotos", "dropbox", "ClientVehiclePhotos", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehicleCurrentLocation", "textbox", "ClientVehicleCurrentLocation", "string", false); lst.Add(itm);

            //itm = new DBItem("ClientVehicleBikeType", "textbox", "ClientVehicleBikeType", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehicleBikeType", "dropbox", "ClientVehicleBikeType", "string", false); 
            itm.TableBound = "Bike";
            itm.TableBoundIDColumn = "bike";
            itm.TableBoundTextFieldColumn = "bike";
            lst.Add(itm);


            itm = new DBItem("ClientVehicleCustomPartsEquipment", "textbox", "ClientVehicleCustomPartsEquipment", "string", false); lst.Add(itm);
            itm = new DBItem("ClientVehicleDamageEstimate", "textbox", "ClientVehicleDamageEstimate", "string", false); lst.Add(itm);

            lblText.Text = "Property Damage";

            Panel4.Visible = true;
        }


        if (Request.QueryString["sec"].ToString() == "5")
        {
            itm = new DBItem("ClientInjuryClassificationSoftTissue", "textbox", "ClientInjuryClassificationSoftTissue", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationRoadRash", "textbox", "ClientInjuryClassificationRoadRash", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationFractures", "textbox", "ClientInjuryClassificationFractures", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationHead", "textbox", "ClientInjuryClassificationHead", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationOrganInjuries", "textbox", "ClientInjuryClassificationOrganInjuries", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationOther", "textbox", "ClientInjuryClassificationOther", "string", false); lst.Add(itm);
            itm = new DBItem("ClientInjuryClassificationAmputation", "textbox", "ClientInjuryClassificationAmputation", "string", false); lst.Add(itm);

            itm = new DBItem("drInjuryTypeID", "dropbox", "InjuryTypeID", "int", false);
            itm.TableBound = "InjuryTypes";
            itm.TableBoundIDColumn = "InjuryID";
            itm.TableBoundTextFieldColumn = "InjuryName";
            lst.Add(itm);

            lblText.Text = "Client Injury Classification";
            Panel7.Visible = true;
        }




        if (Request.QueryString["sec"].ToString() == "6")
        {
            itm = new DBItem("ClientTreatmentTreatmenttoDate", "textbox", "ClientTreatmentTreatmenttoDate", "string", false); lst.Add(itm); itm = new DBItem("ClientTreatmentTreatmentFuture", "textbox", "ClientTreatmentTreatmentFuture", "string", false); lst.Add(itm); itm = new DBItem("ClientTreatmentPreexistingConditions", "textbox", "ClientTreatmentPreexistingConditions", "string", false); lst.Add(itm);

            lblText.Text = "Client Treatment";
            Panel8.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "7")
        {
            itm = new DBItem("AdverseDriverDriverName", "textbox", "AdverseDriverDriverName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverDrivePhone", "textbox", "AdverseDriverDrivePhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverDriveAddress", "textbox", "AdverseDriverDriveAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerName", "textbox", "AdverseDriverOwnerName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerPhone", "textbox", "AdverseDriverOwnerPhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverOwnerAddress", "textbox", "AdverseDriverOwnerAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleYear", "dropbox", "AdverseDriverVehicleYear", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleMake", "textbox", "AdverseDriverVehicleMake", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverVehicleModel", "textbox", "AdverseDriverVehicleModel", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceName", "textbox", "AdverseDriverInsuranceName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsurancePolicyNumber", "textbox", "AdverseDriverInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceClaimNumber", "textbox", "AdverseDriverInsuranceClaimNumber", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceAdjusterName", "textbox", "AdverseDriverInsuranceAdjusterName", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceAddress", "textbox", "AdverseDriverInsuranceAddress", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsurancePhone", "textbox", "AdverseDriverInsurancePhone", "string", false); lst.Add(itm); itm = new DBItem("AdverseDriverInsuranceFax", "textbox", "AdverseDriverInsuranceFax", "string", false); lst.Add(itm);

            itm = new DBItem("AdverseDriverRecordedStatement", "dropbox", "AdverseDriverRecordedStatement", "string", false); lst.Add(itm);

            lblText.Text = "Adverse Driver Information";
            Panel6.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "8")
        {
            itm = new DBItem("ClientInsuranceCompanyName", "textbox", "ClientInsuranceCompanyName", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancePolicyNumber", "textbox", "ClientInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancePolicyEffectiveDate", "textbox", "ClientInsurancePolicyEffectiveDate", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancePolicyExpirationDate", "textbox", "ClientInsurancePolicyExpirationDate", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancClaimNumber", "textbox", "ClientInsurancClaimNumber", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancPolicyAdjusterName", "textbox", "ClientInsurancPolicyAdjusterName", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancAddress", "textbox", "ClientInsurancAddress", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancPhone", "textbox", "ClientInsurancPhone", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancFax", "textbox", "ClientInsurancFax", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancCollisionCoverage", "dropbox", "ClientInsurancCollisionCoverage", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancComprehensiveCoverage", "dropbox", "ClientInsurancComprehensiveCoverage", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancRentalCoverage", "dropbox", "ClientInsurancRentalCoverage", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancMedPayAmount", "textbox", "ClientInsurancMedPayAmount", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancUninsuredPolicyLimit", "textbox", "ClientInsurancUninsuredPolicyLimit", "string", false); lst.Add(itm); itm = new DBItem("ClientInsurancUnderInsuredPolicyLimit", "textbox", "ClientInsurancUnderInsuredPolicyLimit", "string", false); lst.Add(itm);

            itm = new DBItem("AlternateInsuranceCompanyName", "textbox", "AlternateInsuranceCompanyName", "string", false); lst.Add(itm); itm = new DBItem("AlternateInsurancePolicyNumber", "textbox", "AlternateInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("AlternateInsuranceAlternateUMUIMPolicyLimit", "textbox", "AlternateInsuranceAlternateUMUIMPolicyLimit", "string", false); lst.Add(itm);

            lblText.Text = "Client Insurance Company Information";
            Panel5.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "9")
        {
            itm = new DBItem("HealthInsuranceName", "textbox", "HealthInsuranceName", "string", false); lst.Add(itm); itm = new DBItem("HealthInsuranceAddress", "textbox", "HealthInsuranceAddress", "string", false); lst.Add(itm); itm = new DBItem("HealthInsurancePhone", "textbox", "HealthInsurancePhone", "string", false); lst.Add(itm); itm = new DBItem("HealthInsurancePolicyNumber", "textbox", "HealthInsurancePolicyNumber", "string", false); lst.Add(itm); itm = new DBItem("HealthInsuranceGroupNumber", "textbox", "HealthInsuranceGroupNumber", "string", false); lst.Add(itm);
            itm = new DBItem("HealthInsurancePolicyHolder", "textbox", "HealthInsurancePolicyHolder", "string", false); lst.Add(itm);
            itm = new DBItem("HealthInsuranceGroupName", "textbox", "HealthInsuranceGroupName", "string", false); lst.Add(itm);

            lblText.Text = "Health Insurance Carrier";
            Panel9.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "10")
        {
            itm = new DBItem("ClientEmployername", "textbox", "ClientEmployername", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerAddress", "textbox", "ClientEmployerAddress", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerPhone", "textbox", "ClientEmployerPhone", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerJobTitle", "textbox", "ClientEmployerJobTitle", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerJobDesc", "textbox", "ClientEmployerJobDesc", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerRateOfPay", "textbox", "ClientEmployerRateOfPay", "string", false); lst.Add(itm); itm = new DBItem("ClientEmployerWorkMissed", "textbox", "ClientEmployerWorkMissed", "string", false); lst.Add(itm);
            itm = new DBItem("ClientEmployerNameOfSupervisor", "textbox", "ClientEmployerNameOfSupervisor", "string", false); lst.Add(itm);

            lblText.Text = "Client Employer";
            Panel10.Visible = true;
        }



        if (Request.QueryString["sec"].ToString() == "11")
        {
            itm = new DBItem("PriorInsuranceClaimsDetails", "textbox", "PriorInsuranceClaimsDetails", "string", false); lst.Add(itm);

            lblText.Text = "Prior Insurance Claims Details";
            Panel11.Visible = true;
        }


        if (Request.QueryString["sec"].ToString() == "12")
        {
            itm = new DBItem("CurrentPriorAttorneyName", "textbox", "CurrentPriorAttorneyName", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyFirm", "textbox", "CurrentPriorAttorneyFirm", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyAddress", "textbox", "CurrentPriorAttorneyAddress", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyPhone", "textbox", "CurrentPriorAttorneyPhone", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyWithDrawerReason", "textbox", "CurrentPriorAttorneyWithDrawerReason", "string", false); lst.Add(itm); itm = new DBItem("CurrentPriorAttorneyAttorny", "textbox", "CurrentPriorAttorneyAttorny", "string", false); lst.Add(itm);

            lblText.Text = "Current/Prior Attorney";
            Panel12.Visible = true;
        }


        if (Request.QueryString["sec"].ToString() == "13")
        {
            itm = new DBItem("AdditionalNotes", "textbox", "AdditionalNotes", "string", false); lst.Add(itm);

            lblText.Text = "Additional Notes";
            Panel13.Visible = true;
        }

    }


}