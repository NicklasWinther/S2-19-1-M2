using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class NewMemeModel : PageModel
    {
        public MemeCreation Meme { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ImageSelected { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MemeText { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string PositionOfText { get; set; } = "";

        public string SelectedImageUrl { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MemeName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FontSize { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FontColor { get; set; }
        public void OnGet()
        {
            MemeImageRepository memeImageRepo = new MemeImageRepository(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;");

            SelectedImageUrl = memeImageRepo.GetUrlFrom(ImageSelected);

            SaveMemeInDb();
        }
       
        private void SaveMemeInDb()
        {
            MemeCreationRepository memeCreationRepo = new MemeCreationRepository(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;");

            MemeCreation memeCreation = new MemeCreation()
            {
                MemeImageId = ImageSelected,
                Text = MemeText,
                Position = PositionOfText,
                Color = FontColor,
                Size = FontSize
            };

            int rowsAffected = memeCreationRepo.Insert(memeCreation);
        }
    }
}