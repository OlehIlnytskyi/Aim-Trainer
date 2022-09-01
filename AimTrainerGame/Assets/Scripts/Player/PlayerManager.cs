using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static int health = 3;

    public static void Miss()
    {
        health--;
        Debug.Log("Health: " + health);

        if (health == 0)
        {
            // Зупинити гру (відключити менеджери я хз)
            // Показати менюшку закінчення гри
        }
    }
}