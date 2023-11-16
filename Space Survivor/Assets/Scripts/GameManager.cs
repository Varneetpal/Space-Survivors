using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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



    private int kills;
    [SerializeField] private int roundLengthInKills = 10;

    [SerializeField] private float healthUpgradeRate = 1.5f;
    [SerializeField] private float damageUpgradeRate = 1.5f;
    [SerializeField] private float fireRateUpgradeRate = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerFinalForm);
        DontDestroyOnLoad(player);
        kills = 0;
        if (mainMenu){
            
            mainMenu.SetActive(true);
          }

        GameObject.DontDestroyOnLoad(this.gameObject);
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
            kills = 0;
            SceneManager.LoadScene("shop");
        }
    }

    public void increaseKills()
    {
        kills += 1;
    }


    public void loadShooterScene()
    {
        player.GetComponent<PlayerController>().switchDecay();
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void upgradeHealth()
    {
        player.GetComponent<PlayerController>().switchDecay();
        player.GetComponent<PlayerController>().increaseHealth(healthUpgradeRate);
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void upgradeFireRate()
    {
        player.GetComponent<PlayerController>().switchDecay();
        player.GetComponent<Shooting>().increaseFireRate(fireRateUpgradeRate);
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void upgradeCharacter()
    {
        if(playerLevel == 1)
        {
            Destroy(player);
            player = Instantiate(playerUpgrade1);
            DontDestroyOnLoad(player);
        }
        else if (playerLevel == 2)
        {
            Destroy(player);
            player = Instantiate(playerUpgrade2);
            DontDestroyOnLoad(player);
        }
        else if (playerLevel == 3)
        {
            Destroy(player);
            player = Instantiate(playerFinalForm);
            DontDestroyOnLoad(player);
        }

        //to do - else game handles max character level
    }

}
