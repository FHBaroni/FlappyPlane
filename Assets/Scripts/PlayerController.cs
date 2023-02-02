using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int score = 0;
    int screenDif = 30;
    bool startGame = false;
    bool endGame = false;
    public Text textScore;
    public GameObject particleLeaf;
    Rigidbody2D playerBody;
    GameObject gameController;
    Vector2 impulseForce = new Vector2(0, 500f);

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("MainCamera");
        playerBody = GetComponent<Rigidbody2D>();
        textScore.transform.position = new Vector2(Screen.width / 2, Screen.height - 100);
        textScore.text = "Clique para iniciar";
        textScore.fontSize = 50;
    }

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
            if (positionPixels > Screen.height + screenDif || positionPixels < -screenDif )
            {
                endGame = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
                GetComponent<Rigidbody2D>().AddTorque(300f);
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.75f, .75f);
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
        Invoke ("ResetScene",5);
        gameController.SendMessage("CancelEnemy");
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
