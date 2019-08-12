using GTI_WebCore.Models;
using System;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface ITributarioRepository {
        int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao);
        Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo);
    }
}
