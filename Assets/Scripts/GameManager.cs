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
    public GameObject scanObject;

    public GameObject[] questObject;
    public bool q1 = true; // 퀘스트1 성공 판별 여부

    public bool isExecution;

    public int textIndex = 0;
    public int count = 0; //DummyObject 활성화 시, 
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
        Q1Execution(objData.id);
    }


    public void Q1Execution(int id)
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
            questObject[0].SetActive(false);
        }
        else if (id == 106 && !q1)
        {
            questObject[1].SetActive(false);
        }
        else if (id == 107 && !q1)
        {
            questObject[2].SetActive(false);
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


}
