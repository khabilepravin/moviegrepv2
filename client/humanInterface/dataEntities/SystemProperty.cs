﻿namespace dataEntities
{
    public class SystemProperty : BaseModelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public string RowStatus { get; set; }
    }
}
