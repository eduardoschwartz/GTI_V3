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
            Tributario_bll tributario_Class = new Tributario_bll(_connection);

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
                TributoListView.Items.Add(lvItem);
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
            TributoListView.Items.Add(lvItem2);

            SpExtrato reg = Lista[0];
            DataBaseLabel.Text = reg.Datadebase.ToString("dd/MM/yyyy");
            DataVenctoLabel.Text = reg.Datavencimento.ToString("dd/MM/yyyy");
            DataVenctoCalcLabel.Text = reg.Datavencimentocalc.Year < 1990 ? reg.Datavencimento.ToString("dd/MM/yyyy") : reg.Datavencimentocalc.ToString("dd/MM/yyyy");
            _valorPago = reg.Valorpagoreal == 0 ? Convert.ToDouble(_valorTotal) : Convert.ToDouble(reg.Valorpagoreal);
            ValorLancadoLabel.Text = _valorTributo.ToString("#0.00");
            ValorAtualLabel.Text = _valorTotal.ToString("#0.00");
            ValorPagoLabel.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");
            LivroLabel.Text = reg.Numlivro == null ? "0000" : Convert.ToInt32(reg.Numlivro).ToString("0000");
            DataInscricaoLabel.Text = reg.Datainscricao == null ? "  /  /    " : Convert.ToDateTime(reg.Datainscricao).ToString("dd/MM/yyyy");
            PaginaLabel.Text = reg.Pagina == null ? "00000" : Convert.ToInt32(reg.Pagina).ToString("00000");
            CertidaoLabel.Text = reg.Certidao == null ? "00000" : Convert.ToInt32(reg.Certidao).ToString("00000");
            AjuizamentoLabel.Text = reg.Dataajuiza == null ? "  /  /    " : Convert.ToDateTime(reg.Dataajuiza).ToString("dd/MM/yyyy");
            ProcessoCNJLabel.Text = reg.Processocnj ?? "0000000-00.0.0.00.0000";
            NumProtocoloLabel.Text = reg.Prot_certidao == null ? "0000000" : reg.Prot_certidao.ToString();
            DataRemessaLabel.Text = reg.Prot_dtremessa == null ? "  /  /    " : Convert.ToDateTime(reg.Prot_dtremessa).ToString("dd/MM/yyyy");
            LancamentoLabel.Text = reg.Codlancamento.ToString("000") + "-" + reg.Desclancamento;
            NomeLabel.Text = _codigo.ToString("000000") + "-" + _nome;
            StatusLabel.Text = reg.Statuslanc.ToString("00") + "-"+reg.Situacao;
            DataPagtoLabel.Text = reg.Datapagamento == null ? "  /  /    " : Convert.ToDateTime(reg.Datapagamento).ToString("dd/MM/yyyy");
            ValorPagoLabel.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");

            Debitoparcela _parcelaReg = new Debitoparcela() {
                Codreduzido=reg.Codreduzido,
                Anoexercicio=reg.Anoexercicio,
                Codlancamento=reg.Codlancamento,
                Seqlancamento=reg.Seqlancamento,
                Numparcela=(byte)reg.Numparcela,
                Codcomplemento=reg.Codcomplemento
            };

            DebitoPagoStruct dpReg = tributario_Class.Retorna_DebitoPago_Parcela(_parcelaReg);
            if (dpReg != null) {
                TaxaExpLabel.Text = Convert.ToDouble(dpReg.Valor_Tarifa).ToString("#0.00");
                if (dpReg.Data_Pagamento_Calc != null && Convert.ToDateTime(dpReg.Data_Pagamento_Calc).Year > 1970)
                    DataPagtoCalcLabel.Text = Convert.ToDateTime(dpReg.Data_Pagamento_Calc).ToString("dd/MM/yyyy");
                else
                    DataPagtoCalcLabel.Text = "  /  /    ";

                DataReceitaLabel.Text = dpReg.Data_Recebimento == null ? "  /  /    " : Convert.ToDateTime(dpReg.Data_Recebimento).ToString("dd/MM/yyyy");
                string _banco = Convert.ToInt32(dpReg.Banco_Codigo).ToString("000");
                string _agencia = Convert.ToInt32(dpReg.Codigo_Agencia).ToString("000");
                BancoLabel.Text = _banco + "/" + _agencia;
                int _numdoc = Convert.ToInt32(dpReg.Numero_Documento);
                NumDocLabel.Text = _numdoc.ToString("00000000") + "-" + tributario_Class.DvDocumento(_numdoc);
                ValorDifLabel.Text = Convert.ToDouble(dpReg.Valor_Dif).ToString("#0.00");
                Numdocumento regDoc = tributario_Class.Retorna_Dados_Documento(_numdoc);
                if (regDoc.Isentomj == 1)
                    IsentoLabel.Text = "Sim";
                else
                    IsentoLabel.Text = "Não";
                DescontoLabel.Text = Convert.ToDecimal(regDoc.Percisencao).ToString("#0.00") + "%";
            }

            if (reg.UserId>0) {
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                string _nome = sistema_Class.Retorna_User_FullName(Convert.ToInt32(reg.UserId));
                this.Text += " (Gerado por: " + _nome + ")";
            }


        }


    }//end Class
}
