using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CRUD_MongoDB.Models
{
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
        public string Mobiles { get; set; }
        public string Salary { get; set; }
    }
}
