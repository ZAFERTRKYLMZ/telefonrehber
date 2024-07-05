using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using telefonrehber.Data;
using telefonrehber.Models;


namespace telefonrehber.Controllers
{
    public class SearchHistoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SearchHistoryController(AppDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool Add([FromBody] SearchHistory search)
        {
            search.SearchDate = DateTime.Now;
            _context.SearchHistories.Add(search);
            _context.SaveChanges();
            return false;
        }
        public IActionResult Search(string searchTerm)
        {
            // Call the search logic here
            var results = SearchLogic(searchTerm);
            return PartialView("_SearchResults", results);
        }

        public IActionResult ClearSearchHistory()
        {
            // Clear the search history list
            ClearSearchHistoryList();
            return RedirectToAction("SearchHistory");
        }

        public IActionResult SearchHistory()
        {
            // Get the search history list
            var searchHistory = GetSearchHistoryList();
            return View(searchHistory);
        }

        private List<SearchHistory> GetSearchHistoryList()
        {
            // Get the search history list from session or cache
            var searchHistory = _httpContextAccessor.HttpContext?.Session.GetObject<List<SearchHistory>>("SearchHistory") ?? new List<SearchHistory>();

            if (searchHistory == null)
            {
                searchHistory = new List<SearchHistory>();
            }
            return searchHistory;
        }

        private void ClearSearchHistoryList()
        {
            // Clear the search history list from session or cache
            _httpContextAccessor.HttpContext.Session.Remove("SearchHistory");
        }
         
        private List<kisi> SearchLogic(string searchTerm)
        {
            return _context.kisiler
                .Where(k => k.ad.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}
