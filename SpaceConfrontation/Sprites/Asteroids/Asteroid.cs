using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceConfrontation
{
    public class Asteroid : Sprite
    {
        public int live { get; set; }
        Rectangle initialRectangle;
        float angle;
        static SoundEffect explosion;
        Vector2 escala, origen;
        bool firstrun = true;
        static Texture2D texture;


        public Asteroid(int live = 50, Color? color = null)
        {
            int size = rnd.Next(10, 50);
            this.live = live;
            rectangle = new Rectangle(800, rnd.Next(500), size, size);
            initialRectangle = new Rectangle(5, 11, 48, 50);

            if (color != null)
                this.color = (Color)color;
            escala = new Vector2(2 * (float)rnd.NextDouble());
            origen = new Vector2(initialRectangle.Width / 2, initialRectangle.Height / 2);
            angle = 0;
        }

        public override void LoadContent()
        {
            if (texture == null)
                texture = Game1.CurrentGame.Content.Load<Texture2D>("Images/rocks");
            if (explosion == null)
            {
                explosion = Game1.CurrentGame.Content.Load<SoundEffect>("Sounds/Explosion1");
                explosion.CreateInstance();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (live <= 0 && firstrun)
            {
                firstrun = false;
                explosion.Play();
                Game1.CurrentGame.storedsprites.Add(this);
            }

            if (rectangle.X > 2 * Game1.CurrentGame.GraphicsDevice.Viewport.Width)
            {
                Game1.CurrentGame.storedsprites.Add(this);
            }

            rectangle.X--;

            angle += 0.02f;
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.CurrentGame.Drawer.Draw(texture, rectangle,
                                        initialRectangle, color
                                        , angle, origen,
                                        SpriteEffects.None, 1);
        }

    }
}
