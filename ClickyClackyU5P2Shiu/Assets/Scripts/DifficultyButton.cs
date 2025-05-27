using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
      button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
        GameObject gmObject = GameObject.Find("Game Manager");
        if (gmObject != null)
        {
            gameManager = gmObject.GetComponent<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager component not found on 'Game Manager' GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'Game Manager' not found in the scene.");
        }
        button.onClick.AddListener(SetDifficulty);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");

        gameManager.StartGame();
        


    }
}
