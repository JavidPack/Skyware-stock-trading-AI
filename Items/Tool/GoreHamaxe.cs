using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class GoreHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Gore Hamaxe";
            item.width = 60;
            item.height = 60;
            item.value = 30000;
            item.rare = 5;
			  item.hammer = 45;
            item.axe = 13;

            item.damage = 27;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = 8;
            item.useAnimation = 29;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}