using System;

class UndoStack
{
    private string[] stack;
    private int top;

    public UndoStack(int size)
    {
        stack = new string[size];
        top = -1;
    }

    // Push operation
    public void Push(string action)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow!");
            return;
        }

        stack[++top] = action;
        Display();
    }

    // Pop operation (Undo)
    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Nothing to Undo (Stack is Empty)");
            return;
        }

        Console.WriteLine($"Undo: {stack[top]}");
        top--;
        Display();
    }

    // Display current state
    public void Display()
    {
        Console.Write("Current State: ");

        if (top == -1)
        {
            Console.WriteLine("Empty");
            return;
        }

        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        UndoStack editor = new UndoStack(10);

        // Sample Input
        editor.Push("Type A");
        editor.Push("Type B");
        editor.Push("Type C");

        editor.Pop(); // Undo
        editor.Pop(); // Undo
    }
}