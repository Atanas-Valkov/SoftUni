

 string[] text = Console
     .ReadLine()
     .Split()
     .ToArray();

 for (int i = 0; i < text.Length / 2 ; i++)
 {
   string firstElement = text[i];
   string lastElement = text[text.Length - 1 - i ];

   text[i] = lastElement;
  text[text.Length - 1 - i ]= firstElement;
 }
 Console.WriteLine(string.Join(" ", text));



    // string[] text = Console.ReadLine().Split();
    //
    //for (int i = text.Length - 1; i >= 0; i--)
    //{
    //    Console.Write($"{text[i]} ");
    //}