using UnityEngine;

public class Background : MonoBehaviour
{
    public float lUnityPlaneSize = 1.0f; // 10 for a Unity3d plane

    private void Awake()
    {
        Update();
    }
    void Update()
    {
        Camera lCamera = Camera.main;

        if (lCamera.orthographic)
        {
            float lSizeY = lCamera.orthographicSize * 2.0f;
            float lSizeX = lSizeY * lCamera.aspect;
            GetComponent<SpriteRenderer>().size = new Vector2(lSizeX / lUnityPlaneSize, lSizeY / lUnityPlaneSize);
        }
    }
    private void OnMouseDown()
    {
        PlayerManager.Miss();
    }
}