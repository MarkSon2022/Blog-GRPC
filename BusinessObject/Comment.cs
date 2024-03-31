using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public partial class Comment
    {
     
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? PostId { get; set; }
        public string UserId { get; set; }


        public virtual Post? Post { get; set; }
      
        public virtual User? User { get; set; }
    }
}
