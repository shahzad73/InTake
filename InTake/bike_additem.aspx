﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="bike_additem.aspx.cs" Inherits="dma_additem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">

            <div class="table">
                <h1 class="heading"><asp:Label ID="lblText" runat="server"></asp:Label> </h1>
            

                    <table>
                        <tr><td></td></tr>
                        <tr><td>


                                <asp:TextBox runat="server" ID="txtBike"></asp:TextBox> <asp:Label runat="server" ID="lbltxtBike"></asp:Label>
                                <br />
                                <br />
                                <asp:Button runat="server" ID="btn1" onclick="btn1_Click" Text="Save   "  />    
                                 <asp:Button runat="server" ID="Button1" onclick="btn2_Click" Text="Cancel   "  />


                        </td></tr>                   
                        <tr><td></td></tr>
                     </table>

                     <asp:HiddenField runat="server" ID="hidOldValue" />
            </div>
</div>

</asp:Content>

