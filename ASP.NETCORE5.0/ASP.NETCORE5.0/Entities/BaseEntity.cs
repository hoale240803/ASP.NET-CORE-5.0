using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ASP.NETCORE5._0.Entities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
        }

        [BsonId]
        public string Id { get; set; }

        /// <summary>
        /// The date time UTC when the item is added
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? UpdatedAt { get; set; }

        [BsonIgnoreIfNull]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? DeletedAt { get; set; }

        [BsonIgnoreIfNull]
        public string DeletedBy { get; set; }
    }
}