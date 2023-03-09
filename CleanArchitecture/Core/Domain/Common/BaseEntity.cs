using System;
using System.Linq;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? DateUpdate { get; set; }
        public DateTimeOffset? DateDelete { get; set; }
    }
}
