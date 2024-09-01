using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Game : BaseEntity
    {



        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        [MaxLength(250)]
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; } //foreign Key
        public Category Category { get; set; } //Navigitional Property


        public ICollection<GameDevice> Device { get; set; } = new HashSet<GameDevice>();
    }
}
