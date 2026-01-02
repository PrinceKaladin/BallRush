using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tap : MonoBehaviour
{

    public Text text;
    public Text text1;

    private void OnEnable()
    {
        text.text = PlayerPrefs.GetInt("lastscore").ToString();
        text1.text = PlayerPrefs.GetInt("bestscore").ToString();
    }
}
