using JarvisGoogleAPI.Domain.Entities;
using JarvisGoogleAPI.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Domain.Repositories.EntityFramework
{
    public class EfProcNamesRepository : IProcNamesRepository
    {

        private readonly AppDbContext _context;
        public EfProcNamesRepository(AppDbContext context) => _context = context;

        public void DeleteProcName(ProcName procName)
        {
            _context.ProcNames.Remove(procName);
            _context.SaveChanges();
        }

        public IQueryable<ProcName> GetProcNames()
        {
            return _context.ProcNames;
        }

        public Dictionary<string, string> GetProcNamesAsDictionary()
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            IQueryable<ProcName> result = _context.ProcNames;

            foreach (var item in result)
            {
                temp.Add(item.UserName, item.SystemName);
            }

            return temp;
        }

        public void SaveProcName(ProcName procName)
        {
            _context.Entry(procName).State = (procName.Id == default)
               ? EntityState.Added
               : EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
