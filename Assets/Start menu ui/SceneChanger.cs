using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void Exit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
 //       Debug.Log("Current Scene Name: " + currentScene.name);
    }
}