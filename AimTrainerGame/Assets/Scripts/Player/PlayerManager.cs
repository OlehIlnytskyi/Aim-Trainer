using UnityEngine;

[RequireComponent(typeof(Managers))]
public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private static int health;


    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //

        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {
        health = 3;
    }
    public void EndGame()
    {

    }
    public void Miss()
    {
        health--;
        Debug.Log("Health: " + health);

        if (health == 0)
        {
            gameObject.GetComponent<Managers>().EndGame();
            // Показати менюшку закінчення гри
        }
    }
}