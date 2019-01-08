using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceConfrontation
{
    public class Vida : Sprite
    {
        public Vida(Point InitialLocation)  //este es el constructor de la bala que crea la imagen segun la ubicacion de la nave que recibe como parametro
        {
            rectangle = new Rectangle(InitialLocation.X,
                                        InitialLocation.Y,
                                        15, 15); //aca le pasa la ubicacion de la nave 
        }


        //dentro del metodo draw, meter un if //if (gameTime.ElapsedGameTime)
        public override void LoadContent()
        {
            texture = Game1.CurrentGame.Content.Load<Texture2D>(@"Images/bala");
        }

        public override void Update(GameTime gameTime)
        {
            // no hacemos nada
            //throw new NotImplementedException();
        }
    }
}
