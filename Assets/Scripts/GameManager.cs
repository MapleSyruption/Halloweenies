using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Parameters
    int numScenarios = 3;


    //Variables
    public int currentScenarioNum = 0;
    public bool isLose = false;

    //Refs
    public GameObject[] scenarios;
    private GameObject currentlyLoadedScenario;

    void Start()
    {
        
    }

    private void DespawnScenario()
    {
        //despawn that bit
    }

    private void SpawnNextScenario()
    {
        if(currentScenarioNum < numScenarios - 1)
        {
            //spawn that bit
            //set currentScenario var
        }
        else
        {
            //win
            StartCoroutine("EndSequence");
        }
    }

    public void Lose()
    {
        isLose = true;
        StartCoroutine("EndSequence");
    }

    IEnumerator EndSequence()
    {
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
}
