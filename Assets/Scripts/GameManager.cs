using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
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

    public bool isExecution;

    private int textIndex = 0;
    private int count = 0; //DummyObject 활성화 시,
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
            Text(objData.id);
        }

        textPanel.SetActive(isExecution);
    }

    public void QuestExecution(GameObject scanObj)
    {
        scanObject = scanObj;
        Object objData = scanObject.GetComponent<Object>();

        if (objData.id >= 104 && objData.id <= 107)
            Q1Execution(objData.id);
        else if (objData.id == 204 || objData.id == 207)
            Q2Execution(objData.id);
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
        }
        
    }

    public void MapMove(int id) //맵 2층 퀘스트
    {
        if (id == 300)// 열쇠 찾았을 시
        {
            playerObject.transform.Translate(new Vector3(-57, 10, 0));
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
