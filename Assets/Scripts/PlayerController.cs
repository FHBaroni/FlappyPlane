using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    bool startGame;
    bool endGame;
    Rigidbody2D playerBody;
    Vector2 impulseForce = new Vector2(0, 500f);

    public GameObject particleLeaf;
    public Text textScore;
    GameObject gameController;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        textScore.transform.position = new Vector2(Screen.width / 2, Screen.height - 100);
        textScore.text = "Clique para iniciar";
        textScore.fontSize = 50;
        gameController = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

        if (!endGame)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!startGame)
                {
                    startGame = true;
                    playerBody.isKinematic = false;
                    textScore.fontSize = 100;
                    textScore.text = score.ToString();
                    gameController.SendMessage("GameStart");
                }

                playerBody.velocity = Vector2.zero;
                playerBody.AddForce(impulseForce);
                GameObject leaf = Instantiate(particleLeaf);
                Vector3 positionPlayer = transform.position + new Vector3(0, 10, 0);
                leaf.transform.position = transform.position;
            }
            float positionPixels = Camera.main.WorldToScreenPoint(transform.position).y;
            if (positionPixels > Screen.height)
            {
                GameOver();
            }

            transform.rotation = Quaternion.Euler(0, 0, playerBody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!endGame)
        {
            endGame = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
            GetComponent<Rigidbody2D>().AddTorque(300f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.75f, .75f);
            GameOver();
        }
    }
    private void GameOver()
    {
        Invoke("ResetScene", 4);
        gameController.SendMessage("EndGame");
    }
    public void AddScore()
    {
        score++;
        textScore.text = score.ToString();
        textScore.fontSize =100;

    }
    void ResetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
