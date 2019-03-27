using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeImageRepository : BaseRepository
    {
        public MemeImageRepository(string conString) : base(conString)
        {
        }

        public List<MemeImage> GetAllMemeImages()
        {
            List<MemeImage> memeImages = new List<MemeImage>();

            string sql = "SELECT * FROM MemeImages";

            DataTable MemeImagesTable = ExecuteQuery(sql);

            foreach (DataRow row in MemeImagesTable.Rows)
            {
                int id = (int)row["Id"];
                string url = (string)row["Url"];
                string altText = (string)row["AltText"];

                MemeImage memeImage = new MemeImage(id, url, altText);

                memeImages.Add(memeImage);
            }

            return memeImages;
        }

        public string GetUrlFrom(int imageId)
        {
            string sql = $"SELECT Url FROM MemeImages WHERE Id = {imageId}";

            DataTable memeImagesTable = ExecuteQuery(sql);

            if (memeImagesTable.Rows.Count == 1)
            {
                return (string)memeImagesTable.Rows[0]["Url"];
            }
            else
            {
                throw new ArgumentException($"MemeImage with id={imageId} not found.");
            }
            
        }
    }
}
