using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField; 
    private void Start()
    {
        GameSessionController gameSessionController = FindObjectOfType<GameSessionController>();
        int score = gameSessionController.getScore();
        string str = scoreField.text;
        str = str + " " + score.ToString();
        scoreField.text = str;
        Destroy(gameSessionController.gameObject);
    }
    public void onClickStart(){
        SceneManager.LoadScene(0);
    }

    public void onClickExit(){
        Application.Quit(0);
    }
}
