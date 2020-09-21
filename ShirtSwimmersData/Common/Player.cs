namespace ShirtSwimmersData.Common
{
    public class Player
    {
        public long match_id { get; set; }
        public int? player_slot { get; set; }
        public long? account_id { get; set; }
        public int? kills { get; set; }
        public int? deaths { get; set; }
        public int? assists { get; set; }
        public int? last_hits { get; set; }
        public int? denies { get; set; }
        public int? gold { get; set; }
        public int? gold_per_min { get; set; }
        public int? gold_spent { get; set; }
        public int? hero_damage { get; set; }
        public int? hero_healing { get; set; }
        public int? tower_damage { get; set; }
        public int? xp_per_min { get; set; }
        public string personaname { get; set; }
        public bool? isRadiant { get; set; }
        public int? win { get; set; }
        public int? lose { get; set; }
        public int? total_gold { get; set; }
        public int? total_xp { get; set; }
        public int? kda { get; set; }
        public int? abandons { get; set; }
        public int? hero_id { get; set; }
        public int? item_0 { get; set; }
        public int? item_1 { get; set; }
        public int? item_2 { get; set; }
        public int? item_3 { get; set; }
        public int? item_4 { get; set; }
        public int? item_5 { get; set; }
        public int? item_neutral { get; set; }
        public int? backpack_0 { get; set; }
        public int? backpack_1 { get; set; }
        public int? backpack_2 { get; set; }
        public int? party_size { get; set; }
    }
}
