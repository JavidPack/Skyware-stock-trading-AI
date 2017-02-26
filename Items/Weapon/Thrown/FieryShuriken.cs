using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class FieryShuriken : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Fiery Shuriken";
            item.width = 26;
            item.height = 26;           
            item.shoot = mod.ProjectileType("FireShuriken");
            item.useAnimation = 30;
            item.toolTip = "Occasionally stops in place while in midair \n Can burn foes";
            item.useTime = 30;
            item.shootSpeed = 8f;
            item.damage = 22;
            item.knockBack = 2f;
			item.value = Terraria.Item.sellPrice(0, 0, 3, 0);
            item.crit = 6;
            item.rare = 4;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"CarvedRock", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
