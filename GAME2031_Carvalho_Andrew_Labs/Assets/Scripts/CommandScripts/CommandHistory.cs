using System.Collections.Generic;

public class CommandHistory 
{
    private List<ICommand> commandHistory = new();

    private int currentIndex = -1;

    public void ExecuteCommand(ICommand command)
    {
        if (currentIndex < commandHistory.Count - 1)
        {
            commandHistory.RemoveRange(currentIndex + 1, commandHistory.Count - currentIndex - 1);
        }

        command.Execute();
        commandHistory.Add(command);
        currentIndex++;
    }

    public void Undo()
    {
        if (currentIndex < 0) return;

        commandHistory[currentIndex].Undo();
        currentIndex--;

    }

    public void Redo()
    {
        if (currentIndex + 1 >= commandHistory.Count) return;

        currentIndex++;
        commandHistory[currentIndex].Execute();
    }
}
