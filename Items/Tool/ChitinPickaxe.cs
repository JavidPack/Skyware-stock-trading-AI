using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class ChitinPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Chitin Pickaxe";
            item.width = 36;
            item.height = 36;
            item.value = 100;
            item.rare = 1;
            item.pick = 43;
            item.damage = 5;
            item.knockBack = 2;
            item.useStyle = 1;
            item.useTime = 14;
            item.useAnimation = 20;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chitin", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
