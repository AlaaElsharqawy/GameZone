using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
   public class Device:BaseEntity
    {
        [MaxLength(250)]
        public string Icon { get; set; } =string.Empty;

        public ICollection<GameDevice> Games { get; set; } = new HashSet<GameDevice>();
    }          
}
