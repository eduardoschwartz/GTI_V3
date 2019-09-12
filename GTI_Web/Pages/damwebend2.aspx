<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="damwebend2.aspx.cs" Inherits="UIWeb.Pages.damwebend2" MasterPageFile="~/Pages/default.Master"    %>




<asp:Content ID="Content" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server" >
    <link href="../css/gti.css" rel="stylesheet" />


    <style>
          .modalDialog {
        position: fixed;
        font-family: Arial, Helvetica, sans-serif;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background: rgba(0,0,0,0.8);
        z-index: 99999;
        -webkit-transition: opacity 400ms ease-in;
        -moz-transition: opacity 400ms ease-in;
        transition: opacity 400ms ease-in;
    }
    .modalDialog > div {
        width: 400px;
        position: relative;
        margin: 10% auto;
        margin-left:20%;
        padding: 5px 20px 13px 20px;
        border-radius: 10px;
        background: #fff;
        background: -moz-linear-gradient(#fff, #999);
        background: -webkit-linear-gradient(#fff, #999);
        background: -o-linear-gradient(#fff, #999);
    }
    .close {
        background: #606061;
        color: #FFFFFF;
        line-height: 25px;
        position: absolute;
        right: -12px;
        text-align: center;
        top: -10px;
        width: 24px;
        text-decoration: none;
        font-weight: bold;
        -webkit-border-radius: 12px;
        -moz-border-radius: 12px;
        border-radius: 12px;
        -moz-box-shadow: 1px 1px 3px #000;
        -webkit-box-shadow: 1px 1px 3px #000;
        box-shadow: 1px 1px 3px #000;
    }
    .close:hover { background: #00d9ff; }
    </style>


    <%--<form id="pagamento" runat="server" action="https://mpag.bb.com.br/site/mpag/" method="post" name="pagamento">--%>
        <div class="auto-style1">
        <input type="hidden" name="msgLoja" value="<%= "RECEBER SOMENTE ATE O VENCIMENTO, APOS ATUALIZAR O BOLETO NO SITE www.jaboticabal.sp.gov.br" %>" />
        <input type="hidden" name="cep" value="<%= Convert.ToInt32(RetornaNumero( txtCep.Text)) %>" />
        <input type="hidden" name="uf" value="<%= txtUF.Text %>" />
        <input type="hidden" name="cidade" value="<%= txtCidade.Text %>" />
        <input type="hidden" name="endereco" value="<%= txtEndereco.Text %>" />
        <input type="hidden" name="nome" value="<%= txtNome.Text %>" />
        <input type="hidden" name="urlInforma" value="<%= "sistemas.jaboticabal.sp.gov.br/gti/Pages/boletoBB.aspx" %>" />
        <input type="hidden" name="urlRetorno" value="<%= "sistemas.jaboticabal.sp.gov.br/gti/Pages/boletoBB.aspx" %>" />
        <input type="hidden" name="tpDuplicata" value="<%= "DS" %>" />
        <input type="hidden" name="dataLimiteDesconto" value="<%=0 %>" />
        <input type="hidden" name="valorDesconto" value="<%= 0 %>" />
        <input type="hidden" name="indicadorPessoa" value="<%=txtcpfCnpj.Text.Length==14?2:1 %>" />
        <input type="hidden" name="cpfCnpj" value="<%=RetornaNumero( txtcpfCnpj.Text) %>" />
        <input type="hidden" name="tpPagamento" value="<%= 2 %>" />
        <input type="hidden" name="dtVenc" value="<%=RetornaNumero(txtDtVenc.Text) %>" />
        <input type="hidden" name="qtdPontos" value="<%= 0 %>" />
        <input type="hidden" name="valor" value="<%= Convert.ToInt64(RetornaNumero( txtValor.Text)) %>" />
        <input type="hidden" name="refTran" value="<%=  String.IsNullOrEmpty(txtrefTran.Text)?0: Convert.ToInt64(txtrefTran.Text) %>" />
        <input type="hidden" name="idConv" value="<%= 317203 %>" />


       <div style="color: #3a8dcc;">
            &nbsp;<br />
           <br />
           Clique em imprimir boleto para 
           gerar o Boleto Bancário<br />
           
            <br />
            <br />

        <asp:Table ID="Table1" runat="server" Width="484px">

            <asp:TableRow>
                <asp:TableCell >
                    <asp:Label ID="Label8"  runat="server" Text="Nº Documento: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtrefTran" runat="server" Width="200" ReadOnly="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7"  runat="server" Text="Valor R$: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtValor" runat="server" ReadOnly="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Vencimento: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtDtVenc" runat="server" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="CPF/CNPJ: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtcpfCnpj" runat="server" Width="200" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Nome: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtNome" runat="server" Width="350" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Endereço: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtEndereco" runat="server"  Width="350" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Cidade: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtCidade" runat="server" Width="350" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="UF: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtUF" runat="server" Width="50" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label6"  runat="server" Text="Cep: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtCep" runat="server" ReadOnly="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>       
               </div>
        <br />

        
        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None"></asp:TextBox>

        
        <asp:Button ID="btGerar" runat="server" Text="Imprimir Boleto" class="button1"  PostBackUrl="https://mpag.bb.com.br/site/mpag/"   />
        &nbsp;&nbsp;&nbsp;
        </div>
       

    g<asp:Button ID="btnOpenModal" runat="server" Text="Open Modal Window" OnClick="btnOpenModal_Click" />
    <div id="divModal" runat="server" class ="modalDialog" visible="false">
    <div>
        <asp:LinkButton ID="lbtnModalClose" runat="server"  CssClass="close" Text="X" OnClick="CloseModal" />
        <h2>Modal Box</h2>
        <p>This is a sample modal box that can be created using CSS3.</p>
        <br />
        <asp:Button ID="btn123" runat="server" Text="Close" OnClick="CloseModal" />
    </div>
</div>



</asp:Content>