using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //will change our scene to the string passed in
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);

    }

    //reloads the current scene we are in
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
        
    
    //loads out Title scene. Must be called title exactly
    public void ToTitleScreen()
    {
        SceneManager.LoadScene("Title");

    }

    //Get our Active scene name
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }


    //Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }

}
