using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems.Folv
{
	public class FolvMissile3 : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Folv's Missile Barrage";
			item.damage = 60;
			item.magic = true;
			item.mana = 13;
			item.width = 28;
			item.height = 30;
			item.toolTip = "Rapidly shoots out exploding missiles of energy \n ~Donator Item~";
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 5;
			item.value = 95400;
            item.crit += 6;
			item.rare = 8;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FolvBolt3");
			item.shootSpeed = 12f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FolvMissile2", 1);
            recipe.AddIngredient(ItemID.SoulofSight, 3);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddIngredient(ItemID.SoulofMight, 3);
            recipe.AddIngredient(ItemID.Ectoplasm, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}