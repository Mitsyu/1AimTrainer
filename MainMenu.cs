using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace aim_trainer_game
{
    public class MainMenu : GameState
    {

        private Texture2D _backgroundTexture;
        private SpriteFont _font;
        private KeyboardState _previousKeyboardState;

        public MainMenu(GameStateManager stateManager) : base(stateManager)
        {
            // state initializer thing 
        }
        public override void LoadContent(ContentManager content)
        {
            _backgroundTexture = content.Load<Texture2D>("background");
            _font = content.Load<SpriteFont>("Score");
           
        }

      
        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Enter) && _previousKeyboardState.IsKeyUp(Keys.Enter))
            {
                _stateManager.ChangeState(new GameScreen(_stateManager));
            }

            _previousKeyboardState = currentKeyboardState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, Vector2.Zero, Color.White);

            spriteBatch.DrawString(_font, "Main Menu", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(_font, "Press Enter to Start", new Vector2(100, 200), Color.White);
        }
    }
    
}
