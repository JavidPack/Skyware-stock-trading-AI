using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Magic
{
	public class OrichalcumStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Orichalcum Staff";
			item.damage = 45;
			item.magic = true;
            item.toolTip = "Shoots an Orichalcum Bolt that goes through walls";
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 1;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("OrichalcumStaffProj");
			item.shootSpeed = 10f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
             recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}