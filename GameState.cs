using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Xml.Linq;

namespace aim_trainer_game
{
    public abstract class GameState
    {
        protected StateManager _stateManager;
        

        public GameState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }
        public virtual void Enter()
        {
            // Logic to execute when entering the state
        }

        public virtual void Exit()
        {
            // Logic to execute when exiting the state
        }

        public virtual void LoadContent(ContentManager content)
        {
            _stateManager.LoadContent(content);
        }

        public virtual void Update(GameTime gameTime)
        {
            // Update logic specific to the state
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Draw logic specific to the state
        }
    }
}