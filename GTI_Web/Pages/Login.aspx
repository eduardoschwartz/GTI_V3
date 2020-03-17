<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GTI_Web.Pages.LoginFunc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />

     <div style="color: #3a8dcc; width: 282px; height: 214px;">
    
            <br /> 
            <br />
            <br />
            <br />
            <table style="width: 254px;" >
                
                <tr>
                    <td class="panel" style="width: 70px; height: 36px;">Login....:</td>
                    <td style="height: 36px">
                <asp:TextBox ID="Login" runat="server" Width="145px" MaxLength="30"  BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style1" style="width: 70px">Senha....:</td>
                    <td>
                <asp:TextBox ID="Pwd" runat="server" Width="145px" MaxLength="30" TextMode="Password"  BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    </td>
                </tr>
                <tr><td style="width: 70px"></td></tr>
                <tr>
                    <td class="auto-style1" style="width: 70px">&nbsp;</td>
                    <td>
                <asp:Button class="button1" ID="AcessoButton" runat="server" Text="Acessar" OnClick="AcessoButton_Click" Width="86px" />
                    &nbsp;</td>
                </tr>
            </table>
            
             
            <br />
            <br />
            
             
         <asp:Label  ID="lblMsg" runat="server" ForeColor="Red"  />

     </div>
        <br />
        <br />

        
   


</asp:Content>
