using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceConfrontation
{
    public class Explosion : Sprite
    {
        static List<Rectangle> rectangles;
        TimeSpan explosiontime;
        int rectagleindex;
        static new Texture2D texture;

        public Explosion(Sprite owner)
        {
            if (rectangles == null)
            {
                rectangles = new List<Rectangle>();
                rectangles.Add(new Rectangle(0, 0, 122, 119));
                rectangles.Add(new Rectangle(123, 0, 122, 119));
                rectangles.Add(new Rectangle(255, 0, 122, 119));
                rectangles.Add(new Rectangle(382, 0, 122, 119));
                rectangles.Add(new Rectangle(0, 1, 122, 119));
                rectangles.Add(new Rectangle(123, 1, 122, 119));
                rectangles.Add(new Rectangle(255, 1, 122, 119));
                rectangles.Add(new Rectangle(382, 1, 122, 119));
                rectangles.Add(new Rectangle(0, 2, 122, 119));
                rectangles.Add(new Rectangle(123, 2, 122, 119));
                rectangles.Add(new Rectangle(255, 2, 122, 119));
                rectangles.Add(new Rectangle(382, 2, 122, 119));
                rectangles.Add(new Rectangle(0, 3, 122, 119));
                rectangles.Add(new Rectangle(123, 3, 122, 119));
                rectangles.Add(new Rectangle(255, 3, 122, 119));
                rectangles.Add(new Rectangle(382, 3, 122, 119));
            }
            rectangle = owner.Rectangle;
            LoadContent();
            Game1.CurrentGame.storedsprites.Add(this);
        }

        public override void LoadContent()
        {
            if (texture == null)
                texture = Game1.CurrentGame.Content.Load<Texture2D>("Images/explosion");
        }

        public override void Update(GameTime gameTime)
        {
            if (explosiontime == TimeSpan.Zero)
                explosiontime = gameTime.TotalGameTime;

            if (gameTime.TotalGameTime.Subtract(explosiontime) > new TimeSpan(0, 0, 0, 0, 200))
            {
                rectagleindex++;
                explosiontime = gameTime.TotalGameTime;
            }

            if (rectagleindex > 3)
                Game1.CurrentGame.storedsprites.Add(this);

        }

        public override void Draw(GameTime gameTime)
        {
            if (rectagleindex > 3)
                return;

            Game1.CurrentGame.Drawer.Draw(texture, rectangle,
                                     rectangles[rectagleindex], color);
            //base.Draw(gameTime);
        }
    }
}
