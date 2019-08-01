using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models {
    public class SQLEmpresaRepository : IEmpresaRepository {
        private readonly AppDbContext context;

        public SQLEmpresaRepository(AppDbContext context) {
            this.context = context;
        }


        public Mobiliario GetEmpresaDetail(int Codigo) {
            return context.Mobiliario.Find(Codigo);
           
        }
    }
}
