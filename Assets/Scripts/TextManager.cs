using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;

    public void Action()
    {
        talkText.text = "나에겐 필요없는 것 같다... 다른걸 찾아보자.....";
    }
}
