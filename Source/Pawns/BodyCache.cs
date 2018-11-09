using System.Collections.Generic;
using System.Linq;
using Verse;

namespace HumanlikeLifeStages
{
    public static class BodyCache
    {
        private static readonly Dictionary<RaceProperties, BodyPartRecord> GroinBodyPartRecordsCache = new Dictionary<RaceProperties, BodyPartRecord>();

        public static BodyPartRecord Groin(Pawn pawn)
        {
            return GroinBodyPartRecordsCache.TryGetValue(pawn.RaceProps) ?? (GroinBodyPartRecordsCache[pawn.RaceProps] = pawn.RaceProps.body.AllParts.First(x => x.def == BodyPartDefOf.Groin));
        }

        private static readonly Dictionary<RaceProperties, IEnumerable<BodyPartRecord>> HairyBodyPartRecordsCache = new Dictionary<RaceProperties, IEnumerable<BodyPartRecord>>();

        public static IEnumerable<BodyPartRecord> ValidFurryParts(Pawn pawn)
        {
            return HairyBodyPartRecordsCache.TryGetValue(pawn.RaceProps) ?? (HairyBodyPartRecordsCache[pawn.RaceProps] = cacheValueRace_BodyPartRecords(pawn));
        }

        private static IEnumerable<BodyPartRecord> cacheValueRace_BodyPartRecords(Pawn pawn)
        {
            IEnumerable<BodyPartDef> hairyParts = BodyHairHelper.WhatSkinCanGetHairy(pawn);
            IEnumerable<BodyPartRecord> validParts = pawn.RaceProps.body.AllParts.Where(x => hairyParts.Contains(x.def));
            return validParts;
        }

        private static readonly Dictionary<RaceProperties, BodyPartRecord> LifeStages_ReproductiveOrgansCache = new Dictionary<RaceProperties, BodyPartRecord>();

        public static BodyPartRecord LifeStages_ReproductiveOrgans(Pawn pawn)
        {
            return LifeStages_ReproductiveOrgansCache.TryGetValue(pawn.RaceProps) ?? (LifeStages_ReproductiveOrgansCache[pawn.RaceProps] = pawn.RaceProps.body.AllParts.First(x => x.def == BodyPartDefOf.LifeStages_ReproductiveOrgans));
        }

        private static readonly Dictionary<RaceProperties, BodyPartRecord> ChestBodyPartRecordsCache = new Dictionary<RaceProperties, BodyPartRecord>();

        public static BodyPartRecord Chest(Pawn pawn)
        {
            BodyPartRecord chest = ChestBodyPartRecordsCache.TryGetValue(pawn.RaceProps) ?? (ChestBodyPartRecordsCache[pawn.RaceProps] = pawn.RaceProps.body.AllParts.Find(b => (b.def == BodyPartDefOf.Chest)));
            return chest;
        }
    }
}