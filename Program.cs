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
            int count = 0;

            //particle colour registry
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
            { FillColor = new Color(190, 190, 200) };
            RectangleShape cube9 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(50, 250, 100) };
            RectangleShape cube10 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(250, 250, 250) };
            RectangleShape cube20 = new RectangleShape(new Vector2f(10, 10))
            { FillColor = new Color(100, 100, 110) };

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

            //main loop
            while (window.IsOpen)
            {
                //setup and initialization
                window.Clear(windowColor);
                window.DispatchEvents();

                //keyboard events
                {
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
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.Hyphen))
                    {
                        material = 10;
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.Equal))
                    {
                        material = 20;
                    }

                    //clear switch
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
                    //brush switch
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        brush = false;
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    {
                        brush = true;
                    }
                    //sleep switch
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    {
                        sleep = 0;
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
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                    {
                        goto pause;
                    }
                }

                //collision logic
                for (y = 0; y < 800; y = y + 10) 
                {
                    for (x = 0; x < 1000; x = x + 10)
                    {
                        switch (positions[x, y])
                        {
                            //main line particles
                            case 1: //rock
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
                                break;
                            case 2: //antigrav
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
                                break;
                            case 3: //water
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
                                break;
                            case 4: //wood
                                break;
                            case 5: //sand
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
                                break;
                            case 6: //ice
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
                                break;
                            case 7: //fire-main
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
                                break;
                            case 8: //steam
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
                                break;
                            case 9: //cloner
                                {
                                    switch (positions[x, y - 10])
                                    {
                                        case 1:
                                            {
                                                positions[x, y] = 19;
                                            }
                                            break;
                                        case 3:
                                            {
                                                positions[x, y] = 39;
                                            }
                                            break;
                                        case 5:
                                            {
                                                positions[x, y] = 59;
                                            }
                                            break;
                                        case 6:
                                            {
                                                positions[x, y] = 69;
                                            }
                                            break;
                                    }

                                    switch (positions[x, y + 10])
                                    {
                                        case 2:
                                            {
                                                positions[x, y] = 29;
                                            }
                                            break;
                                        case 7:
                                            {
                                                positions[x, y] = 79;
                                            }
                                            break;
                                        case 8:
                                            {
                                                positions[x, y] = 89;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case 10: //cell
                                {
                                    bot = positions[x, y + 10];
                                    bol = positions[x - 10, y + 10];
                                    bor = positions[x + 10, y + 10];
                                    rig = positions[x + 10, y];
                                    lef = positions[x - 10, y];
                                    top = positions[x, y - 10];
                                    tol = positions[x - 10, y - 10];
                                    tor = positions[x + 10, y - 10];

                                    count = 0;
                                    if (bot == 10 | bot == 120) { count++; }
                                    if (bol == 10 | bol == 120) { count++; }
                                    if (bor == 10 | bor == 120) { count++; }
                                    if (rig == 10 | rig == 120) { count++; }
                                    if (lef == 10 | lef == 110) { count++; }
                                    if (top == 10 | top == 110) { count++; }
                                    if (tol == 10 | tol == 110) { count++; }
                                    if (tor == 10 | tor == 110) { count++; }

                                    if ((bot == 0 | bot == 110) && y < 770) { positions[x, y + 10] = 100; }
                                    if ((bol == 0 | bol == 110) && y < 770 && x > 10) { positions[x - 10, y + 10] = 100; }
                                    if ((bor == 0 | bor == 110) && y < 770 && x < 979) { positions[x + 10, y + 10] = 100; }
                                    if ((rig == 0 | rig == 110) && x < 979) { positions[x + 10, y] = 100; }
                                    if ((lef == 0) && x > 10) { positions[x - 10, y] = 100; }
                                    if ((top == 0) && y > 10) { positions[x, y - 10] = 100; }
                                    if ((tol == 0) && y > 10 && x > 10) { positions[x - 10, y - 10] = 100; }
                                    if ((tor == 0) && y > 10 && x < 979) { positions[x + 10, y - 10] = 100; }

                                    switch (count)
                                    {
                                        case 0:
                                        case 1:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                            positions[x, y] = 110;
                                            break;
                                    }
                                }
                                break;
                            case 110: //dying cell
                                positions[x, y] = 0;
                                    break;
                            case 120: //newborn cell
                                {
                                    bot = positions[x, y + 10];
                                    bol = positions[x - 10, y + 10];
                                    bor = positions[x + 10, y + 10];
                                    rig = positions[x + 10, y];
                                    lef = positions[x - 10, y];
                                    top = positions[x, y - 10];
                                    tol = positions[x - 10, y - 10];
                                    tor = positions[x + 10, y - 10];

                                    count = 0;
                                    if (bot == 10 | bot == 120) { count++; }
                                    if (bol == 10 | bol == 120) { count++; }
                                    if (bor == 10 | bor == 120) { count++; }
                                    if (rig == 10 | rig == 120) { count++; }
                                    if (lef == 10 | lef == 110) { count++; }
                                    if (top == 10 | top == 110) { count++; }
                                    if (tol == 10 | tol == 110) { count++; }
                                    if (tor == 10 | tor == 110) { count++; }

                                    if ((bot == 0 | bot == 110) && y < 770) { positions[x, y + 10] = 100; }
                                    if ((bol == 0 | bol == 110) && y < 770 && x > 10) { positions[x - 10, y + 10] = 100; }
                                    if ((bor == 0 | bor == 110) && y < 770 && x < 979) { positions[x + 10, y + 10] = 100; }
                                    if ((rig == 0 | rig == 110) && x < 979) { positions[x + 10, y] = 100; }
                                    if ((lef == 0) && x > 10) { positions[x - 10, y] = 100; }
                                    if ((top == 0) && y > 10) { positions[x, y - 10] = 100; }
                                    if ((tol == 0) && y > 10 && x > 10) { positions[x - 10, y - 10] = 100; }
                                    if ((tor == 0) && y > 10 && x < 979) { positions[x + 10, y - 10] = 100; }

                                    switch (count)
                                    {
                                        case 0:
                                        case 1:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                            positions[x, y] = 110;
                                            break;
                                        case 2:
                                        case 3:
                                            positions[x, y] = 10;
                                            break;
                                    }
                                }
                                break;

                            //runoff particles
                            //fire runoff
                            case 17:
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
                                break;
                            case 27:
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
                                break;
                            case 37:
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
                                break;
                            case 47:
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
                                break;
                            case 57:
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
                                break;
                            case 67:
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
                                break;
                            case 77:
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
                                break;
                            case 87:
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
                                break;
                            case 97:
                                {
                                    positions[x, y] = 0;
                                }
                                break;
                            //cloner runoff
                            case 19:
                                {
                                    positions[x, y + 10] = 1;
                                }
                                break;
                            case 29:
                                {
                                    positions[x, y - 10] = 2;
                                }
                                break;
                            case 39:
                                {
                                    positions[x, y + 10] = 3;
                                }
                                break;
                            case 59:
                                {
                                    positions[x, y + 10] = 5;
                                }
                                break;
                            case 69:
                                {
                                    positions[x, y + 10] = 6;
                                }
                                break;
                            case 79:
                                {
                                    positions[x, y - 10] = 7;
                                }
                                break;
                            case 89:
                                {
                                    positions[x, y - 10] = 8;
                                }
                                break;
                            //moved particles cleanup
                            case 11:
                                {
                                    positions[x, y] = 1;
                                    position.X = (x);
                                    position.Y = (y);
                                    cube1.Position = position;
                                    window.Draw(cube1);
                                }
                                break;
                            case 13:
                                {
                                    positions[x, y] = 3;
                                    position.X = (x);
                                    position.Y = (y);
                                    cube3.Position = position;
                                    window.Draw(cube3);
                                }
                                break;
                            case 15:
                                {
                                    positions[x, y] = 5;
                                    position.X = (x);
                                    position.Y = (y);
                                    cube5.Position = position;
                                    window.Draw(cube5);
                                }
                                break;
                            case 16:
                                {
                                    positions[x, y] = 6;
                                    position.X = (x);
                                    position.Y = (y);
                                    cube6.Position = position;
                                    window.Draw(cube6);
                                }
                                break;
                            case 26:
                                {
                                    positions[x, y] = 16;
                                }
                                break;
                        }
                    }
                }

                //game of life cleanup
                for (y = 0; y < 800; y = y + 10)
                {
                    for (x = 0; x < 1000; x = x + 10) 
                    {
                        if (positions[x, y] == 100)
                        {
                            bot = positions[x, y + 10];
                            bol = positions[x - 10, y + 10];
                            bor = positions[x + 10, y + 10];
                            rig = positions[x + 10, y];
                            lef = positions[x - 10, y];
                            top = positions[x, y - 10];
                            tol = positions[x - 10, y - 10];
                            tor = positions[x + 10, y - 10];

                            count = 0;
                            if (bot == 10 | bot == 110) { count++; }
                            if (bol == 10 | bol == 110) { count++; }
                            if (bor == 10 | bor == 110) { count++; }
                            if (rig == 10 | rig == 110) { count++; }
                            if (lef == 10 | lef == 110) { count++; }
                            if (top == 10 | top == 110) { count++; }
                            if (tol == 10 | tol == 110) { count++; }
                            if (tor == 10 | tor == 110) { count++; }

                            if (count == 3)
                            {
                                positions[x, y] = 120;
                            }
                            else
                            {
                                positions[x, y] = 0;
                            }
                        }
                    }
                }

                pause:

                //mouse events
                if (isPressed)
                {
                    Vector2i mousePosition = Mouse.GetPosition(window);
                    //takes the coordinates of the mouse
                    rawX = mousePosition.X;
                    rawY = mousePosition.Y;
                    //rounds the mouse coord data to the grid
                    newX = (rawX / gridSize) * gridSize;
                    newY = (rawY / gridSize) * gridSize;

                    //sets grid location to particle type
                    if (brush == false && newX > 0 && newX < 990 && newY > 0 && newY < 780)
                    {
                        positions[newX, newY] = material;
                    }
                    else if (brush == true && newX > 10 && newX < 980 && newY > 10 && newY < 770)
                    {
                        positions[newX, newY] = material;
                        positions[newX + 10, newY] = material;
                        positions[newX - 10, newY] = material;
                        positions[newX, newY + 10] = material;
                        positions[newX, newY - 10] = material;
                    }
                }

                //drawing logic
                for (y = 0; y < 800; y = y + 10) 
                {
                    for (x = 0; x < 1000; x = x + 10)
                    {
                        switch (positions[x, y])
                        {
                            case 1:
                                position.X = (x);
                                position.Y = (y);
                                cube1.Position = position;
                                window.Draw(cube1);
                                break;
                            case 2:
                                position.X = (x);
                                position.Y = (y);
                                cube2.Position = position;
                                window.Draw(cube2);
                                break;
                            case 3:
                                position.X = (x);
                                position.Y = (y);
                                cube3.Position = position;
                                window.Draw(cube3);
                                break;
                            case 4:
                                position.X = (x);
                                position.Y = (y);
                                cube4.Position = position;
                                window.Draw(cube4);
                                break;
                            case 5:
                                position.X = (x);
                                position.Y = (y);
                                cube5.Position = position;
                                window.Draw(cube5);
                                break;
                            case 6:
                            case 16:
                            case 26:
                                position.X = (x);
                                position.Y = (y);
                                cube6.Position = position;
                                window.Draw(cube6);
                                break;
                            case 7:
                            case 17:
                            case 27:
                            case 37:
                            case 47:
                            case 57:
                            case 67:
                            case 77:
                            case 87:
                            case 97:
                                position.X = (x);
                                position.Y = (y);
                                cube7.Position = position;
                                window.Draw(cube7);
                                break;
                            case 8:
                                position.X = (x);
                                position.Y = (y);
                                cube8.Position = position;
                                window.Draw(cube8);
                                break;
                            case 9:
                            case 19:
                            case 29:
                            case 39:
                            case 59:
                            case 69:
                            case 79:
                            case 89:
                                position.X = (x);
                                position.Y = (y);
                                cube9.Position = position;
                                window.Draw(cube9);
                                break;
                            case 10:
                            case 110:
                                position.X = (x);
                                position.Y = (y);
                                cube10.Position = position;
                                window.Draw(cube10);
                                break;
                            case 20:
                                position.X = (x);
                                position.Y = (y);
                                cube20.Position = position;
                                window.Draw(cube20);
                                break;
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
