using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Interfaces {
    public interface IEmpresaRepository {
        Mobiliario GetEmpresaDetail(int Codigo);
    }
}
