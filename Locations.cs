

using System.Media;

namespace J1P2_PRO_Prototype3_simon_boersma
{
    internal class Locations
    {
        string userInput = ""; // Er wordt een string aangemaakt met de naam userInput en met de waarde "".

        Enemy enemy1 = new Enemy(); // Er wordt een nieuwe class Enemy aangemaakt met de naam enemy1
        Enemy enemy2 = new Enemy(); // Er wordt een nieuwe class Enemy aangemaakt met de naam enemy2
        Enemy enemy3 = new Enemy(); // Er wordt een nieuwe class Enemy aangemaakt met de naam enemy3
        Enemy enemy4 = new Enemy(); // Er wordt een nieuwe class Enemy aangemaakt met de naam enemy4
        Enemy enemy5 = new Enemy(); // Enz...
        Enemy enemy6 = new Enemy();
        Enemy enemy7 = new Enemy();
        Enemy enemy8 = new Enemy();
        Enemy enemy9 = new Enemy();
        Enemy enemy10 = new Enemy();
        Enemy enemy11 = new Enemy();
        Enemy enemy12 = new Enemy();
        Enemy enemy13 = new Enemy();
        Enemy e = new Enemy(); // Er wordt een nieuwe class Enemy aangemaakt met de naam e
        Items i = new Items(); // Er wordt een nieuwe class Items aangemaakt met de naam i
        Player p = new Player(); // Er wordt een nieuwe class Player aangemaakt met de naam p

