// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Security.Principal;

Console.WriteLine("Hello, User!");

int hp = 20;
double warningzone = 4.5;
bool areweok = true;
string statement = "Your hp value is currently:";


Console.WriteLine("Your spaceship is heading into the asteroid field, Think Fast! Left or right?");
Console.WriteLine(statement + hp);
string response = Console.ReadLine();
if (response == "Left")
{
    Console.WriteLine("Scrape!");
     hp -= 5;
     Console.WriteLine(statement + hp);
     Console.WriteLine ("You are ok");
}else if (response == "Right")
{
    hp -= 18;
    if (hp < warningzone){
        Console.WriteLine("Bang! SKRRRT! SHRRRKKRKRKRK!");
        areweok = false;
        Console.WriteLine(statement + hp);
        Console.WriteLine("YOU ARE NOT OK MAKE EVASIVE MANUEVERS");
    }
}