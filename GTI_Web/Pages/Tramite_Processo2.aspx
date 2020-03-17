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
    <br />
    <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" TabIndex="7" RowHeaderColumn="Sequencia" OnRowCommand="grdMain_RowCommand">
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
                <ItemStyle Width="80px" Wrap="False"/>
            </asp:BoundField>
            <asp:BoundField DataField="Despacho" HeaderText="Despacho" ItemStyle-Width="80" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" Wrap="False"  />
                <ItemStyle Width="80px" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Data2" HeaderText="Data Env" ItemStyle-Width="60" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                <HeaderStyle HorizontalAlign="Center" Font-Size="Small" Font-Bold="false"  />
                <ItemStyle Width="60px" Wrap="False"  />
            </asp:BoundField>
            <asp:BoundField DataField="Usuario2" HeaderText="Enviado por" ItemStyle-Width="80" HtmlEncode="false" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="#3A8DCC" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small">
                <HeaderStyle HorizontalAlign="Left" Font-Size="Small" Font-Bold="false" Wrap="False"  />
                <ItemStyle Width="80px" Wrap="False" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/receber.png" Text="Button" CommandName="cmdReceber" >
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/enviar.png" Text="Button" CommandName ="cmdEnviar">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/acima.gif" Text="Button">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/abaixo.gif" Text="Button">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/inserir_local.png" Text="Button">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/remover_local.png" Text="Button">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/observacao.png" Text="Button">
            <ItemStyle BorderStyle="Solid" Width="20px" HorizontalAlign="Center"/>
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
    <br />
    <br />
    <br />



    <br />


















</asp:Content>
