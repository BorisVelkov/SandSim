using System;
using System.Collections.Generic;
using SFML;
using SFML.Window;
using SFML.System;
using SFML.Graphics;


namespace SandSim
{
    class Program
    {
        //grid array
        static int[,] positions = new int[1000, 800];

        //window close logic
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main(string[] args)
        {
            //sets up integers
            int material = 1;
            int rawX = 0;
            int rawY = 0;
            int newX = 0;
            int newY = 0;
            int gridSize = 10;
            int y = 0;
            int x = 0;
            int rand;
            int bot;
            int bol;
            int bor;
            int top;
            int tol;
            int tor;
            int rig;
            int lef;

            bool brush = false;
            int sleep = 1;

            Vector2f position = new Vector2f(0, 0);
            RectangleShape cube1 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(100, 100, 100) };
            RectangleShape cube2 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(200, 0, 250) };
            RectangleShape cube3 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(0, 50, 250) };
            RectangleShape cube4 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(80, 30, 0) };
            RectangleShape cube5 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(200, 180, 20) };
            RectangleShape cube6 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(200, 200, 250) };
            RectangleShape cube7 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(250, 50, 0) };
            RectangleShape cube8 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(240, 240, 240) };
            RectangleShape cube9 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(50, 250, 100) };

            //handles window
            var window = new RenderWindow(new VideoMode(1000, 800), "SandSim");
            Color windowColor = new Color(0, 0, 0);
            window.Closed += new EventHandler(OnClose);

            //handles mouse events
            bool isPressed = false;
            window.MouseButtonPressed += buttonclick;
            void buttonclick(object sender, EventArgs e) { isPressed = true; }
            window.MouseButtonReleased += buttondrop;
            void buttondrop(object sender, EventArgs e) { isPressed = false; }


            while (window.IsOpen)
            {
                //setup and initialization                              

                window.Clear(windowColor);
                window.DispatchEvents();

                //material switch
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num0))
                {
                    material = 0;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num1))
                {
                    material = 1;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num2))
                {
                    material = 2;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num3))
                {
                    material = 3;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num4))
                {
                    material = 4;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num5))
                {
                    material = 5;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num6))
                {
                    material = 6;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num7))
                {
                    material = 7;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num8))
                {
                    material = 8;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Num9))
                {
                    material = 9;
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.C))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        for (int c = 0; c < 800; c++)
                        {
                            positions[i, c] = 0;
                        }
                    }
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    brush = false;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    brush = true;
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                {
                    sleep = 1;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    sleep = 10;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                {
                    sleep = 25;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                {
                    sleep = 50;
                }

                //mouse events
                Vector2i mousePosition = Mouse.GetPosition(window);
                if (isPressed)
                {
                    //takes the coordinates of the mouse
                    rawX = mousePosition.X;
                    rawY = mousePosition.Y;
                    //rounds the mouse coord data to the grid
                    newX = (rawX / gridSize) * gridSize;
                    newY = (rawY / gridSize) * gridSize;

                    //sets grid location to particle type
                    if (brush == false && newX > 0 && newX < 990 && newY > 0 && newY < 780)
                    {
                        switch (material)
                        {
                            case 0:
                                positions[newX, newY] = 0;
                                break;
                            case 1:
                                positions[newX, newY] = 1;
                                break;
                            case 2:
                                positions[newX, newY] = 2;
                                break;
                            case 3:
                                positions[newX, newY] = 3;
                                break;
                            case 4:
                                positions[newX, newY] = 4;
                                break;
                            case 5:
                                positions[newX, newY] = 5;
                                break;
                            case 6:
                                positions[newX, newY] = 6;
                                break;
                            case 7:
                                positions[newX, newY] = 7;
                                break;
                            case 8:
                                positions[newX, newY] = 8;
                                break;
                            case 9:
                                positions[newX, newY] = 9;
                                break;
                        }
                    }
                    else if (brush == true && newX > 10 && newX < 980 && newY > 10 && newY < 770)
                    {
                        switch (material)
                        {
                            case 0:
                                positions[newX, newY] = 0;
                                positions[newX + 10, newY] = 0;
                                positions[newX - 10, newY] = 0;
                                positions[newX, newY + 10] = 0;
                                positions[newX, newY - 10] = 0;
                                break;
                            case 1:
                                positions[newX, newY] = 1;
                                positions[newX + 10, newY] = 1;
                                positions[newX - 10, newY] = 1;
                                positions[newX, newY + 10] = 1;
                                positions[newX, newY - 10] = 1;
                                break;
                            case 2:
                                positions[newX, newY] = 2;
                                positions[newX + 10, newY] = 2;
                                positions[newX - 10, newY] = 2;
                                positions[newX, newY + 10] = 2;
                                positions[newX, newY - 10] = 2;
                                break;
                            case 3:
                                positions[newX, newY] = 3;
                                positions[newX + 10, newY] = 3;
                                positions[newX - 10, newY] = 3;
                                positions[newX, newY + 10] = 3;
                                positions[newX, newY - 10] = 3;
                                break;
                            case 4:
                                positions[newX, newY] = 4;
                                positions[newX + 10, newY] = 4;
                                positions[newX - 10, newY] = 4;
                                positions[newX, newY + 10] = 4;
                                positions[newX, newY - 10] = 4;
                                break;
                            case 5:
                                positions[newX, newY] = 5;
                                positions[newX + 10, newY] = 5;
                                positions[newX - 10, newY] = 5;
                                positions[newX, newY + 10] = 5;
                                positions[newX, newY - 10] = 5;
                                break;
                            case 6:
                                positions[newX, newY] = 6;
                                positions[newX + 10, newY] = 6;
                                positions[newX - 10, newY] = 6;
                                positions[newX, newY + 10] = 6;
                                positions[newX, newY - 10] = 6;
                                break;
                            case 7:
                                positions[newX, newY] = 7;
                                positions[newX + 10, newY] = 7;
                                positions[newX - 10, newY] = 7;
                                positions[newX, newY + 10] = 7;
                                positions[newX, newY - 10] = 7;
                                break;
                            case 8:
                                positions[newX, newY] = 8;
                                positions[newX + 10, newY] = 8;
                                positions[newX - 10, newY] = 8;
                                positions[newX, newY + 10] = 8;
                                positions[newX, newY - 10] = 8;
                                break;
                            case 9:
                                positions[newX, newY] = 9;
                                positions[newX + 10, newY] = 9;
                                positions[newX - 10, newY] = 9;
                                positions[newX, newY + 10] = 9;
                                positions[newX, newY - 10] = 9;
                                break;
                        }
                    }
                }


                //collision logic
                for (x = 0; x < 1000; x = x + 10)
                {
                    for (y = 0; y < 800; y = y + 10)
                    {
                        //runs when a particle type is found
                        //rock
                        if (positions[x, y] == 1)
                        {
                            bot = positions[x, y + 10];
                            bol = positions[x + 10, y + 10];
                            bor = positions[x - 10, y + 10];
                            lef = positions[x + 10, y];
                            rig = positions[x - 10, y];

                            if ((bot == 0 | bot == 2 | bot == 3 | bot == 5 | bot == 7 | bot == 8) && y < 770)
                            {
                                positions[x, y] = bot;
                                positions[x, (y + 10)] = 11;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if ((bol == 0 && lef == 0) && y < 770 && x < 979)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y + 10)] = 11;
                                        }
                                        break;
                                    case 1:
                                        if ((bor == 0 && rig == 0) && y < 770 && x > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y + 10)] = 11;
                                        }
                                        break;
                                }
                            }

                        }
                        //antigrav
                        else if (positions[x, y] == 2)
                        {
                            if (positions[x, y - 10] == 0 && y > 10)
                            {
                                positions[x, y] = 0;
                                positions[x, (y - 10)] = 2;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if (positions[x + 10, y - 10] == 0 && positions[x + 10, y] == 0 && y > 10 && x < 979)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 2;
                                        }
                                        break;
                                    case 1:
                                        if (positions[x - 10, y - 10] == 0 && positions[x - 10, y] == 0 && y > 10 && x > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 2;
                                        }
                                        break;
                                }
                            }
                        }
                        //water
                        else if (positions[x, y] == 3)
                        {
                            bot = positions[x, y + 10];
                            if ((bot == 0 | bot == 8) && y < 770)
                            {
                                positions[x, y] = bot;
                                positions[x, (y + 10)] = 13;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if (positions[x + 10, y] == 0 && y < 770 && x < 979)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), y] = 13;
                                        }
                                        break;
                                    case 1:
                                        if (positions[x - 10, y] == 0 && y < 770 && x > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), y] = 13;
                                        }
                                        break;
                                }
                            }
                        }
                        //oil
                        else if (positions[x, y] == 5)
                        {
                            bot = positions[x, y + 10];
                            lef = positions[x + 10, y];
                            rig = positions[x - 10, y];

                            if ((bot == 0 | bot == 3) && y < 770)
                            {
                                positions[x, y] = bot;
                                positions[x, (y + 10)] = 15;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if ((lef == 0 | lef == 3) && y < 770 && x < 979)
                                        {
                                            positions[x, y] = lef;
                                            positions[(x + 10), y] = 15;
                                        }
                                        break;
                                    case 1:
                                        if ((rig == 0 | rig == 3) && y < 770 && x > 10)
                                        {
                                            positions[x, y] = rig;
                                            positions[(x - 10), y] = 15;
                                        }
                                        break;
                                }
                            }

                        }
                        //ice
                        else if (positions[x, y] == 6)
                        {
                            bot = positions[x, y + 10];
                            bol = positions[x + 10, y + 10];
                            bor = positions[x - 10, y + 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];
                            top = positions[x, y - 10];

                            if ((bot == 0 | bot == 2 | bot == 3) && y < 770)
                            {
                                positions[x, y] = bot;
                                positions[x, (y + 10)] = 16;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if ((bol == 0 && lef == 0) && y < 770 && x < 979)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y + 10)] = 16;

                                        }
                                        break;
                                    case 1:
                                        if ((bor == 0 && rig == 0) && y < 770 && x > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y + 10)] = 16;

                                        }
                                        break;
                                }
                            }
                            {
                                if (bot == 3)
                                {
                                    positions[x, y + 10] = 26;
                                }
                                if (lef == 3)
                                {
                                    positions[x - 10, y] = 16;
                                }
                                if (rig == 3)
                                {
                                    positions[x + 10, y] = 26;
                                }
                                if (top == 3)
                                {
                                    positions[x, y - 10] = 16;
                                }
                            }

                        }
                        //fire1
                        else if (positions[x, y] == 7)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 17;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 17;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 17;
                                        }
                                        break;
                                }
                            }
                            positions[x, y] = 0;
                        }
                        //fire2
                        else if (positions[x, y] == 17)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 27;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 27;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 27;
                                        }
                                        break;
                                }
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 27)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 37;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 37;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 37;
                                        }
                                        break;
                                }
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 37)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 47;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 47;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 47;
                                        }
                                        break;
                                }
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            if (lef == 4)
                            {
                                positions[x - 10, y] = 37;
                            }
                            if (rig == 4)
                            {
                                positions[x + 10, y] = 37;
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 47)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 57;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 57;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 57;
                                        }
                                        break;
                                }
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            if (lef == 4)
                            {
                                positions[x - 10, y] = 37;
                            }
                            if (rig == 4)
                            {
                                positions[x + 10, y] = 37;
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 57)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 67;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 67;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 67;
                                        }
                                        break;
                                }
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            if (lef == 4)
                            {
                                positions[x - 10, y] = 37;
                            }
                            if (rig == 4)
                            {
                                positions[x + 10, y] = 37;
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 67)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 77;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 77;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 77;
                                        }
                                        break;
                                }
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            if (lef == 4)
                            {
                                positions[x - 10, y] = 37;
                            }
                            if (rig == 4)
                            {
                                positions[x + 10, y] = 37;
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 77)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 87;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 87;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 87;
                                        }
                                        break;
                                }
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            if (lef == 4)
                            {
                                positions[x - 10, y] = 37;
                            }
                            if (rig == 4)
                            {
                                positions[x + 10, y] = 37;
                            }
                            if (top == 4)
                            {
                                positions[x, y - 10] = 37;
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 87)
                        {
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];
                            lef = positions[x - 10, y];
                            rig = positions[x + 10, y];


                            if ((top == 0 | tol == 0 | tor == 0) && y > 10)
                            {
                                rand = new Random().Next(0, 4);
                                switch (rand)
                                {
                                    case 0:
                                    case 1:
                                        if ((top == 0) && y > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[x, (y - 10)] = 97;
                                        }
                                        break;
                                    case 2:
                                        if ((tol == 0 && (lef == 0 | top == 0) && y > 10 && x > 10))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), (y - 10)] = 97;
                                        }
                                        break;
                                    case 3:
                                        if ((tor == 0 && (rig == 0 | top == 0) && y > 10 && x < 979))
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), (y - 10)] = 97;
                                        }
                                        break;
                                }
                            }
                            positions[x, y] = 0;
                        }
                        else if (positions[x, y] == 97)
                        {
                            positions[x, y] = 0;
                        }
                        //steam
                        else if (positions[x, y] == 8)
                        {
                            if (y > 10 && y < 100)
                            {
                                positions[x, y] = 3;
                            }
                            else if (positions[x, y - 10] == 0 && y > 30)
                            {
                                positions[x, y] = 0;
                                positions[x, (y - 10)] = 8;
                            }
                            else
                            {
                                rand = new Random().Next(0, 2);
                                switch (rand)
                                {
                                    case 0:
                                        if (positions[x + 10, y] == 0 && x < 979)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x + 10), y] = 8;
                                        }
                                        break;
                                    case 1:
                                        if (positions[x - 10, y] == 0 && x > 10)
                                        {
                                            positions[x, y] = 0;
                                            positions[(x - 10), y] = 8;
                                        }
                                        break;
                                }
                            }
                        }
                        //cloner
                        else if (positions[x, y] == 9)
                        {
                            if (positions[x, y - 10] == 1)
                            {
                                positions[x, y] = 19;
                            }
                            if (positions[x, y + 10] == 2)
                            {
                                positions[x, y] = 29;
                            }
                            if (positions[x, y - 10] == 3)
                            {
                                positions[x, y] = 39;
                            }
                            if (positions[x, y - 10] == 5)
                            {
                                positions[x, y] = 59;
                            }
                            if (positions[x, y - 10] == 6)
                            {
                                positions[x, y] = 69;
                            }
                            if (positions[x, y + 10] == 7)
                            {
                                positions[x, y] = 79;
                            }
                            if (positions[x, y + 10] == 8)
                            {
                                positions[x, y] = 89;
                            }
                        }
                        //cloner stone
                        else if (positions[x, y] == 19)
                        {
                            positions[x, y + 10] = 1;
                        }
                        //cloner antigrav
                        else if (positions[x, y] == 29)
                        {
                            positions[x, y - 10] = 2;
                        }
                        //cloner water
                        else if (positions[x, y] == 39)
                        {
                            positions[x, y + 10] = 3;
                        }
                        //cloner oil
                        else if (positions[x, y] == 59)
                        {
                            positions[x, y + 10] = 5;
                        }
                        //cloner ice
                        else if (positions[x, y] == 69)
                        {
                            positions[x, y + 10] = 6;
                        }
                        //cloner fire
                        else if (positions[x, y] == 79)
                        {
                            positions[x, y - 10] = 7;
                        }
                        //cloner steam
                        else if (positions[x, y] == 89)
                        {
                            positions[x, y - 10] = 8;
                        }

                        //particles that have been moved already are written over to regular states
                        {
                            if (positions[x, y] == 11)
                            {
                                positions[x, y] = 1;
                            }
                            else if (positions[x, y] == 12)
                            {
                                positions[x, y] = 2;
                            }
                            else if (positions[x, y] == 13)
                            {
                                positions[x, y] = 3;
                            }
                            else if (positions[x, y] == 15)
                            {
                                positions[x, y] = 5;
                            }
                            else if (positions[x, y] == 26)
                            {
                                positions[x, y] = 16;
                            }
                            else if (positions[x, y] == 16)
                            {
                                positions[x, y] = 6;
                            }
                        }
                    }
                }
                //draw logic
                for (y = 0; y < 800; y = y + 10)
                {
                    for (x = 0; x < 1000; x = x + 10)
                    {
                        //when comes across a particle, draws it
                        if (positions[x, y] == 1)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube1.Position = position;
                            window.Draw(cube1);
                        }
                        else if (positions[x, y] == 2)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube2.Position = position;
                            window.Draw(cube2);
                        }
                        else if (positions[x, y] == 3)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube3.Position = position;
                            window.Draw(cube3);
                        }
                        else if (positions[x, y] == 4)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube4.Position = position;
                            window.Draw(cube4);
                        }
                        else if (positions[x, y] == 5)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube5.Position = position;
                            window.Draw(cube5);
                        }
                        else if (positions[x, y] == 6 | positions[x, y] == 16 | positions[x, y] == 26 | positions[x, y] == 36
                            | positions[x, y] == 46 | positions[x, y] == 56 | positions[x, y] == 76 | positions[x, y] == 86 | positions[x, y] == 96)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube6.Position = position;
                            window.Draw(cube6);
                        }
                        else if (positions[x, y] == 7 | positions[x, y] == 17 | positions[x, y] == 27 | positions[x, y] == 37
                            | positions[x, y] == 47 | positions[x, y] == 57 | positions[x, y] == 67
                            | positions[x, y] == 77 | positions[x, y] == 87 | positions[x, y] == 97)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube7.Position = position;
                            window.Draw(cube7);
                        }
                        else if (positions[x, y] == 8)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube8.Position = position;
                            window.Draw(cube8);
                        }
                        else if (positions[x, y] == 9 | positions[x, y] == 19 | positions[x, y] == 29 | positions[x, y] == 39
                            | positions[x, y] == 59 | positions[x, y] == 69 | positions[x, y] == 79 | positions[x, y] == 89)
                        {
                            position.X = (x);
                            position.Y = (y);
                            cube9.Position = position;
                            window.Draw(cube9);
                        }
                    }
                }

                //updates window, waits, resets main loop
                window.Display();
                System.Threading.Thread.Sleep(sleep);
            }
        }
    }
}