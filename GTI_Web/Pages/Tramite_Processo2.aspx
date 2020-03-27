<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="Tramite_Processo2.aspx.cs" Inherits="GTI_Web.Pages.Tramite_Processo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />


     <style type="text/css">
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
                margin-left: 20%;
                padding: 5px 20px 13px 20px;
                border-radius: 10px;
                background: #fff;
                background: -moz-linear-gradient(#fff, #bbb);
                background: -webkit-linear-gradient(#fff, #bbb);
                background: -o-linear-gradient(#fff, #bbb);
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

            .close:hover {
                background: #00d9ff;
            }


        .auto-style3 {
            color: blue;
        }

         .auto-style5 {
             left: 94px;
             top: 83px;
             width: 426px;
             text-align: justify;
         }

         .auto-style6 {
             left: 73px;
             top: 58px;
             width: 426px;
             text-align: justify;
             height: 228px;
         }

         .auto-style7 {
             left: 95px;
             top: 83px;
             width: 426px;
             text-align: justify;
         }

        </style>
   
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
    <br />

    <div style="color: #3a8dcc;">

        <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" TabIndex="7" RowHeaderColumn="Sequencia" OnRowCommand="grdMain_RowCommand" OnRowDataBound="grdMain_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Seq" HeaderStyle-HorizontalAlign="Center" HeaderText="Seq" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="false" Width="12px" />
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Local" HeaderText="Setor/Depto" ItemStyle-Width="240" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" />
                    <ItemStyle Width="240px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Data" HeaderText="Data" ItemStyle-Width="60" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="false" />
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Hora" HeaderText="Hora" ItemStyle-Width="40" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="false" />
                    <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Usuario1" HeaderText="Recebido por" ItemStyle-Width="80" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" Wrap="False" />
                    <ItemStyle Width="80px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Despacho" HeaderText="Despacho" ItemStyle-Width="80" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" Wrap="False" />
                    <ItemStyle Width="80px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Data2" HeaderText="Data Env" ItemStyle-Width="60" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="false" />
                    <ItemStyle Width="60px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Usuario2" HeaderText="Enviado por" ItemStyle-Width="80" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                    <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" Wrap="False" />
                    <ItemStyle Width="80px" Wrap="False" />
                </asp:BoundField>

                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/receber.png" Text="Button" CommandName="cmdReceber" >
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/enviar.png" Text="Button" CommandName="cmdEnviar">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/acima.gif" Text="Button" CommandName="cmdAcima">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/abaixo.gif" Text="Button" CommandName="cmdAbaixo">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/inserir_local.png" Text="Button" CommandName="cmdInserir">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/remover_local.png" Text="Button" CommandName="cmdRemover">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/observacao.png" Text="Button" CommandName="cmdObs">
                    <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
                </asp:ButtonField>

            </Columns>
            <EditRowStyle HorizontalAlign="Right" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" Height="18px" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>

    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC0000" Text="lblMsg"></asp:Label>
    <br />
    <br />
    <a href="Tramite_Processo.aspx" style="color:darkred;font-size:10pt">Tramitar outro processo</a>

    <div id="divModalReceber" runat="server" class="modalDialog" visible="false">
        <div class="auto-style7">
            <h4 style="color: red">Recebimento de Processo </h4>
            <asp:Label ID="SeqReceberLabel" runat="server" Text="0" Visible="False"></asp:Label>
            <br />
            <br />
            <strong>
                <asp:Label ID="Label1" runat="server" Text="Selecione o despacho"></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="DespachoListReceber" runat="server" Height="16px" Width="405px">
                </asp:DropDownList>
                <br />
                <br />
            </strong>
            <br />

            <asp:Button ID="btOkReceber" runat="server" align="left" OnClick="btOkReceber_Click" Text="Aceitar" class="button1" Width="80px" />
            &nbsp;<asp:Button ID="btCancelarReceber" runat="server" colspan="2" OnClick="CloseModalReceber" Text="Cancelar" class="button1" Width="80px" Height="20px" />
        </div>
    </div>


    <div id="divModalEnviar" runat="server" class="modalDialog" visible="false">
        <div class="auto-style5">
            <h4 style="color: red">Envio de Processo </h4>
            <asp:Label ID="SeqEnviarLabel" runat="server" Text="0" Visible="False"></asp:Label>
            <br />
            <br />
            <strong>
                <asp:Label ID="Label3" runat="server" Text="Selecione o despacho"></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="DespachoListEnviar" runat="server" Height="16px" Width="405px">
                </asp:DropDownList>
                <br />
                <br />
            </strong>
          
            <asp:Label ID="lblMsgEnviar" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btOkEnviar" runat="server" align="left" OnClick="btOkEnviar_Click" Text="Aceitar" class="button1" Width="80px" />
            &nbsp;<asp:Button ID="btCancelarEnviar" runat="server" colspan="2" OnClick="CloseModalInserir" Text="Cancelar" class="button1" Width="80px" Height="20px" />
        </div>
    </div>

    <div id="divModalInserir" runat="server" class="modalDialog" visible="false">
        <div class="auto-style5">
            <h4 style="color: red">Inserir local de trâmite </h4>
            <asp:Label ID="SeqInserirLabel" runat="server" Text="0" Visible="False"></asp:Label>
            <br />
            <br />
            <strong>
                <asp:Label ID="Label4" runat="server" Text="Selecione o local"></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="LocalListInserir" runat="server" Height="16px" Width="405px">
                </asp:DropDownList>
                <br />
                <br />
            </strong>

            <asp:Label ID="lblMsgInserir" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btOkInserir" runat="server" align="left" OnClick="btOkInserir_Click" Text="Aceitar" class="button1" Width="80px" />
            &nbsp;<asp:Button ID="btCancelarInserir" runat="server" colspan="2" OnClick="CloseModalInserir" Text="Cancelar" class="button1" Width="80px" Height="20px" />
        </div>
    </div>

    <div id="divModalObs" runat="server" class="modalDialog" visible="false">
        <div class="auto-style6">
            <h4 style="color: red">Observação do trâmite </h4>
            <asp:Label ID="SeqObsLabel" runat="server" Text="0" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="optGeral" runat="server" AutoPostBack="True" Checked="True" GroupName="optDoc" OnCheckedChanged="optGeral_CheckedChanged" Text="Obs. Geral" />
            &nbsp;&nbsp;
                        <asp:RadioButton ID="optInterno" runat="server" AutoPostBack="True" GroupName="optDoc" OnCheckedChanged="optInterno_CheckedChanged" Text="Obs. Interna" />
            <br />

            <br />
            <asp:TextBox ID="ObsGeralText" runat="server" Height="105px" TextMode="MultiLine" Visible="True" Width="400px">Texto geral</asp:TextBox>
            <asp:TextBox ID="ObsInternoText" runat="server" Height="105px" TextMode="MultiLine" Width="399px" Visible="True">Texto interno</asp:TextBox>
            <br />

            <br />
            <asp:Button ID="btOkObs" runat="server" align="left" OnClick="btOkObs_Click" Text="Gravar" class="button1" Width="80px" />
            &nbsp;<asp:Button ID="btCancelarObs" runat="server" colspan="2" OnClick="CloseModalObs" Text="Cancelar" class="button1" Width="80px" Height="20px" />
        </div>
    </div>


    <%--  <script>
        // Defining custom functions
        function HideInterno() {
            var dvGeral = document.getElementById("ObsGeralText");
            var dvInterno = document.getElementById("ObsInternoText");
            dvGeral.style.visibility = "visible";
            dvInterno.style.visibility = "hidden";
        }

        function HideGeral() {
            var dvGeral = document.getElementById("ObsGeralText");
            var dvInterno = document.getElementById("ObsInternoText");
            dvGeral.style.visibility = "hidden";
            dvInterno.style.visibility = "visible";
        }

        var btn = document.getElementById("ObsGeralButton");
        var btn2 = document.getElementById("ObsInternaButton");
        btn.addEventListener("click", HideInterno);
        btn2.addEventListener("click", HideGeral);
    </script>--%>




</asp:Content>
