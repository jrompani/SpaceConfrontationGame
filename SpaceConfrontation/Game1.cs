using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpaceConfrontation
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Boolean pause = false;
        TimeSpan pausetime;
        private Texture2D texturevidas;
        AsteroidFactory asteroides;
        EnemyFactory enemigos;
        MediumEnemyFactory enemigosmedium;

        //Lado al que pertenece el Sprite
        enum Side { Player, Aliens, None };


        //Number that holds the player score
        int score;
        // The font used to display UI elements
        SpriteFont font;

        private Texture2D backgroundTexture;

        public static Game1 CurrentGame { get; private set; }

        public List<Sprite> sprites { get; private set; }

        public List<Sprite> storedsprites { get; private set; }

        public SpriteBatch Drawer { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            CurrentGame = this;
            sprites = new List<Sprite>();
            storedsprites = new List<Sprite>();
            Window.Title = "Space Confrontation Game";
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.IsFullScreen = false;


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            enemigos = new EnemyFactory();
            asteroides = new AsteroidFactory();
            enemigosmedium = new MediumEnemyFactory();

            sprites.Add(new Ship());
            //sprites.Add(new EnemyFactory());
            sprites.Add(new Enemy());
            sprites.Add(new Enemy(100));
            sprites.Add(new Enemy(300, Color.Green));
            //mostrarVidas(); 
            base.Initialize();

            //Puntaje Inicial del Juego
            score = 0;
        }

        private int vidas = 5;

        public void cantvidas()
        {
            vidas--;
            //aca 
            foreach (var item in Game1.CurrentGame.sprites) //For para la lista de sprites... 
            {
                if (item is Vida) 
                {

                    Game1.CurrentGame.storedsprites.Add(item);  //si es una vida, lo guarda en el store
                }
            }
            // Game1.CurrentGame.mostrarVidas();

            if (vidas == 0)
            {
                Game1.CurrentGame.EndRun();
                //Game1.CurrentGame.Window.ClientBounds; esto podria ser para saber el tamaño de la panrtalla
                //agrego esto:

            }
        }




        public void mostrarVidas()
        {
            //desde aca
            int px = 100;
            for (int x = 1; x < Game1.CurrentGame.vidas; x++)
            {

                px = px + 30;
                Point p = new Point(px, 150);

                Vida c = new Vida(p); //aca creo el objeto VIDA 
                c.LoadContent();

                Game1.CurrentGame.sprites.Add(c);
            }

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            backgroundTexture = Game1.CurrentGame.Content.Load<Texture2D>("Images/space");
            texturevidas = Content.Load<Texture2D>("Images/spaceship"); //PASO 2 Cargo la imagen en la variable. Explicacion: Now let's actually load the images into our texture objects. In the LoadContent() method,
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Drawer = spriteBatch; //para decirle  al drawer quien es el drawer
                                  // Load the score font

            foreach (var item in sprites)
            {
                item.LoadContent();
            }


            
        }

  
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (pausetime == TimeSpan.Zero)
                pausetime = gameTime.TotalGameTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.P)
                && gameTime.TotalGameTime.Subtract(pausetime) > new TimeSpan(0, 0, 0, 1))
            {
                pause = !pause;
                pausetime = gameTime.TotalGameTime;
            }

            if (!pause)
            {

                asteroides.Update(gameTime);
                enemigos.Update(gameTime);
                enemigosmedium.Update(gameTime);

                // TODO: Add your update logic here
                foreach (var item in storedsprites)
                {
                    if (sprites.Contains(item))
                        sprites.Remove(item);
                    else
                        sprites.Add(item);
                }
                //sprites.AddRange(storedsprites);
                storedsprites.Clear();
                foreach (var item in sprites)
                {
                    item.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
                     
            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0,
            graphics.GraphicsDevice.DisplayMode.Width,
            graphics.GraphicsDevice.DisplayMode.Height),
            Color.LightCyan);

            int f, x, y;
            x = 600; //son las coordenadas donde se van a dibujar las vidas
            y = 570; 
            for (f = 0; f < vidas; f++)  //dibujo la cantidad de vidas que van quedando
            {

                spriteBatch.Draw(texturevidas, new Vector2(x, y), Color.White); //dibujo una vida
                x = x + 40; //aca cambio la posicion de la proxima vida que se dibuja
            }


            foreach (var item in sprites)
            {
                item.Draw(gameTime);
            }

            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}

