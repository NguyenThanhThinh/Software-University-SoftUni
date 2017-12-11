﻿namespace Instagraph.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserFollower
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int FollowerId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public User Follower { get; set; }
    }
}