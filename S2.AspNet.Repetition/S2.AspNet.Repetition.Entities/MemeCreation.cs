using System;
using System.Collections.Generic;
using System.Text;

namespace S2.AspNet.Repetition.Entities
{
    public class MemeCreation
    {
        public MemeCreation()
        {

        }
        public MemeCreation(int memeImage, DateTime creationDate, string text, string position, string color, string size)
        {
            MemeImage = memeImage;
            CreationDate = creationDate;
            Text = text;
            Position = position;
            Color = color;
            Size = size;
        }

        public int Id { get; set; }
        public int MemeImage { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public string Position { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

    }
}
