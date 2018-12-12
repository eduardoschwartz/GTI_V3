<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="ConsultaProcessoend.aspx.cs" Inherits="GTI_Web.Pages.ConsultaProcessoend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />


        <div style="color: #3a8dcc;">
            <br />
            &nbsp;<br />
            
            Consulta de Processos<br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Nº do Processo:"></asp:Label>
            <asp:Label ID="Processo" runat="server" Font-Size="Small" ForeColor="#990000" Text="00000-0/0000"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Requerente: "></asp:Label>
            <asp:Label ID="Requerente" runat="server" Font-Size="Small" ForeColor="Maroon" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Data de Abertura: "></asp:Label>
            <asp:Label ID="Data_abertura" runat="server" Font-Size="Small" ForeColor="Maroon" Text="00/00/0000"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Assunto: "></asp:Label>
            <asp:Label ID="Assunto" runat="server" Font-Size="Small" ForeColor="Maroon" Text="..."></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/Pages/ConsultaProcesso.aspx?d=gti">Consultar outro processo</asp:HyperLink>

            <br />
        </div>
        <br />
</asp:Content>
