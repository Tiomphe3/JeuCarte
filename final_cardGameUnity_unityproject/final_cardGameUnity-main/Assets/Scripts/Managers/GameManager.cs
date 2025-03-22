using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI PlayerCountUI;
    public DiscardManager DiscardManager;
    public DrawPileManager DrawPileManager;
    public HandManager HandManager;

    private int playerHealth;
    private int playerXP;
    private int difficulty = 5;

    public OptionsManager OptionsManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public DeckManager DeckManager { get; private set; }

    public TextMeshProUGUI Player1HealthText;
    public TextMeshProUGUI Player2HealthText;

    public TextMeshProUGUI WinText;


    public int DefaultHealth = 100;

    public bool PlayingCard = false;

    public int CurrentPlayer { get => _playerCount; set { _playerCount = value; PlayerCountUI.text = $"Player {value} turn"; } }

    public int NextPlayer { get => (CurrentPlayer + 1) & 1; }

    public int[] PlayersHealth { get; private set; }

    public CharacterStats CurrentSelectionnedCard { get; set; }

    private int _playerCount;

    public void SetPlayerHealth(int idx, int value) {
        value = Mathf.Clamp(value, 0, int.MaxValue);

        PlayersHealth[idx] = value;
        if (idx == 0)
            Player1HealthText.text = $"Player 0 Health: {value}";
        else
            Player2HealthText.text = $"Player 1 Health: {value}";

        if (value <= 0)
        {
            WinText.text = $"Player {(idx + 1) & 1} won!";
            WinText.transform.parent.gameObject.SetActive(true);
            StartCoroutine(GoToMainMenu());
        }
    }

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("mainMenu");
    }

    public void NextTurn(bool b = true)
    {
        CurrentPlayer = NextPlayer;
        if (b) DrawPileManager.DrawCard(HandManager);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        //    DontDestroyOnLoad(gameObject);
            Debug.Log($"Setting Instance to {this}");
            InitializeManagers();

            PlayersHealth =  new int[2];
            SetPlayerHealth(0, DefaultHealth);
            SetPlayerHealth(1, DefaultHealth);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        OptionsManager = GetComponentInChildren<OptionsManager>();
        AudioManager = GetComponentInChildren<AudioManager>();
        DeckManager = GetComponentInChildren<DeckManager>();

        if (OptionsManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/OptionsManager");
            if (prefab == null)
            {
                Debug.Log($"OptionsManager prefab not found");
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                OptionsManager = GetComponentInChildren<OptionsManager>();
            }
        }
        if (AudioManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/AudioManager");
            if (prefab == null)
            {
                Debug.Log($"AudioManager prefab not found");
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                AudioManager = GetComponentInChildren<AudioManager>();
            }
        }
        if (DeckManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/DeckManager");
            if (prefab == null)
            {
                Debug.Log($"DeckManager prefab not found");
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                DeckManager = GetComponentInChildren<DeckManager>();
            }
        }
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    public int PlayerXP
    {
        get { return playerXP; }
        set { playerXP = value; }
    }

    public int Difficulty
    {
        get { return difficulty; }
        set { difficulty = value; }
    }

   /* void Start() {
        AudioManager.Instance.PlayBackgroundSound();
    }*/
}
