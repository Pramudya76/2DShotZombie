using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameover;
    public PlayerMovement PM;
    public Slider healthbar;
    public Image FillImage;
    public GameObject Slider;
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
        Slider.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(PM.health <= 0) {
            gameover.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if(PM.health < 100) {
            Slider.gameObject.SetActive(true);
        }
        HealthBar();
    }

    public void AddScore(int point) {
        score += point;
        scoreText.text = "Kill : " + score.ToString();
    }

    public void ResetScore(int point) {
        score = 0;
        scoreText.text = "Kill : " + score.ToString();
    }

    public void PlayAgain(string SceneName) {
        SceneManager.LoadScene(SceneName);
        gameover.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void HealthBar() {
        healthbar.value = PM.health;
        if(PM.health <= 0) {
            FillImage.enabled = false;
        }else {
            FillImage.enabled = true;
        }
    }

}
