using JarvisGoogleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Domain.Repositories.Abstract
{
    public interface ICommandsRepository
    {
        public IQueryable<Command> GetCommands();
        public Dictionary<string, string> GetCommandsAsDictionary();
        public void SaveCommand(Command command);
        public void DeleteCommand(Command command);
    }
}
