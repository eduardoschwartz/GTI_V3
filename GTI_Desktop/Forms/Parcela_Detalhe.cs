using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace GTI_Desktop.Forms {
    public partial class Parcela_Detalhe : Form {
        Color _backColor = Color.White, _foreColor = Color.DarkBlue;
        Font _font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        int _codigo;
        string _connection = gtiCore.Connection_Name(),_nome;

        public Parcela_Detalhe(int Codigo,string Nome, List<SpExtrato> Lista_Extrato_Tributo) {
            InitializeComponent();
            _codigo = Codigo;
            _nome = Nome;
            Carrega_Detalhe(Lista_Extrato_Tributo);
        }

        private void BtSenha_Click(object sender, EventArgs e) {
            //TODO: Imprimir os detalhes da parcela
        }

        private void BtFindCodigo_Click(object sender, EventArgs e) {
            //TODO: Rotina de duplicados/restituidos
        }

        private void CmdSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Carrega_Detalhe(List<SpExtrato> Lista) {
            decimal _valorTributo = 0,_valorMulta=0,_valorJuros=0,_valorCorrecao=0,_valorTotal=0;
            double _valorPago = 0,_valorTaxa=0;
            Tributario_bll clsTributario = new Tributario_bll(_connection);

            foreach (SpExtrato item in Lista) {
                ListViewItem lvItem = new ListViewItem {
                    Text = item.Abrevtributo,
                    ForeColor = Color.Black,
                    UseItemStyleForSubItems = false
                };
                lvItem.SubItems.Add(item.Valortributo.ToString("#0.00"),  _foreColor,_backColor,_font);
                lvItem.SubItems.Add(item.Valormulta.ToString("#0.00"), _foreColor, _backColor,_font);
                lvItem.SubItems.Add(item.Valorjuros.ToString("#0.00"), _foreColor,_backColor ,_font);
                lvItem.SubItems.Add(item.Valorcorrecao.ToString("#0.00"), _foreColor,_backColor, _font);
                lvItem.SubItems.Add(item.Valortotal.ToString("#0.00"), _foreColor, _backColor, _font);
                lvTributo.Items.Add(lvItem);
                _valorTributo += item.Valortributo;
                _valorJuros += item.Valorjuros;
                _valorMulta += item.Valormulta;
                _valorCorrecao += item.Valorcorrecao;
                _valorTotal += item.Valortotal;
            }
            ListViewItem lvItem2 = new ListViewItem {
                Text = "Total ==>",
                ForeColor = Color.Brown,
                UseItemStyleForSubItems = false
            };
            lvItem2.SubItems.Add(_valorTributo.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorMulta.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorJuros.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorCorrecao.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorTotal.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvTributo.Items.Add(lvItem2);

            SpExtrato reg = Lista[0];
            lblDataBase.Text = reg.Datadebase.ToString("dd/MM/yyyy");
            lblDataVencto.Text = reg.Datavencimento.ToString("dd/MM/yyyy");
            lblDataVenctoCalc.Text = reg.Datavencimentocalc.Year < 1990 ? reg.Datavencimento.ToString("dd/MM/yyyy") : reg.Datavencimentocalc.ToString("dd/MM/yyyy");
            _valorPago = reg.Valorpagoreal == 0 ? Convert.ToDouble(_valorTotal) : Convert.ToDouble(reg.Valorpagoreal);
            lblValorLanc.Text = _valorTributo.ToString("#0.00");
            lblValorAtual.Text = _valorTotal.ToString("#0.00");
            lblValorPago.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");
            lblLivro.Text = reg.Numlivro == null ? "0000" : Convert.ToInt32(reg.Numlivro).ToString("0000");
            lblDataInscricao.Text = reg.Datainscricao == null ? "  /  /    " : Convert.ToDateTime(reg.Datainscricao).ToString("dd/MM/yyyy");
            lblPagina.Text = reg.Pagina == null ? "00000" : Convert.ToInt32(reg.Pagina).ToString("00000");
            lblCertidao.Text = reg.Certidao == null ? "00000" : Convert.ToInt32(reg.Certidao).ToString("00000");
            lblAjuizamento.Text = reg.Dataajuiza == null ? "  /  /    " : Convert.ToDateTime(reg.Dataajuiza).ToString("dd/MM/yyyy");
            lblProcessoCNJ.Text = reg.Processocnj ?? "0000000-00.0.0.00.0000";
            lblNumProtocolo.Text = reg.Prot_certidao == null ? "0000000" : reg.Prot_certidao.ToString();
            lblDataRemessa.Text = reg.Prot_dtremessa == null ? "  /  /    " : Convert.ToDateTime(reg.Prot_dtremessa).ToString("dd/MM/yyyy");
            lblLancamento.Text = reg.Codlancamento.ToString("000") + "-" + reg.Desclancamento;
            lblNome.Text = _codigo.ToString("000000") + "-" + _nome;
            lblStatus.Text = reg.Statuslanc.ToString("00") + "-"+reg.Situacao;
            lblDataPagto.Text = reg.Datapagamento == null ? "  /  /    " : Convert.ToDateTime(reg.Datapagamento).ToString("dd/MM/yyyy");
            lblValorPago.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");

            _valorTaxa = clsTributario.Retorna_Taxa_Expediente(_codigo, reg.Anoexercicio, reg.Codlancamento, reg.Seqlancamento, reg.Numparcela, reg.Codcomplemento);
            lblTaxaExp.Text = Convert.ToDouble(_valorTaxa).ToString("#0.00");
            lblValorDif.Text = Convert.ToDouble(reg.Valorpago - (Convert.ToDecimal(_valorTaxa) + _valorTotal)).ToString("#0.00");
            //TODO: Ler % de Isenção e Isento de Multa de Juros
        }


    }//end Class
}
