using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dataAccess
{
    public class repoMain 
    {
        public IQueryable<main> GetFirst()
        {
            MinerDataAccess dataAccess = new MinerDataAccess();

            return dataAccess.GetFirst();
        }
    }
}
