<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="intakeedit.aspx.cs" Inherits="intakeedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />




<div class="wrapper">

<div class="table">
    
    <h1 class="heading"><asp:Label ID="lblText" runat="server"></asp:Label> </h1>



<table><tr><td>


<table>


<asp:Panel runat="server" ID="Panel1" Visible="false">
    
     <tr>    <td style="width:200px;">First Name </td>   <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="fname"></asp:TextBox></td>  </tr> 

     <tr>    <td>Last Name </td>    <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="lname"></asp:TextBox></td>  </tr> 

     <tr>    <td>Gender</td>        <td><asp:DropDownList runat="server" style="font-size:18px;  width:100px;" ID="gender">  <asp:ListItem Text="Male" Value="Male"></asp:ListItem>  <asp:ListItem Text="Female" Value="Female"></asp:ListItem>   <asp:ListItem Text="Other" Value="Other"></asp:ListItem>  </asp:DropDownList></td>  </tr> 

     <tr>    <td>Email </td>        <td> <asp:TextBox  runat="server" MaxLength="150" Width="400px" ID="email"></asp:TextBox></td>  </tr> 

     <tr>    <td>Phone 1 </td>      <td> <asp:TextBox runat="server" MaxLength="50" ID="phone1"></asp:TextBox></td>  </tr> 

     <tr>    <td>Phone 2 </td>      <td> <asp:TextBox runat="server" MaxLength="50" ID="phone2"></asp:TextBox></td>  </tr> 

    <tr>    <td>DMA Region</td>             <td><asp:DropDownList runat="server" style="font-size:18px;"  ID="drdma">  </asp:DropDownList></td>  </tr> 

    <tr>    <td>Method Of Initial Contact</td>             <td><asp:DropDownList runat="server" style="font-size:18px;"  ID="drMethodOfInitialContact">  </asp:DropDownList></td>  </tr> 

    <tr>    <td>Classification </td>        <td> <asp:DropDownList runat="server" style="font-size:18px;"  ID="drclass">  </asp:DropDownList></td>   </tr> 

    <tr>    <td>Is Remote</td>       <td> <asp:DropDownList  style="font-size:18px;"  runat="server" ID="isEgypt"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>   </asp:DropDownList></td>  </tr> 

    <tr>    <td>Referral Source</td>        <td><asp:DropDownList runat="server" style="font-size:18px;" ID="drrefer">  </asp:DropDownList>   &nbsp;&nbsp;&nbsp;&nbsp; <span style="color:Red;">  <asp:Label ID="drefererffreg" runat="server"></asp:Label>  </span>    </td>  </tr> 

    <tr>    <td style="vertical-align:top; line-height:normal;">Referral Source Notes</td>   <td> <asp:TextBox MaxLength="3980" runat="server" ID="ReffererSourcesNotes" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox> </td>  </tr> 

     <tr>    <td>Date of Birth</td>     <td> <asp:TextBox runat="server" ID="dob"></asp:TextBox></td>  </tr>

     <tr>    <td>Marital Status </td>   <td>  <asp:DropDownList runat="server"  style="font-size:18px;"  ID="maritalstatus"> <asp:ListItem Text="Single" Value="Single"></asp:ListItem> <asp:ListItem Text="Married" Value="Married"></asp:ListItem> </asp:DropDownList>  </td>  </tr> 

     <tr>    <td>Spouse Name </td>      <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="spousename"></asp:TextBox></td>  </tr> 

     <tr>    <td>Address 1 </td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="address1"></asp:TextBox></td>  </tr> 

     <tr>    <td>Address 2 </td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="address2"></asp:TextBox></td>  </tr> 

     <tr>    <td>City </td>     <td> <asp:TextBox runat="server" ID="city"></asp:TextBox></td>  </tr> 

     <tr>    <td>State </td>     <td> <asp:DropDownList style="width:160px; font-size:18px;" runat="server" MaxLength="150" ID="state"></asp:DropDownList></td>  </tr> 

     <tr>    <td>Zip </td>     <td> <asp:TextBox runat="server" MaxLength="150" ID="zip"></asp:TextBox>   <span style="color:Red;"> <asp:Label ID="lblZipError" runat="server"></asp:Label> </span>   </td>  </tr> 

     <tr>    <td>Country </td>     <td> <asp:DropDownList runat="server" style="font-size:18px;"  ID="country">  </asp:DropDownList> </td>  </tr> 

     <tr>    <td>SSN #</td>     <td> <asp:TextBox runat="server" MaxLength="10" ID="ssn"></asp:TextBox></td>  </tr> 

     <tr>    <td>  Wrongful Death  </td>   <td> <asp:DropDownList  style="font-size:18px;"  runat="server" ID="drNotCLient"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>   </asp:DropDownList> </td>     </tr> 
     
     <tr>    <td  style="vertical-align:top; width:150px;"><span class="disClam" style="display:none;">List Claimants</span></td>     <td> <span class="disClam" style="display:none;"><asp:TextBox MaxLength="3980" runat="server" ID="IsClientDeadListClaimants" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox></span></td>  </tr> 


    <script language="javascript" type="text/javascript">

        ShowHideListClaimants();

        $("#<%= dob.ClientID %>").datepicker();

        function ShowHideListClaimants() {
            if ($("#<%= drNotCLient.ClientID %>").val() == "Yes")
                $(".disClam").css("display", "block");
            else {
                $(".disClam").css("display", "none");
                $("#<%= IsClientDeadListClaimants.ClientID %>").val("")
            }
        }

    </script>

