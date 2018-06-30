using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataEntities
{
    public class ExternalSource : BaseModelEntity
    {   
        public int TitleId { get; set; }

        public string ExternalSourceId { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string Type { get; set; }
    }
}
