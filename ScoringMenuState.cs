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
    public class ScoringMenuState : GameState
    {
        
        private SpriteFont _font;
        private int _score;
        private float _accuracy;
        private int _previousScore;
        public ScoringMenuState(StateManager stateManager) : base(stateManager)
        {
            // Scoring menu state initialization
        }

        
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _font = content.Load<SpriteFont>("Score"); // Replace "Score" with the actual font file name you want to use
        }

        
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                // Start the game again by transitioning to the game screen
                _stateManager.ChangeState(new GameScreenState(_stateManager));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "Score: " + _score, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(_font, "Accuracy: " + (_accuracy * 100).ToString("F2") + "%", new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(_font, "Previous Score: " + _previousScore, new Vector2(100, 300), Color.White);
            spriteBatch.DrawString(_font, "Press Enter to Play Again", new Vector2(100, 400), Color.White);
        }

        public void SetScores(int score, float accuracy, int previousScore)
        {
            _score = score;
            _accuracy = accuracy;
            _previousScore = previousScore;
        }
    }
    
}
