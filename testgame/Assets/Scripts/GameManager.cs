using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private GameObject[] candles;

    private int candlesUnlit;
    public bool PlayerLost {  get; private set; }

    public string GameOver_TitleTxt { get; private set; }
    public string GameOver_MessageTxt { get; private set; }

    private enum Difficulty
    {
        Test, Beginner, Intermediate, Hard, Insane
    }

    [SerializeField] private Difficulty difficulty = Difficulty.Beginner;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Health.Instance.OnDead += Instance_OnDead;
        SpawnCandles();
    }

    private void Instance_OnDead(object sender, Health.OnDeadEventArgs e)
    {
        PlayerLost = true;
        SetTitleTxt(e.title);
        SetMessageTxt(e.message);
        GoToGameOver();
    }


    private void SpawnCandles()
    {
        int min, max;
        switch (difficulty)
        {
            case Difficulty.Test:
                min = 1;
                max = 2;
                InstantiateCandles(min, max);
                break;
            case Difficulty.Beginner:
                min = 5;
                max = 8;
                InstantiateCandles(min, max);
                break;
            case Difficulty.Intermediate:
                min = 8;
                max = 15;
                InstantiateCandles(min, max);
                break;
            case Difficulty.Hard:
                min = 20;
                max = 29;
                InstantiateCandles(min, max);
                break;
            case Difficulty.Insane:
                min = candles.Length;
                max = candles.Length;
                InstantiateCandles(min, max);
                break;
            default:
                break;
        }
    }

    private void InstantiateCandles(int min, int max)
    {
        int spawnedCandles;
        if (min == max)
            spawnedCandles = max;
        else
            spawnedCandles = Random.Range(min, max);

        List<int> candlesSpawned = new List<int>();

        for (int i = 0; i <= spawnedCandles; i++)
        {
            int randCandle;
            // Keep generating a new random number until it's unique
            do
            {
                randCandle = Random.Range(0, candles.Length);
                if (!candlesSpawned.Contains(randCandle))
                {
                    // Add the unique randCandle to the list
                    candlesSpawned.Add(randCandle);
                    break;
                }
            } while (true);

            candlesUnlit++;
            var candle = candles[randCandle];
            candle.SetActive(true);
            candle.GetComponentInChildren<LitUpCandle>().OnLit += GameManager_OnLit;
        }
    }

    private void GameManager_OnLit(object sender, System.EventArgs e)
    {
        candlesUnlit--;
        if(candlesUnlit <= 0)
        {
            SetTitleTxt("Victory!");
            SetMessageTxt("You have illuminated the darkness of this world!!!\nThankyou for playing!");
            GoToGameOver();
        }

    }

    private void GoToGameOver()
    {

        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetTitleTxt(string title)
    {
        GameOver_TitleTxt = title;
    }

    public void SetMessageTxt(string message)
    {
        GameOver_MessageTxt = message;
    }
}
