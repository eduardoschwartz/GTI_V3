<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiberacaoParcend.aspx.cs" Inherits="GTI_Web.Pages.LiberacaoParcend" MasterPageFile="~/Pages/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />

    

         <div style="color: #3a8dcc;">
    
         <br />
             <br />
             Emissão de carnê de parcelamento (parcelas de 2020)<br />
             <br />
             <span style="color: #CC0000"><span style="text-decoration: underline">Observação importante</span>:&nbsp; Os boletos serão registrados durante a noite e estarão disponíveis para pagamento<br />
             a partir de amanhã. Caso queira pagar alguma parcela hoje, emitir boleto através da consulta e atualização
             <br />
             de boletos disponível no site.</span><br />
             <br />
             <table style="width: 456px; height: 75px;">
                 <tr><td class="panel" style="height: 19px; width: 140px;">&nbsp;
                     Inscrição Cadastral: </td> <td class="panel" style="height: 19px">&nbsp;&nbsp;
                            000000</td>

                 </tr>
                 <tr><td class="panel" style="height: 20px; width: 140px;">&nbsp;
                     Número do Processo:
                        <br />
                     </td> <td class="panel" style="height: 20px">&nbsp;&nbsp;
                            12345/2020&nbsp;</td>

                 </tr>
                 <tr>
                     <td style="width: 140px; vertical-align: bottom">&nbsp;&nbsp;
                        </td>

                     <td class="panel">                                            
                         <br />
                         &nbsp; <asp:Button ID="Button1" class="button1" runat="server" Text="Imprimir" OnClick="btPrint_Click" Width="89px" />
                     </td>
                 </tr>
                





             </table>
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>



