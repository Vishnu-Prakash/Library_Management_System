using System;

namespace DomainLayer.Models
{
    public class BookHistoryModel
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime OperationPerofrmedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
        public string Remarks { get; set; }
        public string PerformedByID { get; set; }
    }
}
