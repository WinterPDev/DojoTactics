using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoTactics.Models
{
    public class Stat
    {
        [Key]
        public int StatId {get;set;}
        public int UserId {get;set;}
        public int Level {get;set;}
        public int Wins {get;set;}
        public int Losses {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
        public User User {get;set;}
        public List<Match> MatchHistory {get;set;}
    }
}