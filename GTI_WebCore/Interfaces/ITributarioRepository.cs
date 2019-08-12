using System;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface ITributarioRepository {
        int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao);
    }
}
