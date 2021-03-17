using JarvisGoogleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Domain.Repositories.Abstract
{
    public interface IProcNamesRepository
    {
        public IQueryable<ProcName> GetProcNames();
        public Dictionary<string, string> GetProcNamesAsDictionary();

        public List<ProcName> GetProcNamesAsList();
        public void SaveProcName(ProcName procName);
        public void DeleteProcName(ProcName procName);
    }
}
