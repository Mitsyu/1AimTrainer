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
    public class GameScreenState : GameState
    {
        private Texture2D targetTexture;
        private SpriteFont font;
        private List<Vector2> targets; 
        private int score; 
        private int previousScore; 
        private int accuracy; 
        private TimeSpan timer; 
        private TimeSpan currentTime; 

        private const int ScreenWidth = 1920; 
        private const int ScreenHeight = 1080; 
        private const int GameDurationSeconds = 60; 
        public GameScreenState(StateManager stateManager) : base(stateManager)
        {
            // Game screen state initialization
        }
        
        public override void LoadContent(ContentManager content)
        {
            // Load game screen content here
            targetTexture = content.Load<Texture2D>("target");
            font = content.Load<SpriteFont>("Score");
            targets = new List<Vector2>();

            score = 0;
            previousScore = 0;
            accuracy = 0;
            timer = TimeSpan.FromSeconds(GameDurationSeconds);
            currentTime = TimeSpan.Zero;
            SpawnTargets(5); 
        }
        public override void Update(GameTime gameTime)
        {
            // Update game screen logic here
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

                for (int i = targets.Count - 1; i >= 0; i--)
                {
                    if (IsCollision(mousePosition, targets[i]))
                    {
                        targets.RemoveAt(i);

                        score++;
                        int totalShots = score + (previousScore - score);
                        accuracy = (int)((float)score / totalShots * 100);
                    }
                }
            }

            
            if (targets != null)
            {
                for (int i = targets.Count - 1; i >= 0; i--)
                {
                    targets[i] += new Vector2(1, 0); 
                }
            }

            if (targets.Count < 5)
            {
                /
                Random random = new Random();
                Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));

                targets.Add(targetPosition);
            }

            currentTime += gameTime.ElapsedGameTime;
            if (currentTime >= timer)
            {
                // Game logic 
                // Example: Reset game state, show score screen, etc.
            }
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw game screen logic here
            // No need to call SpriteBatch.Begin() and SpriteBatch.End() here

           
            foreach (Vector2 target in targets)
            {
                spriteBatch.Draw(targetTexture, target, Color.White);
            }

            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Accuracy: " + accuracy + "%", new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "Previous Score: " + previousScore, new Vector2(10, 50), Color.White);

            string timeRemaining = "Time: " + (timer - currentTime).Seconds.ToString();
            spriteBatch.DrawString(font, timeRemaining, new Vector2(ScreenWidth - 100, 10), Color.White);
        }

        private bool IsCollision(Vector2 point1, Vector2 point2)
        {
            float distance = Vector2.Distance(point1, point2);
            return distance < 10; 
        }

        private void SpawnTargets(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));
                targets.Add(targetPosition);
            }
        }
    }
    
}
