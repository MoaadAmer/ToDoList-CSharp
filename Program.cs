using System;

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



void seeAllTodos()
{
    if (todos.Count == 0)
    {
        showNoTodoMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
    Console.WriteLine();
}
void addTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        description = Console.ReadLine();
    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
    Console.WriteLine($"TODO successfully added: {description}\n");
}

bool IsDescriptionValid(string? description)
{
    if (string.IsNullOrEmpty(description))
    {
        Console.WriteLine("the description cannot be empty.\n");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine("the description must be unique\n");
        return false;
    }
    return true;
}

void RemoveATodo()
{
    if (todos.Count == 0)
    {
        showNoTodoMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        seeAllTodos();

    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);

}

bool TryReadIndex(out int index)
{
    string input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        index = -1;
        Console.WriteLine("Selected index cannot be empty.\n");
        return false;
    }
    if (int.TryParse(input, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }

    Console.WriteLine("The given index is not valid.\n");
    return false;

}

void showNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.\n");
}

void RemoveTodoAtIndex(int index)
{
    string toDoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine($"TODO removed: {toDoToBeRemoved}");
}