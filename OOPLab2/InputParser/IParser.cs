namespace InputParser
{
    public interface IParser
    {
        ICommand Parse(string input);
    }
}
