using System;
using System.Collections.Generic;

#nullable disable

namespace UpmessageMVCNETCore.Model
{
    public partial class PostTemp
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ParentId { get; set; }
        public long? DiscussionId { get; set; }
    }
}
