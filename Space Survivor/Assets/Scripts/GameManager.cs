using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject mainMenu;


    public GameObject player;

    private int playerLevel = 0;
    public GameObject playerDefualt;
    public GameObject playerUpgrade1;
    public GameObject playerUpgrade2;
    public GameObject playerFinalForm;

    public Text scoreText;

    public GameObject pauseScreen;
    private bool paused;

    public int score = 0;
    public int kills = 0;
    private int gold = 0;
    [SerializeField] private int roundLengthInKills = 10;

    [SerializeField] private float healthUpgradeRate = 1.5f;
    [SerializeField] private float fireRateUpgradeRate = 0.5f;
    [SerializeField] public int goldWorth = 5;


    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerDefualt);
        DontDestroyOnLoad(player);
        player.SetActive(false);
        //PlayerAudioManager.instance.PlaySound("GameplayMusic");
        if (mainMenu){
            mainMenu.SetActive(true);
        }

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (kills != 0 && kills % roundLengthInKills == 0)
        {
            player.GetComponent<PlayerController>().switchDecay();
            player.GetComponent<PlayerController>().resetHealthAndPosition();
            SceneManager.LoadScene("shop");
            kills = 0;
        }
    }

    public void restartGame()
    {
        Destroy(player);
        kills = 0;
        gold = 0;
        playerLevel = 0;
        player = Instantiate(playerDefualt);
        loadShooterScene();
    }

    public void setScoreText()
    {
        scoreText.text = "Gold: " + gold.ToString() + "        PowerLevel: " + playerLevel.ToString();

    }

    public void activtePlayer()
    {
        player.SetActive(true);
    }

    public void increaseKills()
    {
        kills += 1;
        score++;
    }

    public void increaseGold(int amount)
    {
        gold += amount;
        setScoreText();
    }


    public void loadShooterScene()
    {
        setScoreText();
        player.GetComponent<PlayerController>().switchDecay();
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void upgradeHealth()
    {
        if (gold >= 5)
        {
            gold -= 5;
            setScoreText();
            player.GetComponent<PlayerController>().increaseHealth(healthUpgradeRate);
            PlayerAudioManager.instance.PlaySound("UpgradeSound");
            setScoreText();
        }

    }

    public void upgradeFireRate()
    {
        if(gold >= 5) {
            gold -= 5;
            setScoreText();
            player.GetComponent<Shooting>().increaseFireRate(fireRateUpgradeRate);
            PlayerAudioManager.instance.PlaySound("UpgradeSound");
            setScoreText();
        }
    }

    public void upgradeCharacter()
    {
        if(gold >= 10)
        {
            gold -= 10;
            playerLevel += 1;
            if (playerLevel == 1)
            {
                Destroy(player);
                player = Instantiate(playerUpgrade1);
                player.GetComponent<PlayerController>().switchDecay();
                PlayerAudioManager.instance.PlaySound("PowerUp");
                DontDestroyOnLoad(player);
            }
            else if (playerLevel == 2)
            {
                Destroy(player);
                player = Instantiate(playerUpgrade2);
                player.GetComponent<PlayerController>().switchDecay();
                PlayerAudioManager.instance.PlaySound("PowerUp");
                DontDestroyOnLoad(player);
            }
            else if (playerLevel == 3)
            {
                Destroy(player);
                player = Instantiate(playerFinalForm);
                player.GetComponent<PlayerController>().switchDecay();
                PlayerAudioManager.instance.PlaySound("PowerUp");
                DontDestroyOnLoad(player);
            }
            setScoreText();

        }
        //to do - else game handles max character level
    }

}
