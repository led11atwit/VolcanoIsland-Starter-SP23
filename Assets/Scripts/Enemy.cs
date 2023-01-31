using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    public float minSpeed;
    public float maxSpeed;

    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //player takes damage
            GameObject go = col.gameObject;

            Player player = go.GetComponent<Player>();

            player.takeDamage(damage);

            //player the fireball explosion vfx

            //remove the fireball from the scene
            Destroy(this.gameObject);
        }
    }
}
