using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tide
{
    public class TideCaller : ModNPC
    {

        public override void SetDefaults()
        {
            npc.name = "Tide Caller";
            npc.displayName = "Tide Caller";
            npc.width = 74;
            npc.height = 74;
            npc.damage = 26;
            npc.defense = 20;
            npc.lifeMax = 310;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 2329f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 3;
            aiType = NPCID.AngryBones;
            Main.npcFrameCount[npc.type] = 8;

        }
        private int Counter;
        public override bool PreAI()
        {
            Counter++;
            if (Counter > 500)
            {
                int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Clamper"), npc.whoAmI);
                Counter = 0;
            }
            return true;
        }
        public override void NPCLoot()
        {
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlackTide"), 1);
                }
            }
            {
                InvasionWorld.invasionSize -= 2;
                if (InvasionWorld.invasionSize < 0)
                    InvasionWorld.invasionSize = 0;
                if (Main.netMode != 1)
                    InvasionHandler.ReportInvasionProgress(InvasionWorld.invasionSizeStart - InvasionWorld.invasionSize, InvasionWorld.invasionSizeStart, 0);
                if (Main.netMode != 2)
                    return;
                NetMessage.SendData(78, -1, -1, "", InvasionWorld.invasionProgress, (float)InvasionWorld.invasionProgressMax, (float)Main.invasionProgressIcon, 0.0f, 0, 0, 0);
            }
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            if (InvasionWorld.invasionType == SpiritMod.customEvent)
                return 1f;

            return 0;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Callershell"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Callersquid"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Callerhead"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(12) == 1)
            {
                target.AddBuff(mod.BuffType("Wobbly"), 120);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
    }
}

