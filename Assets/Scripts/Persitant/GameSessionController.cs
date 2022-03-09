using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSessionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI lives;


    [SerializeField] int playerLifes = 5;
    int score = 0;



    private void Awake()
    {
        
        int noOfGameSessionControllers = FindObjectsOfType<GameSessionController>().Length;
        // Debug.Log("No of lives on awake   " + playerLifes + "   noOfGameSessionControllers " + noOfGameSessionControllers);
        if(noOfGameSessionControllers > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }



    public void ProcessPlayerDeath(){
        if(playerLifes > 1){
            takeLife();
        }else{
            ResetGameSession();
        }
    }


    private void takeLife()
    {
        Debug.Log("No of lives on awake   " + playerLifes +"  before death");
        playerLifes -= 1;
        int currentHealth = playerLifes;
        Debug.Log("No of lives after death  (current health)  " + currentHealth);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);   
        lives.text = currentHealth.ToString();     
    }

    private void ResetGameSession()
    {
        Destroy(FindObjectOfType<ScenePersistant>().gameObject);
        SceneManager.LoadScene(5);
        // Destroy(gameObject);
    }
    void Start()
    {
        lives.text = playerLifes.ToString();
        printScore();
    }

    public int getScore(){
        return score;
    }

    private void printScore()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Inside Print Score   --> " + score 
                    + "   and scene index is -->" + sceneIndex  
                    + " no of game session objects" + FindObjectsOfType<GameSessionController>().Length 
                    + "game Object ID " + gameObject.GetInstanceID());
        scoreTMP.text = score.ToString();
        Debug.Log("Score TMP Value -- > " + scoreTMP.text);
    }

    public void increementScore(int increementValue){
        score+= increementValue;
        printScore();
    }

    // Update is called once per frame
    void Update()
    {
        printScore();
    }


}
