using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15._2Creating_a_REST_API
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }
    }
}
