public interface IGameController
{
    void ProcessCommand(string input);

    string GenerateFinalResultStats();
}