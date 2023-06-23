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
        private List<Vector2> targets; // List to store the positions of the targets
        private int score; // Player's score
        private int previousScore; // Player's previous score
        private int accuracy; // Player's accuracy (percentage)
        private TimeSpan timer; // Timer for game duration
        private TimeSpan currentTime; // Current time

        private const int ScreenWidth = 1920; // Example: Set the screen width
        private const int ScreenHeight = 1080; // Example: Set the screen height
        private const int GameDurationSeconds = 60; // Example: Set game duration to 60 seconds
        public GameScreenState(StateManager stateManager) : base(stateManager)
        {
            // Game screen state initialization
        }
        public override void LoadContent(ContentManager content)
        {

            targets = new List<Vector2>();

            // Load game screen content here
            targetTexture = content.Load<Texture2D>("target");
            font = content.Load<SpriteFont>("Score");
            
            score = 0;
            previousScore = 0;
            accuracy = 0;
            timer = TimeSpan.FromSeconds(GameDurationSeconds);
            currentTime = TimeSpan.Zero;

            // Spawn initial targets
            SpawnTargets(5); // Example: Spawn 5 targets initially
        }

        //public override void Update(GameTime gameTime)
        //{
        //    // Update game screen logic here
        //    MouseState mouseState = Mouse.GetState();

        //    // Handle mouse click
        //    if (mouseState.LeftButton == ButtonState.Pressed)
        //    {
        //        Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

        //        // Check for collision with targets
        //        for (int i = targets.Count - 1; i >= 0; i--)
        //        {
        //            if (IsCollision(mousePosition, targets[i]))
        //            {
        //                // Remove the target from the list
        //                targets.RemoveAt(i);

        //                // Increment the score
        //                score++;

        //                // Update accuracy
        //                int totalShots = score + (previousScore - score);
        //                accuracy = (int)((float)score / totalShots * 100);
        //            }
        //        }
        //    }

        //    // Update the positions of the targets
        //    for (int i = targets.Count - 1; i >= 0; i--)
        //    {
        //        targets[i] += new Vector2(1, 0); // Example: Move targets to the right
        //    }

        //    // Generate new targets if necessary
        //    if (targets.Count < 5) // Example: Generate up to 5 targets
        //    {
        //        // Generate a random position for the target
        //        Random random = new Random();
        //        Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));

        //        // Add the target to the list
        //        targets.Add(targetPosition);
        //    }

        //    // Update the timer
        //    currentTime += gameTime.ElapsedGameTime;
        //    if (currentTime >= timer)
        //    {
        //        // Game over logic here
        //        // Example: Reset game state, show score screen, etc.
        //    }
        //}
        public override void Update(GameTime gameTime)
        {
            // Update game screen logic here
            MouseState mouseState = Mouse.GetState();

            // Handle mouse click
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

                // Check for collision with targets
                for (int i = targets.Count - 1; i >= 0; i--)
                {
                    if (IsCollision(mousePosition, targets[i]))
                    {
                        // Remove the target from the list
                        targets.RemoveAt(i);

                        // Increment the score
                        score++;

                        // Update accuracy
                        int totalShots = score + (previousScore - score);
                        accuracy = (int)((float)score / totalShots * 100);
                    }
                }
            }

            // Update the positions of the targets if the list is not null
            if (targets != null)
            {
                for (int i = targets.Count - 1; i >= 0; i--)
                {
                    targets[i] += new Vector2(1, 0); // Example: Move targets to the right
                }
            }

            // Generate new targets if necessary
            if (targets.Count < 5) // Example: Generate up to 5 targets
            {
                // Generate a random position for the target
                Random random = new Random();
                Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));

                // Add the target to the list
                targets.Add(targetPosition);
            }

            // Update the timer
            currentTime += gameTime.ElapsedGameTime;
            if (currentTime >= timer)
            {
                // Game over logic here
                // Example: Reset game state, show score screen, etc.
            }
        }
        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    // Draw game screen logic here
        //    spriteBatch.Begin();

        //    // Draw the targets
        //    foreach (Vector2 target in targets)
        //    {
        //        spriteBatch.Draw(targetTexture, target, Color.White);
        //    }

        //    // Draw the score, accuracy, and previous score
        //    spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
        //    spriteBatch.DrawString(font, "Accuracy: " + accuracy + "%", new Vector2(10, 30), Color.White);
        //    spriteBatch.DrawString(font, "Previous Score: " + previousScore, new Vector2(10, 50), Color.White);

        //    // Draw the remaining time
        //    string timeRemaining = "Time: " + (timer - currentTime).Seconds.ToString();
        //    spriteBatch.DrawString(font, timeRemaining, new Vector2(ScreenWidth - 100, 10), Color.White);

        //    spriteBatch.End();
        //}
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw game screen logic here
            // No need to call SpriteBatch.Begin() and SpriteBatch.End() here

            // Draw the targets
            foreach (Vector2 target in targets)
            {
                spriteBatch.Draw(targetTexture, target, Color.White);
            }

            // Draw the score, accuracy, and previous score
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Accuracy: " + accuracy + "%", new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "Previous Score: " + previousScore, new Vector2(10, 50), Color.White);

            // Draw the remaining time
            string timeRemaining = "Time: " + (timer - currentTime).Seconds.ToString();
            spriteBatch.DrawString(font, timeRemaining, new Vector2(ScreenWidth - 100, 10), Color.White);
        }

        private bool IsCollision(Vector2 point1, Vector2 point2)
        {
            // Perform collision detection logic here
            // For example, you can check if the distance between the two points is less than a threshold
            float distance = Vector2.Distance(point1, point2);
            return distance < 10; // Example: Collision threshold of 10 pixels
        }

        private void SpawnTargets(int count)
        {
            // Spawn the specified number of targets randomly on the screen
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));
                targets.Add(targetPosition);
            }
        }
    }
    //public class GameScreenState : GameState
    //{
    //    private Texture2D targetTexture;
    //    private SpriteFont font;
    //    private List<Vector2> targets; // List to store the positions of the targets
    //    private int score; // Player's score
    //    private int previousScore; // Player's previous score
    //    private int accuracy; // Player's accuracy (percentage)

    //    private const int ScreenWidth = 1920; // Example: Set the screen width
    //    private const int ScreenHeight = 1080; // Example: Set the screen height

    //    public override void LoadContent(ContentManager content)
    //    {
    //        // Load game screen content here
    //        targetTexture = content.Load<Texture2D>("target");
    //        font = content.Load<SpriteFont>("Arial");
    //        targets = new List<Vector2>();
    //        score = 0;
    //        previousScore = 0;
    //        accuracy = 0;
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        // Update game screen logic here
    //        MouseState mouseState = Mouse.GetState();

    //        // Handle mouse click
    //        if (mouseState.LeftButton == ButtonState.Pressed)
    //        {
    //            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

    //            // Check for collision with targets
    //            for (int i = targets.Count - 1; i >= 0; i--)
    //            {
    //                if (IsCollision(mousePosition, targets[i]))
    //                {
    //                    // Remove the target from the list
    //                    targets.RemoveAt(i);

    //                    // Increment the score
    //                    score++;

    //                    // Update accuracy
    //                    int totalShots = score + (previousScore - score);
    //                    accuracy = (int)((float)score / totalShots * 100);
    //                }
    //            }
    //        }

    //        // Update the positions of the targets
    //        for (int i = targets.Count - 1; i >= 0; i--)
    //        {
    //            targets[i] += new Vector2(1, 0); // Example: Move targets to the right
    //        }

    //        // Generate new targets if necessary
    //        if (targets.Count < 5) // Example: Generate up to 5 targets
    //        {
    //            // Generate a random position for the target
    //            Random random = new Random();
    //            Vector2 targetPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));

    //            // Add the target to the list
    //            targets.Add(targetPosition);
    //        }
    //    }

    //    public override void Draw(SpriteBatch spriteBatch)
    //    {
    //        // Draw game screen logic here
    //        spriteBatch.Begin();

    //        // Draw the targets
    //        foreach (Vector2 target in targets)
    //        {
    //            spriteBatch.Draw(targetTexture, target, Color.White);
    //        }

    //        // Draw the score, accuracy, and previous score
    //        spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
    //        spriteBatch.DrawString(font, "Accuracy: " + accuracy + "%", new Vector2(10, 30), Color.White);
    //        spriteBatch.DrawString(font, "Previous Score: " + previousScore, new Vector2(10, 50), Color.White);

    //        spriteBatch.End();
    //    }

    //    private bool IsCollision(Vector2 point1, Vector2 point2)
    //    {
    //        // Perform collision detection logic here
    //        // For example, you can check if the distance between the two points is less than a threshold
    //        float distance = Vector2.Distance(point1, point2);
    //        return distance < 10; // Example: Collision threshold of 10 pixels
    //    }
    //}
}
