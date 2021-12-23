using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoTactics.Models
{
    public class Social
    {
        [Key]
        public int SocialId {get;set;}
        public int UserId {get;set;}
        public int FriendId {get;set;}

        [ForeignKey("FriendId")]
        public User FriendUser {get;set;}
    }
}