using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
