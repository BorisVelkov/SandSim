using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace SFML_Test
{
    static class Program
    {
        static List<RectangleShape> cubes = new List<RectangleShape>();
        static List<Vector2f> posits = new List<Vector2f>();
 
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
           var window = new RenderWindow(new VideoMode(800, 600), "Window");
           window.Closed += new EventHandler(OnClose);

           Color windowColor = new Color(0, 0, 0);

            static RectangleShape testFunc()
            {
                var test = new RectangleShape(new Vector2f(20, 20))
                {
                    FillColor = new Color(250, 250, 250)
                };
                return test;
            }

            bool isPressed = false;

            window.MouseButtonPressed += buttonclick;
            void buttonclick(object sender, EventArgs e) {isPressed = true; }

            window.MouseButtonReleased += buttondrop;
            void buttondrop(object sender, EventArgs e) {isPressed = false; }

            int x = 0;

            while (window.IsOpen)
            {

                window.DispatchEvents();
                window.Clear(windowColor);
                Vector2i mousePosition = Mouse.GetPosition(window);

                RectangleShape test = new RectangleShape(new Vector2f(0, 0));

                int gridCubeWidth = 20;
                int gridCubeHeight = 20;

                int oldX = 0;
                int oldY = 0;

                int i;

                if (isPressed)
                {
                    testFunc();
                    
                    test = testFunc();

                    oldX = mousePosition.X;
                    oldY = mousePosition.Y;
                    int newX = (oldX / gridCubeWidth) * gridCubeWidth;
                    int newY = (oldY / gridCubeHeight) * gridCubeHeight;
                    test.Position = new Vector2f(newX, newY);

                    cubes.Add(test);
                    posits.Add(test.Position);
                    Console.WriteLine(cubes.Count + " " + posits.Count);
                    

                }
                
                i = 0;
                for (i = 0; i < cubes.Count; i++)
                {
                    float X = posits[i].X;
                    float Y = posits[i].Y;
                    if(Y <= 560)
                    {
                        X = posits[i].X;
                        Y = posits[i].Y + 20;
                    }
                    
                    Vector2f Vector = (new Vector2f(X, Y));

                    cubes[i] = new RectangleShape(new Vector2f(20, 20)) { FillColor = new Color(250, 250, 250) };
                    cubes[i].Position = Vector;

                    posits.RemoveAt(i);
                    posits.Insert(i, Vector);

                }

                i = 0;
                foreach (RectangleShape element in cubes)
                {
                    window.Draw(cubes[i]);
                    i++;
                }

                window.Display();
                System.Threading.Thread.Sleep(100);

            } 
        }

    } 
}
