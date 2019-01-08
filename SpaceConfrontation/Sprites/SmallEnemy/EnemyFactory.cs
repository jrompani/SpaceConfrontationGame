using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceConfrontation
{
    public class EnemyFactory : FactoryBase
    {
        public override void Update(GameTime gameTime)
        {
            if (rnd.Next(97) > 95)
            {
                Enemy e = new Enemy();
                Game1.CurrentGame.storedsprites.Add(e);
                e.LoadContent();
            }
        }
    }
}
