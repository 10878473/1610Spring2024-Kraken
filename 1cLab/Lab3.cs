// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Lets create a number pyramid. How many lines in the number pyramid?");

int psize = Convert.ToInt32(Console.ReadLine());//stores int for size of pyramid
Console.WriteLine("Beginning:");
for (int i = 1; i < (psize+1); i++)
{
    //This will run the amount of tmes that is said for the pyramid - ex 5 times will run.
    Console.WriteLine("This is row "+i);
    int ns_on_pyramid = 0; 
    for (int b = 1; b < (i+1); b++)
    {
        ns_on_pyramid++;
    }
    Console.WriteLine(i*ns_on_pyramid);
}


/*3. Design and implement a C# program that incorporates the following challenge:

   Challenge: Number Pyramid
   Create a program that prints a number pyramid pattern using nested loops and conditional statements. The program should prompt the user to enter a positive integer representing the number of rows in the pyramid. Each row should contain numbers in ascending order, starting from 1 and incrementing by 1. Use nested loops to achieve the pattern. For example, if the user enters 5, the program should output the following pyramid:
   
       1
       22
       333
       4444
       55555
   
4. Use appropriate variable names and include comments to explain your code and the logic behind your solution in a beginner-friendly manner.
5. Test your program with different input values to ensure the number pyramid pattern is generated correctly.
6. If you encounter any difficulties or errors while writing the code, refer to the provided resources or seek assistance from a teacher, parent, or older sibling.
7. After completing your script, save the file with an appropriate name and the .cs extension.
8. Submit your completed C# script file (.cs) as the deliverable for this lab assignment.*/