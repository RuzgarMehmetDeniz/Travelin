using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project3Travelin.Entities
{
    public class TourRota
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TourRotaId { get; set; }
        public string TourId { get; set; }

        public string Name { get; set; }
    }
}
