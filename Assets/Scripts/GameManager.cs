using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Spawner spawner;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Spawner");
        spawner = go.GetComponent<Spawner>();
        player.reset();
        spawner.reset();
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void onRestartClick()
    {

    }

    public void gameOverCanvasSwitch(bool state)
    {
        gameOverCanvas.gameObject.SetActive(state);
    }

}
