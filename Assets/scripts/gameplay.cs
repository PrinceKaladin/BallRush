using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay : MonoBehaviour
{
    public GameObject taptostart;
    public GameObject gameplayobject;
    public Rigidbody2D ball;


    public float [] min_max;


    private void Awake()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    private void Update()
    {

        if (taptostart.activeSelf == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                taptostart.SetActive(false);
                gameplayobject.SetActive(true);
            }

        }
        else if (gameplayobject.activeSelf == true) {
            if (Input.GetMouseButton(0)) { 
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.x > min_max[0] && pos.x < min_max[1])
                {
                    if (ball.gravityScale == 0)
                    {
                        ball.transform.position = new Vector2(pos.x, ball.transform.position.y);
                    }

                }
            }
            if (Input.GetMouseButtonUp(0)) {
                ball.gravityScale = 1;
            }
        }
    }



}
