using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Services.Impl
{
    public class ParcelBoxService : IParcelBoxService
    {
        private readonly Dictionary<string, object> _box = new Dictionary<string, object>();
        public string Put(object o)
        {
            var token = Guid.NewGuid().ToString();
            _box[token] = o;
            return token;
        }

        public object Get(string key) => 
            _box.TryGetValue(key, out var o) ? o : null;
        
    }   
}
