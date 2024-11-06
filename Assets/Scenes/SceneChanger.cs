using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{
    public string nextSceneName;
    private Collider2D thisCollider;
    private void Start(){
        try{
            thisCollider = GetComponent<Collider2D>();
        }
        catch{
            Debug.LogWarning("no collider2d registered, possible cause of an issue");
        }
    }
    public static void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName){
        SceneManager.UnloadSceneAsync(sceneName);
    }
    public static void Exit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("scene changer collision detected with " + other);
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(nextSceneName);
        }
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            ChangeScene("Pause menu");
        }
    }
}