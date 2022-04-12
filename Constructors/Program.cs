// C# Program to illustrate calling
// a Default constructor
using System;
namespace DefaultConstructorExample
{

	class Geek
	{

		int num;
		string name;

		// this would be invoked while the
		// object of that class created.
		Geek()
		{
			Console.WriteLine("Constructor Called");
		}

		// Main Method
		public static void Main()
		{

			// this would invoke default
			// constructor.
			Geek geek1 = new Geek();

			// Default constructor provides
			// the default values to the
			// int and object as 0, null
			// Note:
			// It Give Warning because
			// Fields are not assign
			Console.WriteLine(geek1.name);
			Console.WriteLine(geek1.num);
		}
	}
}
