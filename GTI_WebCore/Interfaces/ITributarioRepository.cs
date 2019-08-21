using GTI_WebCore.Models;
using System;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface ITributarioRepository {
        int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao);
        chaveStruct Valida_Certidao(string Chave);
        Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo);
        Certidao_valor_venal Retorna_Certidao_Valor_Venal(int Ano, int Numero, int Codigo);
        Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo);
        Certidao_Inscricao Retorna_Certidao_Inscricao(int Ano, int Numero);
        Exception Insert_Certidao_Endereco(Certidao_endereco Reg);
        Exception Insert_Certidao_Valor_Venal(Certidao_valor_venal Reg);
        Exception Insert_Certidao_Isencao(Certidao_isencao Reg);
        Exception Insert_Certidao_Inscricao(Certidao_Inscricao Reg);
    }
}
