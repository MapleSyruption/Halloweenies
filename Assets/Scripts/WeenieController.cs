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

    //Parameters



    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void SetHoverStatus(bool _isHovered)
    {
        speechBubble.SetActive(_isHovered);
        speechBubble.GetComponent<TMP_Text>().text = info.weenieStatement;

        speechBubbleTail.SetActive(_isHovered);

        hoverHand.SetActive(_isHovered);
    }

    public void SelectWeenie()
    {
        Debug.Log("Weenie down");
        if(info.isGuilty)
        {
            aSource.clip = clipGood;
        }
        else
        {
            aSource.clip = clipBad;
        }

        aSource.Play();

        mask.SetActive(false);
    }
}
