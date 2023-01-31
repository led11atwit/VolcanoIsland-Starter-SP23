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
    private Spawner spawner;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Spawner");
        spawner = go.GetComponent<Spawner>();
        player.reset();
        spawner.reset();
    }

}
