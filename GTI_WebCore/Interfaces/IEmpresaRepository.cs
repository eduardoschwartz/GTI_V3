using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Interfaces {
    public interface IEmpresaRepository {
        bool Existe_Empresa_Codigo(int Codigo);
        int Existe_Empresa_Cnpj(string Cnpj);
        int Existe_Empresa_Cpf(string Cpf);
        bool Empresa_Suspensa(int nCodigo);
        EmpresaStruct Dados_Empresa(int Codigo);

    }
}
