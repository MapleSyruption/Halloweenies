using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreenController : MonoBehaviour
{
    public Animator titleScreenAnimator;
    public bool actuallyStartGame;
    public GameObject[] objectss;

    private void Start()
    {
        objectss[Random.Range(0,5)].SetActive(true);
    }
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
