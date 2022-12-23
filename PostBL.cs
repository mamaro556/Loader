using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmessageMVCNETCore
{
    public class PostBL
    {
        public long PostID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string GoogleCaptchaToken { get; set; }
        public long UserID { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ParentID { get; set; }
        public long DiscussionID { get; set; }
        public virtual IList<PostBL> Children { get; set; }
    }
}