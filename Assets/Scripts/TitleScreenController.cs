using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreenController : MonoBehaviour
{
    public Animator titleScreenAnimator;
    public bool actuallyStartGame;
    public void StartGame()
    {
        titleScreenAnimator.SetTrigger("Start Game");
    }

    private void Update()
    {
        if (actuallyStartGame)
        {
            SceneManager.LoadScene(1);

            actuallyStartGame = false;
        }
    }

}
