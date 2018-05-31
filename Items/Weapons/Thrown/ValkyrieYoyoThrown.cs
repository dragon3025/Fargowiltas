﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class ValkyrieYoyoThrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ValkyrieYoyo);
            item.shoot = ProjectileID.ValkyrieYoyo;
            item.melee = false;
            item.thrown = true;
        }

        public override string Texture => "Terraria/Item_3288";

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ValkyrieYoyo, 1, false, (int)item.prefix);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[proj].thrown = true;
            Main.projectile[proj].melee = false;
            return false;
        }
    }
}