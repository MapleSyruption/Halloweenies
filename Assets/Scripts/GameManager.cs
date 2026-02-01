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
    public GameObject winScreen;
    public AudioSource victoryAudio;
    public AudioSource musicSource;

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
            

            //Lerp it into view x=18
            StartCoroutine(MoveScenarioIn());
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
        if (!isLose)
            winScreen.SetActive(true);

        yield return new WaitForSeconds(3);
        //Spawn proper ending
        if(isLose)
        {
            //Toggle loss screen on
        } else
        {
            musicSource.Stop();
            victoryAudio.Play();
            yield return new WaitUntil(() => Input.anyKey);
        }

        //Back to menu
        SceneManager.LoadScene(0);

        yield return null;
    }

    IEnumerator CelebrateSequence()
    {
        yield return new WaitForSeconds(3);

        //Lerp it down
        Transform trans = scenarios[currentScenarioNum].transform;
        Vector3 initPos = trans.position;
        Vector3 newPos = new Vector3(18f, initPos.y, initPos.z);
        float duration = 1f;
        float timePassed = 0f;

        trans.position = newPos;
        scenarios[currentScenarioNum].SetActive(true);

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            trans.position = Vector3.Lerp(initPos, newPos, timePassed);
            yield return new WaitForFixedUpdate();
        }

        scenarios[currentScenarioNum].SetActive(false);
        currentScenarioNum += 1;
        SpawnNextScenario();
        hasCompletedAScenario = false;

    }

    IEnumerator MoveScenarioIn()
    {
        if (currentScenarioNum != 0)
        {
            yield return new WaitForSeconds(0.25f);
        }

        //Lerp it up
        Transform trans = scenarios[currentScenarioNum].transform;
        Vector3 initPos = trans.position;
        Vector3 newPos = new Vector3(18f, initPos.y, initPos.z);
        float duration = 1f;
        float timePassed = 0f;

        trans.position = newPos;
        scenarios[currentScenarioNum].SetActive(true);

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            trans.position = Vector3.Lerp(newPos, initPos - new Vector3(1f,0f,0f), timePassed);
            yield return new WaitForFixedUpdate();
        }

        timePassed = 0f;
        duration = 0.1f;
        while (timePassed < duration)
        {
            float t = timePassed / duration;
            timePassed += Time.deltaTime;
            trans.position = Vector3.Lerp(initPos - new Vector3(1f, 0f, 0f), initPos, t);
            yield return new WaitForFixedUpdate();
        }
    }
}