</asp:Panel>




<asp:Panel runat="server" id="Panel2" Visible="false">

     <tr>    <td>Name</td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="secondarycontactname"></asp:TextBox></td>  </tr> 

     <tr>    <td>Address </td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="secondarycontactaddress"></asp:TextBox></td>  </tr> 

     <tr>    <td>Phone </td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="secondarycontactphone"></asp:TextBox></td>  </tr> 

     <tr>    <td>Relationship </td>     <td> <asp:TextBox runat="server" MaxLength="150" Width="400px" ID="secondarycontactrelationship"></asp:TextBox></td>  </tr> 

</asp:Panel>





<asp:Panel runat="server" id="Panel3" Visible="false">

    <tr>    <td>Date </td>     <td> <asp:TextBox  runat="server" ID="AccidentDate"></asp:TextBox></td>  </tr> 

    <tr>    <td>Time </td>     <td><asp:TextBox MaxLength="30" Width="100px" runat="server" ID="AccidentTime"></asp:TextBox> <asp:DropDownList runat="server"  style="font-size:18px;"  ID="Accidentampm"> <asp:ListItem Text="AM" Value="AM"></asp:ListItem><asp:ListItem Text="PM" Value="PM"></asp:ListItem> </asp:DropDownList></td>     </tr> 

    <tr>    <td>Driver Name </td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="Accidentdrivername"></asp:TextBox></td>  </tr> 

    <tr>    <td>Passenger Name</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AccidentPassangerName"></asp:TextBox></td>  </tr> 

    <tr>    <td  style="vertical-align:top; width:150px;">Collision Description</td>     <td> <asp:TextBox MaxLength="3980" runat="server" ID="AccidentCollisionDesc" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox></td>  </tr> 

    <tr>    <td>Location</td>     <td> <asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AccidentLocation"></asp:TextBox></td>  </tr> 

    <tr>    <td>City</td>     <td> <asp:TextBox MaxLength="50" runat="server" ID="AccidentCity"></asp:TextBox></td>  </tr> 

    <tr>    <td>State</td>     <td> <asp:DropDownList style="width:160px; font-size:18px;" MaxLength="50" runat="server" ID="AccidentState"></asp:DropDownList></td>  </tr> 

    <tr>    <td>Country </td>     <td> <asp:DropDownList runat="server" style="font-size:18px;"  ID="AccidentCountry">  </asp:DropDownList> </td>  </tr> 

    <tr>    <td>Helmet</td>     <td> <asp:DropDownList  style="font-size:18px;"  runat="server" ID="AccidentHelmet"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>   </asp:DropDownList></td>  </tr> 

    <tr>    <td>SeatBelt</td>     <td> <asp:DropDownList style="font-size:18px;"  runat="server" ID="AccidentSeatBelt"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>  </asp:DropDownList></td>  </tr> 

    <tr>    <td>Work Comp</td>     <td> <asp:DropDownList style="font-size:18px;"  runat="server" ID="AccidentEmployed"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList></td>  </tr> 

    <tr>    <td>Accident Report</td>     <td><asp:DropDownList  style="font-size:18px;"  runat="server" ID="AccidentOtherAccidentReport"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem></asp:DropDownList>  </td>  </tr>
    
    <tr>    <td>Client Cited</td>     <td><asp:DropDownList style="font-size:18px;"  runat="server" ID="AccidentClientCited"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem></asp:DropDownList> </td>  </tr>
    
    <tr>    <td>Adverse Cited</td>     <td><asp:DropDownList style="font-size:18px;"  runat="server" ID="AccidentAdverseCited"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem></asp:DropDownList> </td>  </tr>
    
    <tr>    <td>Photos </td>     <td><asp:DropDownList style="font-size:18px;"  runat="server" ID="AccidentPropertyDamage"> <asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem></asp:DropDownList>  </td>  </tr>
    
    <tr>    <td>Police Agency Name</td>     <td><asp:TextBox MaxLength="150" Width="400px"  runat="server" ID="AccidentPoliceAgencyName"></asp:TextBox> </td>  </tr>
    
    <tr>    <td>Police Report #</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AccidentPoliceReportNumber"></asp:TextBox> </td>  </tr>    

    <tr>    <td style="vertical-align:top;">Witness Details</td>     <td> <asp:TextBox runat="server" ID="witness" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox> </td>  </tr>

    <tr>    <td style="vertical-align:top;" > Conversation with driver </td>     <td> <asp:TextBox runat="server" ID="ConversationwithAdverseDriver" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox> </td>  </tr>

    <script language="javascript" type="text/javascript">
        $("#<%= AccidentDate.ClientID %>").datepicker();
    </script>

