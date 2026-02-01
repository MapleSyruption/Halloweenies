using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //INSTANCE
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    //Parameters
    int numScenarios = 3;


    //Variables
    public int currentScenarioNum = 0;
    public bool isLose = false;
    public bool hasCompletedAScenario = false;
    //Refs
    public GameObject[] scenarios;
    private GameObject currentlyLoadedScenario;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            SpawnNextScenario();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DespawnScenario()
    {
        //despawn that bit
        yield return null;
    }

    private void SpawnNextScenario()
    {
        if(currentScenarioNum < numScenarios)
        {
            scenarios[currentScenarioNum].SetActive(true);
            //spawn that bit
            //set currentScenario var
        }
        else
        {
            //win
            StartCoroutine("EndSequence");
        }
    }
    public void Win()
    {
        hasCompletedAScenario = true;
        StartCoroutine("CelebrateSequence");
    }

    public void Lose()
    {
        hasCompletedAScenario = true;
        isLose = true;
        StartCoroutine("EndSequence");
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(3);
        //Spawn proper ending
        if(isLose)
        {
            //Toggle loss screen on
        }
        else
        {
            //Toggle win screen on
        }

        //wait for user input
        yield return new WaitUntil(() => Input.anyKey);

        //Back to menu
        SceneManager.LoadScene(0);

        yield return null;
    }

    IEnumerator CelebrateSequence()
    {
        yield return new WaitForSeconds(3);

        scenarios[currentScenarioNum].SetActive(false);
        currentScenarioNum += 1;
        SpawnNextScenario();
        hasCompletedAScenario = false;

    }
}
