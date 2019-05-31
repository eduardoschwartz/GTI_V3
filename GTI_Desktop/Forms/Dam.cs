using GTI_Desktop.Classes;
using GTI_Models.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Dam : Form {
        string _connection = gtiCore.Connection_Name();
        List<SpExtrato> _lista_selecionados = new List<SpExtrato>();
        List<SpExtrato> _extrato = new List<SpExtrato>();

        public Dam(List<SpExtrato>_ListaSelecionados,List<SpExtrato>_ListaTributos) {
            InitializeComponent();
            tBar.Renderer = new MySR();
            _lista_selecionados = _ListaSelecionados;
            _extrato = _ListaTributos;
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            List<SpExtrato> _listaTmp = new List<SpExtrato>();

            foreach (SpExtrato itemSelected in _lista_selecionados) {
                foreach (SpExtrato itemTributo in _extrato) {
                    if (itemSelected.Anoexercicio == itemTributo.Anoexercicio && itemSelected.Codlancamento == itemTributo.Codlancamento && itemSelected.Seqlancamento == itemTributo.Seqlancamento &&
                        itemSelected.Numparcela == itemTributo.Numparcela && itemSelected.Codcomplemento == itemTributo.Codcomplemento) {

                        int _pos = 0;
                        bool _find = false;
                        foreach (SpExtrato itemTmp in _listaTmp) {
                            if (itemSelected.Anoexercicio == itemTmp.Anoexercicio && itemSelected.Codlancamento == itemTmp.Codlancamento && itemSelected.Seqlancamento == itemTmp.Seqlancamento &&
                                itemSelected.Numparcela == itemTmp.Numparcela && itemSelected.Codcomplemento == itemTmp.Codcomplemento) {
                                _find = true;
                                break;
                            }
                            _pos++;
                        }
                        if (!_find) {
                            SpExtrato _reg = new SpExtrato() {
                                Anoexercicio=itemTributo.Anoexercicio,
                                Codlancamento=itemTributo.Codlancamento,
                                Seqlancamento=itemTributo.Seqlancamento,
                                Numparcela=itemTributo.Numparcela,
                                Codcomplemento=itemTributo.Codcomplemento,
                                Datavencimento=itemTributo.Datavencimento,
                                Valortributo=itemTributo.Valortributo,
                                Valormulta=itemTributo.Valormulta,
                                Valorjuros=itemTributo.Valorjuros,
                                Valorcorrecao=itemTributo.Valorcorrecao,
                                Valortotal=itemTributo.Valortotal
                            };
                            _listaTmp.Add(_reg);
                        } else {
                            _listaTmp[_pos].Valortributo += itemTributo.Valortributo;
                            _listaTmp[_pos].Valormulta += itemTributo.Valormulta;
                            _listaTmp[_pos].Valorjuros += itemTributo.Valorjuros;
                            _listaTmp[_pos].Valorcorrecao += itemTributo.Valorcorrecao;
                            _listaTmp[_pos].Valortotal += itemTributo.Valortotal;
                        }
                    }
                }
            }

            foreach (SpExtrato item in _listaTmp) {
                ListViewItem lvItem = new ListViewItem(item.Anoexercicio.ToString());
                lvItem.SubItems.Add(item.Codlancamento.ToString("00"));
                lvItem.SubItems.Add(item.Seqlancamento.ToString("000"));
                lvItem.SubItems.Add(item.Numparcela.ToString("000"));
                lvItem.SubItems.Add(item.Codcomplemento.ToString());
                lvItem.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lvItem.SubItems.Add(item.Valortributo.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valormulta.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valorjuros.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valorcorrecao.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valortotal.ToString("#0.00"));
                MainListView.Items.Add(lvItem);
            }

        }

    }
}
