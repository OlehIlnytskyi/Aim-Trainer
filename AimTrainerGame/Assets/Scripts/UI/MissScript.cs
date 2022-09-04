using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(KillYourself());
    }
    private IEnumerator KillYourself()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
