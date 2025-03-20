using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject geral;
    private float tempo;
    void Start()
    {
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
        if(transform.position.x > -5.5f)
        {
            transform.Translate(Vector3.left * 7 * Time.deltaTime * tempo);
        }
        else
        {
            transform.position = new Vector2(Random.Range(6f, 10f), Random.Range(-3f, 3f));
        }
        
    }
}
