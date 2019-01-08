using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceConfrontation
{
    public class MediumEnemy : Sprite
    {
        public int live { get; set; }
        Rectangle initialRectangle;
        float angle;
        static SoundEffect explosion;
        Vector2 origen;
        bool firstrun = true;
        static Texture2D texture;

        public MediumEnemy(int live = 100, Color? color = null)//Constructor. (Parametros opcionales. por defecto va 100 pero se puede cambiar la instancias o dejar vacio valiendo 100)
        {
            int size = rnd.Next(40, 40);
            this.live = live;
            rectangle = new Rectangle(800, rnd.Next(700), size, size);
            initialRectangle = new Rectangle(0, 0, 50, 50);

            if (color != null)
                this.color = (Color)color;
                origen = new Vector2(initialRectangle.Width / 2, initialRectangle.Height / 2);
            angle = 0;
        }

        public override void LoadContent()
        {           
                if (texture == null)
                    texture = Game1.CurrentGame.Content.Load<Texture2D>("Images/Enemy2");
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
            if (rectangle.X > 2 * Game1.CurrentGame.GraphicsDevice.Viewport.Height)
            {
                Game1.CurrentGame.storedsprites.Add(this);
            }

            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is Asteroid)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((Asteroid)item).live = 0;

                        break;

                        //lanzo el evento (si corresponde)
                        //if (Collition != null)
                        //  Collition(this, new EventArgs());
                    }
                }
            }

            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is Enemy)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((Enemy)item).live = 0;

                        break;

                        //lanzo el evento (si corresponde)
                        //if (Collition != null)
                        //  Collition(this, new EventArgs());
                    }
                }
            }
            //rectangle.X++; 
            rectangle.X--;   //solo se mueve en el eje Y
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
