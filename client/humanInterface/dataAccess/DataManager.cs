using dataEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace dataAccess
{    
    public class DataManager : DataAccessBase
    {
        private readonly string usp_Title_Insert = "[dbo].[usp_Titles_Insert]";
        private readonly string usp_Titles_Select = "[dbo].[usp_Titles_Select]";
        private readonly string usp_Titles_CheckDuplicity = "[dbo].[usp_Titles_CheckDuplicity]";
        private readonly string usp_Titles_Select_All = "[dbo].[usp_Titles_Select_All]";
        private readonly string usp_Titles_Update = "[dbo].[usp_Titles_Update]";
        private readonly string usp_Titles_IndexStatus_Update = "[dbo].[usp_Titles_IndexStatus_Update]";
        private readonly string usp_SubtitlesText_Insert = "[dbo].[usp_SubtitlesText_Insert]";
        private readonly string usp_SubtitlesText_SelectByTitleId = "[dbo].[usp_SubtitlesText_SelectByTitleId]";
        private readonly string usp_SubtitlesText_SelectByIds = "[dbo].[usp_SubtitlesText_SelectByIds]";
        private readonly string usp_LookupValue_SelectByGroup = "[dbo].[usp_LookupValue_SelectByGroup]";
        private readonly string usp_RandomSubtitleId_Get = "[dbo].[usp_RandomSubtitleId_Get]";
        private readonly string usp_TitleSubtitle_Insert = "[dbo].[usp_TitleSubtitle_Insert]";
        private readonly string usp_TitleSubtitle_SelectGetByTitle  = "[dbo].[usp_TitleSubtitle_SelectGetByTitle]";
        private readonly string usp_Title_GetEndTime = "[dbo].[usp_Title_GetEndTime]";
        private readonly string usp_UserFavorites_Select = "[dbo].[usp_UserFavorites_Select]";
        private readonly string usp_UserFavorites_Insert = "[dbo].[usp_UserFavorites_Insert]";
        private readonly string usp_UserFavorites_Update = "[dbo].[usp_UserFavorites_Update]";

        public int TitlesInsert(Title title)
        {
            int titleId = 0;

            if (RecordExists(title)) { throw new Exception("The record with similar details already exists."); }

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Direction=ParameterDirection.Output, Size=int.MaxValue });
                paramColl.Add(new SqlParameter() { ParameterName = "@Title", Value = NullSafeGetter.IsDefault<string>(title.TitleName) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Season", Value = NullSafeGetter.IsDefault<string>(title.Season) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Episode", Value = NullSafeGetter.IsDefault<string>(title.Episode) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Year", Value = NullSafeGetter.IsDefault<string>(title.Year) });
                paramColl.Add(new SqlParameter() { ParameterName = "@IndexStatus", Value = NullSafeGetter.IsDefault<string>(title.IndexStatus) });
                paramColl.Add(new SqlParameter() { ParameterName = "@RowStatus", Value = NullSafeGetter.IsDefault<string>(title.RowStatus) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Tags", Value = NullSafeGetter.IsDefault<string>(title.Tags) }); 


                using (SqlCommand command = BuildCommand(usp_Title_Insert, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();
                    titleId = Convert.ToInt32(command.Parameters["@Id"].Value);
                }               
            }

            return titleId;
        }

        public Title TitlesGetById(long id)
        {
            Title title = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Value = id });

                using (SqlCommand command = BuildCommand(usp_Titles_Select, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        title = new Title()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            TitleName = reader.GetValueOrDefault<string>("Title"),
                            Season = reader.GetValueOrDefault<string>("Season"),
                            Episode = reader.GetValueOrDefault<string>("Episode"),
                            Year = reader.GetValueOrDefault<string>("Year"),
                            IndexStatus = reader.GetValueOrDefault<string>("IndexStatus"),
                            RowStatus = reader.GetValueOrDefault<string>("RowStatus"),
                            Tags = reader.GetValueOrDefault<string>("Tags")
                        };
                    }

                    reader.Close();
                }
            }

            return title;
        }

        public List<Title> TitlesGetAll()
        {
            List<Title> titles = null;

            using (SqlConnection conn = GetNewConnection())
            {
                using (SqlCommand command = GetCommand(usp_Titles_Select_All, CommandType.StoredProcedure))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Title title = new Title()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            TitleName = reader.GetValueOrDefault<string>("Title"),
                            Season = reader.GetValueOrDefault<string>("Season"),
                            Episode = reader.GetValueOrDefault<string>("Episode"),
                            Year = reader.GetValueOrDefault<string>("Year"),
                            IndexStatus = reader.GetValueOrDefault<string>("IndexStatus"),
                            RowStatus = reader.GetValueOrDefault<string>("RowStatus"),
                            Tags = reader.GetValueOrDefault<string>("Tags")
                        };

                        if (titles == null) { titles = new List<Title>(); }
                        titles.Add(title);
                    }

                    reader.Close();
                }
            }

            return titles;
        }

        public string TitlesGetAllJson()
        {
            StringBuilder titlesBuilder = new StringBuilder();
            using (SqlConnection conn = GetNewConnection())
            {
                using (SqlCommand command = GetCommand(usp_Titles_Select_All, CommandType.StoredProcedure))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        if (!string.IsNullOrWhiteSpace(titlesBuilder.ToString()))
                        {
                            titlesBuilder.Append(",");
                        }

                        titlesBuilder.Append(reader.GetValueOrDefault<string>("Title"));
                    }

                    reader.Close();
                }
            }

            return titlesBuilder.ToString();
        }

        public void TitlesUpdate(Title title)
        {
            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Value = NullSafeGetter.IsDefault<long>(title.Id) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Title", Value = NullSafeGetter.IsDefault<string>(title.TitleName) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Season", Value = NullSafeGetter.IsDefault<string>(title.Season) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Episode", Value = NullSafeGetter.IsDefault<string>(title.Episode) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Year", Value = NullSafeGetter.IsDefault<string>(title.Year) });
                paramColl.Add(new SqlParameter() { ParameterName = "@IndexStatus", Value = NullSafeGetter.IsDefault<string>(title.IndexStatus) });
                paramColl.Add(new SqlParameter() { ParameterName = "@RowStatus", Value = NullSafeGetter.IsDefault<string>(title.RowStatus) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Tags", Value = NullSafeGetter.IsDefault<string>(title.Tags) });


                using (SqlCommand command = BuildCommand(usp_Titles_Update, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();                    
                }
            }
        }

        public void TitlesIndexStatusUpdate(long titleId, string indexStatus)
        {
            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Value = NullSafeGetter.IsDefault<long>(titleId) });
                paramColl.Add(new SqlParameter() { ParameterName = "@IndexStatus", Value = NullSafeGetter.IsDefault<string>(indexStatus) });

                using (SqlCommand command = BuildCommand(usp_Titles_IndexStatus_Update, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool RecordExists(Title title)
        {
           bool isExists = false;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@Title", Value = title.TitleName});
                paramColl.Add(new SqlParameter() { ParameterName = "@Season", Value = NullSafeGetter.IsDefault<string>(title.Season) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Episode", Value = NullSafeGetter.IsDefault<string>(title.Episode) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Year", Value = NullSafeGetter.IsDefault<string>(title.Year) });

                using (SqlCommand command = BuildCommand(usp_Titles_CheckDuplicity, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    isExists = reader.HasRows;

                    reader.Close();
                }
            }

            return isExists;
        }

        public int SubtitlesTextInsert(SubtitlesText subtitlesText)
        {
            int subtitlesTextId = 0;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Direction = ParameterDirection.Output, Size = int.MaxValue });
                paramColl.Add(new SqlParameter() { ParameterName = "@SubtitleTextId", Value = NullSafeGetter.IsDefault<long>(subtitlesText.SubtitleTextId) });
                paramColl.Add(new SqlParameter() { ParameterName = "@StartTime", Value = NullSafeGetter.IsDefault<TimeSpan>(subtitlesText.StartTime) });
                paramColl.Add(new SqlParameter() { ParameterName = "@EndTime", Value = NullSafeGetter.IsDefault<TimeSpan>(subtitlesText.EndTime) });
                paramColl.Add(new SqlParameter() { ParameterName = "@SubtitleText", Value = NullSafeGetter.IsDefault<string>(subtitlesText.SubtitleText) });
                
                using (SqlCommand command = BuildCommand(usp_SubtitlesText_Insert, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();
                    subtitlesTextId = Convert.ToInt32(command.Parameters["@Id"].Value);
                }
            }

            return subtitlesTextId;            
        }

        public List<IndexableEntity> SubtitlesTextGetByTitleId(long titleId)
        {
            List<IndexableEntity> subtitlesTextForTitle = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@TitleId", Value = titleId });

                using (SqlCommand command = BuildCommand(usp_SubtitlesText_SelectByTitleId, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        IndexableEntity subtitlesText = new IndexableEntity()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            SubtitleTextId = reader.GetValueOrDefault<long>("SubtitleTextId"),
                            StartTime = reader.GetValueOrDefault<TimeSpan>("StartTime"),
                            EndTime = reader.GetValueOrDefault<TimeSpan>("EndTime"),
                            SubtitleText = reader.GetValueOrDefault<string>("SubtitleText"),
                            TitleName = reader.GetValueOrDefault<string>("Title")
                        };

                        if (subtitlesTextForTitle == null) { subtitlesTextForTitle = new List<IndexableEntity>(); }
                        subtitlesTextForTitle.Add(subtitlesText);
                    }

                    reader.Close();
                }
            }

            return subtitlesTextForTitle;
        }

        public List<IndexableEntity> SubtitlesTextGetByIds(string ids, string userId="")
        {
            List<IndexableEntity> subtitlesTextList = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@Ids", Value = ids });
                if(!string.IsNullOrWhiteSpace(userId))
                {
                    paramColl.Add(new SqlParameter() { ParameterName = "@UserIdentification", Value = userId });
                }

                using (SqlCommand command = BuildCommand(usp_SubtitlesText_SelectByIds, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        IndexableEntity subtitlesText = new IndexableEntity()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            SubtitleTextId = reader.GetValueOrDefault<long>("SubtitleTextId"),
                            StartTime = reader.GetValueOrDefault<TimeSpan>("StartTime"),
                            EndTime = reader.GetValueOrDefault<TimeSpan>("EndTime"),
                            SubtitleText = reader.GetValueOrDefault<string>("SubtitleText"),
                            TitleName = reader.GetValueOrDefault<string>("Title"),
                            TitleId = reader.GetValueOrDefault<long>("TitleId")//,
                            //Rating = reader.GetValueOrDefault<byte>("Rating"),
                            //RatingId = reader.GetValueOrDefault<long>("RatingId")
                        };

                        subtitlesText.UrlFriendlyQuoteText = subtitlesText.SubtitleText.UrlFriendlyString();

                        if (subtitlesTextList == null) { subtitlesTextList = new List<IndexableEntity>(); }
                        subtitlesTextList.Add(subtitlesText);
                    }

                    reader.Close();
                }
            }

            return subtitlesTextList;
        }

        public List<LookupValue> LookupValueGetByGroupName(string groupName)
        {
            List<LookupValue> lookupValues = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@GroupName", Value = groupName });

                using (SqlCommand command = BuildCommand(usp_LookupValue_SelectByGroup, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        LookupValue lookupValue = new LookupValue()
                        {
                            Id = reader.GetValueOrDefault<int>("Id"),
                            GroupId = reader.GetValueOrDefault<int>("GroupId"),
                            Name = reader.GetValueOrDefault<string>("Name"),
                            Value = reader.GetValueOrDefault<string>("Value"),
                            Description = reader.GetValueOrDefault<string>("Description"),
                            RowStatus = reader.GetValueOrDefault<string>("RowStatus")
                        };

                        if (lookupValues == null) { lookupValues = new List<LookupValue>(); }
                        lookupValues.Add(lookupValue);
                    }

                    reader.Close();
                }
            }

            return lookupValues;
        }

        public IndexableEntity RandomSubtitleGet(string userIdentification)
        {
            IndexableEntity subtitlesText = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@userId", Value = NullSafeGetter.IsDefault<string>(userIdentification) });

                using (SqlCommand command = GetCommand(usp_RandomSubtitleId_Get, CommandType.StoredProcedure))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        subtitlesText = new IndexableEntity()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            SubtitleTextId = reader.GetValueOrDefault<long>("SubtitleTextId"),
                            StartTime = reader.GetValueOrDefault<TimeSpan>("StartTime"),
                            EndTime = reader.GetValueOrDefault<TimeSpan>("EndTime"),
                            SubtitleText = reader.GetValueOrDefault<string>("SubtitleText"),                            
                            TitleName = reader.GetValueOrDefault<string>("Title"),
                            Rating = reader.GetValueOrDefault<byte>("Rating"),
                            RatingId = reader.GetValueOrDefault<int>("UserFavoriteId")
                        };

                        subtitlesText.UrlFriendlyQuoteText = subtitlesText.SubtitleText.UrlFriendlyString();
                    }

                    reader.Close();
                }
            }

            return subtitlesText;
        }

        public int TitleSubtitleInsert(TitleSubtitle titleSubtitle)
        {
            int titleSubtitleId = 0;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@Id", Direction=ParameterDirection.Output, Size=int.MaxValue });
                paramColl.Add(new SqlParameter() { ParameterName = "@TitleId", Value = NullSafeGetter.IsDefault<long>(titleSubtitle.TitleId) });
                paramColl.Add(new SqlParameter() { ParameterName = "@SubtitleText", Value = NullSafeGetter.IsDefault<string>(titleSubtitle.SubtitleText) });                                
                paramColl.Add(new SqlParameter() { ParameterName = "@SubtitleLanguageCode", Value = NullSafeGetter.IsDefault<string>(titleSubtitle.SubtitleLanguageCode) }); 

                using (SqlCommand command = BuildCommand(usp_TitleSubtitle_Insert, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();
                    titleSubtitleId = Convert.ToInt32(command.Parameters["@Id"].Value);
                }
            }

            return titleSubtitleId;
        }

        public List<TitleSubtitle> TitleSubtitleGetByTitleId(long titleId)
        {
            List<TitleSubtitle> titleSubtitles = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@TitleId", Value = titleId });

                using (SqlCommand command = BuildCommand(usp_TitleSubtitle_SelectGetByTitle, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        TitleSubtitle titleSubtitle = new TitleSubtitle()
                        {
                            Id = reader.GetValueOrDefault<long>("Id"),
                            TitleId = reader.GetValueOrDefault<long>("TitleId"),
                            SubtitleText = reader.GetValueOrDefault<string>("SubtitleText"),
                            SubtitleLanguageCode = reader.GetValueOrDefault<string>("SubtitleLanguageCode")
                        };

                        if (titleSubtitles == null) { titleSubtitles = new List<TitleSubtitle>(); }
                        titleSubtitles.Add(titleSubtitle);
                    }

                    reader.Close();
                }
            }

            return titleSubtitles;
        }

        public TimeSpan TitleGetEndTime(long titleId)
        {
            TimeSpan endTime;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@TitleId", Value = titleId });

                using (SqlCommand command = BuildCommand(usp_Title_GetEndTime, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    endTime = (TimeSpan)command.ExecuteScalar();
                }
            }

            return endTime;
        }

        public long UserFavoritesInsert(UserFavorite userFavorite)
        {
            long insertedUserFavoriteId;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@UserFavoriteId", Direction=ParameterDirection.Output, Size=int.MaxValue });
                paramColl.Add(new SqlParameter() { ParameterName = "@UserIdentification", Value = NullSafeGetter.IsDefault<string>(userFavorite.UserIdentification) });
                paramColl.Add(new SqlParameter() { ParameterName = "@IdentificationSource", Value = NullSafeGetter.IsDefault<string>(userFavorite.IdentificationSource) });
                paramColl.Add(new SqlParameter() { ParameterName = "@SubtitleTextId", Value = NullSafeGetter.IsDefault<long>(userFavorite.SubtitleTextId) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Rating", Value = NullSafeGetter.IsDefault<int>(userFavorite.Rating) });
                paramColl.Add(new SqlParameter() { ParameterName = "@RecordStatus", Value = NullSafeGetter.IsDefault<string>("A") }); 

                using (SqlCommand command = BuildCommand(usp_UserFavorites_Insert, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();

                    insertedUserFavoriteId = Convert.ToInt64(command.Parameters["@UserFavoriteId"].Value);
                }
            }

            return insertedUserFavoriteId;
        }

        public void UserFavoritesUpdate(UserFavorite userFavorite)
        {
            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();

                paramColl.Add(new SqlParameter() { ParameterName = "@UserFavoriteId", Value= NullSafeGetter.IsDefault<long>(userFavorite.UserFavoriteId) });
                paramColl.Add(new SqlParameter() { ParameterName = "@Rating", Value = NullSafeGetter.IsDefault<int>(userFavorite.Rating) });                

                using (SqlCommand command = BuildCommand(usp_UserFavorites_Update, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UserFavorite> UserFavoritesGetByUserId(string userIdentification)
        {
            List<UserFavorite> userFavorites = null;

            using (SqlConnection conn = GetNewConnection())
            {
                List<SqlParameter> paramColl = new List<SqlParameter>();
                paramColl.Add(new SqlParameter() { ParameterName = "@UserIdentification", Value = userIdentification });

                using (SqlCommand command = BuildCommand(usp_UserFavorites_Select, CommandType.StoredProcedure, paramColl))
                {
                    command.Connection = conn;
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        UserFavorite userFavorite = new UserFavorite()
                        {
                            SubtitleText = reader.GetValueOrDefault<string>("SubtitleText"),
                            SubtitleTextId = reader.GetValueOrDefault<long>("SubtitleId"),
                            UserFavoriteId = reader.GetValueOrDefault<long>("UserFavoriteId")
                        };

                        if (userFavorites == null) { userFavorites = new List<UserFavorite>(); }
                        userFavorites.Add(userFavorite);
                    }

                    reader.Close();
                }
            }

            return userFavorites;
        }
    }
}
