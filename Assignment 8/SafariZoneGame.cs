using System;
using static System.Console;
namespace Assignment_8
{
    internal class PokemonSafariZone
    {
        static void Main(string[] args)
        {
            WriteLine("  _|_|_|    _|_|    _|_|_|_|    _|_|    _|_|_|    _|_|_|      _|_|_|_|_|    _|_|    _|      _|  _|_|_|_|");
            WriteLine("_|        _|    _|  _|        _|    _|  _|    _|    _|              _|    _|    _|  _|_|    _|  _|      ");
            WriteLine("  _|_|    _|_|_|_|  _|_|_|    _|_|_|_|  _|_|_|      _|            _|      _|    _|  _|  _|  _|  _|_|_|  ");
            WriteLine("      _|  _|    _|  _|        _|    _|  _|    _|    _|          _|        _|    _|  _|    _|_|  _|      ");
            WriteLine("_|_|_|    _|    _|  _|        _|    _|  _|    _|  _|_|_|      _|_|_|_|_|    _|_|    _|      _|  _|_|_|_|");
            WriteLine("                -*:--::-:::::::::::::::-:::=++++++++=                           ");
            WriteLine("                =:.=+#+*- -:   ..  :      =**+:    .+                           ");
            WriteLine("                -*:==:-*#*#-.. .           .-+**-   =                           ");
            WriteLine("                =:     :++****:*-.............--=. :=                           ");
            WriteLine("                =:  +=-=-=****-+             :--:- .#                           ");
            WriteLine("                =:  %++*-==-=. +     (1)         =..#                           ");
            WriteLine("                -:   +.-:---.=.   .::.:%         =..#                           ");
            WriteLine("                =:  :+*#**#**+.  -%**#*==      . . .#                           ");
            WriteLine("                =:   *+#++*+:-==+*#******==-=--=--==#-......+++*+++++=-:-+++++--");
            WriteLine("                =.   +.-::-..   =.=****#-          :-::::::  :=-----. ==+******=");
            WriteLine("                =:   +         .+ : ==-++:         -=-::-::::-+-=-----@-+-+===.+");
            WriteLine("..    .         .=..=:--.:=:....... .:::::::::::::::-=:--:::=: ::-%-:::   .*#*.+");
            WriteLine("-+===-+:::::::---=  --*: .+-::--::-*-:. :------::::=.=- =***..-*****+++.    .:-*");
            WriteLine(" *:::=-               + ... .=++=. ::  .=*+=+++-   .*=.-::.:=::#*(4)*+-: .---##*");
            WriteLine(" =       -. .. +:.    +   .-++*+=..:: -++*+==+*+=. .+=:=-=.   .+==+===== -*    +");
            WriteLine(" #-=-----+**+- +-     +  ..  =--+*+**+++***+**--:::++*+*+**...=.. .. .. .-#--. +");
            WriteLine(" #*+++*+*-:=:- +-     +   .    +#*+(3)--:=*+*+..    :    .-..:=====*-=*####**=.+");
            WriteLine("+=  .....(2).- .. . .*         .=-=+=++=+===:=+*+-. +::::::-:::-:-====-=====-:.:");
            WriteLine("*  --          ==----+    =-:::............. :+***-.+                           ");
            WriteLine("* +**########*##+.       ..  -+*#**=.   +*#-  -+*=: +                           ");
            WriteLine("+ .:=+***+--+=:.=.    :  .    :+***+-::     .-+-.   +                           ");
            WriteLine("==.......::::::.::::.......:----+=+++=. =---+==---==.                           ");

            WriteLine("Welcome to the SAFARI ZONE! For just P500, you can catch all the POKEMON you want in the park!");
            WriteLine("SAFARI ZONE has 4 zones in it. Each zone has different kinds of POKEMON. Use SAFARI BALLs to catch them!");
            Write("Press any key to continue..."); 
            ReadKey(); // waits for key press to continue

            WriteLine("\nChoose which zone you would like to go to!");
            int zoneChoice = 0; // sets zoneChoice variable before entering loop to wait for input
            while (zoneChoice <= 0)
            {
                Write("Enter a zone number: 1-4 >> "); 
                int.TryParse(ReadLine(), out zoneChoice);
                if (zoneChoice > 4)
                {
                    zoneChoice = 0;
                }
            }
            Pokemon pokemon; // makes it easy to reassign subclasses to this object
            // this block of if, else if, and else statements instantiates and
            // assigns pokemon subclass to object instantiated in the previous line
            // zoneChoice is determinant factor in which pokemon you encounter.
            if (zoneChoice == 1)
            {
                Chansey chansey = new Chansey();
                pokemon = chansey; 
            }
            else if (zoneChoice == 2)
            {
                Scyther scyther = new Scyther();
                pokemon = scyther;
            }
            else if (zoneChoice == 3)
            {
                Kangaskhan kangaskhan = new Kangaskhan();
                pokemon = kangaskhan;
            }
            else 
            {
                Tauros tauros = new Tauros();
                pokemon = tauros;
            }
            WriteLine("\nWild " + pokemon.Name + " appeared!");
            pokemon.PokemonASCIIArt(); // this method will display ASCII art of wild pokemon

            do // player interface for wild pokemon encounter
            {
                if (ballAmount == 0) // checks to see if ballAmount is 0 and ends game if so
                {
                    pokemon.Status = "ran away!";
                    WriteLine("The wild {0} " + pokemon.Status, pokemon.Name);
                    break; 
                }
                WriteLine("1: BALL x{0}     2: BAIT\n3: THROW ROCK  4: RUN", ballAmount);
                int userInput = 0; // initializes variable for use in the userInput do loop
                do // userInput do loop
                {
                    Write("What will you do? >> ");
                    int.TryParse(ReadLine(), out userInput); // checks for valid input
                    if (userInput > 4)
                    {
                        userInput = 0;
                    }
                } while (userInput <= 0);

                    switch (userInput) // actions performed based on userInput variable using cases 1-4
                {
                    case 1:
                        {
                            if (usePokeball(pokemon.MaxHP, pokemon.CurrentHP) == true)
                            {
                                WriteLine("\nAll right!\n{0} was caught!", pokemon.Name);
                                WriteLine("New Pokédex Data was added for {0}\n", pokemon.Name);
                                Write("Pokédex: "); pokemon.Pokedex();
                                WriteLine("\n{0} was transferred to BILL'S PC!", pokemon.Name);
                                pokemon.Status = "caught!";
                            }
                            break;
                        }
                    case 2:
                        {
                            throwBait();
                            break;
                        }
                    case 3:
                        {
                            throwRock(pokemon.CurrentHP);
                            if (getThrowRockCounter() > 7)
                            {
                                pokemon.Status = "ran away!";
                                WriteLine("The wild {0} " + pokemon.Status, pokemon.Name);
                                break;
                            }
                            break;
                        }
                    case 4:
                        {
                            bool runTest;
                            runTest = run();
                            if (runTest == true) { pokemon.Status = "ran away!"; }
                            WriteLine("You " + pokemon.Status);
                            break;
                        }
                }
            } while (pokemon.Status != "caught!" && pokemon.Status != "ran away!"); // encounter loop runs until Status attribute meets this criteria
            
            // Safari Zone exit
            if (pokemon.Status == "caught!")
            {
                WriteLine("\nDid you get a good haul? Come again!");
                WriteLine("Thanks for playing!");
            }
            else { WriteLine("\nPA: Ding-dong! Time's up! Your SAFARI GAME is over!"); WriteLine("Thanks for playing!"); }

            ReadKey();
        }
        
