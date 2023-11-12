bool exit = false;
List<string> todos = new List<string>();
do
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "S":
            if (todos.Count > 0)
            {
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{todos[i]}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no todos to show");
            }

            break;
        case "A":
            string todo = "something";
            do
            {
                if (string.IsNullOrEmpty(todo))
                {
                    Console.WriteLine("the description cannot be empty.");
                }
                else if (todos.Contains(todo))
                {
                    Console.WriteLine("the description must be unique");
                }
                Console.WriteLine("Enter a todo description:");
                todo = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(todo) || todos.Contains(todo));
            todos.Add(todo);
            Console.WriteLine($"todo successfuly added :{todo}");
            break;
        case "R":
            if (todos.Count > 0)
            {
                Console.WriteLine("Enter the todo number you would like to remove");
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{todos[i]}");
                }
                Console.WriteLine();

              
                int todoNumber;
                while (!int.TryParse(Console.ReadLine(), out todoNumber))
                {
                    Console.WriteLine("Invalid choice, please enter a number.");
                }
                todos.RemoveAt(todoNumber - 1);
                Console.WriteLine($"to do number {todoNumber} deleted succesfuly.");
            }
            else
            {
                Console.WriteLine("The todos list is empty.");
            }
            break;
        case "E":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }


} while (!exit);
