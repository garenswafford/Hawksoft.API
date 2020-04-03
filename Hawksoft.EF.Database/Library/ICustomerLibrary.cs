using HawkSoft.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hawksoft.EF.Database.Library
{
    // in case you want to swtich out the customer library use the interface for DI
    public interface ICustomerLibrary
    {
        List<ContactWithAddress> GetBusinessContacts(Guid userId);
    }
}
