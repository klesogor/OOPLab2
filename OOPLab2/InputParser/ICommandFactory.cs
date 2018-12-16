namespace InputParser
{
    public interface ICommandFactory
    {
        ICommand Create(string command, params string[] args);
    }
}
