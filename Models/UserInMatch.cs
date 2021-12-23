using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DojoTactics.Models
{
    public class UserInMatch
    {
        [Key]
        public int UserInMatchId {get;set;}
        public int MatchId {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<User> Players {get;set;}
    }
}