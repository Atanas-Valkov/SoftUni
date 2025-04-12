using System.ComponentModel;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
/*
Arrays, Databases, Methods
Swap:Arrays:Methods
Exercise:Databases
 */
namespace P05E10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = " ";
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] arguments = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string operation = arguments[0];
                string lessonTitle = arguments[1];

                if (operation == "Add")
                {
                    Add(arguments, input, lessonTitle);
                }
                else if (operation == "Insert")
                {
                    Insert(arguments, input, lessonTitle);
                }
                else if (operation == "Remove")
                {
                    Remove(input, lessonTitle);
                }
                else if (operation == "Swap")
                {
                    Swap(arguments, input, lessonTitle);
                }
                else if (operation == "Exercise")
                {

                    Exercise(input, lessonTitle);
                }
            }

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{input[i]}");
            }
        }
        private static void Add(string[] arguments, List<string> input, string lessonTitle)
        {
            if (!input.Contains(lessonTitle))
            {
                input.Add(lessonTitle);
            }
        }
        private static void Insert(string[] arguments, List<string> input, string lessonTitle)
        {
            int index = int.Parse(arguments[2]);
            if (!input.Contains(lessonTitle))
            {
                input.Insert(index, lessonTitle);
            }
        }
        private static void Remove(List<string> input, string lessonTitle)
        {
            if (input.Contains(lessonTitle))
            {
                input.Remove(lessonTitle);
                if (input.Contains(lessonTitle + "-Exercise"))
                {
                    input.Remove(lessonTitle + "-Exercise");
                }
            }
        }
        private static void Swap(string[] arguments, List<string> input, string lessonTitle)
        {
            string lessonTitle2 = arguments[2];
            if (input.Contains(lessonTitle) && input.Contains(lessonTitle2))
            {
                int indexLessonTitle = input.IndexOf(lessonTitle);
                int indexLessonTitle2 = input.IndexOf(lessonTitle2);
                input[indexLessonTitle2] = lessonTitle;
                input[indexLessonTitle] = lessonTitle2;

                if (input.Contains(lessonTitle + "-Exercise") || input.Contains(lessonTitle2 + "-Exercise"))
                {
                    if (input.Contains(lessonTitle + "-Exercise"))
                    {
                        input.Insert(indexLessonTitle + 1, lessonTitle + "-Exercise");
                        input.RemoveAt(indexLessonTitle + 1);
                    }
                    else
                    {
                        int newIndexLessonTitle2 = input.IndexOf(lessonTitle2);
                        int newIndexLessonTitle = input.IndexOf(lessonTitle);
                        input.Insert(newIndexLessonTitle2 + 1, lessonTitle2 + "-Exercise");
                        input.RemoveAt(newIndexLessonTitle + 2);
                    }
                }
            }
        }
        private static void Exercise(List<string> input, string lessonTitle)
        {
            string lessonTitleExercise = lessonTitle + "-Exercise";
            if (input.Contains(lessonTitle))
            {
                if (!input.Contains(lessonTitleExercise))
                {
                    int index = input.IndexOf(lessonTitle);
                    input.Insert(index + 1, lessonTitleExercise);
                }
            }
            else
            {
                input.Add(lessonTitle);
                input.Add(lessonTitleExercise);
            }
        }
    }
}