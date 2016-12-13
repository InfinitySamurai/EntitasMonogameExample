using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Entitas;
using System.Collections.Generic;
using System;

namespace Tester {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Systems systems;
        Pools pools;
        Dictionary<String, Texture2D> content;

        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        void CreateSystems() {     
             
            
            systems.Add(pools.core.CreateSystem(new MovementSystem()));
            systems.Add(pools.core.CreateSystem(new ViewRenderSystem(spriteBatch, content)));
            systems.Add(pools.core.CreateSystem(new PlayerKeyboardSystem()));
        }


        void CreateEntitites() {
            var e = pools.core.CreateEntity().AddPosition(0, 0).AddView(content["Hero"]).AddVelocity(0, 0).IsPlayerController(true).AddSpeed(5).AddBoundingBox(new Rectangle());
            Console.WriteLine(e);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            pools = Pools.sharedInstance;
            pools.SetAllPools();
            systems = new Systems();
            content = new Dictionary<string, Texture2D>();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            content["Hero"] = Content.Load<Texture2D>("Hero");
            CreateSystems();
            CreateEntitites();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            systems.Execute();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
