  
  
  
  int wagons = int.Parse(Console.ReadLine());
  
  int[] numberOfPeople = new int[wagons] ;
  int sum = 0;
  for (int i = 0; i < numberOfPeople.Length  ; i++)
  { 
      int passengers = int.Parse(Console.ReadLine());

    numberOfPeople[i] = passengers ;

     
  }
  Console.WriteLine(string.Join(" ", numberOfPeople));
  Console.WriteLine(numberOfPeople.Sum());
 
