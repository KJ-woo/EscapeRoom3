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
        //map1 1층 데이터
        textData.Add(100, new string[] { "피가 묻어져있는 흔적이 보인다..", "자세히 보니 비석으로 가라는 글이 보인다...." });
        textData.Add(101, new string[] { "누군가에 의해 무너진 흔적인 것 같다.." }); // 우물
        textData.Add(102, new string[] { "잠겨져있다..", "상자를 열 수 있는 방법은 없을까?\n방법을 찾아보자.." });// map1 상자
        textData.Add(103, new string[] { "반짝이는 비석이다. 나에겐 필요하지 않은 것 같다." }); //map1 빛나는 문양 비석
        textData.Add(104, new string[] { "누군가가 죽고나서 세운 비석인 것 같다.","계단 위로 올라가고 싶다면 영혼이 담긴 항아리를 수거하자." }); //map1 빛나는 문양 비석
        textData.Add(105, new string[] { "한개의 영혼이 담겨져 있는 항아리를 수거했다." });//항아리1
        textData.Add(106, new string[] { "두개의 영혼이 담겨져 있는 항아리를 수거했다." });//항아리2
        textData.Add(107, new string[] { "세개의 영혼이 담겨져 있는 항아리를 수거했다." });//항아리3
        textData.Add(108, new string[] { "한이 맺힌 영혼을 달래주어야만 지나갈 수 있다." });//표지판

        textData.Add(201, new string[] { "왕의 무덤", "왕의 유품을 찾아보면 탈출할 수 있는 무언가를 얻을 수 있지 않을까?" });//표지판
        textData.Add(202, new string[] { "1대 왕의 무덤", "찾아봤지만 아무것도 나오지 않았다." });//표지판
        textData.Add(203, new string[] { "2대 왕의 무덤", "무언가 있는거 같다. 하지만 나에게 필요한건 아닌 것 같아 보인다.", "다른 무덤을 찾아보자." });//표지판
        textData.Add(204, new string[] { "3대 왕의 무덤", "열쇠처럼 보이는 물건을 찾았다!", "위쪽 통로에 잠겨져있는 문이 있는데 이걸로 열 수 있지 않을까?" });//표지판
        textData.Add(205, new string[] { "4대 왕의 무덤", "깜짝이야!, 안에서 무언가 움직인다. 빨리 유품중 열쇠를 찾아서 움직이자.." });//표지판
        textData.Add(206, new string[] { "세기 200년 1~4대 왕 여기서 잠들다..." });//표지판
        textData.Add(207, new string[] { "........철컥!", "문이 열렸다." });//문

        textData.Add(300, new string[] { "......슈웅!" });

    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // 더이상 남아있는 텍스트 내용이 없을 시
            return null;
        else
            return textData[id][textIndex];
    }


}
