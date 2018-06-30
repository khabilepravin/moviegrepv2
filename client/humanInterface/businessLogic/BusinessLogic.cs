using dataAccess;
using dataEntities;
using indexing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using theParser;

namespace businessLogic
{
    public class BusinessLogic
    {
        public int SubmitTitle(Title title, TitleSubtitle titleSubtitle)
        {
            int titleId = 0;
            using (TransactionScope tansaction = new TransactionScope())
            {
                DataManager da = new DataManager();
                titleId = da.TitlesInsert(title);
                if (titleSubtitle != null)
                {
                    if (titleId > 0)
                    {
                        titleSubtitle.TitleId = titleId;
                    }
                    da.TitleSubtitleInsert(titleSubtitle);
                }

                tansaction.Complete();
            }

            return titleId;
        }

        public void ParseTitle(long titleId)
        {
            DataManager da = new DataManager();
            Title title = da.TitlesGetById(titleId);
            
            if (title != null)
            {
                List<TitleSubtitle> titleSubtitles = da.TitleSubtitleGetByTitleId(title.Id);
                if (titleSubtitles != null && titleSubtitles.Count > 0)
                {
                    foreach (TitleSubtitle titleSubtitle in titleSubtitles)
                    {
                        List<IndexableEntity> parsedData = SubtitleParser.ParseIt(title, titleSubtitle);

                        // insert these into subtitles table
                        if (parsedData != null)
                        {
                            foreach (IndexableEntity indexable in parsedData)
                            {
                                da.SubtitlesTextInsert(indexable);
                            }
                        }
                    }
                }

                da.TitlesIndexStatusUpdate(title.Id, "Parsed");
            }
        }

        public void IndexTitle(long titleId)
        {
            DataManager da = new DataManager();
            List<IndexableEntity> subtitleTextCollection = da.SubtitlesTextGetByTitleId(titleId);

            if(subtitleTextCollection != null)
            {
                IndexMiner.AddUpdateLuceneIndex(subtitleTextCollection);
            }

            da.TitlesIndexStatusUpdate(titleId, "Indexed");
        }

        public List<IndexableEntity> Search(string criteria, string filmName = "", string userId="")
        {
            IEnumerable<IndexableEntity> searchedData = IndexMiner.Search(criteria, filmName);
            return LoadActualDataForIndexSearchResult(searchedData);
        }

        public List<IndexableEntity> Search(Dictionary<string, string> searchTerms, string userId="")
        {
            IEnumerable<IndexableEntity> searchedData = IndexMiner.SearchByMultipleFields(searchTerms);
            return LoadActualDataForIndexSearchResult(searchedData, userId);
        }

        private List<IndexableEntity> LoadActualDataForIndexSearchResult(IEnumerable<IndexableEntity> indexSearchResult, string userId="")
        {
            List<IndexableEntity> actualDataPopulated = null;

            // get the actual data
            if (indexSearchResult != null)
            {
                DataManager da = new DataManager();

                StringBuilder buildIds = new StringBuilder();
                foreach (IndexableEntity searchedItem in indexSearchResult)
                {
                    if (!string.IsNullOrWhiteSpace(buildIds.ToString())) { buildIds.Append(","); }
                    buildIds.Append(searchedItem.Id);
                }

                actualDataPopulated = da.SubtitlesTextGetByIds(buildIds.ToString(), userId);
            }

            return actualDataPopulated;
        }

        public IndexableEntity GetRandomQuote(string userIdentification)
        {
            DataManager da = new DataManager();
            return da.RandomSubtitleGet(userIdentification);
        }

        public void ParseAndReIndexAll()
        {
            DataManager da = new DataManager();
            List<Title> allTitles = da.TitlesGetAll();

            if (allTitles != null)
            {
                IndexMiner.ClearLuceneIndex();

                foreach (Title t in allTitles)
                {
                    ParseTitle(t.Id);
                    IndexTitle(t.Id);
                }
            }
        }

        public List<IndexableEntity> SubtitlesGetAdjacent(int currentSubtitleId, int forwardIncrements, int backwardIncrements)
        {
            List<IndexableEntity> adjacentSubtitles = null;
            string adjacentIds = string.Empty;

            int startingIndex = (currentSubtitleId - backwardIncrements);
            int endingIndex = (currentSubtitleId + forwardIncrements);

            if (startingIndex < 0) { startingIndex = 1; }
            
            while (startingIndex <= endingIndex)
            {
                if (!string.IsNullOrWhiteSpace(adjacentIds)) { adjacentIds += ","; }

                adjacentIds += startingIndex.ToString();

                startingIndex++;
            }

            if (!string.IsNullOrWhiteSpace(adjacentIds))
            {
                DataManager dataManager = new DataManager();
                adjacentSubtitles = dataManager.SubtitlesTextGetByIds(adjacentIds);
            }

            return adjacentSubtitles;
        }

        public int GetCurrentTimePercent(long titleId, double totalCurrentSeconds)
        {
            DataManager da = new DataManager();
            TimeSpan endTime = da.TitleGetEndTime(titleId);

            return Convert.ToInt32((totalCurrentSeconds / endTime.TotalSeconds) * 100);
        }

        public string TitlesGetAllJson()
        {
            DataManager dm = new DataManager();
            return dm.TitlesGetAllJson();
        }

        public long AddUpdateUserFavorite(UserFavorite userFavorite)
        {
            long updatedRecordId;

            DataManager dataAccess = new DataManager();
            if (userFavorite.UserFavoriteId > 0)
            {
                dataAccess.UserFavoritesUpdate(userFavorite);
                updatedRecordId = userFavorite.UserFavoriteId;
            }
            else
            {
                updatedRecordId = dataAccess.UserFavoritesInsert(userFavorite);
            }

            return updatedRecordId;
        }
    }
}
