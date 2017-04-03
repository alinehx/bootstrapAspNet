using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IConnectionDB : IDisposable
    {
        IDatabase database { get; }
        bool connectionIsOpen { get; }

        
        void openConnection();
        void closeConnection();
        new void Dispose();
    }
}
