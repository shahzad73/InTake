<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">

		<meta http-equiv="Content-Type" content="text/html; charset=UTF=8" />
		<meta name="viewport" content="width=device-width, maximum-scale=1.0, minimum-scale=1.0, initial-scale=1.0" />

		<title>Levenbaum Trachtenberg Intake Management System</title>

		<link rel="stylesheet" type="text/css" href="styles/reset.css" />
		<link rel="stylesheet" type="text/css" href="styles/style.css" />
		<link rel="stylesheet" type="text/css" href="styles/screen_layout_large.css" />
		<link rel="stylesheet" type="text/css" media="only screen and (min-width:50px) and (max-width:550px)" href="styles/screen_layout_small.css" />
		<link rel="stylesheet" type="text/css" media="only screen and (min-width:551px) and (max-width:800px)" href="styles/screen_layout_medium.css" />
		<!--[if lt IE 9]>
		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
		<![endif]-->

		<link rel="shortcut icon" href="/favicon.ico" />
		<link rel="apple-touch-icon" href="/apple-touch-icon.png" />

        <script src="scripts/jquery.js" type="text/javascript"></script>
        <script src="scripts/ui/jquery-ui.min.js" type="text/javascript"></script> 
        <script src="base.js" type="text/javascript"></script>

</head>

<body>

<div id="content">
    <div class="wrapper">


