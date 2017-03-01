using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CutenessOverload
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        double timer = 0;
        double explodeCooldown = 0;
        double explodeCooldownTime = 0.25;
        Boolean planesExploded = false;

        // Define all the variables you want to use here

        Texture2D background;  // This is a Texture2D object that will hold the background picture
        Texture2D superDogSheet;  // What's supdog?
        Sprite superdog;  // We will load a superdog image into this sprite and make him do awesome things!
        Sprite superdog2;
        Sprite superdog3;
        Sprite superdog4;
        Sprite superdog5;
        Random rand = new Random(System.Environment.TickCount);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            EffectManager.Initialize(graphics, Content);
            EffectManager.LoadContent();
           

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");  // Load the background picture file into the 
                                                                 // texture.. note that under the properties for 
                                                                 // background.jpg in the Solution explorer you 
                                                                 // should see that it has the asset name of "background"

            superDogSheet = Content.Load<Texture2D>("superdog");

            superdog = new Sprite(new Vector2(1, 325), // Start at x=-150, y=30
                                  superDogSheet, 
                                  new Rectangle(155, 236, 390, 360), // Use this part of the superdog texture
                                  new Vector2(20,0));
            superdog2 = new Sprite(new Vector2(130, 1), // Start at x=-150, y=30
                               superDogSheet,
                               new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                               new Vector2(60, 20));
            superdog3 = new Sprite(new Vector2(90, 1), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                              new Vector2(60, 20));

            superdog4 = new Sprite(new Vector2(-10, 325), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(0, 0, 0, 0), // Use this part of the superdog texture
                              new Vector2(20,0));
            superdog5 = new Sprite(new Vector2(600, this.Window.ClientBounds.Height+147), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(0, 0, 123, 147), // Use this part of the superdog texture
                              new Vector2(0, 0));


            // Add any other initialization code here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 5)
            {
                superdog5.Velocity = new Vector2(0, -60);

                if (superdog5.Location.Y < this.Window.ClientBounds.Height - superdog5.BoundingBoxRect.Height)
                    superdog5.Velocity = new Vector2(0, 0);
            }

            if (timer > 5 && timer < 10)
            {
                explodeCooldown -= gameTime.ElapsedGameTime.TotalSeconds;

                if (explodeCooldown < 0)
                {
                    String effectName = "BasicExplosionWithTrails2";
                    switch (rand.Next(0,3))
                    {
                        case 0:
                            effectName = "BasicExplosionWithTrails2";
                            break;
                        case 1:
                            effectName = "BasicExplosionWithHalo";
                            break;
                        case 2:
                            effectName = "BasicExplosion";
                            break;
                    }
                    EffectManager.Effect(effectName).Trigger(new Vector2(600+rand.Next(-50,50), 240 + rand.Next(-25, 25)));

                    if (!planesExploded)
                    {
                        
                        EffectManager.Effect("BasicExplosionWithTrails2").Trigger(superdog2.Center);
                        EffectManager.Effect("BasicExplosionWithHalo").Trigger(superdog3.Center);
                        EffectManager.Effect("ShipSmokeTrail").Trigger(superdog4.Center);
                        planesExploded = true;
                    }

                    explodeCooldown = explodeCooldownTime; 
                }
            }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
         
            // TODO: Add your update logic here
            superdog.Update(gameTime);  // Update the superdog so he moves
            superdog2.Update(gameTime);
            superdog3.Update(gameTime);
            superdog4.Update(gameTime);
            superdog5.Update(gameTime);




            EffectManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            spriteBatch.Draw(background, new Rectangle(0,0,this.Window.ClientBounds.Width,this.Window.ClientBounds.Height), Color.White); // Draw the background at (0,0) - no crazy tinting

            if (timer < 7)
            {
               // Draw the superdog!
                superdog2.Draw(spriteBatch);
                superdog3.Draw(spriteBatch);
               
            }
            superdog5.Draw(spriteBatch);
            superdog.Draw(spriteBatch);
            superdog4.Draw(spriteBatch);
            spriteBatch.End();

            EffectManager.Draw();

            base.Draw(gameTime);
        }
    }
}
