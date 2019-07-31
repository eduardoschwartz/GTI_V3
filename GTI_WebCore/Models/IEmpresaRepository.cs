using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models {
    public interface IEmpresaRepository {
        Empresa GetEmpresaDetail(int Codigo);
    }
}
