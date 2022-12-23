using System;
using System.Collections.Generic;

#nullable disable

namespace UpmessageMVCNETCore.Model
{
    public partial class Discussion
    {
        public long DiscussionId { get; set; }
        public string Name { get; set; }
        public long? OwnerId { get; set; }
        public long? PostId { get; set; }
    }
}
