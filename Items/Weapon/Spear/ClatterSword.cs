using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear {
public class ClatterSword : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Clatter Sword";
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.melee = true;
        item.noMelee = true;
        item.useAnimation = 5;
        item.useTime = 15;
        item.shootSpeed = 5f;
        item.knockBack = 6f;
        item.damage = 28;
        item.value = Item.sellPrice(0, 0, 15, 0);
        item.rare = 2;
        item.autoReuse = false;
        item.toolTip = "A shortsword that can be swung in any direction";
        item.shoot = mod.ProjectileType("ClatterSwordProj");
    }
    
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
}}
