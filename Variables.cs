using System;
					
public class Program
{
	public static void Main()
	{
		int x = 3;//makes the first half 3
        int y = 6;//makes second half 6
        int z = x*y;//Multiplies those numbers
        		string welcome = "Welcome to the Multiplication station - where we multiply 3 by 6!";//makes a welcome statement

		double half = x/y;//takes 6/3 and makes it 2
		bool is3whole = true;//is a bool
        Console.WriteLine(welcome);//states welcome message
		float egg = 5.456F;//makes a float
      Console.WriteLine("3 Times 6 is = " + z);//18  
		      Console.WriteLine("6/3 is = " + (y/x));//2  
		Console.WriteLine("Is 3 a whole number?  " + is3whole);//true
		Console.WriteLine("number of the day is =  " + egg);//5.456
		egg++;
				Console.WriteLine("number of the day is now  =  " + egg);//6.
		egg+= 5;
				Console.WriteLine("number of the day is now  =  " + egg);//11.stuff
	}
}