using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models {
    public class MockEmpresaRepository:IEmpresaRepository {
        private List<Empresa> _empresaList;

        public MockEmpresaRepository() {
            _empresaList = new List<Empresa>() {
                new Empresa(){Codigo=1,Razao_Social="Empresa 1"},
                new Empresa(){Codigo=2,Razao_Social="Empresa 2"}
            };
        }

        public Empresa GetEmpresaDetail(int Codigo) {
            return _empresaList.FirstOrDefault(e => e.Codigo == Codigo);
        }
    }
}
