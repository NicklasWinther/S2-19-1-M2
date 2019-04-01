using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeCreationRepository : BaseRepository
    {
        public MemeCreationRepository(string conString) : base(conString)
        {
        }

        public int Insert(MemeCreation memeCreation)
        {
            string sql = $"INSERT INTO MemeCreations VALUES({memeCreation.MemeImageId}, CURRENT_TIMESTAMP, '{memeCreation.Text}', '{memeCreation.Position}', '{memeCreation.Color}', '{memeCreation.Size}')";

            return ExecuteNonQuery(sql);
        }

        public MemeCreation GetRandomMeme()
        {
            string sql = "SELECT TOP(1) MemeCreations.*, MemeImages.Url, MemeImages.AltText " +
                "FROM MemeCreations " +
                "JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id " +
                "ORDER BY NEWID(); ";

            DataTable MemeImagesTable = ExecuteQuery(sql);
            DataRow row = MemeImagesTable.Rows[0];
            
                int memeImg = (int)row["MemeImg"];
                DateTime timeStamp = (DateTime)row["TimeStamp"];
                string memeText = (string)row["MemeText"];
                string position = (string)row["Position"];
                string color = (string)row["Color"];
                string size = (string)row["Size"];
                string url = (string)row["Url"];
                string altText = (string)row["AltText"];
                MemeImage memeImage = new MemeImage(memeImg, url, altText);
                MemeCreation meme = new MemeCreation(memeImage, memeImg, timeStamp, memeText, position, color, size);

            return meme;
        }

        public MemeCreation GetLatestMeme()
        {
            string sql = "SELECT TOP(1) MemeCreations.*, MemeImages.Url, MemeImages.AltText " +
                "FROM MemeCreations " +
                "JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id " +
                "ORDER BY TimeStamp DESC; ";

            DataTable MemeImagesTable = ExecuteQuery(sql);
            DataRow row = MemeImagesTable.Rows[0];

            int memeImg = (int)row["MemeImg"];
            DateTime timeStamp = (DateTime)row["TimeStamp"];
            string memeText = (string)row["MemeText"];
            string position = (string)row["Position"];
            string color = (string)row["Color"];
            string size = (string)row["Size"];
            string url = (string)row["Url"];
            string altText = (string)row["AltText"];
            MemeImage memeImage = new MemeImage(memeImg, url, altText);
            MemeCreation meme = new MemeCreation(memeImage, memeImg, timeStamp, memeText, position, color, size);

            return meme;
        }

        public MemeCreation GetMostUsedPosition()
        {
            string sql = "SELECT TOP(1) COUNT(Id), Position " +
                "FROM MemeCreations " +
                "GROUP BY Position " +
                "ORDER BY COUNT(Id) DESC";

            DataTable memeCreationTable = ExecuteQuery(sql);

            MemeCreation memePosition = new MemeCreation();

            memePosition.Position = (string)memeCreationTable.Rows[0]["Position"];

            return memePosition;
        }
    }
}
