using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hawksoft.EF.Database.Library;
using HawkSoft.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hawksoft.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger) // Customer Library should be injected here
        {
            _logger = logger;
        }

        [Route("GetBusinessContacts/{userId}")]
        [HttpGet]
        public List<ContactWithAddress> GetBusinessContacts(Guid userId)
        {
            CustomerLibrary customerLibrary = new CustomerLibrary(new EF.Database.Models.HawkSoftContactContext()); // need to inject DB context in contructor (this will be done through DI)

            var contacts = customerLibrary.GetBusinessContacts(userId);

            return contacts;
        }

        [Route("RemoveContact/{userId}/{contactId}")]
        [HttpDelete]
        public void RemoveContact(Guid userId, Guid contactId)
        {
            CustomerLibrary customerLibrary = new CustomerLibrary(new EF.Database.Models.HawkSoftContactContext()); // need to inject DB context in contructor (this will be done through DI)

            customerLibrary.RemoveBusinessContact(userId, contactId);

        }

        [Route("AddContact")]
        [HttpPost]
        public void AddContact(BusinessContact contact)
        {
            CustomerLibrary customerLibrary = new CustomerLibrary(new EF.Database.Models.HawkSoftContactContext()); // need to inject DB context in contructor (this will be done through DI)

            customerLibrary.AddContact(contact);

        }

        [Route("EditContact")]
        [HttpPost]
        public void EditContact(BusinessContact contact)
        {
            CustomerLibrary customerLibrary = new CustomerLibrary(new EF.Database.Models.HawkSoftContactContext()); // need to inject DB context in contructor (this will be done through DI)

            customerLibrary.EditContact(contact);

        }


    }
}
