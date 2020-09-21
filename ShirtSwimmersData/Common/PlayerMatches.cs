namespace ShirtSwimmersData.Common
{
    public class PlayerMatches
    {
        public long match_id { get; set; }
        public bool? radiant_win { get; set; }
        public int? hero_id { get; set; }
        public int? start_time { get; set; }
        public int? duration { get; set; }
        public int? game_mode { get; set; }
        public int? lobby_type { get; set; }
        public int? kills { get; set; }
        public int? deaths { get; set; }
        public int? assists { get; set; }
        public int? skill { get; set; }
        public int? leaver_status { get; set; }
        public int? party_size { get; set; }
    }
}
