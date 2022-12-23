using System;
using System.Collections.Generic;

#nullable disable

namespace UpmessageMVCNETCore.Model
{
    public partial class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
