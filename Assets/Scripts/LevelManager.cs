using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image canvasFill;
    public GameObject failMenu;
    public GameObject winMenu;
    public  float speedFill = 0.5f;

    private bool GameIsOver = false;

    private void Awake()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if (GameIsOver)
        {
            Color fillColor = canvasFill.color;
            fillColor.a += speedFill * Time.deltaTime;
            fillColor.a = Mathf.Clamp(fillColor.a, 0, 1);
            canvasFill.color = fillColor;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }


    //public void GameOver(bool win)
    //{
    //    GameIsOver = true;
    //    if (win)
    //    {
    //        Win();
    //    }
    //    else
    //    {
    //        Fail();
    //    }
    //}

    public void Fail()
    {
        if (GameIsOver == false)
        {
            failMenu.SetActive(true);
        }
        GameIsOver = true;
    }

    public void Win()
    {
        if (GameIsOver == false)
        {
            winMenu.SetActive(true);
        }
        GameIsOver = true;
    }
}
