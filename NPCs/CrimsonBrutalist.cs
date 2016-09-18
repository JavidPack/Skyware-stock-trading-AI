using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CrimsonBrutalist : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Crimson Brutalist";
            npc.displayName = "Crimson Brutalist";
            npc.width = 42;
            npc.height = 52;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 200;
            npc.soundHit = 2;
            npc.soundKilled = 2;
            npc.value = 60f;
            npc.knockBackResist = .95f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryBones];
            aiType = NPCID.AngryBones;
            animationType = NPCID.AngryBones;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
