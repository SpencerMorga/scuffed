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

        Texture2D pixel;

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
            shaqfu = new Shaq(Content.Load<Texture2D>("shaq"), new Vector2(363, 400), Color.White, new List<Frame>());
            enemything = new Enemy(Content.Load<Texture2D>("beast"), new Vector2(420, 395), Color.White, new List<Frame>());
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            shaqsprites = Content.Load<Texture2D>("shaq");


            //attack logic

           
            
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




            if (shaqfu.cPunch == true)
            {
                if (enemything.bcrouch || enemything.bcrouchblock || enemything.bcrouchkick || enemything.bcrouchpunch)
                {
                    enemything.health = enemything.health - 0;
                }
                else if (enemything.bjump)
                {
                    enemything.health = enemything.health - 0;
                }
                else if (enemything.bblock)
                {
                    enemything.health = enemything.health - 1;
                }
                else
                {
                    enemything.health = enemything.health - 2;
                }//361 1268
            }
            if (shaqfu.cKick == true)
            {
                if (enemything.bcrouch || enemything.bcrouchblock || enemything.bcrouchkick || enemything.bcrouchpunch)
                {
                    enemything.health = enemything.health - 0;
                }
                else if (enemything.bjump)
                {
                    enemything.health = enemything.health - 0;
                }
                else if (enemything.bblock)
                {
                    enemything.health = enemything.health - 1;
                }
                else
                {
                    enemything.health = enemything.health - 2;
                }
            }
            if (shaqfu.cCrouchPunch == true || shaqfu.cCrouchKick == true)
            {
                if (enemything.bcrouchblock)
                {
                    enemything.health = enemything.health - 1;
                }
                else if (enemything.bjump)
                {
                    enemything.health = enemything.health - 0;
                }
                else
                {
                    enemything.health = enemything.health - 2;
                }
            }


           if (enemything.bpunch == true || enemything.bkick == true)
            {
                if (shaqfu.cCrouch || shaqfu.cCrouchBlock || shaqfu.cCrouchKick || shaqfu.cCrouchPunch)
                {
                    shaqfu.health = shaqfu.health - 0;
                }
                else if (shaqfu.cJump)
                {
                    shaqfu.health = shaqfu.health - 0;
                }
                else if (shaqfu.cBlock)
                {
                    shaqfu.health = shaqfu.health - 1;
                }
                else
                {
                    shaqfu.health = shaqfu.health - 2;
                }
            }
            if (enemything.bcrouchkick || enemything.bcrouchpunch)
            {
                if (shaqfu.cCrouchBlock)
                {
                    shaqfu.health = shaqfu.health - 1;
                }
                else if (shaqfu.cJump)
                {
                    shaqfu.health = shaqfu.health - 0;
                }
                else
                {
                    shaqfu.health = shaqfu.health - 2;
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
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            // TODO: Add your drawing code here

            shaqfu.Draw(spriteBatch, pixel);
            enemything.Draw(spriteBatch, pixel);
            //spriteBatch.Draw(Content.Load<Texture2D>(""), new Vector2(380, 404), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0); 
            //spriteBatch.Draw(shaqsprites, new Rectangle(350, 404, 10, 10), shaqfu.sourceRectangle, Color.White);
            spriteBatch.Draw(pixel, new Rectangle(0, 0, 2, shaqfu.health), Color.DarkSlateGray);
            spriteBatch.Draw(pixel, new Rectangle(798, 0, 2, enemything.health), Color.DarkSlateGray);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}