</asp:Panel>





<asp:Panel runat="server" ID="Panel4" Visible='false'>

      <tr>    <td>Vehicle Year</td>     <td>   <asp:DropDownList style="font-size:18px; width:100px;"  MaxLength="150" runat="server" ID="VehicleInfoYear"></asp:DropDownList>   </td>  </tr>

      <tr>    <td>Vehicle Make</td>     <td>   <asp:DropDownList  style="font-size:18px;"  runat="server" ID="VehicleInfoMake"></asp:DropDownList>   &nbsp;&nbsp;&nbsp;&nbsp; <span style="color:Red;"> <asp:Label runat="server" ID="lblvehicleinfomakeerror"></asp:Label>  </span>  </td>  </tr>
     
      <tr>    <td>Model</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="VehicalInfoModel"></asp:TextBox>   </td>  </tr>  
     
      <tr>    <td>Lien Holder</td>     <td>   <asp:DropDownList style="font-size:18px; width:100px;"  MaxLength="150" runat="server" ID="ClientVehicleLienHolder"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList>   </td>  </tr>

      <tr>    <td>Personal Property</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="ClientVehiclePersonalProperty"></asp:TextBox>   </td>  </tr>  

      <tr>    <td>Estimated Market Value</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="ClientVehicleEstimatedMarketValue"></asp:TextBox>   </td>  </tr>  

      <tr>    <td>Photos</td>     <td>   <asp:DropDownList style="font-size:18px; width:100px;"  MaxLength="150" runat="server" ID="ClientVehiclePhotos"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem> <asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList>   </td>  </tr>

      <tr>    <td>Current Location</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="ClientVehicleCurrentLocation"></asp:TextBox>   </td>  </tr>  

      <tr>    <td>Bike Type</td>     <td>   <asp:DropDownList runat="server" style="font-size:18px;"  ID="ClientVehicleBikeType">  </asp:DropDownList>     &nbsp;&nbsp;&nbsp;&nbsp; <span style="color:Red;"> <asp:Label runat="server" ID="lblerrorbiketypemake"></asp:Label>  </span>    </td>  </tr>  

      <tr>    <td>Custom Parts Equipment</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="ClientVehicleCustomPartsEquipment"></asp:TextBox>   </td>  </tr>  

      <tr>    <td>Damage Estimate</td>     <td><asp:TextBox  MaxLength="150" runat="server" ID="ClientVehicleDamageEstimate"></asp:TextBox>   </td>  </tr>  