        // the following static variables are used here so that they can be accessed by the methods within the PokemonSafariZone class
        static int ballAmount = 6; // amount of pokeballs the user has to play game with
        static int baitRate = 0; // necessary for the throwBait and usePokeball methods
        public static bool usePokeball(int pkmnMaxHP, int pkmnCurrentHP) // encounter input 1: attempts to catch pokemon
        {
            // game mechanics from Pokemon R/B/Y. Source: https://www.dragonflycave.com/mechanics/gen-i-capturing#english
            // modified some mechanics for simplicity of this project
            
            // R2 Factor
            Random rng = new Random();
            int R2 = rng.Next(0, 255);
            R2 -= baitRate; // implementation of baitRate variable from throwBait method

            // HP Factor
            int F1 = (pkmnMaxHP * 255) / 12;
            int F2 = pkmnCurrentHP / 4;
            if (F2 == 0) { F2 = 1; }
            int F = F1 / F2;
            if (F > 255) { F = 255; }
            
            // decrease ballAmount
            ballAmount--;

            // R2 and F comparison
            if (R2 <= F)
            {
                return true;
            }
            else { WriteLine("Aw, it appeared to be caught!"); return false; }
        }

        static int throwRockCounter = 0;
        public static int getThrowRockCounter()
        {
            return throwRockCounter;
        }
        public static int throwRock(int minuend) // encounter input 3: lowers the Pokemon's currentHP to increases catch rate
        {
            int returnInt; 
            double minuendDouble = Convert.ToDouble(minuend);
            returnInt = Convert.ToInt32(minuendDouble - (minuendDouble * 0.1));
            if (returnInt == 0) { returnInt = 1; }
            throwRockCounter++;
            return returnInt;
        }

