using System.Threading;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool tutorialRunning = true;
    Canvas canvas;
    [SerializeField] TMP_Text text;
    int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        TutorialClass(count++);
    }
    void TutorialClass(int count)
    {
        if (tutorialRunning)
        {
            canvas.enabled = true;
            Time.timeScale = 0.1f;
            if (count == 0)
            {
                text.text = "use WASD or the arrow keys to move";
            }
            else if (count == 1)
            {
                text.text = "Left click and drag with your mouse to select any unit with a health bar";
            }
            else if (count == 2) {
                text.text = "You can then right click and drag to deploy those selected units in a line";
            }
            else if (count == 3)
            {
                text.text = "Here come the enemy's advance guard now, good luck";
            }
        }
    }
    private void endTutorial()
    {
        tutorialRunning = false;
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.S)))
        {
            TutorialClass(count++);
        }
        else if (count == 2 && Input.GetMouseButtonUp(0))
        {
            TutorialClass(count++);
        }
        else if (count == 3 && (Input.GetMouseButtonDown(1)))
        {
            TutorialClass(count++);
        }
        else if (count == 4 && Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            canvas.enabled = false;
        }
    }
}
