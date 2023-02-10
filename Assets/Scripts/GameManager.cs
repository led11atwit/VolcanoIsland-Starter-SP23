using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    //singleton part
    private static GameManager _instance = null;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }


    public Player player;
    public Canvas gameOverCanvas;
    public Text healthText;
    public TMP_Text 

    private Spawner spawner;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Spawner");
        spawner = go.GetComponent<Spawner>();
        onRestartClick();
    }

    public void onRestartClick()
    {
        player.reset();
        spawner.reset();
        healthText.text = "x" + player.maxHealth;
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void updateHealthText(int value)
    {
        healthText.text = "x" + value;
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOverCanvasSwitch(bool state)
    {
        gameOverCanvas.gameObject.SetActive(state);
    }

}
