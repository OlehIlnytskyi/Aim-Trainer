using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer BG;

    private float bgX;
    private float bgY;

    private float timeToCube = 0.8f;
    private float timer = 0f;
    private void Start()
    {
        bgX = BG.bounds.size.x;
        bgY = BG.bounds.size.y;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToCube)
        {
            GameObject target = Instantiate(Resources.Load<GameObject>("Target"));
            Vector3 pos = new Vector3(Random.Range(-bgX / 2 + 1, bgX / 2 - 1), Random.Range(-bgY / 2 + 0.5f, bgY / 2 - 0.5f), -0.01f);
            target.transform.position = pos;

            timer = 0f;
        }
    }
}