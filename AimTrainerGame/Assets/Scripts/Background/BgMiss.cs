using UnityEngine;

public class BgMiss : MonoBehaviour
{
    public bool isEnabled;
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            Managers.PlayerManager.Miss();
        }
    }
}