<div class="wrapper">
    

        <br />
        <br />
        <br />
        <span style="font-size:20px; font-weight:bold;"> <asp:Literal ID="litClientName" runat="server"></asp:Literal> </span>
        <br /><br />


	    <div id="form-layout">
		

  		<div class="full-width">
			<h1>History</h1>
			<div>

                <div style="padding:10px 10px 10px 10px">
                     
                        <asp:Repeater id="tblHistory" runat="server">

                            <HeaderTemplate>

                                <table>
							        <thead>
                                        <td  style="width:60px"><b>Date</b></td>
                                        <td style="width:170px"><b>Status</b></td>
                                        <td  style="width:120px"><b>User</b></td>
                                        <td><b>Comments</b></td>
                                    </thead>
					            <tbody>

                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td style="vertical-align:top;"><label class="field-text2"><%# string.Format("{0:M/d/yyyy}", DataBinder.Eval(Container.DataItem, "StatusChangeDate"))%></label></td>
                                    <td  style="vertical-align:top;"><label class="field-text2"><%# DataBinder.Eval(Container.DataItem,"Status") %></label></td>
                                    <td  style="vertical-align:top;"><label class="field-text2"><%# DataBinder.Eval(Container.DataItem,"firstname") %> <%# DataBinder.Eval(Container.DataItem,"lastname") %></label></td>
                                    <td  style="vertical-align:top;"><label class="field-text2"><%# DataBinder.Eval(Container.DataItem,"Comments") %></label></td>
                                </tr>
                            </ItemTemplate>


                            <FooterTemplate>
                                </table>
                            </FooterTemplate>

                        </asp:Repeater>


                </div>

                <br />
            </div>
	   </div>


		<div class="full-width" id="sec2">
			<h1>Intake Memo</h1>
			<div>

                <div class="left">
                     
                     <label>First Name</label> <label class="field-text"><asp:Label runat="server" ID="fname" ></asp:Label></label> <br />

                     <label>Last Name</label> <label class="field-text"><asp:Label runat="server" ID="lname"></asp:Label></label><br />

                     <label>Gender</label> <label class="field-text"><asp:Label runat="server" ID="gender"></asp:Label></label><br />

                     <label>Email</label>  <label class="field-text"><asp:Label runat="server" ID="email"></asp:Label></label><br />

                     <label>Classification</label>  <label class="field-text"><asp:Label runat="server" ID="lblclass"></asp:Label></label>

                     <label>Is Remote Client</label>  <label class="field-text"> <asp:Label runat ="server" ID="lblIsEgypt"></asp:Label> </label>

                    <label>Wrongful Death </label> <label class="field-text"> <asp:Label runat="server" ID="isClientDead"></asp:Label></label><br />

                    <label>Date of Birth</label>  <label class="field-text"><asp:Label runat="server" ID="dob"></asp:Label></label><br />

                    <label>Marital Status</label>  <label class="field-text"><asp:Label runat="server" ID="maritalstatus"></asp:Label></label><br />

                    <label>Spouse Name</label> <label class="field-text"><asp:Label runat="server" ID="spousename"></asp:Label></label><br />                             

                    <label>List Claimants</label>  <label class="field-text"><asp:Label runat="server" ID="IsClientDeadListClaimants"></asp:Label></label><br />

                </div>


                <div class="right">

                    <label>Address Line 1</label>  <label class="field-text"><asp:Label runat="server" ID="address1"></asp:Label></label><br />

                    <label>Address Line 2</label>  <label class="field-text"><asp:Label runat="server" ID="address2"></asp:Label></label><br />

                    <label>City</label>  <label class="field-text"><asp:Label runat="server" ID="city"></asp:Label></label><br />

                    <label>State</label>  <label class="field-text"><asp:Label runat="server" ID="state"></asp:Label></label><br />

                    <label>Zip</label>  <label class="field-text"><asp:Label runat="server" ID="zip"></asp:Label></label><br />

                    <label>Country</label>  <label class="field-text"><asp:Label runat="server" ID="Country"></asp:Label></label><br />

                    <label>SSN</label>  <label class="field-text"><asp:Label runat="server" ID="ssn"></asp:Label></label><br />

                     <label>Phone 1</label>  <label class="field-text"><asp:Label runat="server" ID="phone1"></asp:Label></label><br />

                     <label>Phone 2</label>  <label class="field-text"><asp:Label runat="server" ID="phone2"></asp:Label></label><br />

                     <label>Region/DMA</label>  <label class="field-text"><asp:Label runat ="server" ID="lblDma"></asp:Label> </label>    <br />
                     
                     <label>Method Of Initial Contact</label> <label class="field-text"><asp:Label runat="server" ID="lblMethodOfInitialContact"></asp:Label></label>   <br />

                     <label>Referral Source</label> <label class="field-text"><asp:Label runat="server" ID="lblreferral"></asp:Label></label>   <br />

                     <label>Referral Source Notes</label>  <label class="field-text"><asp:Label runat="server" ID="ReffererSourcesNotes"></asp:Label></label> <br />

                </div>

                <br />
                 
                 
            </div>
	   </div>
       



        
		<div class="full-width" id="sec3">
			<h1>Secondary Contact</h1>
			<div>
                         
                         <div class="left">
                             <label>Name</label>  <label class="field-text"><asp:Label runat="server" ID="secondarycontactname"></asp:Label></label><br />

                             <label>Address</label>  <label class="field-text"><asp:Label runat="server" ID="secondarycontactaddress"></asp:Label></label><br />
                        </div>
                         

                         <div class="right">
                             <label>Phone</label>  <label class="field-text"><asp:Label runat="server" ID="secondarycontactphone"></asp:Label></label><br />

                             <label>Relationship</label>  <label class="field-text"><asp:Label runat="server" ID="secondarycontactrelationship"></asp:Label></label><br />
                        </div>
                         
                <br />
                 
            </div>
	   </div>





		<div class="full-width" id="sec4">
			<h1>Accident Details</h1>
			<div>

                    <div class="left">
                          <label>Date</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentDate"></asp:Label></label><br />

                          <label>Time</label>    <label class="field-text"><asp:Label runat="server" ID="AccidentTime"></asp:Label> <asp:Label runat="server" ID="Accidentampm"></asp:Label></label>  <br />

                          <label>Driver Name</label>   <label class="field-text"><asp:Label runat="server" ID="Accidentdrivername"></asp:Label></label><br />

                          <label>Passenger Name</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentPassangerName"></asp:Label></label><br />

                          <label>Collision Description</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentCollisionDesc"></asp:Label></label><br />

                          <label>Accident Report</label><label class="field-text"><asp:Label runat="server" ID="AccidentOtherAccidentReport"> </asp:Label></label> <br /> 

                          <label>Client Cited</label> <label class="field-text"><asp:Label runat="server" ID="AccidentClientCited"> </asp:Label></label> <br /> 

                          <label>Adverse Cited</label> <label class="field-text"><asp:Label runat="server" ID="AccidentAdverseCited"> </asp:Label></label> <br /> 

                          <label>Witness Details</label> <label class="field-text"><asp:Label runat="server" ID="witness"> </asp:Label></label> <br/>

                          <label>&nbsp;</label>
	                </div>
                          
                     

                    <div class="right">      
                          <label>Location</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentLocation"></asp:Label></label><br />

                          <label>City</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentCity"></asp:Label></label><br />

                          <label>State</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentState"></asp:Label></label><br />

                          <label>Country</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentCountry"></asp:Label></label><br />

                          <label>Helmet</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentHelmet"></asp:Label></label><br />

                          <label>Seatbelt</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentSeatBelt"></asp:Label></label><br />

                          <label>Work Comp</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentEmployed"></asp:Label></label><br />
                    
                          <label> Photos </label>   <label class="field-text"><asp:Label runat="server" ID="AccidentPropertyDamage"> </asp:Label></label> <br /> 

                          <label>Police Agency Name</label>     <label class="field-text"><asp:Label runat="server" ID="AccidentPoliceAgencyName"> </asp:Label></label> <br /> 

                          <label>Police Report Number</label>   <label class="field-text"><asp:Label runat="server" ID="AccidentPoliceReportNumber"> </asp:Label></label> <br />                    

                          <label>Conversation with driver</label><label class="field-text"><asp:Label runat="server" ID="ConversationwithAdverseDriver"> </asp:Label></label> <br/>                        
                    </div>
                 
                
                <br />

            </div>
	   </div>






		<div class="full-width" id="sec5">
			<h1>Property Damage</h1>
			<div>

                    <div class="left">
                        <label>Vehicle Year</label><label class="field-text"><asp:Label runat="server" ID="VehicleInfoYear"></asp:Label></label>  <br/> 
                         
                        <label>Vehicle Make</label><label class="field-text"><asp:Label runat="server" ID="VehicleInfoMake"></asp:Label></label>  <br/>  

                        <label>Model</label><label class="field-text"><asp:Label runat="server" ID="VehicalInfoModel"></asp:Label></label>  <br/> 

                        <label>Lien Holder</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleLienHolder"></asp:Label></label>  <br/> 

                        <label>Personal Property</label><label class="field-text"><asp:Label runat="server" ID="ClientVehiclePersonalProperty"></asp:Label></label>  <br/> 

                        <label>Estimated Market Value</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleEstimatedMarketValue"></asp:Label></label>  <br/> 
                    </div>    
                    
                    
                    <div class="right">

                        <label>Photos</label><label class="field-text"><asp:Label runat="server" ID="ClientVehiclePhotos"></asp:Label></label>  <br/> 

                        <label>Current Location</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleCurrentLocation"></asp:Label></label>  <br/> 

                        <label>Bike Type</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleBikeType"></asp:Label></label>  <br/> 

                        <label>Custom Parts Equipment</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleCustomPartsEquipment"></asp:Label></label>  <br/> 

                        <label>Damage Estimate</label><label class="field-text"><asp:Label runat="server" ID="ClientVehicleDamageEstimate"></asp:Label></label>  <br/> 

                    </div>    

                    
                 <br />

            </div>
	   </div>





		<div class="full-width" id="sec8">
			<h1>Client Injury Classification</h1>
			<div>
                   <div class="left">
                         <label>Soft Tissue</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationSoftTissue"></asp:Label></label>  <br />  

                         <label>Road Rash</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationRoadRash"></asp:Label> </label> <br />  

                         <label>Fractures</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationFractures"></asp:Label> </label> <br />  

                         <label>Head</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationHead"></asp:Label> </label> <br />  
                    </div>     

                    <div class="right">

                         <label>Organ Injuries</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationOrganInjuries"></asp:Label> </label> <br />
                           
                         <label>Other</label><label class="field-text"><asp:Label runat="server" ID="ClientInjuryClassificationOther"></asp:Label> </label> <br />
                    </div>

                <br />

            </div>
	   </div>






		<div class="full-width" id="sec9">
			<h1>Client Treatment</h1>
			<div>

                <div class="left">
                    <label>Treatment to Date</label><label class="field-text"><asp:Label runat="server" ID="ClientTreatmentTreatmenttoDate"></asp:Label></label>  <br />  

                    <label>Treatment - Future</label><label class="field-text"><asp:Label runat="server" ID="ClientTreatmentTreatmentFuture"></asp:Label> </label> <br />  
                </div>    
                
                <div class="right">    
                    <label>Preexisting Conditions Details</label><label class="field-text"><asp:Label runat="server" ID="ClientTreatmentPreexistingConditions"></asp:Label> </label> <br />  
                </div>

                <br />

            </div>
	   </div>





		<div class="full-width" id="sec7">
			<h1>Adverse Driver Information</h1>
			<div>
                
                    <div class="left">
                        <span class="editheadings">Adverse Driver Information</label></span><br /><br />

                        <label>Driver Name</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverDriverName"></asp:Label> </label> <br/>  

                        <label>Driver Phone</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverDrivePhone"></asp:Label> </label> <br/>  

                        <label>Driver Address</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverDriveAddress"></asp:Label> </label> <br/> 
                         
                        <label>Owner Name</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverOwnerName"></asp:Label> </label> <br/>  

                        <label>Owner Phone</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverOwnerPhone"></asp:Label> </label> <br/>  

                        <label>Owner Address</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverOwnerAddress"></asp:Label> </label> <br/>  

                        <label>Vehicle Year</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverVehicleYear"></asp:Label> </label> <br/>  

                        <label>Vehicle Make</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverVehicleMake"></asp:Label> </label> <br/>  

                        <label>Vehicle Model</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverVehicleModel"></asp:Label></label>  <br/>  

                        <label>Recorded Statement</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverRecordedStatement"></asp:Label></label>  <br/>                        

                    </div>
                    
                    
                    <div class="right">    
                        <span class="editheadings" style="float:left;">Insurance Company Information</span><br /><br />

                        <label>Name</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsuranceName"></asp:Label> </label> <br/>  

                        <label>Policy Number</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsurancePolicyNumber"></asp:Label></label>  <br/>  

                        <label>Claim Number</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsuranceClaimNumber"></asp:Label> </label> <br/>  

                        <label>Adjuster Name</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsuranceAdjusterName"></asp:Label> </label> <br/>  

                        <label>Address</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsuranceAddress"></asp:Label> </label> <br/>  

                        <label>Phone</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsurancePhone"></asp:Label> </label> <br/>  

                        <label>Fax</label><label class="field-text"><asp:Label runat="server" ID="AdverseDriverInsuranceFax"></asp:Label></label>  <br/>                        

                        <label>&nbsp;</label>    
                    </div>

                <br />

            </div>
	   </div>






        
		<div class="full-width" id="sec6">
			<h1>Client Insurance Company Information</h1>
			<div>

                    <div class="left">
                        <label>Company Name</label><label class="field-text"><asp:Label runat="server" ID="ClientInsuranceCompanyName"></asp:Label></label>  <br/>
                          
                        <label>Policy Number</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancePolicyNumber"></asp:Label></label>  <br/> 

                        <label>Policy Effective Date</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancePolicyEffectiveDate"></asp:Label></label>  <br/>
                          
                        <label>Policy Expiration Date</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancePolicyExpirationDate"></asp:Label></label>  <br/>  

                        <label>Claim Number</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancClaimNumber"></asp:Label></label>  <br/> 

                        <label>Policy Adjuster Name</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancPolicyAdjusterName"></asp:Label></label>  <br/> 

                        <label>Address</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancAddress"></asp:Label></label>  <br/>  

                        <label>Phone</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancPhone"></asp:Label></label>  <br/>  

                        <label>Fax</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancFax"></asp:Label></label>  <br/>  

                        <label>Collision Coverage</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancCollisionCoverage"></asp:Label> </label> <br/>  

                        <label>Comprehensive Coverage</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancComprehensiveCoverage"></asp:Label></label>  <br/> 

                    </div>
                    
                    <div class="right">    

                        <label>Rental Coverage</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancRentalCoverage"></asp:Label> </label> <br/> 

                        <label>Med Pay Amount</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancMedPayAmount"></asp:Label></label>  <br/> 

                        <label>Uninsured Policy Limit</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancUninsuredPolicyLimit"></asp:Label></label>  <br/>  

                        <label>Under-Insured Policy Limit</label><label class="field-text"><asp:Label runat="server" ID="ClientInsurancUnderInsuredPolicyLimit"></asp:Label></label>  <br/>

                        <br /><br />

                        <span class="editheadings" style="float:left;">Secondary Insurance Company</label></span><br /><br />

                        <label>Company Name</label><label class="field-text"><asp:Label runat="server" ID="AlternateInsuranceCompanyName"></asp:Label></label>  <br/>  

                        <label>Policy Number</label><label class="field-text"><asp:Label runat="server" ID="AlternateInsurancePolicyNumber"></asp:Label></label>  <br/>  

                        <label>Alternate UM/UIM Policy Limit</label><label class="field-text"><asp:Label runat="server" ID="AlternateInsuranceAlternateUMUIMPolicyLimit"></asp:Label></label>  <br />


                    </div>    

                    <br />

            </div>
	   </div>












		<div class="full-width"  id="sec10">
			<h1>Health Insurance Carrier</h1>
			<div>

                <div class="left">
                      <label>Name</label><label class="field-text"><asp:Label runat="server" ID="HealthInsuranceName"></asp:Label> </label> <br />  

                      <label>Address</label><label class="field-text"><asp:Label runat="server" ID="HealthInsuranceAddress"></asp:Label> </label> <br />  

                      <label>Phone</label><label class="field-text"><asp:Label runat="server" ID="HealthInsurancePhone"></asp:Label></label>  <br />  

                      <label>Policy Number</label><label class="field-text"><asp:Label runat="server" ID="HealthInsurancePolicyNumber"></asp:Label>  </label><br />
                </div>
                
                
                <div class="right">  
                      <label>Group Number</label><label class="field-text"><asp:Label runat="server" ID="HealthInsuranceGroupNumber"></asp:Label> </label> <br />

                      <label>Group Name</label><label class="field-text"><asp:Label runat="server" ID="HealthInsuranceGroupName"></asp:Label> </label> <br />
                      
                      <label>Policy Holder</label><label class="field-text"><asp:Label runat="server" ID="HealthInsurancePolicyHolder"></asp:Label> </label> <br />                      
                      
                      <label>&nbsp;</label>
                </div>

                <br />

            </div>
	   </div>
      




		<div class="full-width"  id="sec11">
			<h1>Client Employer</h1>
			<div>

            <div class="left">
                  <label>Name</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployername"></asp:Label></label>  <br />  

                  <label>Address</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerAddress"></asp:Label> </label> <br />  

                  <label>Phone</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerPhone"></asp:Label> </label> <br />  

                  <label>Job Title</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerJobTitle"></asp:Label> </label> <br />  
            </div>
            

            <div class="right">      
                  <label>Job Description</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerJobDesc"></asp:Label> </label> <br />  

                  <label>Rate of Pay</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerRateOfPay"></asp:Label> </label> <br />  

                  <label>Work Missed</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerWorkMissed"></asp:Label></label>  <br />

                  <label>Name Of Supervisor</label><label class="field-text"><asp:Label runat="server" ID="ClientEmployerNameOfSupervisor"></asp:Label></label>  <br />

                  <label>&nbsp;</label>
            </div>
            

            <br />

            </div>
	   </div>




		<div class="full-width" id="sec12">
			<h1>Prior Insurance Claims Details</h1>
			<div>

                <div style="padding:10px 10px 10px 10px">
                      <label class="field-text2"><asp:Label runat="server" ID="PriorInsuranceClaimsDetails"></asp:Label></label>  <br />  
                </div>

                <br />

            </div>
	   </div>





		<div class="full-width" id="sec13">
			<h1>Current/Prior Attorney</h1>
			<div>
                
                <div class="left">
                  <label>Name</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyName"></asp:Label></label>  <br />  

                  <label>Firm</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyFirm"></asp:Label> </label> <br />  

                  <label>Address</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyAddress"></asp:Label></label>  <br />  
                </div>  
                  
                <div class="right">  
                  <label>Phone</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyPhone"></asp:Label> </label> <br />  

                  <label>Withdrawal Reason</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyWithDrawerReason"></asp:Label></label>  <br />
                    
                  <label>Attorney</label><label class="field-text"><asp:Label runat="server" ID="CurrentPriorAttorneyAttorny"></asp:Label></label>  <br />  
                </div>   

                <br />

            </div>
	   </div>



  		<div class="full-width" id="sec14">
			<h1>Additional Notes</h1>
			<div>
                
                <div style="padding:10px 10px 10px 10px">
                     <label class="field-text2"><asp:Label runat="server" ID="AdditionalNotes"></asp:Label></label>  <br />
                </div>

                <br />

            </div>
	   </div>





        </div>
    </div>

	    
    </div>
</div>


</body>
</html>
