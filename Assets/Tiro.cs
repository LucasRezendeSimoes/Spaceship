using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro: MonoBehaviour
{
    public float velocidade = 7f;
    public bool player = false;

    void Start()
    {
        if(gameObject.name == "T1")
        {
            player = true;
        }
    }

    void Update()
    {
        if(player)
        {
            // O projétil vai da esquerda para a direita (movimento positivo no eixo X)
            if(transform.position.x < 6)  // Limite da borda direita
            {
                transform.Translate(Vector3.right * velocidade * Time.deltaTime);  // Movimento para a direita
            }
        }
        else
        {
            // O projétil vai da direita para a esquerda (movimento negativo no eixo X)
            if(transform.position.x > -6)  // Limite da borda esquerda
            {
                transform.Translate(Vector3.left * velocidade / 2 * Time.deltaTime);  // Movimento para a esquerda
            }
        }
    }
}
