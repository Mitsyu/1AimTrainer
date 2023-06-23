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
    public class MainMenuState : GameState
    {

        private Texture2D _backgroundTexture;
        private SpriteFont _font;
        private KeyboardState _previousKeyboardState;

        public MainMenuState(StateManager stateManager) : base(stateManager)
        {
            // Main menu state initialization
        }
        public override void LoadContent(ContentManager content)
        {
            // Load main menu content here
            _backgroundTexture = content.Load<Texture2D>("background");
            _font = content.Load<SpriteFont>("Score");
           
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            // Check for input to start the game
            if (currentKeyboardState.IsKeyDown(Keys.Enter) && _previousKeyboardState.IsKeyUp(Keys.Enter))
            {
                // Start the game by transitioning to the game screen
                _stateManager.ChangeState(new GameScreenState(_stateManager));
            }

            _previousKeyboardState = currentKeyboardState;
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw main menu logic here
            spriteBatch.Draw(_backgroundTexture, Vector2.Zero, Color.White);

            // Draw menu text
            spriteBatch.DrawString(_font, "Main Menu", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(_font, "Press Enter to Start", new Vector2(100, 200), Color.White);
        }
    }
    
}
