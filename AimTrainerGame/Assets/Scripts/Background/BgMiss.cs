using UnityEngine;

public class BgMiss : MonoBehaviour
{
    public bool isEnabled;
    public void BackgroundClick()
    {
        if (isEnabled)
        {
            GameObject miss = Instantiate(Resources.Load<GameObject>("Miss"));
            miss.transform.SetParent(Managers.UIManager.GetBatya(), false);
            miss.transform.position = Input.mousePosition;

            Managers.PlayerManager.Miss();
            Managers.SoundManager.PlayMissSound();
        }
    }
}