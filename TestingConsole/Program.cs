using TestingConsole;

Dog dog = new Dog();
dog.DateOfBirth = DateTime.Now;

Console.WriteLine(dog.DateOfFirstDeWorming.ToString());
Console.WriteLine(dog.DateOfSecondDeWorming.ToString());
Console.WriteLine(dog.DateOfThirdDeWorming.ToString());
Console.WriteLine(dog.DateOfFirstVaccination.ToString());
