using UnityEngine;

public class TargetManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    [SerializeField] private GameObject targetBatya;

    private float timeToNewTarget;
    private float timer;

    private bool isEnabled;

    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //
        isEnabled = false;
        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {
        timeToNewTarget = 0.8f;
        timer = 0f;
        isEnabled = true;
        Managers.UIManager.SetSpeed((60f / timeToNewTarget) / 60f);
    }
    public void EndGame()
    {
        isEnabled = false;
        foreach (Transform child in targetBatya.transform)
        {
            Destroy(child.gameObject);
        }
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

            target.transform.position = Managers.UIManager.RandomBgPosition();
            target.transform.SetParent(targetBatya.transform, false);
            //target.transform.localScale = new Vector3(Managers.UIManager.GetResolution().x / 1920f - 0.1f, Managers.UIManager.GetResolution().y / 1080f - 0.1f, 1f);

            timer = 0f;
            timeToNewTarget -= 0.002f;
            Managers.UIManager.SetSpeed((60f / timeToNewTarget) / 60f);
        }
    }
}