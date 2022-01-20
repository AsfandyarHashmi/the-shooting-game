using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    private PlayerScript player;
    private Text playerHealthText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerHealthText = GameObject.Find("Player Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + player.health;
    }
}
