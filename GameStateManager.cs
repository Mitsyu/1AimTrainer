using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aim_trainer_game
{

    public class GameStateManager
    {
        private GameState _currentState;

        public void ChangeState(GameState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = newState;
            _currentState.Enter();
        }

        public void LoadContent(ContentManager content)
        {
            _currentState.LoadContent(content);

        }

        public void Update(GameTime gameTime)
        {
            _currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentState.Draw(spriteBatch);
        }
        public void AddState(GameState state)
        {
            _currentState = state;
            _currentState.Enter();
        }
    }

}
