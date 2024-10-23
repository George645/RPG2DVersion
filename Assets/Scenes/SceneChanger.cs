using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{
    public string nextSceneName;
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName){
        SceneManager.UnloadSceneAsync(sceneName);
    }
    public void Exit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    private void OnCollisionEnter2D(Collision2D other){
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(nextSceneName);
        }
    }
}