using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Comunicado_Isencao : Form {
        private string _connection = gtiCore.Connection_Name();


        public Comunicado_Isencao() {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e) {

            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);

            List<int> _lista_codigos = imovel_Class.Lista_Comunicado_Isencao();
            foreach (int _codigo in _lista_codigos) {

                //Dados contribuinte
                string _nome = "", _cpfcnpj = "", _endereco = "", _bairro = "", _cidade = "", _cep = "", _inscricao = "", _lote = "", _quadra = "";
                string  _complemento = "", _complemento_entrega = "", _endereco_entrega = "", _bairro_entrega = "", _cidade_entrega = "", _cep_entrega = "";

                Contribuinte_Header_Struct dados = sistema_Class.Contribuinte_Header(_codigo);
                if (dados == null)
                    goto Proximo;

                _nome = dados.Nome;
                _cpfcnpj = dados.Cpf_cnpj;
                _inscricao = dados.Inscricao;
                _complemento = dados.Complemento == "" ? "" : " " + dados.Complemento;
                _endereco = dados.Endereco + ", " + dados.Numero.ToString() + _complemento;
                _bairro = dados.Nome_bairro;
                _cidade = dados.Nome_cidade + "/" + dados.Nome_uf;
                _cep = dados.Cep;
                _lote = dados.Lote_original;
                _quadra = dados.Quadra_original;

                //Endereço de Entrega
                EnderecoStruct endImovel = imovel_Class.Dados_Endereco(_codigo, dados.TipoEndereco);
                _complemento_entrega = endImovel.Complemento == "" ? "" : " " + endImovel.Complemento;
                _endereco_entrega = endImovel.Endereco + ", " + endImovel.Numero.ToString() + _complemento_entrega;
                _bairro_entrega = endImovel.NomeBairro;
                _cidade_entrega = endImovel.NomeCidade + "/" + endImovel.UF;
                _cep_entrega = endImovel.Cep;
Proximo:;
            }

            ReportCR fRpt = new ReportCR("Comunicado_Isencao", null, null, 0);
            fRpt.ShowDialog();



        }


    }
}
