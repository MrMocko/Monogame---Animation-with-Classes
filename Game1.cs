using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Monogame___Animation_with_Classes
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Random generator;


        List<Tribble> tribbles;
        List<Texture2D> tribbleTexture;

        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = window.Height;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            tribbles = new List<Tribble>();
            tribbleTexture = new List<Texture2D>();
            generator = new Random();


            base.Initialize(); // content is loaded

           


            for (int i = 0; i < 500; i++)
                tribbles.Add(new Tribble(tribbleTexture[generator.Next(tribbleTexture.Count)], new Rectangle(generator.Next(window.Width - 120), generator.Next(window.Height - 120), generator.Next (20, 120), generator.Next(20, 120)), new Vector2(generator.Next(-3, 3), generator.Next(-3, 3))));

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
           tribbleTexture.Add(Content.Load<Texture2D>("tribbleGrey"));
           tribbleTexture.Add(Content.Load<Texture2D>("tribbleBrown"));
           tribbleTexture.Add(Content.Load<Texture2D>("tribbleCream"));
           tribbleTexture.Add(Content.Load<Texture2D>("tribbleOrange"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            for (int i = 0; i < tribbles.Count; i++)
                tribbles[i].Move(window);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            
            _spriteBatch.Begin();
            for (int i = 0; i < tribbles.Count; i++)
                tribbles[i].Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
