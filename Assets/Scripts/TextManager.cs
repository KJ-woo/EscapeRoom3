using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
   
    Dictionary<int, string[]> textData;
    Dictionary<int[], string[]> caseData;

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
        textData.Add(102, new string[] { "잠겨져있다..", "여기서는 열 수 있는 방법이 없는 것 같다.\n다른 걸 찾아보자..." });// map1 상자
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
        textData.Add(207, new string[] { "철컥..", "문이 잠겨있다 뒤로 가서 열쇠를 찾아보자.." });//열쇠X
        textData.Add(208, new string[] { "........철컥! 문이 열렸다."});//열쇠O

        textData.Add(300, new string[] { "이동중.....","어라? 불안정해서 장소이동이 되지 않는다\n이동석을 찾아 비석과 연결하면 이동이 될 것 같다." });
        textData.Add(301, new string[] { "상자의 방","움직이는 상자...고정된 상자....공존..찾아라...밀어라" });
        textData.Add(302, new string[] { "석상에 있는 스위치를 누르니 밑에 있는 문이 열렸다." });
        textData.Add(303, new string[] { "스위치를 다시 눌러서 밑에 있는 문이 다시 닫혔다.\n다시 눌러서 문을 열자." });
        textData.Add(304, new string[] { "....철컥! 상자가 열렸다!\n상자에는 텔레포트에 필요한 이동석이 있었다.!\n이제 다음장소로 이동할까?" }); //열쇠를 찾았을 시, 상자
        textData.Add(305, new string[] { "잠겨져있다..", "상자를 열 수 있는 방법은 없을까?\n열쇠를 찾아보자" });// 열쇠를 못 찾았을 시, 상자
        textData.Add(306, new string[] { "이미 이동석을 얻었다.\n다음 장소로 이동하자" });// 열린상자
        textData.Add(307, new string[] { "항아리 안에 아무것도 없었다.", "다른 항아리를 찾아보자" });// 열쇠x 항아리
        textData.Add(308, new string[] { "항아리 안에 열쇠를 찾았다!", "상자를 열어보자.." });


        textData.Add(400, new string[] { "대칭의 방","모든것....대칭...반드시..." }); //맵3 표지판
        textData.Add(401, new string[] { "상자를 부셨다.\n안에 또다른 상자가 있었다!" }); // 대칭이 아닌 오브젝트
        textData.Add(402, new string[] { "모든게 대칭이 되었다." });

        textData.Add(500, new string[] { "시작 그리고 끝","비석.. 움직여라.....그 곳으로.." });
        textData.Add(501, new string[] { "기도중.....","기도를 종료 후 힘이 강해졌다.." });
        textData.Add(502, new string[] { "너무 무거워 꼼짝하지 않는다...\n무슨 방법이 없을까?" });
        textData.Add(503, new string[] { "힘이 강해져서 비석을 옮길 수 있을 것 같다....","비석을 옮겨보자." });
    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // 더이상 남아있는 텍스트 내용이 없을 시
            return null;
        else
            return textData[id][textIndex];
    }
 

}