</asp:Panel>




<asp:Panel runat="server" ID="Panel5" Visible='false'>

         <tr>    <td>Company Name</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientInsuranceCompanyName"></asp:TextBox>   </td>  </tr>  
         
         <tr>    <td>Policy Number</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="ClientInsurancePolicyNumber"></asp:TextBox> </td>  </tr>   
         
         <tr>    <td>Policy Effective Date</td>     <td><asp:TextBox runat="server" ID="ClientInsurancePolicyEffectiveDate"></asp:TextBox>    </td>  </tr> 
         
         <tr>    <td>Policy Expiration Date</td>     <td><asp:TextBox runat="server" ID="ClientInsurancePolicyExpirationDate"></asp:TextBox> </td>  </tr>   
         
         <tr>    <td>Claim Number</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="ClientInsurancClaimNumber"></asp:TextBox>    </td>  </tr> 
         
         <tr>    <td>Policy Adjuster Name</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="ClientInsurancPolicyAdjusterName"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Address</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancAddress"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Phone</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancPhone"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Fax</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancFax"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Collision Coverage</td>     <td><asp:DropDownList  style="font-size:18px;"  runat="server" ID="ClientInsurancCollisionCoverage"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem><asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList>    </td>  </tr> 
         
         <tr>    <td>Comprehensive Coverage</td>     <td><asp:DropDownList  style="font-size:18px;"  runat="server" ID="ClientInsurancComprehensiveCoverage"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem><asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList></td>  </tr>    
         
         <tr>    <td>Rental Coverage</td>     <td><asp:DropDownList  style="font-size:18px;"  runat="server" ID="ClientInsurancRentalCoverage"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem><asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList>   </td>  </tr> 
         
         <tr>    <td>Med Pay Amount</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancMedPayAmount"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Uninsured Policy Limit</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancUninsuredPolicyLimit"></asp:TextBox>  </td>  </tr>   
         
         <tr>    <td>Under-Insured Policy Limit</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="ClientInsurancUnderInsuredPolicyLimit"></asp:TextBox><br/></td>  </tr> 


         <tr><td>&nbsp;</td></tr>

         <tr><td> <span style="font-size:16px; font-weight:bold;"> Secondary Insurance Company </span> </td><td></td></tr>

         <tr>    <td>Company Name</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AlternateInsuranceCompanyName"></asp:TextBox> </td>  </tr>     
         
         <tr>    <td>Policy Number</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AlternateInsurancePolicyNumber"></asp:TextBox> </td>  </tr>     
         
         <tr>    <td>Alternate UM/UIM Policy Limit</td>     <td><asp:TextBox MaxLength="150" Width="400px" runat="server" ID="AlternateInsuranceAlternateUMUIMPolicyLimit"></asp:TextBox></td>  </tr> 


        <script language="javascript" type="text/javascript">

            $("#<%= ClientInsurancePolicyEffectiveDate.ClientID %>").datepicker(); 
            $("#<%= ClientInsurancePolicyExpirationDate.ClientID %>").datepicker();

        </script>

</asp:Panel>




