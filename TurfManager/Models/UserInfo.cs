using System;
using System.Collections.Generic;

namespace TurfManager.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public string UserAPIKey { get; set; }
    }
}
