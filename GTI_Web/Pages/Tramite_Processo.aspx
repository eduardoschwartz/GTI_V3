<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="Tramite_Processo.aspx.cs" Inherits="GTI_Web.Pages.Tramite_Processo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
   
      <link href="../css/gti.css" rel="stylesheet" />

    <script>

        function formata(campo, mask, evt) {

            if (document.all) { // Internet Explorer 
                key = evt.keyCode;
            }
            else { // Nestcape 
                key = evt.which;
            }

            string = campo.value;
            i = string.length;

            if (i < mask.length) {
                if (mask.charAt(i) == '§') {
                    return (key > 47 && key < 58);
                } else {
                    if (mask.charAt(i) == '!') { return true; }
                    for (c = i; c < mask.length; c++) {
                        if (mask.charAt(c) != '§' && mask.charAt(c) != '!')
                            campo.value = campo.value + mask.charAt(c);
                        else if (mask.charAt(c) == '!') {
                            return true;
                        } else {
                            return (key > 47 && key < 58);
                        }
                    }
                }
            } else return false;
        }
    </script>


         <div style="color: #3a8dcc;">
    
         <br />
             <br />
             <span style="color: #990000">Trâmite de Processo</span><br />
             <br />
             <table style="width: 258px; height: 25px;">
                 <tr>
                     <td class="auto-style1" style="width: 134px">Número do Processo.:</td>
                     <td>
                         <asp:TextBox ID="txtProcesso" runat="server" Width="92px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"  style="margin-left: 1em" ></asp:TextBox>
                     </td>
                 </tr>
                

             </table>
             <br />
             <asp:Button ID="ConsultarButton" class="button1" runat="server" Text="Consultar" OnClick="ConsultarButton_Click"   />
             <br />
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>
