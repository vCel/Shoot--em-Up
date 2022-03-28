using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;
    public static bool isPaused = false;

    SpriteRenderer UISprites;

    public GameObject BottomUI;
    public Image UltMeter;
    public GameObject GameOverMenu;
    public GameObject WinMenu;
    public GameObject PauseMenu;
    public Sprite[] ultBarSprites = new Sprite[2];
    public float xBound = 30;
    public float zBound = 35;
    public int Lives = 3;
    public float ultimateCharge = 0f;
    public int enemyCount = 0;

    private int previousLives;

    public GameObject Player;

    // Awake Checks - Singleton setup
    void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        Screen.SetResolution(768, 1024, true); // Set resolution
        previousLives = Lives;
    }

    void Start()
    {
        Time.timeScale = 1f;
        UISprites = GetComponent<SpriteRenderer>();
        InvokeRepeating("PassiveUltCharge", 2f, 2f); // Generates 1% Ult Charge every 2 seconds.
    }

    void Update()
    {
        // Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PauseMenu.GetComponent<GameOverScript>().Resume();
            }
            else
            {
                PauseMenu.GetComponent<GameOverScript>().Pause();
            }
        }
        // Checks if dead
        if (Lives < previousLives)
        {
            Debug.Log(previousLives + " |  " + Lives);
            previousLives = Lives;
            TriggerDeath();
        }

        // Adjusts the heath UI
        foreach (Transform child in BottomUI.transform)
        {
            if (int.Parse(child.name.Substring(child.name.Length - 1)) <= Lives)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        ultBar();
    }

    // Function for dying
    public void TriggerDeath()
    {
        Invoke("PlayerDeath", 4);
    }

    // Function for winning
    public void TriggerWin()
    {
        WinMenu.SetActive(true);
    }

    private void PlayerDeath()
    {
        if (Lives > 0)
        {
            StartCoroutine(InvincibleTime());
        }
        else
        {
            Time.timeScale = 0f;
            GameOverMenu.SetActive(true);
        }
    }

    // Charges ult charge through time
    private void PassiveUltCharge()
    {
        if (ultimateCharge < 100)
        {
            ultimateCharge++;
        }
        
    }

    // Adjusts ult bar UI
    private void ultBar()
    {
        UltMeter.fillAmount = ultimateCharge / 100f;
        UltMeter.sprite = ultimateCharge >= 100f ? ultBarSprites[1] : ultBarSprites[0];
    }

    // Add lives
    public void addLives()
    {
        Lives++;
        previousLives++;
    }

    // Invincibility timer
    public IEnumerator InvincibleTime()
    {
        GameObject NewPlayer = Instantiate(Player, Player.transform.position, Player.transform.rotation);
        SpriteRenderer PlayerSpriteRenderer = NewPlayer.GetComponent<SpriteRenderer>();
        PlayerSpriteRenderer.color = Color.cyan;
        NewPlayer.GetComponent<PlayerScript>().isInvincible = true;
        yield return new WaitForSeconds(3f);
        PlayerSpriteRenderer.color = Color.white;
        NewPlayer.GetComponent<PlayerScript>().isInvincible = false;
    }
}
