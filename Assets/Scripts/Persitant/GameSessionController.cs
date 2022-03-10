using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSessionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI lives;

    bool deathOnceOnAScene = false;


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
        if(playerLifes >= 1){
            takeLife();
        }else{
            ResetGameSession();
        }
    }


    private void takeLife()
    {
        if(!deathOnceOnAScene){ // if not even died once in current scene
            deathOnceOnAScene = true; 
            Debug.Log("No of lives on awake   " + playerLifes +"  before death");
            playerLifes -= 1;
            int currentHealth = playerLifes;
            Debug.Log("No of lives after death  (current health)  " + currentHealth);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(restartScene(currentSceneIndex));
            PlayerAnimations playerAnimations = FindObjectOfType<PlayerAnimations>();
            playerAnimations.playDeathAnim();
            lives.text = currentHealth.ToString();
        }
    }


    IEnumerator restartScene(int currentSceneIndex){
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(currentSceneIndex); 
        deathOnceOnAScene = false;
    }
    private void ResetGameSession()
    {
        Destroy(GameObject.FindGameObjectWithTag("ScenePersist"));
        StartCoroutine(restartScene(5));
        FindObjectOfType<PlayerAnimations>().playDeathAnim();
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
        // Debug.Log("Inside Print Score   --> " + score 
        //             + "   and scene index is -->" + sceneIndex  
        //             + " no of game session objects" + FindObjectsOfType<GameSessionController>().Length 
        //             + "game Object ID " + gameObject.GetInstanceID());
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
