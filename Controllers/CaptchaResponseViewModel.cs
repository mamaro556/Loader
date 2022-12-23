using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace UpmessageMVCNETCore
{
    [DataContract]
    internal class CaptchaResponseViewModel
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }
        [DataMember(Name = "action")]
        public String Action { get; set; }
        [DataMember(Name = "score")]
        public double Score { get; set; }   
        [DataMember(Name = "challenge_ts")]
        public DateTime ChallengeTimeStamp { get; set; }
        [DataMember(Name = "hostname")]
        public string Hostname { get; set; }
        [DataMember(Name = "error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }

    }
}