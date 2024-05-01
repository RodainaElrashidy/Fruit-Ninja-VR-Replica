using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] Slider slider;
    int score;
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        GameConst.value = 100;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene.buildIndex == 1)
        {
            score += int.Parse(scoreTxt.text) + GameConst.score;
            scoreTxt.text = score.ToString();
            slider.value = GameConst.value;
        }
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }

}
