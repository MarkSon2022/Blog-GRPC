using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean? Status { get; set; }  

        [JsonIgnore]
        public virtual ICollection<Comment>? Comments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
