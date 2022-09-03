using UnityEngine;

public class BgMiss : MonoBehaviour
{
    public bool isEnabled;
    public void BackgroundClick()
    {
        if (isEnabled)
        {
            Managers.PlayerManager.Miss();
        }
    }
}