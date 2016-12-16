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
        Dictionary<String, Texture2D> sprites;
        SpriteFont font;

        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        void CreateSystems() {
            systems.Add(pools.core.CreateSystem(new PlayerKeyboardSystem()));
            systems.Add(pools.core.CreateSystem(new MovementSystem()));
            systems.Add(pools.core.CreateSystem(new UpdateCentreSystem()));
            systems.Add(pools.core.CreateSystem(new UpdateBoundingBoxSystem()));
            systems.Add(pools.core.CreateSystem(new CollisionDetectionSystem()));
            systems.Add(pools.core.CreateSystem(new HandleCollisionSystem()));
            systems.Add(pools.core.CreateSystem(new HandlePointsSystem()));
            systems.Add(pools.core.CreateSystem(new DrawScoreSystem(spriteBatch)));
            systems.Add(pools.core.CreateSystem(new ViewRenderSystem(spriteBatch, sprites)));
        }


        void CreateEntitites() {
            var e1 = pools.core.CreateEntity();
            e1.AddPosition(0, 0);
            e1.AddView(sprites["Hero"]);
            e1.AddVelocity(0, 0);
            e1.IsPlayerController(true);
            e1.AddSpeed(5);
            e1.AddBoundingBox(new Rectangle());
            e1.AddCentre(0, 0);

            var e2 = pools.core.CreateEntity();
            e2.AddPosition(500,200);
            e2.AddView(sprites["Coin"]);
            e2.AddBoundingBox(new Rectangle());
            e2.AddCentre(0, 0);

            var eScore = pools.core.CreateEntity();
            eScore.AddScore(0);
            eScore.AddText("Score: ");
            eScore.AddFont(font);
            eScore.AddPosition(20, 20);
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
            sprites = new Dictionary<string, Texture2D>();


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
            sprites["Hero"] = Content.Load<Texture2D>("Hero");
            sprites["Coin"] = Content.Load<Texture2D>("Coin");
            font = Content.Load<SpriteFont>("Font");
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
