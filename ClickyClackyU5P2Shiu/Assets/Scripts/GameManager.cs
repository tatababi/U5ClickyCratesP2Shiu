using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    public Button restartButton;
    public GameObject titleScreen;
   
     

    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdatedScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
       
      
    }

   
public void RestartGame()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}


public void StartGame(int difficulty)
{
    isGameActive = true;
    score = 0;
    spawnRate = spawnRate / difficulty;
    StartCoroutine(SpawnTarget());

    UpdatedScore(0);

        titleScreen.gameObject.SetActive(false);
}
}