        public static void throwBait() // encounter input 2: decreases R2 factor in usePokeball method to increases catch rate
        {
            baitRate += 10;
        }

        public static bool run() // encounter input 4: exits encounter and ends game
        {
            return true;
        }
    }
    class Pokemon
    {
        public string Name { set; get; }
        public string Status { set; get; }
        public int MaxHP { set; get; }
        public int CurrentHP { set; get; }
        public Pokemon()
        {
            Name = "MISSINGNO";
            Status = "";
        }
        public virtual void Pokedex()
        {
            Write("");
        }
        public virtual void PokemonASCIIArt()
        {
            Write("");
        }
    }
    class Chansey : Pokemon
    {
        public Chansey()
        {
            Name = "CHANSEY";
            MaxHP = 167;
            CurrentHP = 167;
        }
        public override void Pokedex()
        {
            WriteLine("A rare and elusive POKéMON that is said to bring happiness to those who manage to get it.");
        }
        public override void PokemonASCIIArt()
        {
            base.PokemonASCIIArt();
            WriteLine("        _,, _      ");
            WriteLine("       '     '     ");
            WriteLine("     _/  '_'  \\_   ");
            WriteLine("    '_/       \\_'  ");
            WriteLine("      ' /)(\\  '    ");
            WriteLine("     /         \\   ");
            WriteLine("     \\   ()    /   ");
            WriteLine("      \\,.....,/_   ");
            WriteLine("      /_/   \\_\\    ");
        }
    }
    class Scyther : Pokemon
    {
        public Scyther()
        {
            Name = "SCYTHER";
            MaxHP = 77;
            CurrentHP = 77;
        }
        public override void Pokedex()
        {
            WriteLine("With ninja-like agility and speed, it can create the illusion that there is more than one.");
        }
        public override void PokemonASCIIArt()
        {
            base.PokemonASCIIArt();
            WriteLine("       _.-'______`._,.                               ");
            WriteLine("     ,_, '      `-.`._         /.|                               ");
            WriteLine("   ,',   ____      `-.`.___   / |                               ");
            WriteLine("  /.' ,-'    `-._     `.   | j.  |  /|                           ");
            WriteLine(" // .'   __...._  `'--.. `. ' |   | ' '                           ");
            WriteLine("j/  _.-''       `._,.''.   |  |   |/ '                            ");
            WriteLine("|.-'                    `.'/| |   | /                             ");
            WriteLine("'                        '/ | |   |/                              ");
            WriteLine("                         /  ' '   '                               ");
            WriteLine("                   |.   ` .'/.   /                                ");
            WriteLine("                   | `. ,','.  ,'                                 ");
            WriteLine("                   |   \\.' j.-'/                                  ");
            WriteLine("                   '   '   '. /                                   ");
            WriteLine("                  |          `' - ...__                             ");
            WriteLine("                  |             _..-'                             ");
            WriteLine("                 ,|'      __.-7'   _......____                    ");
            WriteLine("                . |    ,' /   , '`.'__........___`-...__            ");
            WriteLine("                 .    '-'_..' .-''-._         `'''-----`---...___ ");
            WriteLine("                 |____.-','' /      /`.._, ''._.- ''");
            WriteLine("              ,'`| , '   ' |      ., --. ; --| _,-'    ");
            WriteLine("             |   '.| `-.|   `.     ||   /   '`---.....--''.       ");
            WriteLine("             '     `._  |     `+----`._;'.   `-..____..--''       ");
            WriteLine("              `.    | ''|__...-|,|       /     `.                 ");
            WriteLine("                |-..|`-.7    /   '      /   |  '|                 ");
            WriteLine("                ' |' `.||`--'    |      \\   | . |                 ");
            WriteLine("                        |        |       \\  ' | |                 ");
        }
    }
    class Kangaskhan : Pokemon
    {
        public Kangaskhan()
        {
            Name = "KANGASKHAN";
            MaxHP = 95;
            CurrentHP = 95;
        }
        public override void Pokedex()
        {
            WriteLine("The infant rarely ventures out of its mother’s protective pouch until it is 3 years old.");
        }
        public override void PokemonASCIIArt()
        {
            base.PokemonASCIIArt();
            WriteLine("                .'  .'.         .'. ......             ");
            WriteLine("    ...'....     .''.            .'.. ..'. ........    ");
            WriteLine("   .' '.....''.    '.           '.   .`'..'..''.. '    ");
            WriteLine("  ' '..'..'   .....'`.      .''....'''  ......` '.'.   ");
            WriteLine("  .''.   .      ' ' ''    .`^'.    '.'...        ...'  ");
            WriteLine("     ''         ''.' ......     .  '. .'         `..   ");
            WriteLine("      .'..       '..`.. .......'.... '..       .'      ");
            WriteLine("         .'     '.....'`'''...'.. . ...       .'       ");
            WriteLine("          .'    .'''.........     '.'..      .'        ");
            WriteLine("            ... '`.          ...   .      ....         ");
            WriteLine("              .`'              ..        .'.           ");
            WriteLine("              ..    '......     .'      ..`.           ");
            WriteLine("              '  ...'' ..''      ..       `.           ");
            WriteLine("             ..  '..''.'`'''      '       ^..          ");
            WriteLine("           ..'....''...' .''     .'       ^ '     ..'' ");
            WriteLine("        .... '   .......``'........'......^'. ... '..' ");
            WriteLine("      ..'    '                   .'.      .'. .'.'.. ' ");
            WriteLine("      '''.   '                  .'          '''..... ` ");
            WriteLine("      '....  .'                 '           .'. .'.''. ");
            WriteLine("      '....  '''.              ..        .....'  ..''  ");
            WriteLine("     ...`'.  '..'`''..         '.        .....'   ''   ");
            WriteLine("     '... ...'.'. .'.''.......'.'''      '    '..'.    ");
            WriteLine("       .....'. .....  .....''''`   '     ...'..        ");
            WriteLine("                               .''.. .'.....''.        ");
            WriteLine("                               `.''.'.    ''...        ");
            WriteLine("                                     ....'.            ");
        }
    }
    class Tauros : Pokemon
    {
        public Tauros() 
        {
            Name = "TAUROS";
            MaxHP = 80;
            CurrentHP = 80;
        }
        public override void Pokedex()
        {
            WriteLine("When it targets an enemy, it charges furiously while whipping its body with its long tails.");
        }
        public override void PokemonASCIIArt()
        {
            base.PokemonASCIIArt();
            WriteLine("   /\\  /\\                        ");
            WriteLine("   ||  ||                        ");
            WriteLine("   ||__||  _______  ________()   ");
            WriteLine("   /_ _  \\/       \\/_________()  ");
            WriteLine("   |     |        |/__________() ");
            WriteLine("   \\(00) /|       |/             ");
            WriteLine("         /\\_______/\\             ");
            WriteLine("         ||       ||             ");
            WriteLine("         ||       ||             ");
            WriteLine("        /_\\       /_\\            ");
        }
    }
}
