using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextManager textManager;
    public GameObject textPanel;
    public Text Objtext;
    public GameObject scanObject;
    public bool isExecution;

    public int textIndex = 0;
    public int count = 0; //DummyObject Ȱ��ȭ ��, 
    public void Execution(GameObject scanObj)
    {


        if (count == 0 && scanObj.layer == LayerMask.NameToLayer("DummyObject"))
        {
            count++;
            isExecution = true;
            Objtext.text = "������ �ʿ���� �� ����... �ٸ��� ã�ƺ���.....";
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
