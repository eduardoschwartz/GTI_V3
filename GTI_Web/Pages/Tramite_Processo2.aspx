<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="Tramite_Processo2.aspx.cs" Inherits="GTI_Web.Pages.Tramite_Processo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">

   
    <br />
    <br />
     <!--###########################-->
    <!--      DADOS DO PROCESSO    -->
    <!--###########################-->


    
            <asp:Table ID="DadosProcesso" runat="server" Width="600px" BorderStyle="solid" BorderWidth="1px" Height="19px" BorderColor="#3a8dcc" >
            <asp:TableRow Width="800px" BorderStyle="Solid" BorderWidth="1px">
                <asp:TableCell Width="120px">Nº do processo:</asp:TableCell>
                <asp:TableCell runat="server" ID="Processo"  ForeColor="Black" HorizontalAlign="Left" Font-Names="Arial" Font-Bold="true"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="800px" BorderStyle="Solid" BorderWidth="1px">
                <asp:TableCell Width="120px">Data processo:</asp:TableCell>
                <asp:TableCell runat="server" ID="DataAbertura"  ForeColor="Black" HorizontalAlign="Left" Font-Names="Arial" Font-Bold="true"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="800px" BorderStyle="Solid" BorderWidth="1px">
                                <asp:TableCell Width="120px">Requerente:</asp:TableCell>
                <asp:TableCell runat="server" ID="Requerente"  ForeColor="Black" HorizontalAlign="Left" Font-Names="Arial" Font-Bold="true"></asp:TableCell>

            </asp:TableRow>
            <asp:TableRow Width="800px" BorderStyle="Solid" BorderWidth="1px">
                <asp:TableCell Width="120px">Assunto:</asp:TableCell>
                <asp:TableCell runat="server" ID="Assunto"  ForeColor="Black" HorizontalAlign="Left" Font-Names="Arial" Font-Bold="true"></asp:TableCell>

            </asp:TableRow>
        </asp:Table>


    <br />


















</asp:Content>
