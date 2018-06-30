
namespace dataEntities
{
    public class IndexableEntity : SubtitlesText
    {
        public long TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleStartTime { get; set; }
        public string TitleEndTime { get; set; }
        public byte Rating { get; set; }
        public long RatingId { get; set; }
        public string UrlFriendlyQuoteText { get; set; }
    }
}
