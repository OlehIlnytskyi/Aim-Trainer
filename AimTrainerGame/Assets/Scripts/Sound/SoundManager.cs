using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip missSound;

    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //

        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {

    }
    public void EndGame()
    {

    }
    public void PlayHitSound()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(hitSound, 0.25f);
    }
    public void PlayMissSound()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(missSound, 0.25f);
    }
}
