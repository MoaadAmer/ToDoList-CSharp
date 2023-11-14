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
            seeAllTodos();
            break;
        case "A":
            addTodo();
            break;
        case "R":
            RemoveATodo();
            break;
        case "E":
            exit = true;
            break;
        default:
            Console.WriteLine("Incorrect input\n");
            break;
    }


} while (!exit);

void RemoveATodo()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.\n");
        return;
    }

    bool invalidInput = true;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        seeAllTodos();
        string input = Console.ReadLine();
        int todoIndex;
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Selected index cannot be empty.\n");
            continue;
        }
        else if (int.TryParse(input, out todoIndex) && todoIndex >= 1 && todoIndex <= todos.Count)
        {
            invalidInput = false;
            int realIndex = todoIndex - 1;
            string toDoToBeRemoved = todos[realIndex];
            todos.RemoveAt(realIndex);
            Console.WriteLine($"TODO removed: {toDoToBeRemoved}");
        }
        else
        {
            Console.WriteLine("The given index is not valid.\n");
        }

    } while (invalidInput);


}

void seeAllTodos()
{
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
        showNoTodoMessage();
    }
}

void addTodo()
{


    bool isValidDescription = false;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        string todo = Console.ReadLine();
        if (string.IsNullOrEmpty(todo))
        {
            Console.WriteLine("the description cannot be empty.\n");
        }
        else if (todos.Contains(todo))
        {
            Console.WriteLine("the description must be unique\n");
        }
        else
        {
            isValidDescription = true;
            todos.Add(todo);
            Console.WriteLine($"TODO successfully added: {todo}\n");
        }
    }

    while (!isValidDescription);

}


void showNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.\n");
}