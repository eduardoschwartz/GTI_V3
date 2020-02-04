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
                <div style="color: #3a8dcc;">
            &nbsp;<br />
           <br />
           Clique em imprimir boleto para 
           gerar o Boleto Bancário<br />
           
            <br />
            <br />

        <asp:Table ID="Table1" runat="server" Width="484px">

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Inscrição cadastral: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtCodigo" runat="server" Width="350" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Nome/Razão Social: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtNome" runat="server" Width="350" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="CPF/CNPJ: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtcpfCnpj" runat="server" Width="200" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Endereço: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtEndereco" runat="server"  Width="350" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Cidade: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtCidade" runat="server" Width="350" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label6"  runat="server" Text="Cep: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtCep" runat="server" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7"  runat="server" Text="Nº do processo: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtProcesso" runat="server" ReadOnly="true" ForeColor="OrangeRed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>       
               </div>
            <br />
            

           <asp:Button ID="btGerar" runat="server" Text="Imprimir Boleto" class="button1" OnClick="btPrint_Click"     />
<br /> <br />            
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>



