using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextManager textManager;
    public GameObject textPanel;
    public Text Objtext;
    private GameObject scanObject;

    [SerializeField]
    private GameObject playerObject;

    public GameObject[] questObject;
    private bool q1 = true; // 퀘스트1 성공 판별 여부
    private int q1count = 0;
    private int q2count = 0;

    private int q3count = 0;
    private int q31count = 0;

    private int q4count = 0;

    private int q5count = 0;

    public bool isExecution; // UI 패널 액티브 활성화 비활성화 판단 변수
    public bool isEnding = false; //게임 종료 변수

    private int textIndex = 0;
    private int count = 0; //DummyObject 활성화 시,

    [SerializeField]
    private GameObject endingCredit; //엔딩크레딧

    public void Execution(GameObject scanObj)
    {


        if (count == 0 && scanObj.layer == LayerMask.NameToLayer("DummyObject"))
        {
            count++;
            isExecution = true;
            Objtext.text = "나에겐 필요없는 것 같다... 다른걸 찾아보자.....";
        }
        else if (count == 1)
        {
            isExecution = false;
            count = 0;
        }
        else if (scanObj.layer == LayerMask.NameToLayer("Object"))
        {
            scanObject = scanObj;
            Object objData = scanObject.GetComponent<Object>();
            if ((q2count == 1 && objData.id == 207) || (q3count == 2 && objData.id == 302))
                Text(objData.id + 1);
            else if ((q31count == 0 && objData.id == 304))
            {
                Text(objData.id + 1);
                SoundManager.instance.PlaySoundEffect("lockbox");
            }
            else
                Text(objData.id);
        }

        textPanel.SetActive(isExecution);
    }

    public void QuestExecution(GameObject scanObj)
    {
        scanObject = scanObj;
        Object objData = scanObject.GetComponent<Object>();

        if ((objData.id >= 104 && objData.id <= 107) || objData.id == 102)
            Q1Execution(objData.id);
        else if (objData.id == 204 || objData.id == 207)
            Q2Execution(objData.id);
        else if (objData.id == 302 || objData.id == 304 || objData.id == 308)
            Q3Execution(objData.id);
        else if (objData.id == 401 || objData.id == 402)
            Q4Execution(objData.id);
        else if (objData.id == 501)
            Q5Execution(objData.id);
        else if (objData.id == 300)
            MapMove(objData.id);
    }


    public void Q1Execution(int id) //맵 1층 퀘스트
    {
        if (id == 104 && q1)// 비석퀘스트 실행시
        {
            for(int i =0; i<3;i++)
            { 
                questObject[i].SetActive(true);
            }
            q1 = false;
        }
        else if (id == 102)
        {
            SoundManager.instance.PlaySoundEffect("lockbox");
        }
        else if(id == 105 && !q1)
        {
            q1count++;
            questObject[0].SetActive(false);
        }
        else if (id == 106 && !q1)
        {
            q1count++;
            questObject[1].SetActive(false);
        }
        else if (id == 107 && !q1)
        {
            q1count++;
            questObject[2].SetActive(false);
        }
        
        if (q1count==3)
        {
            questObject[3].SetActive(false);
        }
    }

    public void Q2Execution(int id) //맵 2층 퀘스트
    {
        if (id == 204 && q2count == 0)// 열쇠 찾았을 시
        {
            q2count++;
        }
        else if (id == 207 && q2count > 0) // 키를 가진상태에서 상호작용 했을 시
        {
            questObject[4].SetActive(false); // 닫혀있는 문 해제
            questObject[5].SetActive(true); //열려있는 문 출력
            SoundManager.instance.PlaySoundEffect("opendoor1");
        }
    }
    public void Q3Execution(int id) //맵 2층 퀘스트
    {
        if (id == 302 && q3count <= 1)// 스위치 누를시
        {
            q3count++;
            questObject[6].SetActive(false);
            questObject[7].SetActive(true); // 문이 열림
            SoundManager.instance.PlaySoundEffect("opendoor2");
        }
        else if (id == 302 && q3count >= 2)// 스위치를 다시 누를시
        {
            q3count++;
            questObject[6].SetActive(true);
            questObject[7].SetActive(false); // 다시 문이 닫힘 
            SoundManager.instance.PlaySoundEffect("closedoor");
            if (q3count == 4)
                q3count = 0;
        }
        else if (id == 308 && q31count == 0)// 항아리안에 열쇠 찾을 시
        {
            q31count++;
        }

        else if (id == 304 && q31count == 1)// 항아리 열쇠를 먹고나서 상자를 열 시
        {
            q31count++;
            questObject[8].SetActive(false);
            questObject[9].SetActive(true);
            SoundManager.instance.PlaySoundEffect("openbox");
        }
    }
    public void Q4Execution(int id) //맵 2층 퀘스트
    {
        if (id == 401 && q4count == 0)// 상자를 부술 시
        {
            q4count++;
            questObject[10].SetActive(false);
            questObject[11].SetActive(true);
            SoundManager.instance.PlaySoundEffect("crushbox");
        }
    }
    public void Q5Execution(int id) //맵 2층 퀘스트
    {
        if (id == 501 && q5count == 0)//석상과 상호작용했을 시
        {
            q5count++;
            questObject[12].SetActive(false);
            questObject[13].SetActive(true);
        }

    }
    public void End()
    {
        if (isEnding)
        {
            isExecution = false;
            endingCredit.SetActive(true);
        }
    }

    public void MapMove(int id) //맵 2층 퀘스트
    {
        if (id == 300 && q2count == 1)// 텔레포트 석상 상호작용 시
        {
            playerObject.transform.position = new Vector3(-57, 10, 0); //맵2로 이동
            q2count--;
        }
        else if (id == 300 && q31count == 2)// 텔레포트 석상 상호작용 시
        {
            playerObject.transform.position = new Vector3(-40, 21, 0); //맵3로 이동
            q31count--;
        }
        else if (id == 300 && q4count == 1)// 텔레포트 석상 상호작용 시
        {
            playerObject.transform.position = new Vector3(-27, 5, 0); //맵4로 이동
            q4count--;
        }


    }

    void Text(int id)
    {

        string textData = textManager.getText(id, textIndex);

        if (textData == null)
        {
            isExecution = false;
            textIndex = 0;
            return;
        }
        else
        Objtext.text = textData;

        isExecution = true;
        textIndex++;
    }

    public void setTextPanel()
    {
        textIndex = 0;
        isExecution = false;
        textPanel.SetActive(isExecution);
    }


}
