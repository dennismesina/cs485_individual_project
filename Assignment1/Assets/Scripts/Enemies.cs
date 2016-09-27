using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemies : MonoBehaviour {

    // Use this for initialization
    public Text countText;
    public Text winText;

    void Start()
    {
        winText.text = "";
        countEnemies();
        
    }

    // Update is called once per frame
    void Update()
    {
        countEnemies();
    }

    void countEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombies");
        int zombies = enemies.Length - 1;
        int count = 0;
        for(int i = 0; i < zombies; i++)
        {
            ZombieActions actions = enemies[i].GetComponent<ZombieActions>();
            if (actions.Dead == true)
            {
                count++;
            }
        }
        int display = zombies - count;
        countText.text = "Enemies Remaining: " + display.ToString();
        if (count == zombies)
        {
            winText.text = "YOU WIN...for now...";
        }
    }
}
