using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarziniYarat.Core.DataAccess.EntityFramework
{
    class SingletonContext<TContext> where TContext : new()
    {
        private static TContext _context;

        internal static TContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }

        }
    }
}
