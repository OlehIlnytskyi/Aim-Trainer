using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private static int score = 0;
    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    private void OnMouseDown()
    {
        score++;
        scoreText.text = "Score - " + score.ToString();
        Destroy(this.gameObject);
    }
}