        public void AllLocations() // De Method AllLocations wordt aangemaakt. De Method is public
        {
            MainMenu(); // De Method MainMenu wordt opgeroepen
            Car(); // De Method Car wordt opgeroepen
        }
        public void MainMenu() // De Method MainMenu wordt aangemaakt. De Method is public
        {
            SoundPlayer sound = new SoundPlayer("Main.wav"); // Er wordt een SounPlayer aangemaakt met de naam sound en krijgt de waarde van het muziek van de Main.wav
            sound.Play(); // De variabel sound speelt af
            Console.BackgroundColor = ConsoleColor.Black; // De achtergrongkleur van de console wordt verandert naar zwart
            Console.Clear(); // Alles op de console wist
            Console.ForegroundColor = ConsoleColor.Gray; // De letterkleur wordt verandert naar grijs
            Console.WriteLine("Welcome to Viscacha Hunt! \n\nPress any key to enter the car and begin your mission"); // Er wordt tekst op de console geprint. Daartussen worden ook enters gebruikt
            Console.ReadKey(); // Druk op een willekeurige knop om verder te gaan
            sound.Stop(); // De variabel sound stopt met afspelen
        }
        public void Car()
        {
            SoundPlayer sound = new SoundPlayer("Car.wav");
            sound.Play();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hello Jardani! \n\nWe in the car underway in Italy to Viscacha Santino's house\nYou're goal is to find and eliminate Viscacha Santino. \nOn your way to finding him you will enqounter various types of enemy's. \tSo watch out! \nViscacha Santino is located on the second floor. \nYour character is always looking in the same direction when in a room \nGrab as many weapons as possible because you will need it! \nTry to be stealthy because otherwise your fighting will be put to the test!");
            Console.ReadKey();
            Console.WriteLine("\nWe arrived at the house! \nHappy Hunting! \n\nPress any key to exit the car");
            Console.ReadKey();
            sound.Stop();
            FrontDoor();
        }
        public void FrontDoor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            while (userInput != null) // Run de code in de scope zolang usserInput niet niks is
            {
                Console.WriteLine("You're at the front door of the house.");
                userInput = Console.ReadLine().ToLower(); // De input van de user wordt verandert naar kleine letters en wordt opgeslagen in de variabel userInput
                if (userInput == "open the front door" || userInput == "open front door" || userInput == "open the front door" || userInput == "go in front door" || userInput == "go in the front door" || userInput == "open door" || userInput == "open the door" || userInput == "enter" || userInput == "go in" || userInput == "open" || userInput == "open na noor") // Als de userInput zegt om de front door te openen dan...
                {
                    EntranceHall(); // ... Wordt de Method EntranceHall opgeroepen
                }
                else if (userInput == "go left" || userInput == "go left of the house" || userInput == "go to the left of the house") // Anders Als de userInput zegt om naar links te gaan dan...
                {
                    SouthWindow(); // ... Wordt de Method SouthWindow opgeroepen
                }
                else if (userInput == "go right" || userInput == "go right of the house" || userInput == "go to the right of the house") // Anders Als de userInput zegt om naar rechts te gaan dan...
                {
                    NorthWindow(); // ... Wordt de Method NorthWindow opgeroepen
                }
                else // Anders...
                {
                    Console.WriteLine("Input is wrong"); // ... Wordt er op de console tekst geprint
                    continue; // ... En begint de code weer bij de while loop
                }
            }
        }
        public void SouthWindow()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the South window");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open window" || userInput == "open the window") // Als de userInput zegt om het raam open te doen dan...
                {
                    Console.WriteLine("The window is already open"); // ... Wordt er tekst op de console geprint
                    userInput = Console.ReadLine().ToLower(); // ... En vraagt de user weer om input
                }
                if (userInput == "go in window" || userInput == "go in the window" || userInput == "go into the window" || userInput == "go through window" || userInput == "go through the window" || userInput == "get in the window" || userInput == "get in" || userInput == "go in") // Als de userInput zegt om in het raam te gaan dan...
                {
                    StorageRoom(); // ... Wordt de Method StorageRoom opgeroepen
                }
                else if (userInput == "go back" || userInput == "go back to front door" || userInput == "go back to the front door") // Anders Als de userInput zegt om terug te gaan naar de front door dan...
                {
                    FrontDoor(); // ... Wordt de Method FrontDoor opgeroepen
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void NorthWindow()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the North window");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open window" || userInput == "open the window")
                {
                    Console.WriteLine("The window is already open");
                    userInput = Console.ReadLine().ToLower();
                }
                if (userInput == "go in window" || userInput == "go in the window" || userInput == "go into the window" || userInput == "go through window" || userInput == "go through the window" || userInput == "get in the window" || userInput == "get in" || userInput == "go in")
                {
                    BathRoom();
                }
                else if (userInput == "go back" || userInput == "go back to front door" || userInput == "go back to the front door")
                {
                    FrontDoor();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void EntranceHall()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Entrance Hall \nThere is a door in front of you and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me") // Als de userInput zegt om de deur voor te openen dan...
                {
                    MainHall(); // ... Wordt de Method MainHall opgeroepen
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind") // Anders Als de userInput zegt om de deur achter te openen dan...
                {
                    FrontDoor(); // ... Wordt de Method Fornt door opgeroepen
                }
                else if (userInput == "go back to the front door" || userInput == "go back to front door" || userInput == "go back to the front door") // Anders Als de userInput zegt om terug te gaan naar de front door dan...
                {
                    FrontDoor(); // Wordt de Method FrontDoor opgeroepen
                }
                else if (userInput == "go back to main hall" || userInput == "go back to the main hall") // Anders als de userInput zegt om terug te gaan naar de main hall dan...
                {
                    MainHall(); // ... Wordt de Method MainHall opgeroepen
                }
                else if (userInput == "go back") // Anders Als de userInput zegt om terug te gaan dan...
                {
                    Console.WriteLine("Go back where?"); // ... Wordt er tekst op de console geprint
                    userInput = Console.ReadLine().ToLower(); // ... En wordt de input van de user omgezet naar kleine letters en opgeslagen in de variabel useInput
                    if (userInput == "front door" || userInput == "the front door" || userInput == "go back to front door" || userInput == "go back to the front door" || userInput == "to front door" || userInput == "to the front door") // Als de userInput zegt om terug te gaan naar de front door dan...
                    {
                        FrontDoor(); // ... Wordt de Method FrontDoor opgeroepen
                    }
                    else if (userInput == "main hall" || userInput == "the main hall" || userInput == "go back to main hall" || userInput == "go back to the main hall" || userInput == "to main hall" || userInput == "to the main hall") // Anders Als de userInput zegt om terug te gaan naar de front door dan...
                    {
                        MainHall(); // ... Wordt de Method MainHall opgeroepen
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void MainHall()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine();
            if (enemy1.enemyHp > 0) // Als de variabel enemyHp uit enemy1 (Enemy class) groter dan 1 is dan...
            {
                enemy1.Tino(i, p); // ... Wordt de Tino Method uit enemy1 (Enemy class)  opgeroepen met de arguments i (Items class) en p (Player class)
            }
            while (userInput != null)
            {

                Console.WriteLine();
                Console.WriteLine("You're in the Main Hall \nThere is a door in front of you, to the right and behind of you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right") // Als de userInput zegt om naar rechts te gaan dan...
                {
                    EntranceHall(); // Wordt de Method EntranceHall opgeroepen
                }
                else if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    Hall();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    SecurityRoom();
                }
                else if (userInput == "go back to the security room" || userInput == "go back to security room")
                {
                    SecurityRoom();
                }
                else if (userInput == "go back to the hall" || userInput == "go back to hall")
                {
                    Hall();
                }
                else if (userInput == "go back to the entrance hall" || userInput == "go back to entrance hall")
                {
                    EntranceHall();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "security room" || userInput == "the security room" || userInput == "go back to security room" || userInput == "go back to the security room" || userInput == "to security room" || userInput == "to the security room")
                    {
                        SecurityRoom();
                    }
                    else if (userInput == "hall" || userInput == "the hall" || userInput == "go back to hall" || userInput == "go back to the hall" || userInput == "to hall" || userInput == "to the hall")
                    {
                        Hall();
                    }
                    else if (userInput == "entrance hall" || userInput == "the entrance hall" || userInput == "go back to entrance hall" || userInput == "go back to the entrance hall" || userInput == "to entrance hall" || userInput == "to the entrance hall")
                    {
                        EntranceHall();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void StorageRoom()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            if (i.baseBat == 0) // Als de variabel baseBat uit i (Items class) gelijk is aan 0 dan...
            {
                i.BaseBallBat(); // ... Wordt de Method BaseBallBat uit i (Items class) opgeroepen
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Storage Room \nThere is a door");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    SecurityRoom();
                }
                else if (userInput == "go back to window" || userInput == "get back to window" || userInput == "go back to the window" || userInput == "get back to the window")
                {
                    SouthWindow();
                }
                else if (userInput == "go back to security room" || userInput == "go back to the security room")
                {
                    SecurityRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "window" || userInput == "the window" || userInput == "go back to the window" || userInput == "to window" || userInput == "to the window")
                    {
                        SouthWindow();
                    }
                    else if (userInput == "security room" || userInput == "the security room" || userInput == "go back to the security room" || userInput == "to security room" || userInput == "to the security room")
                    {
                        SecurityRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void BathRoom()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            while (userInput != null)
            {
                Console.WriteLine();
                if (p.quest == 0)
                {
                    Console.WriteLine("There is a spy in the room! \nWhat do you want to do? \nTalk or ignore?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "talk")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Hello there Jardani! \nI'm here to gather some intel but Vincent is stopping me from entering the Living Room. \nCan you take him out?");
                        userInput = Console.ReadLine().ToLower();
                        if (userInput == "yes")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Glad you can help, i will have a gift for you when you finish your quest.");
                            p.quest = 2;
                        }
                        else if (userInput == "no")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Alright, then i will have to find another way in \nGoodbye friend.");
                            p.quest = 2;
                        }
                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                    }
                    else if (userInput == "ignore")
                    {
                        p.quest = 2;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else if (p.quest == 1)
                {
                    Console.WriteLine("A spy in the room wants to talk");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine("Hello there! \nThank you for taking out Vincent! \nHere have this body armour. I'm sure it will help you. \nBe seeing you!");
                    p.userHp += 10;
                    Console.WriteLine($"Player HP: {p.userHp}");
                    p.quest = 2;
                }
                else if (p.quest == 2)
                {
                    Console.WriteLine("You're in the Bathroom \nThere is a door");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                    {
                        BedRoom();
                    }
                    else if (userInput == "go back to window" || userInput == "get back to window" || userInput == "go back to the window" || userInput == "get back to the window")
                    {
                        NorthWindow();
                    }
                    else if (userInput == "go back to bedroom" || userInput == "go back to the bathroom")
                    {
                        BathRoom();
                    }
                    else if (userInput == "go back")
                    {
                        Console.WriteLine("Go back where?");
                        userInput = Console.ReadLine().ToLower();
                        if (userInput == "window" || userInput == "the window" || userInput == "go back to window" || userInput == "go back to the window" || userInput == "to window" || userInput == "to the window")
                        {
                            NorthWindow();
                        }
                        else if (userInput == "bedroom" || userInput == "the bedroom" || userInput == "go back to bedroom" || userInput == "go back to the bedroom" || userInput == "to bedroom" || userInput == "to the bedroom")
                        {
                            BedRoom();
                        }
                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
            }
        }
        public void SecurityRoom()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            if (enemy2.enemyHp > 0)
            {
                enemy2.Tino(i, p);
            }
            if (i.gun == 0) // Als de variabel gun uit i (Items class) gelijk is aan 0 dan...
            {
                i.Gun(); // ... Wordt de Method Gun uit i (Items class) opgeroepen
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Security Room \nThere is a door in front of you, to the right of you and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    MainHall();
                }
                else if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    Stairs();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    StorageRoom();
                }
                else if (userInput == "go back to storage room" || userInput == "go back to the storage room")
                {
                    StorageRoom();
                }
                else if (userInput == "go back to stairs" || userInput == "go back to the stairs")
                {
                    Stairs();
                }
                else if (userInput == "go back to main hall" || userInput == "go back to the main hall")
                {
                    MainHall();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "storage room" || userInput == "the storage room" || userInput == "go back to storage room" || userInput == "go back to the storage room" || userInput == "to storage room" || userInput == "to the storage room")
                    {
                        StorageRoom();
                    }
                    else if (userInput == "stairs" || userInput == "the stairs" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "to stairs" || userInput == "to the stairs")
                    {
                        SecurityRoom();
                    }
                    else if (userInput == "main hall" || userInput == "the main hall" || userInput == "go back to main hall" || userInput == "go back to the main hall" || userInput == "to main hall" || userInput == "to the main hall")
                    {
                        MainHall();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void BedRoom()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            if (enemy3.enemyHp > 0)
            {
                enemy3.Tino(i, p);
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Bedroom \nThere is a door in front of you, to the right of you and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    BathRoom();
                }
                else if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    Hall();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    LivingRoom();
                }
                else if (userInput == "go back to bathroom" || userInput == "go back to the bathroom")
                {
                    BathRoom();
                }
                else if (userInput == "go back to hall" || userInput == "go back to the hall")
                {
                    Hall();
                }
                else if (userInput == "go back to living room" || userInput == "go back to the living room")
                {
                    LivingRoom();
                }
                else if (userInput == "go back to bathroom" || userInput == "go back to the bathroom")
                {
                    BathRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "bathroom" || userInput == "the bathroom" || userInput == "go back to bathroom" || userInput == "go back to the bathroom" || userInput == "to bathroom" || userInput == "to the bathroom")
                    {
                        BathRoom();
                    }
                    else if (userInput == "hall" || userInput == "the hall" || userInput == "go back to hall" || userInput == "go back to the hall" || userInput == "to hall" || userInput == "to the hall")
                    {
                        Hall();
                    }
                    else if (userInput == "living room" || userInput == "the living room" || userInput == "go back to living room" || userInput == "go back to the living room" || userInput == "to living room" || userInput == "to the living room")
                    {
                        LivingRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void Hall()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Hall \nThere is a door to the right, to the left and behind of you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    DanceFloor();
                }
                else if (userInput == "open the door to the left" || userInput == "open door to the left" || userInput == "open the door to the left of me" || userInput == "open the door left of me" || userInput == "open the door on the left" || userInput == "open the left door" || userInput == "open left door" || userInput == "go in the left door" || userInput == "go in left door" || userInput == "go left" || userInput == "open door left")
                {
                    BedRoom();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind")
                {
                    MainHall();
                }
                else if (userInput == "go back to main hall" || userInput == "go back to the main hall")
                {
                    MainHall();
                }
                else if (userInput == "go back to bedroom" || userInput == "go back to bedroom")
                {
                    BedRoom();
                }
                else if (userInput == "go back to dance floor" || userInput == "go back to the dance floor")
                {
                    DanceFloor();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "main hall" || userInput == "the main hall" || userInput == "go back to main hall" || userInput == "go back to the main hall" || userInput == "to main hall" || userInput == "to the main hall")
                    {
                        MainHall();
                    }
                    else if (userInput == "bedroom" || userInput == "the bedroom" || userInput == "go back to bedroom" || userInput == "go back to the bedroom" || userInput == "to bedroom" || userInput == "to the bedroom")
                    {
                        BedRoom();
                    }
                    else if (userInput == "dance floor" || userInput == "the dance floor" || userInput == "go back to dance floor" || userInput == "go back to the dance floor" || userInput == "to dance floor" || userInput == "to the dance floor")
                    {
                        DanceFloor();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void DanceFloor()
        {
            SoundPlayer sound = new SoundPlayer("Dance Floor.wav");
            sound.Play();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            if (enemy10.miniHp > 0) // Als de variabel miniHp uit enemy10 (Enemy class) groter is dan 0 dan...
            {
                enemy10.MiniBoss(i, p, "Killa", 20); // ... Wordt de Method MiniBoss uit enemy10 (Enemy class) opgeroepen met de arguments i (Items class), p (Player class), "Killa" en 20
            }
            while (userInput != null)
            {
                Random rd = new Random();
                int color = rd.Next(1, 6);
                if (color == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else if (color == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else if (color == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (color == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else if (color == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                Console.WriteLine();
                Console.WriteLine("You're in the Dance Floor \nThere is a door \nAnd there are lights you can change by pressing any button");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    sound.Stop();
                    Hall();
                }
                else if (userInput == "go back" || userInput == "go back to hall" || userInput == "go back to the hall")
                {
                    sound.Stop();
                    Hall();
                }
                else
                {
                    continue;
                }
            }
        }
        public void LivingRoom()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            if (enemy9.miniHp > 0)
            {
                enemy9.MiniBoss(i, p, "Vincent", 20);
                p.quest = 1;
            }
            i.ListAllWeapons();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Living Room \nThere is a door");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    BedRoom();
                }
                else if (userInput == "go back" || userInput == "go back to bedroom" || userInput == "go back to the bedroom")
                {
                    BedRoom();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void Stairs()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the Stairs of the Ground Floor \nThere is a door and there are stairs you can take to the first floor");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    SecurityRoom();
                }
                else if (userInput == "take stairs" || userInput == "take the stairs" || userInput == "walk up stairs" || userInput == "walk up the stairs" || userInput == "go up stairs" || userInput == "go up the stairs" || userInput == "go up") // Als de userInput zegt om op de trap te lopen dan...
                {
                    StairsFF(); // ... Wordt de Method StairsFF opgeroepen
                }
                else if (userInput == "go back" || userInput == "go back to security room" || userInput == "go back to the security room")
                {
                    SecurityRoom();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void StairsFF()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the Stairs of the First Floor \nThere is a door and there are stairs you can take to the ground floor");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    Office();
                }
                else if (userInput == "take stairs" || userInput == "take the stairs" || userInput == "walk down stairs" || userInput == "walk down the stairs" || userInput == "go down stairs" || userInput == "go down the stairs" || userInput == "go down")
                {
                    Stairs();
                }
                else if (userInput == "go back" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "go back to ground floor" || userInput == "go back to the ground floor")
                {
                    Stairs();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void Office()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            if (enemy4.enemyHp > 0)
            {
                enemy4.Tino(i, p);
            }
            if (i.pencil == 0) // Als de variabel pencil uit i (Items class) gelijk is aan 0 dan...
            {
                i.Pencil(); // ... Wordt de Method Pencil uit i (Items class) opgeroepen
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Office \nThere is a door to the left, to the right and in front of you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door to the left" || userInput == "open door to the left" || userInput == "open the door to the left of me" || userInput == "open the door left of me" || userInput == "open the door on the left" || userInput == "open the left door" || userInput == "open left door" || userInput == "go in the left door" || userInput == "go in left door" || userInput == "go left" || userInput == "open door left")
                {
                    SamuraiRoom();
                }
                else if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    StairsFF();
                }
                else if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    Bar();
                }
                else if (userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "go back to stairs of the first floor" || userInput == "go back to the stairs of the first floor")
                {
                    StairsFF();
                }
                else if (userInput == "go back to bar" || userInput == "go back to the bar")
                {
                    Bar();
                }
                else if (userInput == "go back to samurai room" || userInput == "go back to the samurai room")
                {
                    SamuraiRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "stairs" || userInput == "the stairs" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "to stairs" || userInput == "to the stairs")
                    {
                        StairsFF();
                    }
                    else if (userInput == "bar" || userInput == "the bar" || userInput == "go back to bar" || userInput == "go back to the bar" || userInput == "to bar" || userInput == "to the bar")
                    {
                        Bar();
                    }
                    else if (userInput == "samurai room" || userInput == "the samurai room" || userInput == "go back to samurai room" || userInput == "go back to the samurai room" || userInput == "to samurai" || userInput == "to the samurai room")
                    {
                        SamuraiRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void SamuraiRoom()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            if (i.knife == 0) // Als de variabel knife uit i (Items class) gelijk is aan 0 dan...
            {
                i.Knife(); // ... Wordt de Method Knife opgeroepen uit i (Items class)
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Samurai Room \nThere is a door");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    Office();
                }
                else if (userInput == "go back" || userInput == "go back to office" || userInput == "go back to the office")
                {
                    Office();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void Bar()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            if (enemy5.enemyHp > 0)
            {
                enemy5.Tino(i, p);
            }
            i.Safe(); // De Method Safe uit i (Items class) wordt opgeroepen
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Bar \nThere is a door in front of you, to the right of you and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    TrainingRoom();
                }
                else if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    TinoGuardRoom();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    Office();
                }
                else if (userInput == "go back to office" || userInput == "go back to the office")
                {
                    Office();
                }
                else if (userInput == "go back to tino guards room" || userInput == "go back to the tino guards room")
                {
                    TinoGuardRoom();
                }
                else if (userInput == "go back to training room" || userInput == "go back to the training room")
                {
                    TrainingRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "office" || userInput == "the office" || userInput == "go back to office" || userInput == "go back to the office" || userInput == "to office" || userInput == "to the office")
                    {
                        Office();
                    }
                    else if (userInput == "tino guards room" || userInput == "the tino guards room" || userInput == "go back to tino guards room" || userInput == "go back to the tino guards room" || userInput == "to tino guards room" || userInput == "to the tino guards room")
                    {
                        TinoGuardRoom();
                    }
                    else if (userInput == "training room" || userInput == "the training room" || userInput == "go back to training room" || userInput == "go back to the training room" || userInput == "to training room" || userInput == "to the training room")
                    {
                        TrainingRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void TinoGuardRoom()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            if (enemy6.enemyHp > 0)
            {
                enemy6.Tino(i, p);
            }
            if (i.suppressor == 0) // Als de variabel suppressor uit i (Items class) gelijk is aan 0 dan...
            {
                i.Suppressor(); // ... Wordt de Method Suppressor uit i (Items class) opgeroepen
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Tino Guard Room \nThere is a door");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    Bar();
                }
                else if (userInput == "go back" || userInput == "go back to bar" || userInput == "go back to the bar")
                {
                    Bar();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void TrainingRoom()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            if (enemy11.miniHp > 0)
            {
                enemy11.MiniBoss(i, p, "Caine", 20);
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Training room \nThere is a door left and behind of you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door to the left" || userInput == "open door to the left" || userInput == "open the door to the left of me" || userInput == "open the door left of me" || userInput == "open the door on the left" || userInput == "open the left door" || userInput == "open left door" || userInput == "go in the left door" || userInput == "go in left door" || userInput == "go left" || userInput == "open door left")
                {
                    StairsFS();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    Bar();
                }
                else if (userInput == "go back to bar" || userInput == "go back to the bar")
                {
                    Bar();
                }
                else if (userInput == "go back to stairs" || userInput == "go back to the stairs")
                {
                    StairsFS();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "bar" || userInput == "the bar" || userInput == "go back to bar" || userInput == "go back to the bar" || userInput == "to bar" || userInput == "to the bar")
                    {
                        Bar();
                    }
                    else if (userInput == "stairs" || userInput == "the stairs" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "to stairs" || userInput == "to the stairs")
                    {
                        StairsFS();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void StairsFS()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the Stairs of the First Floor \nThere is a door and there are stairs you can take to the second floor");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    TrainingRoom();
                }
                else if (userInput == "take stairs" || userInput == "take the stairs" || userInput == "walk up stairs" || userInput == "walk up the stairs" || userInput == "go up stairs" || userInput == "go up the stairs" || userInput == "go up")
                {
                    StairsSF();
                }
                else if (userInput == "go back" || userInput == "go back to training room" || userInput == "go back to the training room")
                {
                    TrainingRoom();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void StairsSF()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're at the Stairs of the Second floor \nThere is a door and there are stairs you can take to the first floor");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    ArtRoom();
                }
                else if (userInput == "take stairs" || userInput == "take the stairs" || userInput == "walk down stairs" || userInput == "walk down the stairs" || userInput == "go down stairs" || userInput == "go down the stairs" || userInput == "go down")
                {
                    StairsFS();
                }
                else if (userInput == "go back" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "go back to first floor" || userInput == "go back to the first floor")
                {
                    StairsFS();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void ArtRoom()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();
            if (enemy7.enemyHp > 0)
            {
                enemy7.Tino(i, p);
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Art Room \nThere is a door to the left, to the right and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door to the left" || userInput == "open door to the left" || userInput == "open the door to the left of me" || userInput == "open the door left of me" || userInput == "open the door on the left" || userInput == "open the left door" || userInput == "open left door" || userInput == "go in the left door" || userInput == "go in left door" || userInput == "go left" || userInput == "open door left")
                {
                    StairsSF();
                }
                else if (userInput == "open the door to the right" || userInput == "open door to the right" || userInput == "open the door to the right of me" || userInput == "open the door right of me" || userInput == "open the door on the right" || userInput == "open the right door" || userInput == "open right door" || userInput == "go in the right door" || userInput == "go in right door" || userInput == "go right" || userInput == "open door right")
                {
                    ChillRoom();
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    AmmoRoom();
                }
                else if (userInput == "go back to stairs" || userInput == "go back to the stairs")
                {
                    StairsSF();
                }
                else if (userInput == "go back to ammo room" || userInput == "go back to the ammo room")
                {
                    AmmoRoom();
                }
                else if (userInput == "go back to chill room" || userInput == "go back to the chill room")
                {
                    ChillRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "stairs" || userInput == "the stairs" || userInput == "go back to stairs" || userInput == "go back to the stairs" || userInput == "to stairs" || userInput == "to the stairs")
                    {
                        StairsSF();
                    }
                    else if (userInput == "ammo room" || userInput == "the ammo room" || userInput == "go back to ammo room" || userInput == "go back to the ammo room" || userInput == "to ammo room" || userInput == "to the ammo room")
                    {
                        AmmoRoom();
                    }
                    else if (userInput == "chill room" || userInput == "the chill room" || userInput == "go back to chill room" || userInput == "go back to the chill room" || userInput == "to chill room" || userInput == "to the chill room")
                    {
                        ChillRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void AmmoRoom()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            if (i.gunMag < 7) // Als de variabel gunMag uit i (Items class) kleiner is dan 7 dan...
            {
                i.Ammo(); // ... Wordt de Method Ammo uit i (Items class) opgeroepen
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Ammo Room \nThere is a door");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open door" || userInput == "open the door" || userInput == "go in door" || userInput == "go in the door")
                {
                    ArtRoom();
                }
                else if (userInput == "go back" || userInput == "go back to art room" || userInput == "go back to the art room")
                {
                    ArtRoom();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void ChillRoom()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            if (enemy8.enemyHp > 0)
            {
                enemy8.Tino(i, p);
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Chill Room \nThere is a door in front and left of you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    ArtRoom();
                }
                else if (userInput == "open the door to the left" || userInput == "open door to the left" || userInput == "open the door to the left of me" || userInput == "open the door left of me" || userInput == "open the door on the left" || userInput == "open the left door" || userInput == "open left door" || userInput == "go in the left door" || userInput == "go in left door" || userInput == "go left" || userInput == "open door left")
                {
                    PersonalBodyguardRoom();
                }
                else if (userInput == "go back to art room" || userInput == "go back to the art room")
                {
                    ArtRoom();
                }
                else if (userInput == "go back to personal bodyguard room" || userInput == "go back to the personal bodyguard room")
                {
                    PersonalBodyguardRoom();
                }
                else if (userInput == "go back")
                {
                    Console.WriteLine("Go back where?");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "art room" || userInput == "the art room" || userInput == "go back to art room" || userInput == "go back to the art room" || userInput == "to art room" || userInput == "to the art room")
                    {
                        ArtRoom();
                    }
                    else if (userInput == "personal bodyguard room" || userInput == "the personal bodyguard room" || userInput == "go back to personal bodyguard room" || userInput == "go back to the personal bodyguard room" || userInput == "to personal bodyguard room" || userInput == "to the personal bodyguard room")
                    {
                        PersonalBodyguardRoom();
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void PersonalBodyguardRoom()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            if (enemy12.miniHp > 0)
            {
                enemy12.MiniBoss(i, p, "Cassian", 25);
            }
            while (userInput != null)
            {
                Console.WriteLine();
                Console.WriteLine("You're in the Personal Bodyguard Room \nThere is a door in front of you and behind you");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "open the door in front" || userInput == "open the door in front of me" || userInput == "get in the door in front of me" || userInput == "open door in front of me" || userInput == "open the door in front" || userInput == "open door in front" || userInput == "go in door in front" || userInput == "go in the door in front" || userInput == "go in door in front of me" || userInput == "go in the door in front of me")
                {
                    i.Keypad(); // De Method Keypad uit i (Items class) wordt opgeroepen
                    if (i.userNum == i.code) // Als de variabel userNum uit i gelijk is aan de variabel code uit i dan...
                    {
                        Console.WriteLine("You entered the right code! \nPress any key to enter");
                        Console.ReadKey();
                        ViscachaSantinoRoom();
                    }
                    else
                    {
                        Console.WriteLine("The code is wrong");
                        continue;
                    }
                }
                else if (userInput == "open the door behind me" || userInput == "open door behind me" || userInput == "open door behind" || userInput == "open the door behind" || userInput == "go in door behind" || userInput == "go in door behind me" || userInput == "go in the door behind" || userInput == "go in the door behind me" || userInput == "go behind")
                {
                    ChillRoom();
                }
                else if (userInput == "go back" || userInput == "go back to chill room" || userInput == "go back to the chill room")
                {
                    ChillRoom();
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
            }
        }
        public void ViscachaSantinoRoom()
        {
            SoundPlayer sound = new SoundPlayer("Boss Fight.wav");
            sound.Play();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            string viscacha = File.ReadAllText("Viscacha.txt"); // Er wordt een string aangemaakt genaamd viscacha die de waarde krijgt van de File Viscacha.txt
            Console.WriteLine(viscacha); // De tekst van de File wordt op de console geprint
            Console.WriteLine("It's Viscacha Santino!");
            Console.ReadKey();
            Console.Clear();
            enemy13.MiniBoss(i, p, "Viscacha Santino", 40);
            sound.Stop();
            Outro();
        }

        public void Outro()
        {
            Console.Clear();
            SoundPlayer sound = new SoundPlayer("Outro.wav"); // Er wordt een SounPlayer aangemaakt met de naam sound en krijgt de waarde van het muziek van de Outro.wav
            sound.Play(); // De variabel sound speelt af
            string jardani = File.ReadAllText("Jardani.txt");
            Console.WriteLine(jardani);
            Console.WriteLine("Congrats! \nYou succesfully eliminated Viscacha Santino!");
            Console.WriteLine("Credits: \nMade by: Simon Boersma \nIntro music: Story Of Wick \nCar (intel) music: The Judge \nDance Floor music: Blood Code \nSantino Boss Fight music: The Ex Ex Chapter 3 \nOutro music: Warehouse Smackdown \nMusic by: Tyler Bates, Joel Richard, Le Castle Vania and Ketsueki Sakuru");
            Console.ReadKey();
            sound.Stop(); // De variabel sound stopt met afspelen
            e.GameOver(); // De Method GameOver uit e (Enemy class) wordt opgeroepen
        }
    }
}
