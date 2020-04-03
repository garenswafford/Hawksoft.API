using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using HawkSoft.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HawkSoft.Razor.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<ContactWithAddress> _businessContacts { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            if (_businessContacts == null)
                _businessContacts = await ProcessRepositories();
        }

        private static async Task<List<ContactWithAddress>> ProcessRepositories()
        {
            using var client = new HttpCoreClient();

            // Only one user right now. If would continue this exercise would have a user logon to grab his/her id to pull from it
            return client.CallWebService<ContactWithAddress>("Contact/GetBusinessContacts/D7F13827-3230-48DB-8DF4-2825888C9E44").ToList(); 
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {

            return RedirectToPage();
        }
    }
}
