using Hawksoft.EF.Database.Models;
using HawkSoft.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hawksoft.EF.Database.Library
{
    public class CustomerLibrary : ICustomerLibrary
    {
        private HawkSoftContactContext _context;

        
        public CustomerLibrary(HawkSoftContactContext context)
        {
            _context = context;
        }
        public List<ContactWithAddress> GetBusinessContacts(Guid userId)
        {
            var contacts = (from businessContacts in _context.BusinessContact
                            join address in _context.Address
                             on businessContacts.AddressId equals address.Id
                            where businessContacts.UserId == userId
                            select new ContactWithAddress
                            {
                                UserId = businessContacts.UserId,
                                AddressId = address.Id,
                                City = address.City,
                                Name = businessContacts.Name,
                                Email = businessContacts.Eamil,
                                State = address.State,
                                StreetName = address.StreetName,
                                Id = businessContacts.Id
                            });

            return contacts.ToList();
                
        }
        public void RemoveBusinessContact(Guid userId, Guid contactId)
        {
            BusinessContact contact = new BusinessContact
            {
                Id = contactId,
                UserId = userId
            };

            _context.BusinessContact.Remove(contact);

            _context.SaveChanges();
            
        }

        public void AddContact(BusinessContact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
        }

        public void EditContact(BusinessContact fullContact)
        {
            var contact = _context.BusinessContact.FirstOrDefault(x => x.Id == fullContact.Id);

            if (contact != null)
            {
                contact.Eamil = fullContact.Eamil;
                contact.Name = fullContact.Name;
                contact.AddressId = fullContact.AddressId;

                _context.BusinessContact.Update(contact);

                _context.SaveChanges();

            }
            

        }
    }
}
