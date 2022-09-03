using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
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
                Managers.PlayerManager.Miss();
                Destroy(gameObject);
            }
        }
    }
    public void TargetClick()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(clip, 0.25f);
        Managers.UIManager.AddPoint();
        Destroy(gameObject);
    }
}