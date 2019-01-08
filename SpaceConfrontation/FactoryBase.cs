using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceConfrontation
{
    public abstract class FactoryBase
    {
        protected static Random rnd;

        public FactoryBase()
        {
            if (rnd == null)
                rnd = new Random();
        }

        public abstract void Update(GameTime gameTime);


    }
}