
namespace J1P2_PRO_Prototype3_simon_boersma
{
    internal class Enemy
    {
        char userAt; // Er wordt een char aangemaakt met de naam userAt
        public int enemyHp = 10; // Er wordt een int aangemaakt met de naam enemyHp en krijgt de waarde 10. De variabel is public
        public int miniHp = 20; // Er wordt een int aangemaakt met de naam miniHp en krijgt de waarde 20. De variabel is public
        string userReplay = ""; // Er wordt een string gemaakt met de naam userReplay en krijgt de waarde ""
        public void Tino(Items i, Player p) // De Method Tino wordt aangemaakt met de parameters Items class met de naam i en Player class met de naam p. De Method is public
        {
            while (p.userHp > 0 || enemyHp > 0) // Run de code tussen de scope zolang de variabel uir p groter is dan 0 OF de variabel enemyHp groter is 0
            {
                string userChoice;
                Console.WriteLine($"Player HP: {p.userHp}"); // Er wordt tekst met een variabel (door de $) op de console geprint
                Console.WriteLine($"Enemy HP: {enemyHp}");
                Console.WriteLine("There is a Tino in the room!");

                if (p.seeAble == false) // Als de variabel seeAble uit p false is dan...
                {
                    Console.WriteLine();
                    Console.WriteLine("The Tino bodyguard doesn't see you \nHow do you want to attack:");

                    Console.WriteLine("1. Attack with hands");
                    if (i.gun == 1) // Als de variabel gun uit i gelijk is aan 1 dan...
                    {
                        Console.WriteLine("2. Shoot with gun");
                    }
                    if (i.baseBat == 1)
                    {
                        Console.WriteLine("3. Attack with baseballbat");
                    }
                    if (i.knife == 1)
                    {
                        Console.WriteLine("4. Attack with knife");
                    }
                    if (i.pencil == 1)
                    {
                        Console.WriteLine("5. Attack with pencil");
                    }

                    userChoice = Console.ReadLine().ToLower(); // De input van de user wordt opgeslagen in de variabel userChoice en wordt omgezet naar kleine letters

                    if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.") // Als de userChoice zegt om te schieten dan...
                    {
                        if (i.gun != 1) // Als de variabel gun uit i niet gelijk is aan 1 dan...
                        {
                            Console.WriteLine("You don't have a weapon");
                            Console.WriteLine();
                            continue; // ... Begint de code weer bij de while loop
                        }
                        if (i.gunMag <= 0) // Als de variabel gunMag kleiner is of gelijk is aan 0 dan...
                        {
                            Console.WriteLine("you dont have bullets");
                            Console.WriteLine();
                            continue;
                        }
                        if (i.suppressor == 0) // Als de variabel suppressor gelijk is aan 0 dan...
                        {
                            p.seeAble = true; // ... Wordt de variabel seeAble uit p true
                        }
                        if (i.suppressor == 1) // ... Als de variabel suppressor uit i gelijk is aan 1 dan...
                        {
                            p.seeAble = false; // ... Wordt de variabel seeAble uit p false
                        }
                        i.gunMag--; // De variabel gunMag uit i krijgt min 1
                        enemyHp -= 10; // De variabel enemyHp krijgt min 10
                        Console.WriteLine($"Enemy HP: {enemyHp}");
                        Console.WriteLine($"Pistol mag:{i.gunMag}");
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine("You killed a Tino bodyguard");
                        }
                        break; // De die runt gaat uit de while loop (en gaat dus verder)
                    }
                    else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                    {
                        if (i.baseBat != 1)
                        {
                            Console.WriteLine("You don't have a bat");
                            Console.WriteLine();
                            continue;
                        }
                        p.seeAble = false;
                        enemyHp -= 5;

                        Console.WriteLine($"Enemy HP: {enemyHp}");
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("You killed a Tino bodyguard");

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You knocked out a Tino bodyguard");
                        }
                        break;
                    }
                    else if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.")
                    {
                        p.seeAble = false;
                        enemyHp -= 2;

                        Console.WriteLine($"Enemy HP: {enemyHp}");
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine("You killed a Tino bodyguard");

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You knocked out a Tino bodyguard");
                        }
                        break;
                    }
                    else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                    {
                        if (i.knife != 1)
                        {
                            Console.WriteLine("You don't have a knife");
                            Console.WriteLine();
                            continue;
                        }
                        p.seeAble = false;
                        enemyHp -= 8;

                        Console.WriteLine($"Enemy HP: {enemyHp}");
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine("You killed a Tino bodyguard");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You knocked out a Tino bodyguard");
                        }
                        break;
                    }
                    else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                    {
                        if (i.pencil != 1)
                        {
                            Console.WriteLine("You don't have a pencil");
                            Console.WriteLine();
                            continue;
                        }
                        p.seeAble = false;
                        enemyHp -= 10;

                        Console.WriteLine($"Enemy HP: {enemyHp}");
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine("You killed a Tino bodyguard with a pencil!?");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Input is wrong");
                    }
                }
                else if (p.seeAble == true) // Anders Als de variabel uit p seeAble true is dan...
                {
                    Console.WriteLine("There is a Tino bodyguard in the room \nHe sees you! \nYou will have to fight");
                    while (p.userHp > 0 || enemyHp > 0)
                    {
                        Console.WriteLine("Press 'j' to left jab \nPress 'k' to right jab \nPress 'n' to left kick \nPress 'm' to right kick");
                        Random rd = new Random(); // Er wordt een random generator aangemaakt met de naam rd
                        int enemyAt = rd.Next(1, 5); // Er wordt een int aangemaakt met de naam enemyAt en krijgt de waarde van rd (getal tussen de 1 en 5)
                        try // In de scope staat de code die een error kan veroorzaken
                        {
                            userAt = char.Parse(Console.ReadLine());
                        }
                        catch // Als de error komt dan runt de code in deze scope
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        if (userAt == 'j' && enemyAt == 1) // Als de userAt 'j' is EN enemyAt gelijk is aan 1 dan...
                        {
                            Console.WriteLine();
                            Console.WriteLine("The Tino blocked your attack!");
                            p.userHp -= 2; // De variabel userHp uit p krigt min 2
                            if (p.PlayerCheck() == true) // Als de Method PlayerCheck uit p true is dan...
                            {
                                GameOver(); // ... Wordt de Method GameOver wordt opgeroepen
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'k' && enemyAt == 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("The Tino blocked your attack!");
                            p.userHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'n' && enemyAt == 3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("The Tino blocked your attack!");
                            p.userHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'm' && enemyAt == 4)
                        {
                            Console.WriteLine();
                            Console.WriteLine("The Tino blocked your attack!");
                            p.userHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'j') // Anders Als userAt 'j' is dan...
                        {
                            Console.WriteLine();
                            Console.WriteLine("You attacked the Tino succesfully!");
                            enemyHp -= 2; // De variabel enemyHp krijgt min 2
                            if (p.PlayerCheck() == true) // Als ded Method PlayerCheck uit p true is dan...
                            {
                                GameOver(); // ... Wordt de Method GameOver opgeroepen
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'k')
                        {
                            Console.WriteLine();
                            Console.WriteLine("You attacked the Tino succesfully!");
                            enemyHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'n')
                        {
                            Console.WriteLine();
                            Console.WriteLine("You attacked the Tino succesfully!");
                            enemyHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else if (userAt == 'm')
                        {
                            Console.WriteLine();
                            Console.WriteLine("You attacked the Tino succesfully!");
                            enemyHp -= 2;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine($"Player HP: {p.userHp}");
                            Console.WriteLine($"Enemy HP: {enemyHp}");
                        }
                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        if (enemyHp <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("You killed a Tino bodyguard!");
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public void MiniBoss(Items i, Player p, string pName, int pMiniHp) // Er wordt een Method MiniBoss aangemaakt met de parameters Items class met de naam i, Player class met de naam p, string met de naam pName en int met de naam pMiniHp. De Method is public
        {
            miniHp = pMiniHp; // miniHp is gelijk aan pMiniHp

            while (p.userHp > 0 || miniHp > 0)
            {
                Random rd = new Random();
                int randChoice = rd.Next(1, 6);
                string userChoice;
                Console.WriteLine();

                if (randChoice == 1) // Als de variabel randChoice 1 is dan...
                {
                    while (p.userHp > 0 || miniHp > 0)
                    {
                        Console.WriteLine($"{pName} is in the room \nHe is not holding any weapon \nHow do you want to attack?");
                        Console.WriteLine("1. Attack with hands");
                        if (i.gun == 1)
                        {
                            Console.WriteLine("2. Shoot with gun");
                        }
                        if (i.baseBat == 1)
                        {
                            Console.WriteLine("3. Attack with baseballbat");
                        }
                        if (i.knife == 1)
                        {
                            Console.WriteLine("4. Attack with knife");
                        }
                        if (i.pencil == 1)
                        {
                            Console.WriteLine("5. Attack with pencil");
                        }
                        userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.") // Als de userChoice zegt dat je moet attacken met de hands dan...
                        {
                            miniHp -= 0; // ... Wordt de variabel miniHp min 0 gedaan
                            p.userHp -= 2; // En wordt de variabel userHp uit p min 2 gedaan
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe blocked you're attack so think wisely how to attack");
                        }

                        else if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.")
                        {
                            if (i.gun != 1)
                            {
                                Console.WriteLine("You don't have a weapon");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.gunMag <= 0)
                            {
                                Console.WriteLine("you dont have bullets");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.suppressor == 0)
                            {
                                p.seeAble = true;
                            }

                            i.gunMag -= 1;
                            Console.WriteLine($"Pistol mag: {i.gunMag}");
                            miniHp -= 8;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                        {
                            if (i.baseBat != 1)
                            {
                                Console.WriteLine("You don't have a bat");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 3;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                        {
                            if (i.knife != 1)
                            {
                                Console.WriteLine("You don't have a knife");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 5;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                        {
                            if (i.pencil != 1)
                            {
                                Console.WriteLine("You don't have a pencil");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 7;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName} with a pencil?!");
                        }

                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }

                        break;
                    }

                    if (miniHp > 0)
                    {
                        while (p.userHp > 0 || miniHp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{pName} is going to attack with his hands \nHow do you want to block?");
                            Console.WriteLine("1. Block with hands");
                            if (i.gun == 1)
                            {
                                Console.WriteLine("2. Block with gun");
                            }
                            if (i.baseBat == 1)
                            {
                                Console.WriteLine("3. Block with baseballbat");
                            }
                            if (i.knife == 1)
                            {
                                Console.WriteLine("4. Block with knife");
                            }
                            if (i.pencil == 1)
                            {
                                Console.WriteLine("5. Block with pencil");
                            }
                            userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "block with hands" || userChoice == "with hands" || userChoice == "1" || userChoice == "1.")
                            {
                                miniHp -= 2;
                                p.userHp -= 0;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} coudn't attack \nWell done!");
                            }

                            else if (userChoice == "block with gun" || userChoice == "with gun" || userChoice == "2" || userChoice == "2.")
                            {
                                if (i.gun != 1)
                                {
                                    Console.WriteLine("You don't have a weapon");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 2;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe attacks with hands so think wisely how to block");
                            }

                            else if (userChoice == "block with baseballbat" || userChoice == "with baseballbat" || userChoice == "3" || userChoice == "3.")
                            {
                                if (i.baseBat != 1)
                                {
                                    Console.WriteLine("You don't have a bat");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 4;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with knife" || userChoice == "with knife" || userChoice == "4" || userChoice == "4.")
                            {
                                if (i.knife != 1)
                                {
                                    Console.WriteLine("You don't have a knife");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 7;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with pencil" || userChoice == "with pencil" || userChoice == "5" || userChoice == "5.")
                            {
                                if (i.pencil != 1)
                                {
                                    Console.WriteLine("You don't have a pencil");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 2;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe attacks with his hands so think wisely how to block");
                            }
                            else
                            {
                                Console.WriteLine("Input is wrong");
                                continue;
                            }
                            
                            break;
                        }
                    }
                }

                if (randChoice == 2)
                {
                    while (p.userHp > 0 || miniHp > 0)
                    {
                        Console.WriteLine($"{pName} is in the room \nHe has an axe \nHow do you want to attack?");
                        Console.WriteLine("1. Attack with hands");
                        if (i.gun == 1)
                        {
                            Console.WriteLine("2. Shoot with gun");
                        }
                        if (i.baseBat == 1)
                        {
                            Console.WriteLine("3. Attack with baseballbat");
                        }
                        if (i.knife == 1)
                        {
                            Console.WriteLine("4. Attack with knife");
                        }
                        if (i.pencil == 1)
                        {
                            Console.WriteLine("5. Attack with pencil");
                        }
                        userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.")
                        {
                            miniHp -= 0;
                            p.userHp -= 5;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has an axe so think wisely how to attack");
                        }

                        else if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.")
                        {
                            if (i.gun != 1)
                            {
                                Console.WriteLine("You don't have a weapon");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.gunMag <= 0)
                            {
                                Console.WriteLine("you dont have bullets");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.suppressor == 0)
                            {
                                p.seeAble = true;
                            }

                            i.gunMag -= 1;
                            Console.WriteLine($"Pistol mag: {i.gunMag}");
                            miniHp -= 8;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                        {
                            if (i.baseBat != 1)
                            {
                                Console.WriteLine("You don't have a bat");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 0;
                            p.userHp -= 5;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has an axe so think wisely how to attack");
                        }

                        else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                        {
                            if (i.knife != 1)
                            {
                                Console.WriteLine("You don't have a knife");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 5;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                        {
                            if (i.pencil != 1)
                            {
                                Console.WriteLine("You don't have a pencil");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 7;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName} with a pencil?!");
                        }

                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        break;
                    }

                    if (miniHp > 0)
                    {
                        while (p.userHp > 0 || miniHp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{pName} is going to attack with an axe \nHow do you want to block?");
                            Console.WriteLine("1. Block with hands");
                            if (i.gun == 1)
                            {
                                Console.WriteLine("2. Block with gun");
                            }
                            if (i.baseBat == 1)
                            {
                                Console.WriteLine("3. Block with baseballbat");
                            }
                            if (i.knife == 1)
                            {
                                Console.WriteLine("4. Block with knife");
                            }
                            if (i.pencil == 1)
                            {
                                Console.WriteLine("5. Block with pencil");
                            }
                            userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "block with hands" || userChoice == "with hands" || userChoice == "1" || userChoice == "1.")
                            {
                                miniHp -= 0;
                                p.userHp -= 5;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has aan axe so think wisely how to block");
                            }

                            else if (userChoice == "block with gun" || userChoice == "with gun" || userChoice == "2" || userChoice == "2.")
                            {
                                if (i.gun != 1)
                                {
                                    Console.WriteLine("You don't have a weapon");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 5;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has an axe so think wisely how to block");
                            }

                            else if (userChoice == "block with baseballbat" || userChoice == "with baseballbat" || userChoice == "3" || userChoice == "3.")
                            {
                                if (i.baseBat != 1)
                                {
                                    Console.WriteLine("You don't have a bat");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 4;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with knife" || userChoice == "with knife" || userChoice == "4" || userChoice == "4.")
                            {
                                if (i.knife != 1)
                                {
                                    Console.WriteLine("You don't have a knife");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 7;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with pencil" || userChoice == "with pencil" || userChoice == "5" || userChoice == "5.")
                            {
                                if (i.pencil != 1)
                                {
                                    Console.WriteLine("You don't have a pencil");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 5;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a stick so think wisely how to block");
                            }
                            else
                            {
                                Console.WriteLine("Input is wrong");
                                continue;
                            }
                            break;
                        }
                    }
                }

                if (randChoice == 3)
                {
                    while (p.userHp > 0 || miniHp > 0)
                    {
                        Console.WriteLine($"{pName} is in the room \nHe has a stick \nHow do you want to attack?");
                        Console.WriteLine("1. Attack with hands");
                        if (i.gun == 1)
                        {
                            Console.WriteLine("2. Shoot with gun");
                        }
                        if (i.baseBat == 1)
                        {
                            Console.WriteLine("3. Attack with baseballbat");
                        }
                        if (i.knife == 1)
                        {
                            Console.WriteLine("4. Attack with knife");
                        }
                        if (i.pencil == 1)
                        {
                            Console.WriteLine("5. Attack with pencil");
                        }
                        userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.")
                        {
                            miniHp -= 0;
                            p.userHp -= 5;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has a stick so think wisely how to attack");
                        }

                        else if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.")
                        {
                            if (i.gun != 1)
                            {
                                Console.WriteLine("You don't have a weapon");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.gunMag <= 0)
                            {
                                Console.WriteLine("you dont have bullets");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.suppressor == 0)
                            {
                                p.seeAble = true;
                            }

                            i.gunMag -= 1;
                            Console.WriteLine($"Pistol mag: {i.gunMag}");
                            miniHp -= 8;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                        {
                            if (i.baseBat != 1)
                            {
                                Console.WriteLine("You don't have a bat");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 0;
                            p.userHp -= 5;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has a stick so think wisely how to attack");
                        }

                        else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                        {
                            if (i.knife != 1)
                            {
                                Console.WriteLine("You don't have a knife");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 5;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                        {
                            if (i.pencil != 1)
                            {
                                Console.WriteLine("You don't have a pencil");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 7;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName} with a pencil?!");
                        }

                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        break;
                    }

                    if (miniHp > 0)
                    {
                        while (p.userHp > 0 || miniHp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{pName} is going to attack with a stick \nHow do you want to block?");
                            Console.WriteLine("1. Block with hands");
                            if (i.gun == 1)
                            {
                                Console.WriteLine("2. Block with gun");
                            }
                            if (i.baseBat == 1)
                            {
                                Console.WriteLine("3. Block with baseballbat");
                            }
                            if (i.knife == 1)
                            {
                                Console.WriteLine("4. Block with knife");
                            }
                            if (i.pencil == 1)
                            {
                                Console.WriteLine("5. Block with pencil");
                            }
                            userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "block with hands" || userChoice == "with hands" || userChoice == "1" || userChoice == "1.")
                            {
                                miniHp -= 0;
                                p.userHp -= 3;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a stick so think wisely how to block");
                            }

                            else if (userChoice == "block with gun" || userChoice == "with gun" || userChoice == "2" || userChoice == "2.")
                            {
                                if (i.gun != 1)
                                {
                                    Console.WriteLine("You don't have a weapon");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 3;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a stick so think wisely how to block");
                            }

                            else if (userChoice == "block with baseballbat" || userChoice == "with baseballbat" || userChoice == "3" || userChoice == "3.")
                            {
                                if (i.baseBat != 1)
                                {
                                    Console.WriteLine("You don't have a bat");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 4;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with knife" || userChoice == "with knife" || userChoice == "4" || userChoice == "4.")
                            {
                                if (i.knife != 1)
                                {
                                    Console.WriteLine("You don't have a knife");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 7;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with pencil" || userChoice == "with pencil" || userChoice == "5" || userChoice == "5.")
                            {
                                if (i.pencil != 1)
                                {
                                    Console.WriteLine("You don't have a pencil");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 3;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a stick so think wisely how to block");
                            }
                            else
                            {
                                Console.WriteLine("Input is wrong");
                                continue;
                            }
                            break;
                        }
                    }
                }

                if (randChoice == 4)
                {
                    while (p.userHp > 0 || miniHp > 0)
                    {
                        Console.WriteLine($"{pName} is in the room \nHe has a sword \nHow do you want to attack?");
                        Console.WriteLine("1. Attack with hands");
                        if (i.gun == 1)
                        {
                            Console.WriteLine("2. Shoot with gun");
                        }
                        if (i.baseBat == 1)
                        {
                            Console.WriteLine("3. Attack with baseballbat");
                        }
                        if (i.knife == 1)
                        {
                            Console.WriteLine("4. Attack with knife");
                        }
                        if (i.pencil == 1)
                        {
                            Console.WriteLine("5. Attack with pencil");
                        }
                        userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.")
                        {
                            miniHp -= 0;
                            p.userHp -= 7;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has a sword so think wisely how to attack");
                        }

                        else if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.")
                        {
                            if (i.gun != 1)
                            {
                                Console.WriteLine("You don't have a weapon");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.gunMag <= 0)
                            {
                                Console.WriteLine("you dont have bullets");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.suppressor == 0)
                            {
                                p.seeAble = true;
                            }

                            i.gunMag -= 1;
                            Console.WriteLine($"Pistol mag: {i.gunMag}");
                            miniHp -= 8;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                        {
                            if (i.baseBat != 1)
                            {
                                Console.WriteLine("You don't have a bat");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 0;
                            p.userHp -= 7;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"{pName} blocked your attatck! \nHe has a sword so think wisely how to attack");
                        }

                        else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                        {
                            if (i.knife != 1)
                            {
                                Console.WriteLine("You don't have a knife");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 5;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                        {
                            if (i.pencil != 1)
                            {
                                Console.WriteLine("You don't have a pencil");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 7;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName} with a pencil?!");
                        }

                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        break;
                    }

                    if (miniHp > 0)
                    {
                        while (p.userHp > 0 || miniHp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{pName} is going to attack with a sword \nHow do you want to block?");
                            Console.WriteLine("1. Block with hands");
                            if (i.gun == 1)
                            {
                                Console.WriteLine("2. Block with gun");
                            }
                            if (i.baseBat == 1)
                            {
                                Console.WriteLine("3. Block with baseballbat");
                            }
                            if (i.knife == 1)
                            {
                                Console.WriteLine("4. Block with knife");
                            }
                            if (i.pencil == 1)
                            {
                                Console.WriteLine("5. Block with pencil");
                            }
                            userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "block with hands" || userChoice == "with hands" || userChoice == "1" || userChoice == "1.")
                            {
                                miniHp -= 0;
                                p.userHp -= 7;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a sword so think wisely how to block");
                            }

                            else if (userChoice == "block with gun" || userChoice == "with gun" || userChoice == "2" || userChoice == "2.")
                            {
                                if (i.gun != 1)
                                {
                                    Console.WriteLine("You don't have a weapon");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 7;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a sword so think wisely how to block");
                            }

                            else if (userChoice == "block with baseballbat" || userChoice == "with baseballbat" || userChoice == "3" || userChoice == "3.")
                            {
                                if (i.baseBat != 1)
                                {
                                    Console.WriteLine("You don't have a bat");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 4;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} couldn't attack! \nWell done!");
                            }

                            else if (userChoice == "block with knife" || userChoice == "with knife" || userChoice == "4" || userChoice == "4.")
                            {
                                if (i.knife != 1)
                                {
                                    Console.WriteLine("You don't have a knife");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 7;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a sword so think wisely how to block");
                            }

                            else if (userChoice == "block with pencil" || userChoice == "with pencil" || userChoice == "5" || userChoice == "5.")
                            {
                                if (i.pencil != 1)
                                {
                                    Console.WriteLine("You don't have a pencil");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 7;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a sword so think wisely how to block");
                            }
                            else
                            {
                                Console.WriteLine("Input is wrong");
                                continue;
                            }
                            break;
                        }
                    }
                }

                if (randChoice == 5)
                {
                    while (p.userHp > 0 || miniHp > 0)
                    {
                        Console.WriteLine($"{pName} is in the room \nHe has a gun \nHow do you want to attack?");
                        Console.WriteLine("1. Attack with hands");
                        if (i.gun == 1)
                        {
                            Console.WriteLine("2. Shoot with gun");
                        }
                        if (i.baseBat == 1)
                        {
                            Console.WriteLine("3. Attack with baseballbat");
                        }
                        if (i.knife == 1)
                        {
                            Console.WriteLine("4. Attack with knife");
                        }
                        if (i.pencil == 1)
                        {
                            Console.WriteLine("5. Attack with pencil");
                        }
                        userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "attack with hands" || userChoice == "1" || userChoice == "1.")
                        {
                            miniHp -= 2;
                            p.userHp -= 0;
                            if (p.PlayerCheck() == true)
                            {
                                GameOver();
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "shoot" || userChoice == "shoot with gun" || userChoice == "shoot gun" || userChoice == "2" || userChoice == "2.")
                        {
                            if (i.gun != 1)
                            {
                                Console.WriteLine("You don't have a weapon");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.gunMag <= 0)
                            {
                                Console.WriteLine("you dont have bullets");
                                Console.WriteLine();
                                continue;
                            }
                            if (i.suppressor == 0)
                            {
                                p.seeAble = true;
                            }

                            i.gunMag -= 1;
                            Console.WriteLine($"Pistol mag: {i.gunMag}");
                            miniHp -= 8;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with baseballbat" || userChoice == "3" || userChoice == "3.")
                        {
                            if (i.baseBat != 1)
                            {
                                Console.WriteLine("You don't have a bat");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 4;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with knife" || userChoice == "4" || userChoice == "4.")
                        {
                            if (i.knife != 1)
                            {
                                Console.WriteLine("You don't have a knife");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 5;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName}!");
                        }

                        else if (userChoice == "attack with pencil" || userChoice == "5" || userChoice == "5.")
                        {
                            if (i.pencil != 1)
                            {
                                Console.WriteLine("You don't have a pencil");
                                Console.WriteLine();
                                continue;
                            }
                            miniHp -= 7;
                            p.userHp -= 0;
                            Console.WriteLine();
                            Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                            Console.WriteLine($"You succesfully attacked {pName} with a pencil?!");
                        }

                        else
                        {
                            Console.WriteLine("Input is wrong");
                            continue;
                        }
                        break;
                    }

                    if (miniHp > 0)
                    {
                        while (p.userHp > 0 || miniHp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{pName} is going to attack with a gun \nHow do you want to block?");
                            Console.WriteLine("1. Block with hands");
                            if (i.gun == 1)
                            {
                                Console.WriteLine("2. Block with gun");
                            }
                            if (i.baseBat == 1)
                            {
                                Console.WriteLine("3. Block with baseballbat");
                            }
                            if (i.knife == 1)
                            {
                                Console.WriteLine("4. Block with knife");
                            }
                            if (i.pencil == 1)
                            {
                                Console.WriteLine("5. Block with pencil");
                            }
                            userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "block with hands" || userChoice == "with hands" || userChoice == "1" || userChoice == "1.")
                            {
                                miniHp -= 0;
                                p.userHp -= 8;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a gun so think wisely how to block");
                            }

                            else if (userChoice == "block with gun" || userChoice == "with gun" || userChoice == "2" || userChoice == "2.")
                            {
                                if (i.gun != 1)
                                {
                                    Console.WriteLine("You don't have a weapon");
                                    Console.WriteLine();
                                    continue;
                                }
                                if (i.gunMag <= 0)
                                {
                                    Console.WriteLine("you dont have bullets");
                                    Console.WriteLine();
                                    continue;
                                }
                                if (i.suppressor == 0)
                                {
                                    p.seeAble = true;
                                }

                                i.gunMag -= 1;
                                Console.WriteLine($"Pistol mag: {i.gunMag}");
                                miniHp -= 8;
                                p.userHp -= 0;
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"You shot faster than {pName} \nWell done!");
                            }

                            else if (userChoice == "block with baseballbat" || userChoice == "with baseballbat" || userChoice == "3" || userChoice == "3.")
                            {
                                if (i.baseBat != 1)
                                {
                                    Console.WriteLine("You don't have a bat");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 8;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a gun so think wisely how to block");
                            }

                            else if (userChoice == "block with knife" || userChoice == "with knife" || userChoice == "4" || userChoice == "4.")
                            {
                                if (i.knife != 1)
                                {
                                    Console.WriteLine("You don't have a knife");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 8;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a gun so think wisely how to block");
                            }

                            else if (userChoice == "block with pencil" || userChoice == "with pencil" || userChoice == "5" || userChoice == "5.")
                            {
                                if (i.pencil != 1)
                                {
                                    Console.WriteLine("You don't have a pencil");
                                    Console.WriteLine();
                                    continue;
                                }
                                miniHp -= 0;
                                p.userHp -= 8;
                                if (p.PlayerCheck() == true)
                                {
                                    GameOver();
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Player HP: {p.userHp} \n{pName} HP: {miniHp}");
                                Console.WriteLine($"{pName} attacked succesfully! \nHe has a gun so think wisely how to block");
                            }
                            else
                            {
                                Console.WriteLine("Input is wrong");
                                continue;
                            }
                            break;
                        }
                    }
                }

                if (miniHp <= 0 || p.userHp <= 0)
                {
                    Console.WriteLine($"You beat {pName}!");
                    Console.WriteLine();
                    break;
                }
                continue;
            }

        }
        public void GameOver()
        {
            Locations l = new Locations();
            while (userReplay != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("Game Over! \nType 'replay' to play again");
                userReplay = Console.ReadLine().ToLower();
                if (userReplay == "replay")
                {
                    l.AllLocations();
                }
            }
        }
    }
}
