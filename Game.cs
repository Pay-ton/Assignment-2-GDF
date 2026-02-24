// Include the namespaces (code libraries) you need below.
using System;
using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        // For Circle Detection
        bool ActiveCircle = false;

        // For Randomizing Circle Position
        // Randomized Float Code from module 3, Tweaked slightly
        float VerticalCirclePosition = Random.Float(1, 200);
        float HorizontalCirclePosition = Random.Float(1, 200);


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Clear previous image ( MOVED UP HERE BECAUSE CLEARING BACKGROUND EVERY UPDATE SOUNDS LIKE A BAD IDEA ) 
            Window.ClearBackground(Color.OffWhite);
            // NEVERMIND, IT WAS ON THAT LAYER FOR A REASON
        }


        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // THIS IS WHAT FIXED THE DUPLICATION ERROR ( I put it back) 
            Window.ClearBackground(Color.OffWhite);

            // MOUSE POSITION CONVERSION I HOPE
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();


            // Probably also need to spawn the circles under the updates section I imagine
            if (ActiveCircle == false)
            {
                // For Randomizing Circle Position
                // Randomized Float Code from module 3, Tweaked slightly
                VerticalCirclePosition = Random.Float(1, 200);
                HorizontalCirclePosition = Random.Float(1, 200);
                Window.ClearBackground(Color.OffWhite);

                ActiveCircle = true;
                // OF Note, THE ABOVE CODE IS THE CODE THAT STOPS THE SIEZURES. REMOVE THE COMMENT MARKINGS if you'd like, I figured I would leave it in for demonstrative purpose


            }

            // This spawns the circles
            Draw.FillColor = Color.Red;
            Draw.LineColor = Color.Black;
            Draw.Circle(HorizontalCirclePosition, (VerticalCirclePosition), (25));

            // Draw a circle at mouse position ( EXCEPT SMALLER NOW! ) 
            Draw.FillColor = Color.Green;
            Draw.LineColor = Color.Black;
            Draw.Circle(mouseX, mouseY, 5);

            // Anaha Helped me with this part, a distance check made so much more sense. 
            // For calculating distance between mouse and random circle
            float DistanceX = HorizontalCirclePosition - mouseX;
            float DistanceY = VerticalCirclePosition - mouseY;

            // FOR HANDLING NEGATIVE VALUES ON GRID IN DISTANCE MEASUREMENT
            if (DistanceX < 0)
            {
                DistanceX = DistanceX * -1;
            }
            if (DistanceY < 0)
            {
                DistanceY = DistanceY * -1;
            }

            float DistanceCheck = DistanceX + DistanceY;

            // DETECTION MAYBE PLEASE???????
            if (DistanceCheck < 25)
            {
                ActiveCircle = false;
                Console.WriteLine("CIRCLE DETECTED!!!!!!!");
            }
            // DETECTION WORKS



            // UNUSED WASTES OF CODE HELL

            // OK SO I PROBABLY NEED TO MAKE THE MOUSE POSITION BIGGER THAN THE EXACT POSITION. Gonna try and see if I can't do that with below
            // float MouseLocation = (Input.GetMousePosition() + 5) & (Input.GetMousePosition() - 5);  GUESS WHAT? MORE UNUSABLE CODE THAT I'VE ELECTED TO GIVE UP ON

            // For Detecting mouse location    NEVER FUCKING MIND ACTUALLY, EAT SHIT AND DIE PERHAPS? THATS ALL THIS FUCKING CODE IS TELLING ME IT REFUSES TO WORK
            // float mouseLocationVertical = ;
            // float mouseLocationHorizontal =;

        }

    }
}
