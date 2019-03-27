using System;
using System.Collections.Generic;
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
            string sql = $"INSERT INTO MemeCreations VALUES({memeCreation.MemeImage}, CURRENT_TIMESTAMP, '{memeCreation.Text}', '{memeCreation.Position}', '{memeCreation.Color}', '{memeCreation.Size}')";

            return ExecuteNonQuery(sql);
        }
    }
}
