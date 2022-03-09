using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonOnClick : MonoBehaviour
{

    public void onClickStart(){
        SceneManager.LoadScene(1);
    }

    public void onClickExit(){
        Application.Quit(0);
    }
}
