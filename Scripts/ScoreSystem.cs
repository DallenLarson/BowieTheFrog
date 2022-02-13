using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreSystem : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public Text ScoreTextEnd;
    public Text ScoreTextEndOutline;
    protected float Timer;
    public int DelayAmount = 1;
    public int Hearts = 3;
    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;
    public Animator anim;
    public bool isAlive;
    public GameObject player;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject ButtonGame;
    public bool runOnce;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            if (isAlive)
            {
                Timer = 0f;
                Score++;
                ScoreText.text = "SCORE: " + Score.ToString("0000");
                ScoreTextEnd.text = "SCORE: " + Score.ToString("0000");
                ScoreTextEndOutline.text = "SCORE: " + Score.ToString("0000");
            }
        }
        if (Hearts == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        if (Hearts == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        if (Hearts == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
        if (Hearts == 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        if(runOnce == false)
        {
            runOnce = true;
            ButtonGame.SetActive(false);
            Button1.SetActive(true);
            Button2.SetActive(true);
            isAlive = false;
            Debug.Log("Died");
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            anim = GameObject.Find("FadeToBlack").GetComponent<Animator>();
            Time.timeScale = 0.35f;
            anim.SetTrigger("FTB");
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Button1);
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0.0f;
        player.SetActive(false);
    }
}
