using System;
using System.Collections.Generic;

namespace InitiumTicketSoftwareEntity.Model
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Queue { get; set; }
    }
}
