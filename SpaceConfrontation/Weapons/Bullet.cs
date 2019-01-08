using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace SpaceConfrontation
{
    public class Bullet : Sprite
    {
        SoundEffect disparo;
        bool firstrun = true;

        public EventHandler Collition;

        public Bullet(Point InitialLocation)
        {
            rectangle = new Rectangle(InitialLocation.X + 50,
                                         InitialLocation.Y + 12,
                                         30, 15); //aca le pasa la ubicacion de la nave 

        }

        public override void LoadContent()
        {
            texture = Game1.CurrentGame.Content.Load<Texture2D>("Images/laser");
            disparo = Game1.CurrentGame.Content.Load<SoundEffect>("Sounds/bullet");
            disparo.CreateInstance();
        }

        public override void Update(GameTime gameTime)
        {
            int cantidad = 0;
            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is Asteroid)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        //Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((Asteroid)item).live = 0;
                        Game1.CurrentGame.storedsprites.Add(this);
                        cantidad++;

                        //lanzo el evento (si corresponde)
                        if (Collition != null)
                            Collition(this, new EventArgs());
                    }
                }
                if (item is Enemy)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        //Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((Enemy)item).live-=25;
                        Game1.CurrentGame.storedsprites.Add(this);
                        cantidad+=+10;

                        //lanzo el evento (si corresponde)
                        if (Collition != null)
                            Collition(this, new EventArgs());
                    }
                }
                if (item is MediumEnemy)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        //Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((MediumEnemy)item).live -= 25;
                        Game1.CurrentGame.storedsprites.Add(this);
                        cantidad += +10;

                        //lanzo el evento (si corresponde)
                        if (Collition != null)
                            Collition(this, new EventArgs());
                        
                    }
                }
            }

            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is Ship)
                {
                    ((Ship)item).Score += cantidad;
                }
            }


                foreach (var item in Game1.CurrentGame.sprites)
            {
                
            }


            if (firstrun)
            {
                disparo.Play(1.0f, 0.0f, 0.5f);
                firstrun = false;
            }

            if (rectangle.X > 2 * Game1.CurrentGame.GraphicsDevice.Viewport.Width)
            {
                Game1.CurrentGame.storedsprites.Add(this);
            }
            rectangle.X += 10;
        }
    }
}
