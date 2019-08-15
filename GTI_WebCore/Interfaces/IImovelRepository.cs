using GTI_WebCore.Models;
using System;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface IImovelRepository {
        bool Existe_Imovel(int nCodigo);
        ImovelStruct Dados_Imovel(int nCodigo);
        List<ProprietarioStruct> Lista_Proprietario(int CodigoImovel, bool Principal = false);
        Laseriptu Dados_IPTU(int Codigo, int Ano);
        List<Laseriptu> Dados_IPTU(int Codigo);
        SpCalculo Calculo_IPTU(int Codigo, int Ano);
        decimal Soma_Area(int Codigo);
    }
}
