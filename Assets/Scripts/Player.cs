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
    }

    //called once per physics frame (usually 60fps)
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input * speed,0f);
    }


    public void reset()
    {
        health = maxHealth;
        Vector3 pos = new Vector3(0f, -2.5f, 0f);
        this.transform.position = pos;
        this.gameObject.SetActive(true);
    }

    public void takeDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            //game over condition
            //play a sound/music
            //play a particle system
            //show the game over screen
            this.gameObject.SetActive(false);
        }
    }
}
