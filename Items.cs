
namespace J1P2_PRO_Prototype3_simon_boersma
{
    internal class Items
    {
        string userIn = ""; // Er wordt een string aangemaakt met de naam userIn en krijgt de waarde ""
        char userInter; // Er wordt een char aangemaakt met de naam userInter
        public int userNum = 0; // Er wordt een int aangemaakt met de naam userNum en krijgt de waarde 0. De variabel is public
        public int gun = 0; // Er wordt een int aangemaakt met de naam gun en krijgt de waarde 0. De variabel is public
        public int baseBat = 0; // Er wordt een int aangemaakt met de naam baseBat en krijgt de waarde 0. De variabel is public
        public int knife = 0; // Er wordt een int aangemaakt met de naam knife en krijgt de waarde 0. De variabel is public
        public int gunMag = 7; // Er wordt een int aangemaakt met de naam gunMag en krijgt de waarde 7. De variabel is public
        public int suppressor = 0; // Er wordt een int aangemaakt met de naam suppressor en krijgt de waarde 0. De variabel is public
        public int pencil = 0; // Er wordt een int aangemaakt met de naam pencil en krijgt de waarde 0. De variabel is public
        public int code; // Er wordt een int aangemaakt met de naam code. De variabel is public

        internal Items() // Er wordt een contructor aangemaakt
        {
            Random rd = new Random(); // Er wordt een random generator aangemaakt met de naam rd
            code = rd.Next(1000, 9999); // de variabel krijgt een random waarde van tussen de 1000 en 9999
        }
        public void Gun() // Er wordt een Method aangemaakt met de naam Gun. De Method is public
        {
            while (userInter != null)
            {
                Console.WriteLine("There is a gun in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter) // Er wordt een switch aangemaakt dat de variabel userInter bijhoudt
                {
                    case 'i': // Als userInter 'i' is dan...
                        gun++; // De variabel gun wordt plus 1 gedaan
                        Console.WriteLine("You picked up a Gun"); // Wordt er tekst op de console geprint
                        break; // De code breekt uit de switch (en gaat verder met andere code)
                    case 'w': // Alse userInter 'w' is dan...
                        break; // breekt de code uit de switch (en gaat verder met andere code)
                    default: // Als userInter NIET 'i' of 'w' is dan...
                        Console.WriteLine("Input is wrong"); // Wordt er tekst op de console geprint
                        continue; // De code begint weer bij het begin van de while loop
                }
                break;
            }
        }
        public void BaseBallBat()
        {
            while (userInter != null)
            {
                Console.WriteLine("There is a baseballbat in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter)
                {
                    case 'i':
                        baseBat++;
                        Console.WriteLine("You picked up a Baseballbat");
                        break;
                    case 'w':
                        break;
                    default:
                        Console.WriteLine("Input is wrong");
                        continue;
                }
                break;
            }
        }
        public void Knife()
        {
            while (userInter != null)
            {
                Console.WriteLine("There is a knife in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter)
                {
                    case 'i':
                        knife++;
                        Console.WriteLine("You picked up a Knife");
                        break;
                    case 'w':
                        break;
                    default:
                        Console.WriteLine("Input is wrong");
                        continue;
                }
                break;
            }
        }
        public void ListAllWeapons()
        {
            while (userInter != null)
            {
                List<string> list = new List<string>() { "Gun", "Baseballbat", "Knife" }; // Er wordt een string List aangemaakt met de naam list en krijgt de waarde "Gun", "Baseballbat", "Knife"
                Console.WriteLine("There is a list of all weapons from the house! \nPress 'i' to take a look at the list \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter)
                {
                    case 'i':
                        Console.WriteLine();
                        foreach (string i in list) // Er wordt een string aangemaakt met de naam i die alle items pakt uit de list
                        {
                            Console.WriteLine(i); // De variabel i wordt op de console geprint
                        }
                        break;
                    case 'w':
                        break;
                    default:
                        Console.WriteLine("Input is wrong");
                        continue;
                }
                break;
            }
        }
        public void Safe()
        {
            while (userIn != null)
            {
                Console.WriteLine();
                Console.WriteLine("There is a safe in the room!");
                userIn = Console.ReadLine().ToLower();
                if (userIn == "open safe" || userIn == "open the safe" || userIn == "look in safe" || userIn == "look in the safe" || userIn == "open")
                {
                    Console.WriteLine();
                    Console.WriteLine("There is a code in the safe!");
                    Console.WriteLine();
                    Console.WriteLine(code);
                }
                else if (userIn == "walk away" || userIn == "walk away from safe" || userIn == "walk away from the safe" || userIn == "go away" || userIn == "go away from safe" || userIn == "go away from the safe" || userIn == "walk past" || userIn == "walk past safe" || userIn == "walk past the safe")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                break;
            }
        }
        public void Suppressor()
        {
            while (userInter != null)
            {
                Console.WriteLine("There is a suppressor in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter)
                {
                    case 'i':
                        suppressor++;
                        Console.WriteLine("You picked up a Suppressor");
                        break;
                    case 'w':
                        break;
                    default:
                        Console.WriteLine("Input is wrong");
                        continue;
                }
                break;
            }
        }
        public void Ammo()
        {
            while (userInter != null)
            {
                Console.WriteLine("There is ammo in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                try
                {
                    userInter = Char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    continue;
                }
                switch (userInter)
                {
                    case 'i':
                        gunMag = 7;
                        Console.WriteLine("You picked up Ammo");
                        Console.WriteLine($"Pistol mag: {gunMag}");
                        break;
                    case 'w':
                        break;
                    default:
                        Console.WriteLine("Input is wrong");
                        continue;
                }
                break;
            }
        }
        public void Keypad()
        {
            int i = 1; // Er wordt een int aangemaakt met de naam i en krijgt de waarde 1
            char[,] pad = new char[3, 3]; // Er wordt een multi-dimensional array aangemaakt met de naam pad en krijgt de waarde 3 (lengte), 3 (breedte)
            while (userNum != null)
            {
                Console.WriteLine();
                for (int x = 0; x < pad.GetLength(0); x++) // Er wordt een for loop aangemaakt die doorgaat totdat de variabel x kleiner is dan de lengte van de array pad
                {
                    for (int y = 0; y < pad.GetLength(1); y++) // Er wordt een for loop aangemaakt die doorgaat totdat de variabel y kleiner is dan de lengte van de array pad
                    {
                        Console.Write(i++); // De variabel wordt plus 1 gedaan en wordt geprint op de console
                        if (y < pad.GetLength(1) - 1) // Als de variabel y kleiner is dan de lengte van de array y (tweede vak) min 1 dan...
                        {
                            Console.Write("|");
                        }
                    }
                    Console.WriteLine();

                    if (x < pad.GetLength(0) - 1) // Als de variabel x kleiner is de de lengte van de array x (eerste vak) min 1 dan...
                    {
                        Console.WriteLine("-----");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("There is a keypad next to the door \nEnter a code");
                try
                {
                    userNum = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input is wrong");
                    break;
                }

                break;
            }
        }
        public void Pencil()
        {
            Random rd = new Random();
            int random = rd.Next(0, 10);
            if (random == 1)
            {
                while (userInter != null)
                {
                    Console.WriteLine("There is a pencil in the room! \nPress 'i' to pick it up \nPress 'w' to walk past");
                    try
                    {
                        userInter = Char.Parse(Console.ReadLine().ToLower());
                    }
                    catch
                    {
                        Console.WriteLine("Input is wrong");
                        continue;
                    }
                    switch (userInter)
                    {
                        case 'i':
                            pencil++;
                            Console.WriteLine("You picked up a Pencil");
                            break;
                        case 'w':
                            break;
                        default:
                            Console.WriteLine("Input is wrong");
                            continue;
                    }
                    break;
                }
            }
        }
    }
}
