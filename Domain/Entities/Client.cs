using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumbers { get; set; }

        public ICollection<ClientTask> Tasks { get; set; }

        public Client()
        {
            Tasks = new List<ClientTask>();
        }
    }
}
