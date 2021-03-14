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
    public class EfCommandsRepository : ICommandsRepository
    {
        private readonly AppDbContext _context;
        public EfCommandsRepository(AppDbContext context) => _context = context;

        public void DeleteCommand(Command command)
        {
            _context.Commands.Remove(command);
            _context.SaveChanges();
        }

        public IQueryable<Command> GetCommands()
        {
            return _context.Commands;
        }

        public Dictionary<string, string> GetCommandsAsDictionary()
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            IQueryable<Command> result = _context.Commands;

            foreach(var item in result)
            {
                temp.Add(item.SystemName, item.UserName);
            }

            return temp;
        }

        public void SaveCommand(Command command)
        {
            _context.Entry(command).State = (command.Id == default)
                ? EntityState.Added
                : EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
