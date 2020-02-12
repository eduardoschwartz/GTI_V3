<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiberacaoParc.aspx.cs" Inherits="GTI_Web.Pages.LiberacaoParc" MasterPageFile="~/Pages/default.Master" %>

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
             Emissão de carnê de parcelamento (parcelas de 2020)<br />
             <br />
             <span style="color: #CC0000"><span style="text-decoration: underline">Observação importante</span>:&nbsp; Os boletos serão registrados durante a noite e estarão disponíveis para pagamento<br />
             a partir de amanhã. Caso queira pagar alguma parcela hoje, emitir boleto através da consulta e atualização
             <br />
             de boletos disponível no site.</span><br />
             <br />
             <table style="width: 456px; height: 62px;">
                 <tr><td class="panel" style="height: 23px; width: 173px;">&nbsp;
                     Inscrição Cadastral/ Código: </td> <td class="panel" style="height: 23px">&nbsp;&nbsp;
                            <asp:TextBox ID="txtIM" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="14" Width="66px" TabIndex="1"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                        </td>

                 </tr>
                 <tr><td class="panel" style="height: 40px; width: 173px;">&nbsp;
                     Número do Processo:
                        <br />
&nbsp;<span style="color: #009900">(Ex: 1234-5/2020)</span></td> <td class="panel" style="height: 40px">&nbsp;&nbsp;
                            <asp:TextBox ID="txtProcesso" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="11" Width="108px" TabIndex="1" ></asp:TextBox> 
                        &nbsp;</td>

                 </tr>
                 <tr>
                     <td style="width: 173px; vertical-align: bottom">&nbsp;&nbsp;
                         <img height="30" alt="" src="Turing.aspx" width="80" />&nbsp;</td>

                     <td class="panel">&nbsp;Digite o conteúdo da imagem                                              
                         <br />&nbsp;&nbsp;
                         <asp:TextBox ID="txtimgcode" runat="server" OnClick="btConsultar_Click" ViewStateMode="Disabled" Width="108px" TabIndex="3" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                         &nbsp; <asp:Button ID="Button1" class="button1" runat="server" Text="Próximo" OnClick="btPrint_Click" Width="89px" />
                     </td>
                 </tr>
                





             </table>
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>



