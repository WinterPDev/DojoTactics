using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DojoTactics.Models
{
    public class Match
    {
        [Key]
        public int MatchId {get;set;}
        public int UserId {get;set;}
        public int OpponentId {get;set;}
        public string MatchWinner {get;set;}
        public DateTime MatchDate {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [ForeignKey("OpponentId")]
        public User Opponent {get;set;}
    }
}