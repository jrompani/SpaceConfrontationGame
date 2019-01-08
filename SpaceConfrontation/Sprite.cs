using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceConfrontation
{
    public abstract class Sprite
    {
        protected static Random rnd;
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected Color color;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }

        public Sprite()
        {
            if (rnd == null)
                rnd = new Random();
            color = Color.White;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(GameTime gameTime)
        {
            Game1.CurrentGame.Drawer.Draw(texture, rectangle, color);
        }
    }
}
