// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("What's the current Temperature in Celsius?");
int temp = Convert.ToInt32(Console.ReadLine());//Converts string to int
if (temp > 30 )
{
    Console.WriteLine("Stay hydrated and dont be in the sun too long!");
} else if (temp <0 && temp > -40)
{
    Console.WriteLine("Dress warmly!");
} else if(temp < -40)
{
    Console.WriteLine("DO NOT GO OUTSIDE ITS TOO DANG COLD!");
} else
{
    Console.WriteLine("Enjoy your nice weather!");
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
Console.WriteLine("Also, What is your favorite Subject? lowercase only");
string favclass = Console.ReadLine();
switch (favclass)
{
    case "math":
        Console.WriteLine("I suggest you study hard and do homework on time");
        break;
    case "english":
        Console.WriteLine("I suggest you read lots and make lots of drafts");
        break;
    case "art":
        Console.WriteLine("Be confident in your lines and draw a lot!");
        break;
    
    default:
        Console.WriteLine("I didn't think about that! Good luck!");
        break;
}

Console.WriteLine("Good Night!");
/*  Challenge 1: Weather Adviser

   Enhance the "Temperature Adviser" program from the lab assignment. Modify the existing 
   code to check for different temperature ranges and provide more specific advice based on the 
   conditions. Customize the messages based on the temperature conditions to provide detailed weather 
   advice. For example, if the temperature is below 10 degrees Celsius, suggest wearing warm clothing. 
   I recommend carrying a light jacket if the temperature is between 10 and 20 degrees Celsius.

   Challenge 2: Subject Selector

   Expand the "Exam Grader" program from the lab assignment. In addition to displaying the grade 
   based on the exam score, prompt the user to enter their favorite subject. Use a switch statement
    to display a message related to their chosen topic. For example, if the issue is "Math," show a 
    message encouraging them to keep practicing and exploring mathematical concepts. Customize the
     messages for different subjects and make it fun and encouraging.*/