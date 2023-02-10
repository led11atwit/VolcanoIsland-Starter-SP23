using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public int maxHealth;

    private int health;
    private float input;

    private Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input == 0) //not moving
        {
            anim.SetBool("isRunning", false);
        } else
        {
            anim.SetBool("isRunning", true);
        }

        if (input > 0)//moving to the right
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else if (input < 0) //moving to the left
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    //called once per physics frame (usually 60fps)
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input * speed,0f);
    }


    public void reset()
    {
        health = maxHealth;
        Vector3 pos = new Vector3(0f, -3.8f, 0f);
        this.transform.position = pos;
        this.gameObject.SetActive(true);
    }

    public void takeDamage(int value)
    {
        health -= value;
        GameManager.instance().updateHealthText(health);

        if (health <= 0)
        {
            //game over condition
            //play a sound/music
            //play a particle system
            //show the game over screen

            //enable the game over canvas
            GameManager.instance().gameOverCanvasSwitch(true);

            //distable the player object
            this.gameObject.SetActive(false);
        }
    }
}
