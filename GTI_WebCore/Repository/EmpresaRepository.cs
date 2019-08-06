using GTI_WebCore.Models;
using GTI_WebCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Repository {
    public class EmpresaRepository : IEmpresaRepository {
        private readonly AppDbContext context;

        public EmpresaRepository(AppDbContext context) {
            this.context = context;
        }

        public Mobiliario GetEmpresaDetail(int Codigo) {
            return context.Mobiliario.Find(Codigo);
        }

        public bool Existe_Empresa_Codigo(int nCodigo) {
            bool bRet = false;
            var existingReg = context.Mobiliario.Count(a => a.Codigomob == nCodigo);
            if (existingReg != 0) 
                bRet = true;
            return bRet;
        }

        public int Existe_Empresa_Cnpj(string Cnpj) {
            int nCodigo = 0;
            var existingReg = context.Mobiliario.Count(a => a.Cnpj == Cnpj);
            if (existingReg != 0) {
                int reg = (from m in context.Mobiliario where m.Cnpj == Cnpj select m.Codigomob).FirstOrDefault();
                nCodigo = reg;
            }
            return nCodigo;
        }

        public int Existe_Empresa_Cpf(string Cpf) {
            int nCodigo = 0;
            var existingReg = context.Mobiliario.Count(a => a.Cpf == Cpf);
            if (existingReg != 0) {
                int reg = (from m in context.Mobiliario where m.Cnpj == Cpf select m.Codigomob).FirstOrDefault();
                nCodigo = reg;
            }
            return nCodigo;
        }

    }
}
