using TMPro;
using UnityEngine;

public class Startingexposition : MonoBehaviour
{
    TMP_Text text;
    int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (count == 0)
            {
                text.text = "There will be enemy troops coming from various points on multiple maps, they will only load when you are on the same map as them, but if you move the day to the next without dealing with them all, you will fail";
            }
            else if (count == 1) {
                text.text = "A brief exposition:\nThis world contains magic, but it is such a scarce supply that you are unlikely to encounter them in these battles. Good luck. If you manage to survive, You will be promoted. If you fail, the whole country falls. It all rests on you and how you deploy your troops";
            }
            else
            {
                SceneChanger.ChangeScene("tutorial");
            }
            count++;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneChanger.ChangeScene("tutorial");
        }
    }
}
