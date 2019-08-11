using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;

    public bool isRight;

   
    void Start()
    {
        height = transform.localScale.y;
        
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;
       
        if (isRightPaddle)
        {
            pos = new Vector2(Gamemanager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            pos = new Vector2(Gamemanager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }

        transform.position = pos;
        transform.name = input;
        
    }

    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < Gamemanager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > Gamemanager.topRight.y - height / 2 && move  > 0)
        {
            move = 0;
        }


        transform.Translate(move * Vector2.up);
    }

    
}
