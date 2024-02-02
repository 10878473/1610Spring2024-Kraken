// See https://aka.ms/new-console-template for more information
System.Random random = new System.Random(); 

Console.WriteLine("Hello, World!");

Console.WriteLine("Guess a number between 1 and 100!");
int randy = random.Next(1,100);//Creates the random number 
//Console.WriteLine(randy);Unused testing
int guess = Convert.ToInt32(Console.ReadLine());
int tries = 1;
string whatwasit = "IDK YET YOU SHOULD NEVER SEE THIS";// creates variable that will be used later
while (guess != randy)
{
     if (guess > randy)
    {
       whatwasit =  "high";//stores that number is over random number
    } else
    {
        whatwasit = "low";//stores that guess is under random number
    }
    Console.WriteLine("your guess was too " + whatwasit + ", Try again!");//tells you if it was too high or too low
    tries++;//tracks number of attempts
    guess = Convert.ToInt32(Console.ReadLine());//repeats process until you hit the guess

} 
Console.WriteLine("The number was in fact " + randy + "! You got it in only " + Convert.ToInt32(tries) +" Tries!");//Tells you how many times you tried

/*
3. Design and implement a C# program that incorporates the following challenges:

  Challenge 1: Number Guesser

 Create a game where the program generates a random number between 1 and 10. Prompt the user to guess the number. Use a loop to give the user multiple chances to guess. Provide feedback after each guess, indicating if the guess is too high or too low. When the user assumes the correct number, display a congratulatory message and the number of attempts made.

Challenge 2: Favorite Foods

  Create a program that prompts the user to enter their three favorite foods. Use an array to store these food items. Display each item on a new line with a message, such as "I love [food item]!". Use a loop to iterate through the array and print the messages.

4. Use appropriate variable names and include comments to explain your code and the logic behind your solutions in a beginner-friendly manner.

5. Test your program by running it and entering different values to verify that the conditional statements, arrays, and loops work correctly.*/