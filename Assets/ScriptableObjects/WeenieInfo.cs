using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeenieInfo", menuName = "ScriptableObjects/Weenie Info", order = 1)]
public class WeenieInfo : ScriptableObject
{
    public string weenieStatement;
    public bool isGuilty;
}
