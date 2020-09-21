using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirtSwimmersData.Common
{
    public class Match
    {
        public long match_id { get; set; }
        public int? dire_score { get; set; }
        public int? radiant_score { get; set; }
        public int? duration { get; set; }
        public int? game_mode { get; set; }
        public int? lobby_type { get; set; }
        public int? skill { get; set; }
        public int? start_time { get; set; }
        public int? tower_status_dire { get; set; }
        public int? tower_status_radiant { get; set; }
        public bool? radiant_win { get; set; }
        public int? patch { get; set; }
        public int? region { get; set; }
        public List<Player> players { get; set; }

    }
}
