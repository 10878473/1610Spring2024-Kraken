// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("What's the current Temperature in Celsius?");
int temp = Convert.ToInt32(Console.ReadLine());//Converts string to int
if (temp > 30)
{
    Console.WriteLine("Stay hydrated and dont be in the sun too long!");
} else
{
    Console.WriteLine("Enjoy the pleasant weather!");
}
Console.WriteLine("What are was your last exam score as a percentage");
float score = float.Parse(Console.ReadLine());//converts string to float

//This block of code assigns a grade based of the number of score.
if ((score > 90 && score < 100))
{
    Console.WriteLine("You got an A!");
}else if (score > 80 && score < 90)
{
    Console.WriteLine("You got an B");

}else if (score > 70 && score < 80)
{
    Console.WriteLine("You got an C");

}else if (score > 60 && score < 70)
{
    Console.WriteLine("You got an D");

}else if (score > 0 && score < 60)
{
    Console.WriteLine("You Got an F!");

}else
{
    Console.WriteLine("Sorry, unsure of results, Try Again");
}