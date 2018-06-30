
using System;
namespace dataEntities
{
    public class SubtitlesText : BaseModelEntity
    {
        public long SubtitleTextId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string SubtitleText { get; set; }

        public int PopularityIndex { get; set; }
    }
}
