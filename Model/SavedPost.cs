using System;
using System.Collections.Generic;

#nullable disable

namespace UpmessageMVCNETCore.Model
{
    public partial class SavedPost
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
        public DateTime DateSaved { get; set; }
    }
}
