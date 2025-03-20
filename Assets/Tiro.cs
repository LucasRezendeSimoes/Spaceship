using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro: MonoBehaviour
{
    private float velocidade = 7f;
    public GameObject player;
    public int pts = 0;
    public GameObject geral;
    private float tempo;

    void Start()
    {
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Asteroid")
        {
            coll.transform.position = new Vector2(Random.Range(6f, 10f), Random.Range(-3f, 3f));
            transform.position = new Vector2(0f, -5f);
            geral.gameObject.GetComponent<GameManager>().AddPts();
        }
    }

    void Update()
    {
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
        if(transform.position.x < 5.5f && transform.position.y >-5)  // Limite da borda direita
        {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime * tempo);  // Movimento para a direita
        }
        else
        {
            transform.position = new Vector2(0f, -5f);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = player.transform.position;
            }
        }
    }
}
