using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float lenght;
    private float movingSpeed = 5f;
    public GameObject cam;
    public float parallaxEffect;
    public GameObject geral;
    private float tempo;
    // Start is called before the first frame update
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = geral.gameObject.GetComponent<GameManager>().tempo;
        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect * tempo;
        if(transform.position.x < -lenght )
        {
            transform.position = new Vector3(lenght-0.1f, transform.position.y, transform.position.z);
        }
    }

}
