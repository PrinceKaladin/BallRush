using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    
    Vector2 startposition;
    public Text timer;
    public Text score;
    int time = 60;
    Rigidbody2D rb;
    public GameObject gameplayobject;
    public GameObject endgame;
    int scor = 0;
    public AudioSource audios;

    private void Start()
    {
        StartCoroutine(timing());
    }
    private void Update()
    {
        if (time <= 0) { 
        gameplayobject.SetActive(false); 
        endgame.SetActive(true);
        }   
    }
    private void OnEnable()
    {
        startposition =  this.transform.position;
        rb = this.GetComponent<Rigidbody2D>() ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "5") {
            scor += 5;
        }
        if (collision.gameObject.tag == "2")
        {
            scor += 20;
        }
        if (collision.gameObject.tag == "1")
        {
            scor += 50;
        }
        if (PlayerPrefs.GetInt("bestscore") < scor) { PlayerPrefs.SetInt("bestscore",scor); }
        PlayerPrefs.SetInt("lastscore", scor);
        score.text = scor.ToString();
        this.transform.position = startposition;
        rb.Sleep();
        if (PlayerPrefs.GetInt("sound",1) == 1 )
        {
            audios.Play();
        }
        rb.gravityScale = 0;
    }
      
    IEnumerator timing() {
        while (time > 0) {
            yield return new WaitForSeconds(1);
            time -= 1;
            timer.text = time.ToString();
        }

    }

}
