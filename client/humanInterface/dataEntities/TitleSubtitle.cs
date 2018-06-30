
namespace dataEntities
{
    public class TitleSubtitle : BaseModelEntity
    {
        public long Id { get; set; }
        public long TitleId { get; set; }
        public string SubtitleText { get; set; }
        public string SubtitleLanguageCode { get; set; }
    }
}
