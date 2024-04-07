using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAPI.Models
{
    public class BatchUser
    {
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}