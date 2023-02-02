using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    public bool scored;
    GameObject player;
    private float posMin = -12;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posMin)
        {
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.x < player.transform.position.x)
            {
                if (!scored)
                {
                    scored = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 5f);
                    GetComponent<Rigidbody2D>().isKinematic = false;
                    GetComponent<Rigidbody2D>().AddTorque(-50);
                    GetComponent<SpriteRenderer>().color = Color.red;
                    player.SendMessage("AddScore");


                }
            }
        }
    }
}
