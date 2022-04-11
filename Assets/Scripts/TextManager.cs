using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    //[SerializeField]
    //private string[] ObjText = { };

    Dictionary<int, string[]> textData;

    void Awake()
    {
        textData = new Dictionary<int, string[]>();
        InformData();

    }

    void InformData()
    {
        textData.Add(100, new string[] { "피가 묻어져있는 흔적이 보인다..", "자세히 보니 비석으로 가라는 글이 보인다...." });
        textData.Add(101, new string[] { "누군가에 의해 무너진 흔적인 것 같다.." }); // 우물
        textData.Add(102, new string[] { "잠겨져있다..", "상자를 열 수 있는 방법은 없을까?\n방법을 찾아보자.." });// map1 상자
        textData.Add(103, new string[] { "반짝이는 비석이다. 나에겐 필요하지 않은 것 같다." }); //map1 빛나는 문양 비석
        textData.Add(104, new string[] { "피가 묻어져있는 흔적이 보인다..", "자세히 보니 비석으로 가라는 글이 보인다...." });
        textData.Add(105, new string[] { "피가 묻어져있는 흔적이 보인다..", "자세히 보니 비석으로 가라는 글이 보인다...." });


    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // 더이상 남아있는 텍스트 내용이 없을 시
            return null;
        else
            return textData[id][textIndex];
    }


}
