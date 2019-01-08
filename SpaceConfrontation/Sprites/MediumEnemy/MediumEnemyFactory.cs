using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceConfrontation
{
    public class MediumEnemyFactory : FactoryBase
    {
        public override void Update(GameTime gameTime)
        {
            if (rnd.Next(96) > 95)
            {
                MediumEnemy e = new MediumEnemy();
                Game1.CurrentGame.storedsprites.Add(e);
                e.LoadContent();
            }
        }
    }
}
