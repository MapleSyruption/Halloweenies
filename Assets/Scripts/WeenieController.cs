using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeenieController : MonoBehaviour
{
    //Vars
    public bool isHovered = false;

    //Refs
    public WeenieInfo info;
    public GameObject speechBubble;
    public GameObject speechBubbleTail;
    public GameObject hoverHand;
    public GameObject mask;
    private AudioSource aSource;
    public AudioClip clipGood;
    public AudioClip clipBad;
    public Sprite choseHandSprite;

    //Parameters



    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void SetHoverStatus(bool _isHovered)
    {
        speechBubble.SetActive(_isHovered);
        speechBubble.GetComponentInChildren<TMP_Text>().text = info.weenieStatement;

        speechBubbleTail.SetActive(_isHovered);

        hoverHand.SetActive(_isHovered);
    }

    public void SelectWeenie()
    {
        hoverHand.GetComponent<SpriteRenderer>().sprite = choseHandSprite;
        hoverHand.transform.position = new Vector3(hoverHand.transform.position.x, hoverHand.transform.position.y + .4f, hoverHand.transform.position.z);

        speechBubble.SetActive(false);
        if (info.isGuilty)
        {
            aSource.clip = clipGood;
            GameManager.Instance.Win();
        }
        else
        {
            aSource.clip = clipBad;
            GameManager.Instance.Lose();
        }

        aSource.Play();

        mask.SetActive(false);
    }
}
