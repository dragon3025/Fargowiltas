using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class ateway : ModProjectile
    {
        private int yo = 0;
        private int xo = -4;
        private int ye = 0;
        private int xe = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instavator");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;   //This defines the hitbox width
            projectile.height = 36;    //This defines the hitbox height
            projectile.aiStyle = 16;  //explosive ai

            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 10;     //size
            for (int y = -radius; y <= (radius); y++)
            {
                xo = y;
                for (int x = 0; x <= (1000 * radius); x++)
                {
                    yo = x;
                    int yPosition = (int)(y + position.Y / 16.0f);
                    int xPosition = (int)(xe + position.X / 16.0f);
                    int xdow = (int)(x + position.X / 16.0f);
                    int xoPosition = (int)(xo + position.X / 16.0f);
                    int yoPosition = (int)(ye + position.Y / 16.0f);
                    int yodow = (int)(yo + position.Y / 16.0f);
                    int xdiaPosition = (int)(x + y + position.X / 16.0f);
                    int ydiaPosition = (int)(x + position.Y / 16.0f);
                    int ydiadow = (int)(xe - y + position.X / 16.0f);
                    int yodiadow = (int)(xe + position.Y / 16.0f);
                    int xadiaPosition = (int)(xe - y + position.X / 16.0f);
                    int yadiaPosition = (int)(x + position.Y / 16.00f);
                    int yadiadow = (int)(x + y + position.X / 16.0f);
                    int yoadiadow = (int)(xe + position.Y / 16.0f);

                    if ((x * y) <= radius)   //rectangle
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);  //tile destroy
                        WorldGen.KillTile(xdow, yPosition, false, false, false);  //tile destroy
                        WorldGen.KillTile(xoPosition, yoPosition, false, false, false);  //tile destroy
                        WorldGen.KillTile(xoPosition, yodow, false, false, false);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                    if ((x * y) <= 2 * radius)
                    {
                        WorldGen.KillTile(xdiaPosition, ydiaPosition, false, false, false);  //tile destroy
                        WorldGen.KillTile(ydiadow, yodiadow, false, false, false);  //tile destroy
                        WorldGen.KillTile(xadiaPosition, yadiaPosition, false, false, false);  //tile destroy
                        WorldGen.KillTile(yadiadow, yoadiadow, false, false, false);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                    xe = x * -1;
                    ye = yo * -1;
                }
            }
        }
    }
}