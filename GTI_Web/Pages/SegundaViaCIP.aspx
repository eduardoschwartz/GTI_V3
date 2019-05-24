<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegundaViaCIP.aspx.cs" Inherits="UIWeb.Pages.SegundaViaCIP" MasterPageFile="~/Pages/default.Master"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />



    <style type="text/css">
        
        
      
    </style>

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
            &nbsp;<br />
            
            Emissão de segunda via da Contribuição de Iluminação Pública (CIP) - 2019<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="603px" Height="143px">
                <table style="width: 100%;">


                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="lblCod" runat="server" Text="Código do imóvel..:" Font-Size="X-Small"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtCod" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                            &nbsp; <span class="auto-style6">(Sem dígito)</span></td>

                    </tr>
                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Inscrição Cadastral..:" Font-Size="X-Small"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtIC" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="25" Width="197px" onKeyPress="return formata(this, '§.§§.§§§§.§§§§§.§§.§§.§§§', event)"></asp:TextBox>
                        </td>

                    </tr>


                </table>
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                <br />
                <br />
                <table border="0">
                    <tr>
                        <td >
                            <img height="30" alt="" src="Turing.aspx" width="80" />
                        </td>
                        <td >&nbsp;<span class="panel">Digite o conteúdo da imagem</span>
                            <br />
                            <asp:TextBox ID="txtimgcode" runat="server" ViewStateMode="Disabled" Width="171px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            &nbsp; <asp:Button ID="btPrint" class="button1" runat="server" OnClick="btPrint_Click" Text="Imprimir" Width="86px" />
                            <br />
                        </td>
                      
                    </tr>
                </table>
            </asp:Panel>
            <br />

        </div>
        <br />
   
    </asp:Content>