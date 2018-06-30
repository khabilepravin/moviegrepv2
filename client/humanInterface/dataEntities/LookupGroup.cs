using System.Collections.Generic;

namespace dataEntities
{
    public class LookupGroup : BaseModelEntity
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        #region Custom
        public List<LookupValue> LookupValues { get; set; }
        #endregion Custom
    }
}
