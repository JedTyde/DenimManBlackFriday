using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed {  get; private set; }

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI promoCode;
    public AudioSource points;
    public AudioSource gameOverA;
    public Button retryButton;
    public Button menu;

    private Player player;
    private Spawner spawner;

    private float score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance != this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0f;

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        promoCode.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        promoCode.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);

        if (score <= 500)
        {
            promoCode.text = "Keep trying to get more rewards!";
        }
        if (score > 500 && score <= 1000)
        {
            promoCode.text = "Promo code:\nBuenDia0222_5K";
        }
        if (score > 1000 && score <= 1500)
        {
            promoCode.text = "Promo code:\nGame0222_10X";
        }
        if (score > 1500 && score <= 2000)
        {
            promoCode.text = "Promo code:\nBD_Game15Plus";
        }
        if (score > 2000 && score <= 2500)
        {
            promoCode.text = "Promo code:\nBuenDia20_XP";
        }
        if (score > 2500 && score <= 3000)
        {
            promoCode.text = "Promo code:\nGameBD25_Pro";
        }
        if (score > 3000)
        {
            promoCode.text = "Promo code:\nBD0222_30Max";
        }
        gameOverA.Play();
        UpdateHiscore();
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime; //Si se quiere reducir no poner gamespeed
        //scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        //if (score < 500)
        //{
        //    scoreText.text = "0%";
        //}
        //if (score > 499 && score < 1000)
        //{
        //    scoreText.text = "5%";
        //}
        //if (score > 999 && score < 1500)
        //{
        //    scoreText.text = "10%";
        //}
        //if (score > 1499 && score < 2000)
        //{
        //    scoreText.text = "15%";
        //}
        //if (score > 1999 && score < 2500)
        //{
        //    scoreText.text = "20%";
        //}
        //if (score > 2499 && score < 3000)
        //{
        //    scoreText.text = "25%";
        //}
        //if (score > 2999)
        //{
        //    scoreText.text = "30%";
        //}

        if (((int)score % 100 == 0) && (score >= 100))
        {
            //Debug.Log((int)score);
            points.Play();
        }
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void UpdateHiscore()
    {
         float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }
}
