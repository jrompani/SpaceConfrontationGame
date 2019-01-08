using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceConfrontation
{
    public class AsteroidFactory : FactoryBase
    {
        public override void Update(GameTime gameTime)
        {
            if (rnd.Next(98) > 95)
            {
                Asteroid a = new Asteroid();
                Game1.CurrentGame.storedsprites.Add(a);
                a.LoadContent();
            }
        }
    }
}
