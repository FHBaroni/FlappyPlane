using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BgMove : MonoBehaviour
{
    private float screenOrthoWidth;
    void Start()
    {

        SpriteRenderer graphic = GetComponent<SpriteRenderer>();

        float imageWidth = graphic.sprite.bounds.size.x;
        float imageHeight = graphic.sprite.bounds.size.y;

        float screenOrthoHeight = Camera.main.orthographicSize * 2f;
        screenOrthoWidth = (screenOrthoHeight / Screen.height) * Screen.width;

        Vector2 scale = transform.localScale;
        scale.x =  screenOrthoWidth/ imageWidth + 0.05f;
        scale.y = screenOrthoHeight / imageHeight;
        transform.localScale = scale;

        if (name == "BackgroundB")
        {
            transform.position = new Vector2(screenOrthoWidth, 0);
        }
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
    }

    private void Update()
    {
           if(transform.position.x <= -screenOrthoWidth)
        {
            transform.position = new Vector2(screenOrthoWidth, 0f); 
        }
    }
}
