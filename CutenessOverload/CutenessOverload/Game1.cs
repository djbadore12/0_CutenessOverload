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

        // Define all the variables you want to use here

        Texture2D background;  // This is a Texture2D object that will hold the background picture
        Texture2D superDogSheet;  // What's supdog?
        Sprite superdog;  // We will load a superdog image into this sprite and make him do awesome things!
        Sprite superdog2;
        Sprite superdog3;
        Sprite superdog4;
        Sprite superdog5;
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

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");  // Load the background picture file into the 
                                                                 // texture.. note that under the properties for 
                                                                 // background.jpg in the Solution explorer you 
                                                                 // should see that it has the asset name of "background"

            superDogSheet = Content.Load<Texture2D>("superdog");

            superdog = new Sprite(new Vector2(140, 1), // Start at x=-150, y=30
                                  superDogSheet, 
                                  new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                                  new Vector2(60, 80));
            superdog2 = new Sprite(new Vector2(140, 1), // Start at x=-150, y=30
                               superDogSheet,
                               new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                               new Vector2(60, 80));
            superdog3 = new Sprite(new Vector2(140, 1), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                              new Vector2(60, 80));

            superdog4 = new Sprite(new Vector2(140, 1), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                              new Vector2(60, 80));
            superdog5 = new Sprite(new Vector2(600, this.Window.ClientBounds.Height+147), // Start at x=-150, y=30
                              superDogSheet,
                              new Rectangle(0, 0, 123, 147), // Use this part of the superdog texture
                              new Vector2(0, -60));


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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            superdog.Rotation = superdog.Rotation + 0.1f;
            // TODO: Add your update logic here
            superdog.Update(gameTime);  // Update the superdog so he moves
            superdog2.Update(gameTime);
            superdog3.Update(gameTime);
            superdog4.Update(gameTime);
            superdog5.Update(gameTime);

            if (superdog5.Location.Y < this.Window.ClientBounds.Height - superdog5.BoundingBoxRect.Height)
                superdog5.Velocity = new Vector2(0, 0);

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
            superdog.Draw(spriteBatch);  // Draw the superdog!
            superdog2.Draw(spriteBatch);
            superdog3.Draw(spriteBatch);
            superdog4.Draw(spriteBatch);
            superdog5.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
