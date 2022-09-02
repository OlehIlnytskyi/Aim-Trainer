using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private float timeToNewTarget;
    private float timer;

    private bool isEnabled;

    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //
        timeToNewTarget = 0.8f;
        timer = 0f;
        isEnabled = false;
        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {
        isEnabled = true;
    }
    public void EndGame()
    {
        isEnabled = false;
        timer = 0f;
    }
    void Update()
    {
        if (!isEnabled)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= timeToNewTarget)
        {
            GameObject target = Instantiate(Resources.Load<GameObject>("Target"));
            Vector3 pos = new Vector3(Random.Range(-Managers.BG.bounds.size.x / 2 + 1, Managers.BG.bounds.size.x / 2 - 1),
                Random.Range(-Managers.BG.bounds.size.y / 2 + 0.5f, Managers.BG.bounds.size.y / 2 - 0.5f), -0.01f);
            target.transform.position = pos;

            timer = 0f;
        }
    }
}