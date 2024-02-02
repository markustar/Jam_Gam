using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public event EventHandler OnToggleCandle;
    public event EventHandler OnToggleEnemies;


    [SerializeField] private GameObject[] candles;
    [SerializeField] private GameObject testingCandle;

    public int EnemiesAlive { get; private set; }
    public int CandlesUnlit { get; private set; }
    public bool PlayerLost {  get; private set; }

    public string GameOver_TitleTxt { get; private set; }
    public string GameOver_MessageTxt { get; private set; }

    public enum Difficulty
    {
        None, Test, Beginner, Intermediate, Hard, Insane
    }

    public Difficulty difficulty = Difficulty.None;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
       
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        Health.Instance.OnDead -= Instance_OnDead;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == SceneManager.GetSceneByName("MainMenu"))
        {
           
        }
        //gets the candle references
        else if (scene == SceneManager.GetSceneByName("main"))
        {
            //check to see what the temp difficutly was and set it to that
            if(MainMenu.tempDifficulty == MainMenu.TempDifficulty.Beginner)
            {
                difficulty = Difficulty.Beginner;
            }
            else if(MainMenu.tempDifficulty == MainMenu.TempDifficulty.Intermediate)
            {
                difficulty = Difficulty.Intermediate;
            }
            else if(MainMenu.tempDifficulty == MainMenu.TempDifficulty.Hard)
            {
                difficulty = Difficulty.Hard;
            }
            else if(MainMenu.tempDifficulty == MainMenu.TempDifficulty.Insane)
            {
                difficulty = Difficulty.Insane;
            }

            Health.Instance.OnDead += Instance_OnDead;
          
            
        }

    }




    public void OnSceneUnloaded(Scene scene)
    {

    }

    private void Start()
    {
      
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
            case Difficulty.Test:
                testingCandle.SetActive(true);
                CandlesUnlit++;
                testingCandle.GetComponentInChildren<LitUpCandle>().OnLit += GameManager_OnLit;
                break;
            default:
                break;
        }
    }





    private void InstantiateCandles(int min, int max)
    {
        int spawnedCandles;
        if (min == max)
        {
            for (int i = 0; i < max; i++)
            {
                CandlesUnlit++;
                var candle = candles[i];
                OnToggleCandle?.Invoke(this, EventArgs.Empty);
                candle.SetActive(true);
                candle.GetComponentInChildren<LitUpCandle>().OnLit += GameManager_OnLit;
            }
            return;
        }

        else
            spawnedCandles = UnityEngine.Random.Range(min, max);

        List<int> candlesSpawned = new List<int>();

        for (int i = 0; i <= spawnedCandles; i++)
        {
            int randCandle;
            // Keep generating a new random number until it's unique
            do
            {
                randCandle = UnityEngine.Random.Range(0, candles.Length);
                if (!candlesSpawned.Contains(randCandle))
                {
                    // Add the unique randCandle to the list
                    candlesSpawned.Add(randCandle);
                    break;
                }
            } while (true);

            CandlesUnlit++;
            OnToggleCandle?.Invoke(this, EventArgs.Empty);
            var candle = candles[randCandle];
            candle.SetActive(true);
            candle.GetComponentInChildren<LitUpCandle>().OnLit += GameManager_OnLit;
        }
    }

    private void GameManager_OnLit(object sender, System.EventArgs e)
    {
        CandlesUnlit--;
        OnToggleCandle?.Invoke(this, EventArgs.Empty);
        if (CandlesUnlit <= 0)
        {
            SetTitleTxt("Victory!");
            SetMessageTxt("You have illuminated the darkness of this world!!!\nThank you for playing!");
            GoToGameOver();
        }

    }

    public void GoToGameOver()
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
    public void IncrementEnemies()
    {
        EnemiesAlive++;
        OnToggleEnemies?.Invoke(this, EventArgs.Empty);
    }

    public void DecrementEnemies()
    {
        EnemiesAlive--;
        if(EnemiesAlive <= 0 )
        {
            EnemiesAlive = 0;
        }
        OnToggleEnemies?.Invoke(this, EventArgs.Empty);


    }
}
