using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCoreDemo.Modules;

namespace WebCoreDemo.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebCoreDemo.Modules.MovieContext _context;

        public IndexModel(WebCoreDemo.Modules.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
