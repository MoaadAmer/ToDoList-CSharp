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
                    Console.WriteLine($"{i + 1}. {todos[i]}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No TODOs have been added yet.");
            }

            break;
        case "A":

            addTodo();


            break;
        case "R":

            if (todos.Count > 0)
            {
                bool invalidInput = true;
                int todoIndex = 0;
                do
                {
                    Console.WriteLine("Select the index of the TODO you want to remove:");
                    for (int i = 0; i < todos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {todos[i]}");
                    }
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Selected index cannot be empty.");
                    }
                    else if (!int.TryParse(input, out todoIndex) ||
                       (int.TryParse(input, out todoIndex) && (todoIndex > todos.Count || todoIndex < 1)))
                    {
                        Console.WriteLine("The given index is not valid.");
                    }
                    else
                    {
                        invalidInput = false;
                    }

                } while (invalidInput);

                todos.RemoveAt(todoIndex - 1);
                Console.WriteLine($"to do number {todoIndex} deleted succesfuly.");
            }
            else
            {
                Console.WriteLine("No TODOs have been added yet.");
            }
            break;
        case "E":
            exit = true;
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }


} while (!exit);



void addTodo()
{


    bool isValidDescription = false;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        string todo = Console.ReadLine();
        if (string.IsNullOrEmpty(todo))
        {
            Console.WriteLine("the description cannot be empty.");
        }
        else if (todos.Contains(todo))
        {
            Console.WriteLine("the description must be unique");
        }
        else
        {
            isValidDescription = true;
            todos.Add(todo);
            Console.WriteLine($"TODO successfully added: {todo}");
        }
    }

    while (!isValidDescription);

}