<asp:Panel runat="server" ID="Panel6" Visible='false'>

        <tr>    <td> <span style="font-size:16px; font-weight:bold;"> Adverse Driver Information </span> </td> <td></td> </tr>

         <tr>    <td>Driver Name</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverDriverName"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Driver Phone</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverDrivePhone"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Driver Address</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverDriveAddress"></asp:TextBox>  </td>  </tr>    
         
         <tr>    <td>Owner Name</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverOwnerName"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Owner Phone</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverOwnerPhone"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Owner Address</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverOwnerAddress"></asp:TextBox>    </td>  </tr> 
         
         <tr>    <td> Vehicle Year</td>     <td>    <asp:DropDownList runat="server" style="font-size:18px; width:100px" ID="AdverseDriverVehicleYear"></asp:DropDownList>     </td>  </tr> 
         
         <tr>    <td> Vehicle Make</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverVehicleMake"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td> Vehicle Model</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverVehicleModel"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Recorded Statement</td>     <td><asp:DropDownList  style="font-size:18px;"  runat="server" ID="AdverseDriverRecordedStatement"><asp:ListItem Selected="True" Value=" " Text=" "></asp:ListItem><asp:ListItem Value="No" Text="No"></asp:ListItem> <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem> </asp:DropDownList>    </td>  </tr> 



         <tr><td>&nbsp;</td></tr>

         <tr><td> <span style="font-size:16px; font-weight:bold;"> Insurance Company Information </span> </td><td></td></tr>
         
         <tr>    <td> Name</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsuranceName"></asp:TextBox>    </td>  </tr> 
         
         <tr>    <td>  Policy Number </td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsurancePolicyNumber"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Claim Number</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsuranceClaimNumber"></asp:TextBox> </td>  </tr>     
         
         <tr>    <td>Adjuster Name</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsuranceAdjusterName"></asp:TextBox>   </td>  </tr>   
         
         <tr>    <td>Address</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsuranceAddress"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Phone</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsurancePhone"></asp:TextBox>     </td>  </tr> 
         
         <tr>    <td>Fax</td>     <td><asp:TextBox runat="server" MaxLength="150" Width="400px" ID="AdverseDriverInsuranceFax"></asp:TextBox></td>  </tr> 

</asp:Panel>




<asp:Panel runat="server" ID="Panel7" Visible='false'>
         <tr><td>&nbsp;</td> <td></td></tr>
         
         <tr>    <td>Primary Injury Type</td>   <td><asp:DropDownList runat="server" style="font-size:18px;"  ID="drInjuryTypeID">  </asp:DropDownList>   &nbsp;&nbsp;&nbsp;  <span style="color:Red;">  <asp:Label ID="lblErrorSelectInjury" runat="server"></asp:Label>  </span>    </td>  </tr>

         <tr>    <td style="vertical-align:top;"> Soft Tissue</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationSoftTissue" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100" ></asp:TextBox>   </td>  </tr>   
         
         <tr>    <td  style="vertical-align:top;"> Road Rash</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationRoadRash" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100" ></asp:TextBox>    </td>  </tr>  
         
         <tr>    <td  style="vertical-align:top;">  Fractures</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationFractures" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"></asp:TextBox> </td>  </tr>     
         
         <tr>    <td  style="vertical-align:top;"> Head</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationHead" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"></asp:TextBox>    </td>  </tr> 
                  
         <tr>    <td  style="vertical-align:top; width:150px;"> Organ Injuries</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationOrganInjuries" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"> </asp:TextBox>   </td>  </tr>  
                  
         <tr>    <td  style="vertical-align:top;">     Amputation</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationAmputation" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"></asp:TextBox>    </td>  </tr>  

         <tr>    <td  style="vertical-align:top;">     Other</td>     <td><asp:TextBox runat="server" ID="ClientInjuryClassificationOther" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"></asp:TextBox>    </td>  </tr>  

</asp:Panel>



<asp:Panel runat="server" ID="Panel8" Visible='false'>
         <tr>    <td  style="vertical-align:top;">  Treatment to Date</td>     <td><asp:TextBox TextMode="MultiLine"  MaxLength="4000" Width="400px"  runat="server" ID="ClientTreatmentTreatmenttoDate"></asp:TextBox>  </td>  </tr>    
         
         <tr>    <td  style="vertical-align:top;"> Treatment - Future</td>     <td><asp:TextBox TextMode="MultiLine" MaxLength="4000" Width="400px"  runat="server" ID="ClientTreatmentTreatmentFuture"></asp:TextBox>  </td>  </tr>    
                  
         <tr>    <td  style="vertical-align:top; width:200px;"> Preexisting Conditions Details</td>     <td><asp:TextBox runat="server" ID="ClientTreatmentPreexistingConditions" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100"></asp:TextBox> </td>  </tr>
</asp:Panel>




