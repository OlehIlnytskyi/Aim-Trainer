using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UIManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private GameObject Background;

    [SerializeField] private RectTransform canvas;

    //----------------------------------------------------

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject health;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject restartMenu;

    //----------------------------------------------------

    private int score;
    private List<Image> hearts;

    private Sprite emptyHeart;
    private Sprite fullHeart;
    public void Initialize()
    {
        status = ManagerStatus.Initializing;
        //
        // Задній фон
        Background.GetComponent<BgMiss>().isEnabled = false;
        Background.GetComponent<RectTransform>().sizeDelta = GetResolution();

        // Швидкість/Рахунок/Менюшки
        scoreText.gameObject.SetActive(false);
        speedText.gameObject.SetActive(false);
        startMenu.SetActive(true);
        restartMenu.SetActive(false);

        health.SetActive(false);
        hearts = health.GetComponentsInChildren<Image>().ToList();

        emptyHeart = Resources.Load<Sprite>("Sprites/EmptyHeart");
        fullHeart = Resources.Load<Sprite>("Sprites/FullHeart");
        //
        status = ManagerStatus.Started;
    }
    public void StartGame()
    {
        Background.GetComponent<BgMiss>().isEnabled = true;

        startMenu.SetActive(false);
        restartMenu.SetActive(false);

        scoreText.gameObject.SetActive(true);
        speedText.gameObject.SetActive(true);
        health.SetActive(true);

        score = 0;
        scoreText.text = "Score - " + score.ToString();
        hearts.ForEach(x => x.sprite = fullHeart);
    }
    public void EndGame()
    {
        Background.GetComponent<BgMiss>().isEnabled = false;

        scoreText.gameObject.SetActive(false);
        speedText.gameObject.SetActive(false);
        health.SetActive(false);

        restartMenu.SetActive(true);
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score - " + score.ToString();
    }
    public void SetSpeed(float speed)
    {
        speedText.text = "Speed - " + speed.ToString("F2") + "t/sec";
    }
    public Vector2 GetResolution()
    {
        return canvas.sizeDelta;
    }
    public void RemoveHeart()
    {
        foreach (Image image in hearts)
        {
            if (image.sprite == fullHeart)
            {
                image.sprite = emptyHeart;
                break;
            }
        }
    }
    public Vector3 RandomBgPosition()
    {
        return new Vector3(Random.Range(-Background.GetComponent<RectTransform>().sizeDelta.x / 2 + 100, Background.GetComponent<RectTransform>().sizeDelta.x / 2 - 100),
                Random.Range(-Background.GetComponent<RectTransform>().sizeDelta.y / 2 + 50, Background.GetComponent<RectTransform>().sizeDelta.y / 2 - 50), -0.01f);
    }
}