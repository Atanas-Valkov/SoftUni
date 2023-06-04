
   

  string[] inputArray = Console.ReadLine().Split();
  
  int[] numbers  = new int[inputArray.Length];

for (int i = 0; i < inputArray.Length; i++)
{
    numbers[i] = int.Parse(inputArray[i]);
}



  for (int i = 0; i < numbers.Length; i++)
  {
      bool isTop = true;
      for (int j = i + 1 ; j < numbers.Length; j++)
      {
          if (numbers[i] <= numbers[j])
          {
              isTop = false;
              break;
          }
      }
      if (isTop)
      {
          Console.Write($"{numbers[i]} ");
      }

  }






