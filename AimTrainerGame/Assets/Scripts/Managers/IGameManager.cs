public interface IGameManager
{
    ManagerStatus status { get; }

    void Initialize();
    void StartGame();
    void EndGame();
}
public enum ManagerStatus
{
    Shutdown,
    Initializing,
    Started
}