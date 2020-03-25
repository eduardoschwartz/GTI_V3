<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="Senha.aspx.cs" Inherits="GTI_Web.Pages.Senha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />

    
         <div style="color: #3a8dcc;">
    
         <br />
             <br />
             <span style="color: #990000">Alterar a senha</span><br />
             <br />
             <table style="width: 308px; height: 40px;">
                 <tr style="height: 30px;">
                     <td class="auto-style1" style="width: 134px">Senha atual.:</td>
                     <td style="width: 198px">
                         <asp:TextBox ID="SenhaAtual" runat="server" Width="162px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"  style="margin-left: 1em" TextMode="Password" ></asp:TextBox>
                     </td>
                 </tr>
                 
                                 <tr style="height: 30px;">
                     <td class="auto-style1" style="width: 134px">Nova senha.:</td>
                     <td style="width: 198px">
                         <asp:TextBox ID="NovaSenha" runat="server" Width="162px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"  style="margin-left: 1em" TextMode="Password" ></asp:TextBox>
                     </td>
                 </tr>
                                  <tr style="height: 30px;">
                     <td class="auto-style1" style="width: 134px">Confirmação.:</td>
                     <td style="width: 198px">
                         <asp:TextBox ID="Confirmacao" runat="server" Width="162px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"  style="margin-left: 1em" TextMode="Password" ></asp:TextBox>
                     </td>
                 </tr>

             </table>
             <br />
             <asp:Button ID="ConsultarButton" class="button1" runat="server" Text="Gravar nova senha" OnClick="OKButton_Click"   />
             <br />
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



    <script>
        function MsgChange() {
            alert('Sua senha foi alterada, por favor efetue login novamente');
        }
    </script>
</asp:Content>
