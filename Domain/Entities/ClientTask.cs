using System;

namespace Domain.Entities
{
    public class ClientTask : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ClientAddress { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
