<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gtiMenu.aspx.cs" Inherits="UIWeb.gtiMenu" MasterPageFile="~/Pages/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />


        <div id="content" style="width: 600px">
            <h3>Serviços disponíveis</h3>
            <br />
            <br />
           
            <ul>
                <li><a href="gtiMenu2.aspx" style="width: 600px">Consulta e atualização de boletos vencidos para pagamento</a></li>
                <li><a href="SegundaViaIPTU.aspx" style="width: 600px">Emissão de 2ª via do carnê de IPTU (2018)</a></li>
                <li><a href="SegundaViaCIP.aspx" style="width: 600px">Emissão de 2ª via da Contribuição de Iluminação Pública (CIP) (2018)</a></li>
                <li><a href="cip.aspx" style="width: 600px">Consultar endereço da Contribuição de Iluminação Pública (CIP) (2018)</a></li>
                <li><a href="detalhe_boleto.aspx" style="width: 600px">Imprimir os detalhes de um boleto</a></li>
                <li><a href="dadosEmpresa.aspx" style="width: 600px">Consultar dados cadastrais de uma empresa</a></li>
                <li><a href="../Deca/DECANOVO.pdf" style="width: 600px">Download da Declaração Cadastral (DECA)</a></li>
                <li><a href="readVRExml.aspx" style="width: 600px">Importação de arquivos Via Rápida Empresa (VRE)</a></li>
                <li><a href="alvara_vre.aspx" style="width: 600px">Alvará Via Rápida Empresa (VRE)</a></li>
            </ul>
        </div>









</asp:Content>


