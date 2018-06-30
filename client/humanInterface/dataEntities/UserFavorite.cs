
namespace dataEntities
{
    public class UserFavorite : BaseModelEntity
    {
        public long UserFavoriteId { get; set; }

        public string UserIdentification { get; set; }

        public string IdentificationSource { get; set; }

        public long SubtitleTextId { get; set; }

        public string RecordStatus { get; set; }

        public int Rating { get; set; }

        #region Custom
        public string SubtitleText { get; set; }
        #endregion Custom
    }
}
