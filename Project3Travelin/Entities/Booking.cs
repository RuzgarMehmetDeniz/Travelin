using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project3Travelin.Entities
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsStatus { get; set; }
        public string TourId { get; set; }
        public string TourTitle { get; set; }

    }
}
