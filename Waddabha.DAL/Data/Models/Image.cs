using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddabha.DAL.Data.Models
{
    public class Image:BaseEntity
    {
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }
}
