using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GUISkin layout;
    private static int score;
    public float tempo;
    private int timer;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        timer = 5000;
        tempo = 1f;
    }

    public void AddPts()
    {
        score = score + 10;
        PlayerPrefs.SetInt("score", score); // Salva o valor de "score"
        PlayerPrefs.Save();
    }

    void OnGUI()
    {
        GUI.skin = layout;
        if(SceneManager.GetActiveScene().name == "Jogo")
        {
            GUI.skin.label.fontSize = 30;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent(score.ToString()));
            GUI.Label(new Rect(10, Screen.height-label1.y-10, label1.x+1, label1.y), score.ToString());
        }
        else if(SceneManager.GetActiveScene().name == "Ganhou")
        {
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Vitória!"));
            GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Vitória");

            GUI.skin.label.fontSize = 30;
            Vector2 LScore = GUI.skin.label.CalcSize(new GUIContent("Você alcançou 200 pontos."));
            GUI.Label(new Rect((Screen.width-LScore.x)/2, (Screen.height-LScore.y)/2+30, LScore.x+5, LScore.y), "Você alcançou 200 pontos.");
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
        else if(SceneManager.GetActiveScene().name == "Perdeu")
        {
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Fim de Jogo"));
            GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Fim de Jogo");

            GUI.skin.label.fontSize = 30;
            Vector2 LScore = GUI.skin.label.CalcSize(new GUIContent("Sua pontuação final foi "+score.ToString()));
            GUI.Label(new Rect((Screen.width-LScore.x)/2, (Screen.height-LScore.y)/2+30, LScore.x+5, LScore.y), "Sua pontuação final foi "+score.ToString());
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 200)
        {
            SceneManager.LoadScene("Ganhou");
        }
        if(score >= 100 && timer > 0)
        {
            Debug.Log(timer);
            tempo = 0.5f;
            timer--;
        }
        else
        {
            tempo = 1f;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
    }
}
