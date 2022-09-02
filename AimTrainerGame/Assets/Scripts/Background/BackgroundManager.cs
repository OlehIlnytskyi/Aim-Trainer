using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class BackgroundManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private float lUnityPlaneSize;

    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //
        lUnityPlaneSize = 1.0f;
        SetOnCameraSize();

        Managers.BG.GetComponent<BgMiss>().isEnabled = false;
        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {
        Managers.BG.GetComponent<BgMiss>().isEnabled = true;
    }
    public void EndGame()
    {
        Managers.BG.GetComponent<BgMiss>().isEnabled = false;
    }
    private void SetOnCameraSize()
    {
        Camera lCamera = Camera.main;
        
        if (lCamera.orthographic)
        {
            float lSizeY = lCamera.orthographicSize * 2.0f;
            float lSizeX = lSizeY * lCamera.aspect;
            Managers.BG.GetComponent<SpriteRenderer>().size = new Vector2(lSizeX / lUnityPlaneSize, lSizeY / lUnityPlaneSize);
        }
    }
}