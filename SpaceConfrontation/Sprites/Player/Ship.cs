using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceConfrontation
{
    public class Ship : Sprite
    {
        TimeSpan bullettime;
        int speed;
        public int Score { get; set; }
        SpriteFont font;
        
            
        /// <summary>
        /// Sucede cuando la nave colisiona con otro objeto
        /// </summary>
        public EventHandler Collition;

        public Ship()
        {
            rectangle = new Rectangle(100, 200, 80, 40);
            speed = 5;
        }

        public override void LoadContent()
        {
            texture = Game1.CurrentGame.Content.Load<Texture2D>("Images/f1");
            font = Game1.CurrentGame.Content.Load<SpriteFont>("Fonts/BigFont");
            // Load the score font
        }

  

        public override void Update(GameTime gameTime)
        {
            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is Asteroid)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((Asteroid)item).live = 0;
                        Game1.CurrentGame.cantvidas();

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
                        Game1.CurrentGame.cantvidas();

                        break;

                        //lanzo el evento (si corresponde)
                        //if (Collition != null)
                        //  Collition(this, new EventArgs());
                    }
                }
            }

            foreach (var item in Game1.CurrentGame.sprites)
            {
                if (item is MediumEnemy)
                {
                    if (rectangle.Intersects(item.Rectangle))
                    {
                        Game1.CurrentGame.storedsprites.Add(item);
                        Explosion e = new Explosion(this);
                        ((MediumEnemy)item).live = 0;
                        Game1.CurrentGame.cantvidas();

                        break;

                        //lanzo el evento (si corresponde)
                        //if (Collition != null)
                        //  Collition(this, new EventArgs());
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rectangle.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rectangle.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                rectangle.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                rectangle.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                gameTime.TotalGameTime.Subtract(bullettime) >= new TimeSpan(0, 0, 0, 0, 300))
            {
                bullettime = gameTime.TotalGameTime;
                Bullet b = new Bullet(rectangle.Location);
                b.LoadContent();
                Game1.CurrentGame.storedsprites.Add(b);
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Rectangle d = Game1.CurrentGame.Window.ClientBounds;
                if (rectangle.X < 700)  //IF X ES > A TANTO, NO SUMA MAS AL X (LA NAVE SE QUEDA EN EL CUADRADO) Rectangle es la nave
                {
                    rectangle.X++;
                }
                else if (rectangle.X == 700)
                {
                    rectangle.X = 0;
                }

                if (rectangle.X == 790)
                {
                    rectangle.X = -99;

                }
                else
                {
                    rectangle.X++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (rectangle.X > 0)
                {
                    rectangle.X--;
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                rectangle.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (rectangle.Y < Game1.CurrentGame.Window.ClientBounds.Height - 40) //esto devuelve el tamaño de la pantalla, y le resto 40 q es el tamaño de la nave
                {
                    rectangle.Y++;
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                gameTime.TotalGameTime.Subtract(bullettime) >= new TimeSpan(0, 0, 0, 0, 300))
            {
                bullettime = gameTime.TotalGameTime;
                Bullet b = new Bullet(rectangle.Location); //le pasa la ubicacion de la nave (rectngle es la nave)
                b.LoadContent();
                Game1.CurrentGame.storedsprites.Add(b);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Game1.CurrentGame.Drawer.DrawString(font, Score.ToString(),
                                                new Vector2(10.0f, 10.0f),
                                                Color.LawnGreen);
        }




    }
}

