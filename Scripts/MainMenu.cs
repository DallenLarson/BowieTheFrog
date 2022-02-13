using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isGoing;
    public Animator anim;

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        if (isGoing == false)
        {
            StartCoroutine(Exam());
        }
    }

    void Update()
    {
        Time.timeScale = 1.0f;
        if (Input.anyKey)
        {
            if (isGoing == false)
            {
                StartCoroutine(Exam());
            }
        }
    }

    IEnumerator Exam()
    {
        isGoing = true;
        anim.SetTrigger("FTB");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }

}