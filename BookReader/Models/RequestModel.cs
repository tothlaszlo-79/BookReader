using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class RequestModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
