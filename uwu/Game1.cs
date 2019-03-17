using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace uwu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Shaq shaqfu;
        Enemy enemything;


        Texture2D shaqsprites;

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
            shaqfu = new Shaq(Content.Load<Texture2D>("shaq"), new Vector2(350, 400), Color.White, new List<Frame>());
            enemything = new Enemy(Content.Load<Texture2D>("beast"), new Vector2(380, 404), Color.White, new List<Frame>());

            shaqsprites = Content.Load<Texture2D>("shaq");


            //attack logic

            if (shaqfu.bPunch == true)
            {
                if (enemything.bcrouch || enemything.bcrouchblock || enemything.bcrouchkick || enemything.bcrouchpunch)
                {
                    //no damage
                }
                 else if (enemything.bjump)
                {
                    //no damage
                }
                else if (enemything.bblock)
                {
                    //half damage taken
                }
                else
                {
                    //full damage
                }//361 1268
            }
            if (shaqfu.bKick == true)
            {
                if (enemything.bcrouch || enemything.bcrouchblock || enemything.bcrouchkick || enemything.bcrouchpunch)
                {
                    //""
                }
                else if (enemything.bjump)
                {
                    //""
                }
                else if (enemything.bblock)
                {
                    //""
                }
                else
                {
                    //""
                }
            }
            if (shaqfu.bCrouchPunch == true || shaqfu.bCrouchKick == true)
            {
                if (enemything.bcrouchblock)
                {
                    //half
                }
                else if (enemything.bjump)
                {
                    //none
                }
                else
                {
                    //full
                }
            }
            

            if (enemything.bpunch == true || shaqfu.bKick == true)
            {
                if (shaqfu.bCrouch || shaqfu.bCrouchBlock || shaqfu.bCrouchKick || shaqfu.bCrouchPunch)
                {
                    //none
                }
                else if (shaqfu.bJump)
                {
                    //none
                }
                else if (shaqfu.bBlock)
                {
                    //half
                }
                else
                {
                    //full
                }
            }
            if (enemything.bcrouchkick || enemything.bcrouchpunch)
            {
                if (shaqfu.bCrouchBlock)
                {
                    //half
                }
                else if (shaqfu.bJump)
                {
                    //none
                }
                else
                {
                    //full
                }
            }
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            shaqfu.Update(gameTime, Keyboard.GetState());
            enemything.Update(gameTime, Keyboard.GetState());





            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            // TODO: Add your drawing code here

            shaqfu.Draw(spriteBatch);
            enemything.Draw(spriteBatch);
            //spriteBatch.Draw(Content.Load<Texture2D>(""), new Vector2(380, 404), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0); 
            //spriteBatch.Draw(shaqsprites, new Rectangle(350, 404, 10, 10), shaqfu.sourceRectangle, Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}