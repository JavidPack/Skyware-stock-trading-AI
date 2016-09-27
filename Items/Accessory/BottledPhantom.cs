using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class BottledPhantom : ModItem
	{
		private int proj2;
		public override void SetDefaults()
		{
			item.name = "Bottled Phantom";
            item.width = 18;
            item.height = 18;
            item.toolTip = "A spectral entity guides you";
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;

			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{   
		Projectile newProj2 = Main.projectile[proj2];
			player.GetModPlayer<MyPlayer>(mod).Phantom = true;
			if (newProj2.name == "PhantomMinion")
			{
			}
			else {
				proj2 = Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, mod.ProjectileType("PhantomMinion"), 66, 1, player.whoAmI);
				newProj2 = Main.projectile[proj2];
			}
			if (newProj2.active == false)
			{
				proj2 = Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, mod.ProjectileType("PhantomMinion"), 66, 1, player.whoAmI);
				newProj2 = Main.projectile[proj2];
			}
		}
	}
}