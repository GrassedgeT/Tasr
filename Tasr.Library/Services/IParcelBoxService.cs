using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services
{
    public interface IParcelBoxService
    {
        string Put(object o);
        object Get(string key);
    }
}