<asp:Panel runat="server" ID="Panel9" Visible='false'>
     <tr>    <td> Name</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsuranceName"></asp:TextBox>     </td>  </tr>   
     
     <tr>    <td> Address</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsuranceAddress"></asp:TextBox>    </td>  </tr>    
     
     <tr>    <td> Phone</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsurancePhone"></asp:TextBox>     </td>  </tr>   
     
     <tr>    <td> Policy Number</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsurancePolicyNumber"></asp:TextBox>  </td>  </tr>      
     
     <tr>    <td> Group Number</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsuranceGroupNumber"></asp:TextBox></td>  </tr>   

     <tr>    <td> Group Name</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsuranceGroupName"></asp:TextBox>  </td>  </tr>      
     
     <tr>    <td> Policy Holder</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="HealthInsurancePolicyHolder"></asp:TextBox></td>  </tr>   

</asp:Panel>



<asp:Panel runat="server" ID="Panel10" Visible='false'>
     <tr>    <td> Name</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployername"></asp:TextBox>  </td>  </tr>      
     
     <tr>    <td> Address</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerAddress"></asp:TextBox>     </td>  </tr>   
     
     <tr>    <td> Phone</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerPhone"></asp:TextBox>   </td>  </tr>     
     
     <tr>    <td> Job Title</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerJobTitle"></asp:TextBox>   </td>  </tr>     
     
     <tr>    <td> Job Description</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerJobDesc"></asp:TextBox>    </td>  </tr>    
     
     <tr>    <td> Rate of Pay</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerRateOfPay"></asp:TextBox>   </td>  </tr>     
     
     <tr>    <td> Work Missed</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerWorkMissed"></asp:TextBox></td>  </tr>   

     <tr>    <td> Name Of Supervisor</td>     <td><asp:TextBox  MaxLength="150" Width="400px" runat="server" ID="ClientEmployerNameOfSupervisor"></asp:TextBox></td>  </tr>   
</asp:Panel>




<asp:Panel runat="server" ID="Panel11" Visible='false'>
    <tr><td>&nbsp;</td></tr>
    <tr>     <td><asp:TextBox runat="server" TextMode="MultiLine" MaxLength="3990" Rows="10" Columns="100" ID="PriorInsuranceClaimsDetails"></asp:TextBox>  </td>  </tr>      
    <tr><td>&nbsp;</td></tr>
</asp:Panel>
    
    


<asp:Panel runat="server" ID="Panel12" Visible='false'>
    <tr>    <td> Name</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyName"></asp:TextBox>     </td>  </tr>   
    
    <tr>    <td> Firm</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyFirm"></asp:TextBox>     </td>  </tr>   
    
    <tr>    <td> Address</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyAddress"></asp:TextBox>  </td>  </tr>      
    
    <tr>    <td> Phone</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyPhone"></asp:TextBox>     </td>  </tr>   
    
    <tr>    <td> Withdrawal Reason</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyWithDrawerReason"></asp:TextBox> </td>  </tr>       
    
    <tr>    <td> Attorney</td>     <td><asp:TextBox runat="server"  MaxLength="150" Width="400px" ID="CurrentPriorAttorneyAttorny"></asp:TextBox>     </td>  </tr>  
</asp:Panel>




<asp:Panel runat="server" ID="Panel13" Visible='false'>    
    <tr><td>&nbsp;</td></tr>
    <tr>      <td><asp:TextBox runat="server" TextMode="MultiLine" Rows="10" Columns="100" ID="AdditionalNotes"></asp:TextBox></td>  </tr>   
    <tr><td>&nbsp;</td></tr>
</asp:Panel>





</table>



</td></tr>                   

<tr><td>&nbsp;&nbsp;&nbsp;</td></tr>
<tr><td>


    <table><tr>

            <asp:Panel runat="server" ID="pnlsavepre"> <td width="15%" ><asp:Button style="float:left;" ID="Button1" runat="server" Text="  Save and Previous   "   onclick="btnbak_Click" />  </td> </asp:Panel>
            <td width="15%"><asp:Button style="float:left;" ID="btn" runat="server" Text="  Save and Next   "   onclick="btn1_Click" />  </td>
            <td width="15%"><asp:Button style="float:left;" ID="btn3" runat="server" Text="  Save and Back    " onclick="btn3_Click" /></td>
            <td><asp:Button style="float:right;" ID="btn2" runat="server" Text="  Cancel Edit     " onclick="btn2_Click" /></td>
    
    </tr></table>

</td></tr>
</table>

</div>

</div>

</asp:Content>

