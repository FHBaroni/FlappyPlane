using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool startGame;
    bool endGame;
    Rigidbody2D playerBody;
    Vector2 impulseForce = new Vector2(0, 500f);

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (!startGame)
            {
                startGame = true;
                playerBody.isKinematic = false; 
            }
            playerBody.velocity = Vector2.zero;
            playerBody.AddForce(impulseForce);
        }
    }
}
