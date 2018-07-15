<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="gticertidao.aspx.cs" Inherits="GTI_Web.Pages.gticertidao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />


        <div id="content" style="width: 600px">
            <h3>Certidões disponíveis</h3>
            <br />
            <br />
           
            <ul>
                <li><a href="certidaoendereco.aspx" style="width: 600px">Certidão de endereço atualizado</a></li>
                <li><a href="certidaovalorvenal.aspx" style="width: 600px">Certidão de valor venal</a></li>
                <li><a href="certidaoisencao.aspx" style="width: 600px">Certidão de isenção de IPTU</a></li>
                <li><a href="certidaodebito.aspx" style="width: 600px">Certidão de débito</a></li>
                <li><a href="certidaoinscricao.aspx" style="width: 600px">Certidão de inscrição cadastral</a></li>
            </ul>
        </div>

</asp:Content>
