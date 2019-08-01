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
    }
}
