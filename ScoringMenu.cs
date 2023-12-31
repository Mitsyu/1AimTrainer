﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace aim_trainer_game
{
    public class ScoringMenu : GameState
    {
        
        private SpriteFont _font;
        private int _score;
        private float _accuracy;
        private int _previousScore;
        public ScoringMenu(GameStateManager stateManager) : base(stateManager)
        {
           //constructor
        }

        
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _font = content.Load<SpriteFont>("Score");
        }

        public override void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                _stateManager.ChangeState(new GameScreen(_stateManager));
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
