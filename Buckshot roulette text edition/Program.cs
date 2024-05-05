using System.Threading;

public static class GlobalVariables
{
#pragma warning disable CA2211
    public static string name = "nothing";
    public static int MagnifyingGlass = 0;
    public static int Ciggarete = 0;
    public static int Beer = 0;
    public static int Saw = 0;
    public static int Handcuffs = 0;
    public static int DealerMagnifyingGlass = 0;
    public static int DealerCiggarete = 0;
    public static int DealerBeer = 0;
    public static int DealerSaw = 0;
    public static int DealerHandcuffs = 0;

    public static bool DealerHandcuffed = false;
    public static bool PlayerHandcuffed = false;
    public static bool SawActive = false;

    public static int Blank = 0;
    public static int Live = 0;
    public static int DealerCharges = 0;
    public static int PlayerCharges = 0;

    public static string TURN = "player";
    public static string DealerKnowledge = "Null";
    public static string playerchoice;
    public static string Ammo = "Undefined";
}

internal class Program
{
    private static void Main(string[] args)
    {
        GameTitle();
    }

    public static void GameTitle()
    {
        string choice;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Title = "BUCKSHOT ROULETTE: text edition";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"    __         ___       ___       ___  ===");
        Console.WriteLine(@"   ||_) ||  | ||   |//  ||__ ||_| ||  |  |");
        Console.WriteLine(@"   ||_) ||__| ||__ |\\  __|| || | ||__|  |");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("__   __            __ ___ ___  __");
        Console.WriteLine("|_) |  | |  | |   |__  |   |  |__");
        Console.WriteLine("| | |__| |__| |__ |__  |   |  |__");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Text Edition");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Type START or MULTIPLAYER");
        Console.WriteLine("Type INFO if you don't know how to play");
        Console.ForegroundColor = ConsoleColor.White;

        for (int OnMenu = 0; OnMenu == 0;)
        {
            choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "start":
                    {
                        Beggin();
                        OnMenu = 1;
                        break;
                    }
                case "multiplayer":
                    {
                        Multiplayer();
                        break;
                    }
                case "info":
                    {
                        Console.WriteLine("Every round there is an amount of LIVE and BLANK Ammo");
                        Console.WriteLine("You can decide to shoot the DEALER or YOUSELF");
                        Console.WriteLine("If you shoot YOURSELF with a blank, it's still your turn");
                        Console.WriteLine("If you shoot YOURSELF with a live, it's the DEALER's turn");
                        Console.WriteLine("Charges make you don't die when getting hit");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("INVALID, TRY AGAIN");
                        break;
                    }
            }
        }
    }

    public static void Beggin()
    {
        Console.WriteLine("You enter the room, your heart is racing as the dealer says:");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("PLEASE SIGN THE WAIVER");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("______________________");
        Console.WriteLine(@"|RELEASE OF LIABILITY|\");
        Console.WriteLine(@"|....................|_\");
        Console.WriteLine("|.......   ..........|");
        Console.WriteLine("|...............   ..|");
        Console.WriteLine("|....................|");
        Console.WriteLine("|..  ................|");
        Console.WriteLine("|....................|");
        Console.WriteLine("|....................|__");
        Console.WriteLine("|............._______| /");
        Console.WriteLine("|____________________|/");
        GlobalVariables.name = Console.ReadLine().ToUpper();
        if (GlobalVariables.name == "GOD" || GlobalVariables.name == "DEALER")
        {
            Console.Clear();
            GameTitle();
        }
        Console.WriteLine("You write {0} at the waiver ready for what comes next", GlobalVariables.name);
        Console.WriteLine("you're nervous so you try to focus on the money you'll hopefully get");
        Console.Title = $"Buckshot Roulette: Text edition with {GlobalVariables.name}'s life on the line!";
        Thread.Sleep(3000);
        StartRound(5, 7, 7, 9, 3, 30);
    }

    public static void StartRound(int LiveMin, int LiveMax, int BlankMin, int BlankMax, int Charges, int ItemAmount)
    {
        GlobalVariables.TURN = "Player";
        GlobalVariables.MagnifyingGlass = 0;
        GlobalVariables.Ciggarete = 0;
        GlobalVariables.Beer = 0;
        GlobalVariables.Saw = 0;
        GlobalVariables.Handcuffs = 0;
        GlobalVariables.DealerMagnifyingGlass = 0;
        GlobalVariables.DealerCiggarete = 0;
        GlobalVariables.DealerBeer = 0;
        GlobalVariables.DealerSaw = 0;
        GlobalVariables.DealerHandcuffs = 0;

        //configure round
        Console.Clear();
        Random random = new();
        GlobalVariables.DealerCharges = Charges;
        GlobalVariables.PlayerCharges = Charges;

        //round starting configuration

        Console.WriteLine("{0} blanks, {1} live", GlobalVariables.Blank, GlobalVariables.Live);

        while (GlobalVariables.DealerCharges >= 0 && GlobalVariables.PlayerCharges >= 0)
        {
            Console.WriteLine(@"  ________________");
            Console.WriteLine(@" /\               \___");
            Console.WriteLine(@"/__\It's your turn \  /");
            Console.WriteLine(@"    \_______________\/");
            SayCharges(GlobalVariables.PlayerCharges, GlobalVariables.DealerCharges);

            //**************************************************
            //********************PLAYER TURN*******************
            //**************************************************

            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  __________________");
            Console.WriteLine(" /  _______/____/__/");
            Console.WriteLine("/__/-'");
            Console.WriteLine("You get the shotgun");

            Thread.Sleep(1000);

            while (GlobalVariables.TURN == "Player")
            {
                if ((GlobalVariables.Blank + GlobalVariables.Live) == 0)
                {
                    Recharge(LiveMin, LiveMax, BlankMin, BlankMax, ItemAmount);
                }
                Console.WriteLine("");
                Console.WriteLine("What will you do?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Shoot the dealer");
                Console.WriteLine("Shoot myself");
                Console.WriteLine("You can use the following items:");
                if (GlobalVariables.Handcuffs > 0)
                {
                    Console.WriteLine($"{GlobalVariables.Handcuffs}x HANDCUFFS: skip one turn from the dealer");
                }
                if (GlobalVariables.MagnifyingGlass > 0)
                {
                    Console.WriteLine($"{GlobalVariables.MagnifyingGlass}x MAGNIFYING GLASS: see what kind of bullet is on the chamber");
                }
                if (GlobalVariables.Beer > 0)
                {
                    Console.WriteLine($"{GlobalVariables.Beer}x BEER : rack the shotgun (also reveal what kind of bullet it was)");
                }
                if (GlobalVariables.Saw > 0)
                {
                    Console.WriteLine($"{GlobalVariables.Saw}x SAW: shotgun deals 2 damage");
                }
                if (GlobalVariables.Ciggarete > 0)
                {
                    Console.WriteLine($"{GlobalVariables.Ciggarete}x CIGGARETE: gets +1 charge");
                }
                GlobalVariables.playerchoice = Console.ReadLine().ToLower();
                switch (GlobalVariables.playerchoice)
                {
                    case "me":
                    case "shoot me":
                    case "shoot myself":
                    case "shoot yourself":
                    case "myself":
                    case "yourself":
                    case "I":
                        {
                            Shoot("Player", "Self");
                            break;
                        }
                    case "shoot dealer":
                    case "shoot enemy":
                    case "shoot the dealer":
                    case "dealer":
                        {
                            Shoot("Player", "Opponent");
                            break;
                        }
                    case "glass":
                    case "magnifying glass":
                    case "magnifying_glass":
                    case "magnifying":
                    case "magnifing":
                    case "magnyfyng":
                    case "magnifyingglass":
                    case "magnifing glass":
                    case "magnyfyng glass":

                        {
                            UseItem("MagnifyingGlass", "Player");
                            break;
                        }
                    case "hand":
                    case "handcuffs":
                    case "cuffs":
                    case "use the handcuffs":
                    case "handcuff the dealer":
                    case "handcuff dealer":
                    case "use the handcuffs on the dealer":
                        {
                            UseItem("Handcuffs", "Player");
                            break;
                        }
                    case "beer":
                    case "bear beer":
                    case "drink beer":
                    case "drank beer":
                    case "get drunk":
                    case "alcohol":
                        {
                            UseItem("Beer", "Player");
                            break;
                        }
                    case "saw":
                    case "saw the shotgun":
                        {
                            UseItem("Saw", "Player");
                            break;
                        }
                    case "ciggarete":
                    case "smoke":
                    case "smoke the Ciggarete":
                    case "smoke Ciggarete":
                        {
                            UseItem("Ciggarete", "Player");
                            break;
                        }
                    case "ammo":
                        {
                            Console.WriteLine("{0} blanks, {1} live", GlobalVariables.Blank, GlobalVariables.Live);
                            Thread.Sleep(1000);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You shake");
                            Thread.Sleep(1000);
                            Console.WriteLine("But you need to continue");
                            Thread.Sleep(1000);
                            Console.WriteLine("(INVALID COMMAND)");
                            break;
                        }
                }
            }

            if (GlobalVariables.DealerCharges > -1)
            {
                Console.WriteLine(@"  ________   _____________");
                Console.WriteLine(@" /\ .     \__\    m,~     \___");
                Console.WriteLine(@"/__\It's the DEALER's turn \  /");
                Console.WriteLine(@"    \___________/\__________\/");

                while (GlobalVariables.TURN == "Dealer")
                {
                    if ((GlobalVariables.Blank + GlobalVariables.Live) == 0)
                    {
                        Recharge(LiveMin, LiveMax, BlankMin, BlankMax, ItemAmount);
                    }

                    while (GlobalVariables.DealerCiggarete > 1)
                    {
                        UseItem("Ciggarete", "Dealer");
                    }
                    while ((GlobalVariables.Live + 2) < GlobalVariables.Blank && GlobalVariables.DealerBeer > 0)
                    {
                        UseItem("Beer", "Dealer");
                    }
                    while ((GlobalVariables.Live + 1) > GlobalVariables.Blank && GlobalVariables.MagnifyingGlass > 0 && GlobalVariables.Beer <= 0 && GlobalVariables.DealerKnowledge == "Null")
                    {
                        UseItem("MagnifyingGlass", "Dealer");
                    }

                    //if there are more blanks+a bit of randomness are than lives , the dealer will shoot himself
                    if (GlobalVariables.DealerKnowledge == "Live")
                    {
                        Console.WriteLine("The dealer decides to shoot you!!");
                        Shoot("Dealer", "Opponent");
                    }
                    if ((GlobalVariables.Blank + random.Next(0, 2)) > GlobalVariables.Live || GlobalVariables.DealerKnowledge == "Blank")

                    {
                        Console.WriteLine("The dealer decides to shoot himself");
                        Console.WriteLine("  __________________");
                        Console.WriteLine(" /  _______/____/__/");
                        Console.WriteLine("/__/-'");

                        Thread.Sleep(500);
                        Shoot("Dealer", "Self");
                    }
                    else
                    {
                        // Dealer shoots player
                        Console.WriteLine("The dealer decides to shoot you!!");
                        Shoot("Dealer", "Opponent");
                    }
                }
            }
        }
        Thread.Sleep(2000);
        if (GlobalVariables.PlayerCharges == -1)
        {
            GameOver();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Let's make this more interesting");
            Thread.Sleep(2000);
            Console.WriteLine("2 items each");
            Thread.Sleep(2000);

            StartRound(3, 5, 1, 9, 5, 2);
        }
    }

    public static void Multiplayer()
    {
        string choice;
    }

    public static void GameOver()
    {
        Random random = new();
        int DeathTipID = random.Next(1, 4);

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("YOU ARE DEAD");
        Console.WriteLine("Click enter to restart");

        Console.WriteLine("Death's TIP:");
        if (DeathTipID == 1)
        {
            Console.WriteLine("y o u  c a n  w r i t e  dealer  o r  me  i n s t e a d  o f  shoot the dealer  o r  shoot myself");
        }
        if (DeathTipID == 2)
        {
            Console.WriteLine("y o u  c a n  w r i t e  ammo  t o  k n o w  h o w  m a n y  b u l l e t s  a r e  i n s i d e  t h e  c h a m b e r");
        }
        if (DeathTipID == 3)
        {
            Console.WriteLine("t h e  m a g n i f y i n g  g l a s s  a n d  t h e  s a w  m a k e  a  g r e a t  d u a l ,  d o n ' t  y o u  t h i n k  ?");
        }
        if (DeathTipID == 4)
        {
            Console.WriteLine("h e r e ' s  m y  l i s t  o f  i t e m s  s h o r c u t s . . .");
            Console.WriteLine(@"  _____________________");
            Console.WriteLine(@" / |  ITEM       -*    \");
            Console.WriteLine(@"|.*|  *-  SHORTCUTS     |");
            Console.WriteLine(@" \_|                    |");
            Console.WriteLine(@"   |Drink = Beer        |");
            Console.WriteLine(@"   |Glass = MagnifyingG |");
            Console.WriteLine(@"   |Hand = Handcuffs    |");
            Console.WriteLine(@"   |Saw = Saw           |");
            Console.WriteLine(@"   |Smoke = Cigarette   |");
            Console.WriteLine(@"   |____________________|_");
            Console.WriteLine(@"   |@\                    \");
            Console.WriteLine(@"   |@@|                    |");
            Console.WriteLine(@"    \_/___________________/");
        }
        Console.ReadLine();
        GameTitle();
    }

    private static void SayCharges(int PLAYERcharges, int DEALERcharges)
    {
        Console.ForegroundColor = ConsoleColor.White;
        if (PLAYERcharges <= 0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"{GlobalVariables.name}: {PLAYERcharges} charges");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{GlobalVariables.name}: {PLAYERcharges} charges");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        if (DEALERcharges <= 0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"DEALER: {DEALERcharges} charges");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($"DEALER: {DEALERcharges} charges");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    private static void Victory()
    {
        Console.WriteLine("You see a suitcase aproaching");
        Console.WriteLine(@"   _________________________");
        Console.WriteLine(@"  /                         \");
        Console.WriteLine(@" /                           \");
        Console.WriteLine(@"/_____________________________\");
        Console.WriteLine(@"|___| |_________________| |___|");
        Console.WriteLine(@"|   |_|                 |_|   |");
        Console.WriteLine(@"|_____________________________|");
        Console.WriteLine("Press enter to open it");
        Console.ReadLine();

        Console.WriteLine(@"  ___________________________");
        Console.WriteLine(@" /___/ /_______________\ \___\");
        Console.WriteLine(@" \                           /");
        Console.WriteLine(@"  \                         /");
        Console.WriteLine(@"   \_______________________/");
        Console.WriteLine(@"   /$$$$$$$$$$$$$$$$$$$$$$$\");
        Console.WriteLine(@"  /$$$$$$$$$$$$$$$$$$$$$$$$$\");
        Console.WriteLine(@" /$$$$$$$$$$$$$$$$$$$$$$$$$$$\");
        Console.WriteLine(@"/_____________________________\");
        Console.WriteLine(@"|   |_|                 |_|   |");
        Console.WriteLine(@"|_____________________________|");
        Console.ReadLine();
    }

    public static void GetItems(int ItemAmount, bool PlayerItem)
    {
        //items
        Random random = new();

        if (ItemAmount > 0)
        {
            for (int ItemsObtained = 0; ItemsObtained < ItemAmount; ItemsObtained++)
            {
                int WhatItem = random.Next(1, 6);
                if (WhatItem == 1)
                {
                    if (PlayerItem == true)
                    {
                        Console.WriteLine(@"   ______");
                        Console.WriteLine(@"  / ____ \");
                        Console.WriteLine(@" / / *  \ \");
                        Console.WriteLine(@"| |   *  | |");
                        Console.WriteLine(@" \ \____/ /");
                        Console.WriteLine(@"  \______/");
                        Console.WriteLine(@"     \ \");
                        Console.WriteLine(@"      \ \");
                        Console.WriteLine(@"       \_\");
                        Console.WriteLine("You get a magnifying glass");
                        GlobalVariables.MagnifyingGlass++;
                    }
                    else
                    {
                        Console.WriteLine("The dealer got a magnifying glass");
                        GlobalVariables.DealerMagnifyingGlass++;
                    }
                }
                else if (WhatItem == 2)
                {
                    if (PlayerItem == true)
                    {
                        Console.WriteLine(@"_________");
                        Console.WriteLine(@"|///////|");
                        Console.WriteLine(@"|_______|");
                        Console.WriteLine(@"|       |");
                        Console.WriteLine(@"|       |");
                        Console.WriteLine(@"|       |");
                        Console.WriteLine(@"|_______|");
                        Console.WriteLine("You get a pack of Ciggaretes");
                        GlobalVariables.Ciggarete++;
                    }
                    else
                    {
                        Console.WriteLine("You get a pack of Ciggaretes");
                        GlobalVariables.DealerCiggarete++;
                    }
                }
                else if (WhatItem == 3)
                {
                    if (PlayerItem == true)
                    {
                        Console.WriteLine(@" _______");
                        Console.WriteLine(@"/    () \");
                        Console.WriteLine(@"|       |");
                        Console.WriteLine(@"|\_____/|");
                        Console.WriteLine(@"|       |");
                        Console.WriteLine(@"|  BEAR |");
                        Console.WriteLine(@"|   BEER|");
                        Console.WriteLine(@"\______/");

                        Console.WriteLine("You get a can of beer");
                        GlobalVariables.Beer++;
                    }
                    else
                    {
                        Console.WriteLine("The dealer got a can of beer");
                        GlobalVariables.DealerBeer++;
                    }
                }
                else if (WhatItem == 4)
                {
                    if (PlayerItem == true)
                    {
                        Console.WriteLine(@"  ____________");
                        Console.WriteLine(@" /  _________ \");
                        Console.WriteLine(@"/ /__________\ \");
                        Console.WriteLine(@"| ____________ |");
                        Console.WriteLine(@"|/\/\/\/\/\/\/\|");
                        Console.WriteLine("You get a saw");
                        GlobalVariables.Saw++;
                    }
                    else
                    {
                        Console.WriteLine("The dealer got a saw");
                        GlobalVariables.DealerSaw++;
                    }
                }
                else if (WhatItem == 5)
                {
                    if (PlayerItem == true)
                    {
                        Console.WriteLine(@"  _____");
                        Console.WriteLine(@" /     \");
                        Console.WriteLine(@" |     |");
                        Console.WriteLine(@" \_____/       _____");
                        Console.WriteLine(@"      \__     /     \");
                        Console.WriteLine(@"         \____|     |");
                        Console.WriteLine(@"              \_____/");

                        Console.WriteLine("You get a pair of handcuffs");
                        GlobalVariables.Handcuffs++;
                    }
                    else
                    {
                        Console.WriteLine("The dealer got a pair of handcuffs");
                        GlobalVariables.DealerHandcuffs++;
                    }
                }
            }
        }
    }

    public static void Shoot(string Turn, string Who)
    {
        //bullet is live
        if (GlobalVariables.Ammo == "Live")
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            /*
                          themselves|opponent
        X   Dealer shoots_____X_____|___O____
        O   Player shoots:    O     |   X
            */

            if (Turn == "Dealer" && Who == "Opponent" || Turn == "Player" && Who == "Self")
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine(@"     .  .  __________________");
                Console.WriteLine(@"    *##$#@$\__\____\_______  \");
                Console.WriteLine(@"      *                  '-\__\");
                Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("      __________________  .  .");
                Console.WriteLine("     /  _______/____/__/$@#$##*");
                Console.WriteLine("    /__/-'                  *");
                Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            if (GlobalVariables.SawActive == true)
            {
                if (Turn == "Dealer" && Who == "Opponent" || Turn == "Player" && Who == "Self")
                {
                    GlobalVariables.PlayerCharges--;
                    GlobalVariables.PlayerCharges--;
                }
                else
                    GlobalVariables.DealerCharges--;
                    GlobalVariables.DealerCharges--;
                    //player shoots opponent
                    //player shoots themselves
            }
            else
            {
                if (Turn == "Dealer")
                {
                    GlobalVariables.PlayerCharges--;
                }
                else
                {
                    GlobalVariables.DealerCharges--;
                }
            }
            Thread.Sleep(2000);
            GlobalVariables.Live--;
            if (Turn == "Player")
            {
                if (GlobalVariables.DealerHandcuffed == false)
                {
                    GlobalVariables.TURN = "Dealer";
                }
            }
            else
            {
                if (GlobalVariables.PlayerHandcuffed == false)
                {
                    GlobalVariables.TURN = "Player";
                }
            }
            return;
        }
        //bullet is blank
        else
        {
            if (Turn == "Player" && Who == "Opponent")
            {
                Console.WriteLine("*Click!");
                Console.WriteLine("  __________________");
                Console.WriteLine(" /  _______/____/__/");
                Console.WriteLine("/__/-'*");
                //X
            }
            else
            {
                Console.WriteLine("                *Click!");
                Console.WriteLine(@" __________________");
                Console.WriteLine(@" \__\____\_______  \");
                Console.WriteLine(@"               '-\__\");
                //O
            }
            /*
                           themselves|opponent
             Dealer shoots_____X_____|___O____
             Player shoots:    O     |   X
             */

            Thread.Sleep(2000);
            GlobalVariables.Live--;
            if (Turn == "Player" && Who == "Opponent")
            {
                if (GlobalVariables.DealerHandcuffed == false || Who == "Opponent")
                {
                    GlobalVariables.TURN = "Dealer";
                }
            }
            else
            {
                if (GlobalVariables.PlayerHandcuffed == false || Who == "Opponent")
                {
                    GlobalVariables.TURN = "Player";
                }
            }
            GlobalVariables.DealerKnowledge = "Null";
            return;
        }
    }
    public static void Dealertext(string Text)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{Text}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Recharge(int LiveMin, int LiveMax, int BlankMin, int BlankMax, int ItemAmount)
    {
        Random random = new();
        Console.WriteLine("The dealer recharges the shotgun");
        GlobalVariables.Blank = random.Next(BlankMin, BlankMax);
        GlobalVariables.Live = random.Next(LiveMin, LiveMax);
        Thread.Sleep((GlobalVariables.Live + GlobalVariables.Blank) * 100);
        Console.WriteLine("{0} blanks, {1} live", GlobalVariables.Blank, GlobalVariables.Live);
        Thread.Sleep(1000);
        GetItems(ItemAmount, true);
        GetItems(ItemAmount, false);
        SayCharges(GlobalVariables.PlayerCharges, GlobalVariables.DealerCharges);
    }

    public static void AmmoSet()
    {
        Random random = new();
        if (GlobalVariables.Live >= (random.Next(1, (GlobalVariables.Live + GlobalVariables.Blank + 1))))
        {
            GlobalVariables.Ammo = "Live";
        }
        else
        {
            GlobalVariables.Ammo = "Blank";
        };
    }

    public static void UseItem(string Which, string User)
    {
        if (Which == "Beer")
        {
            if (User == "Dealer")
            {
                GlobalVariables.DealerBeer--;
                Console.WriteLine($"The dealer drinks a beer then racks the shotgun");
                Thread.Sleep(500);
                if (GlobalVariables.Ammo == "Blank")
                {
                    Console.WriteLine("A blank gets out of the shotgun");
                    Thread.Sleep(1000);
                    GlobalVariables.Blank--;
                }
                else
                {
                    Console.WriteLine("A live gets out of the shotgun");
                    Thread.Sleep(1000);
                    GlobalVariables.Live--;
                }
                AmmoSet();
            }
            else
            {
                if (GlobalVariables.Beer > 0)
                {
                    GlobalVariables.Beer--;
                    Console.WriteLine("You drink the beer and then rack the shotgun");
                    Thread.Sleep(1000);
                    GlobalVariables.Beer--;
                    if (GlobalVariables.Ammo == "Blank")
                    {
                        Console.WriteLine("A blank gets out of the shotgun");
                        Thread.Sleep(1000);
                        GlobalVariables.Blank--;
                    }
                    else
                    {
                        Console.WriteLine("A live gets out of the shotgun");
                        Thread.Sleep(1000);
                        GlobalVariables.Live--;
                    }
                    AmmoSet();
                }
                else
                {
                    Console.WriteLine("There is no beers");
                    Thread.Sleep(2000);
                }
            }
            AmmoSet();
        }
        if (Which == "Handcuffs")
        {
            if (User == "Dealer")
            {
                GlobalVariables.DealerHandcuffs--;
                Console.WriteLine("The dealer takes the handcuffs and before you realize they're already at your hands");
                Thread.Sleep(500);
                GlobalVariables.PlayerHandcuffed = true;
            }
            else
            {
                GlobalVariables.Handcuffs--;
                Console.WriteLine("The dealer takes the handcuffs and uses them");
                Thread.Sleep(500);
                GlobalVariables.DealerHandcuffed = true;
            }
        }
        if (Which == "Saw")
        {
            if (User == "Dealer")
            {
                Console.WriteLine("The dealer saws the shotgun idk what to write here -Furr_63");
                Thread.Sleep(500);
                GlobalVariables.SawActive = true;
            }
            else if (GlobalVariables.Saw > 0)
            {
                Console.WriteLine("You saw the shotgun");
                Thread.Sleep(2000);
                GlobalVariables.SawActive = true;
            }
        }
        if (Which == "MagnifyingGlass")
        {
            if (User == "Dealer")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("VERY INTERESTING");
                Thread.Sleep(2000);
                GlobalVariables.DealerKnowledge = GlobalVariables.Ammo;
                GlobalVariables.DealerMagnifyingGlass--;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (GlobalVariables.MagnifyingGlass > 0)
                {
                    Console.WriteLine("You break the Magnifying Glass and look inside the chamber");
                    Thread.Sleep(1000);
                    Console.WriteLine($"It's a {GlobalVariables.Ammo}");
                    Thread.Sleep(1000);
                    GlobalVariables.MagnifyingGlass--;
                }
            }
        }
        if (Which == "Ciggarete")
        {
            if (User == "Dealer")
            {
                Console.WriteLine("The dealer lights a ciggarete, getting +1 charge");
                Thread.Sleep(1000);
                GlobalVariables.DealerCharges++;
                GlobalVariables.DealerCiggarete--;
            }
            else
            {
                if (GlobalVariables.Ciggarete > 0)
                {
                    Console.WriteLine("You open the pack and lights a Ciggarete");
                    Thread.Sleep(1000);
                    Console.WriteLine("There's no time for smoking but you get +1 charge");
                    Thread.Sleep(1000);
                    GlobalVariables.PlayerCharges++;
                    GlobalVariables.Ciggarete--;
                }
            }
        }
    }
}