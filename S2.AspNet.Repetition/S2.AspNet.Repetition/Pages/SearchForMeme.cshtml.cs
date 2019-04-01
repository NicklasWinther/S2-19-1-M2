﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class SearchForMemeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; } = "";
        public List<MemeCreation> memes { get; set; }
        public void OnGet()
        {
            MemeCreationRepository memeCreationRepo = new MemeCreationRepository(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;");
            memes = memeCreationRepo.SearchForMeme(searchString);
        }
    }
}