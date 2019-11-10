using System;

namespace Auth.Core.Shared
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}