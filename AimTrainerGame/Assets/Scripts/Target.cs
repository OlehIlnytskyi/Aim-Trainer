using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector3 scale;
    private bool growing;
    private void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 1);
        scale = transform.localScale;

        growing = true;
    }
    private void Update()
    {
        if (growing)
        {
            scale.x += Time.deltaTime / 2.5f;
            scale.y = scale.x;
            transform.localScale = scale;

            if (scale.x >= 1)
            {
                growing = false;
            }
        }
        else
        {
            scale.x -= Time.deltaTime / 2.5f;
            scale.y = scale.x;
            transform.localScale = scale;

            if (scale.x <= 0)
            {
                GameObject miss = Instantiate(Resources.Load<GameObject>("Miss"));
                miss.transform.SetParent(Managers.UIManager.GetBatya(), false);
                miss.transform.position = transform.position;

                Managers.PlayerManager.Miss();
                Managers.SoundManager.PlayMissSound();
                Destroy(gameObject);
            }
        }
    }
    public void TargetClick()
    {
        Managers.SoundManager.PlayHitSound();
        Managers.UIManager.AddPoint();
        Destroy(gameObject);
    }
}