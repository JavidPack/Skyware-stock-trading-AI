using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tide
{
    public class Clamper : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;

        public override void SetDefaults()
        {
            npc.name = "Clamper";
            npc.displayName = "Clamper";
            npc.width = 34;
            npc.height = 38;
            npc.damage = 31;
            npc.defense = 5;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 329f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            aiType = NPCID.CyanBeetle;
            Main.npcFrameCount[npc.type] = 10;

        }
        public override void NPCLoot()
        {
            {
                {
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BabyClamper"), 1);
                    }
                }
            }
            InvasionWorld.invasionSize -= 1;
            if (InvasionWorld.invasionSize < 0)
                InvasionWorld.invasionSize = 0;
            if (Main.netMode != 1)
                InvasionHandler.ReportInvasionProgress(InvasionWorld.invasionSizeStart - InvasionWorld.invasionSize, InvasionWorld.invasionSizeStart, 0);
            if (Main.netMode != 2)
                return;
            NetMessage.SendData(78, -1, -1, "", InvasionWorld.invasionProgress, (float)InvasionWorld.invasionProgressMax, (float)Main.invasionProgressIcon, 0.0f, 0, 0, 0);
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            if (InvasionWorld.invasionType == SpiritMod.customEvent)
                return 8f;

            return 0;
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
            {
                timer++;
                if (timer < 200) //Fires desert feathers like a shotgun
                {
                    npc.defense = 1000;

                }

                if (timer >= 200) //sets velocity to 0, creates dust
                {
                    npc.velocity.X = 0f;
                    npc.defense = 0;

                    if (Main.rand.Next(2) == 0)
                    {
                        int dust = Dust.NewDust(npc.position, npc.width, npc.height, 108);
                        Main.dust[dust].scale = 0.9f;
                    }

                }
                if (timer >= 400)
                {
                    timer = 0;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Clampshell"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Clampshell"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Clampeye"), 1f);
            }
        }
    }
}

