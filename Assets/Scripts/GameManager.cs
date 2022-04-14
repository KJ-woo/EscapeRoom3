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
    private bool q1 = true; // ����Ʈ1 ���� �Ǻ� ����
    private int q1count = 0;
    private int q2count = 0;

    private int q3count = 0;
    private int q31count = 0;

    private int q4count = 0;

    private int q5count = 0;

    public bool isExecution; // UI �г� ��Ƽ�� Ȱ��ȭ ��Ȱ��ȭ �Ǵ� ����
    public bool isEnding = false; //���� ���� ����

    private int textIndex = 0;
    private int count = 0; //DummyObject Ȱ��ȭ ��,

    [SerializeField]
    private GameObject endingCredit; //����ũ����

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


    public void Q1Execution(int id) //�� 1�� ����Ʈ
    {
        if (id == 104 && q1)// ������Ʈ �����
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

    public void Q2Execution(int id) //�� 2�� ����Ʈ
    {
        if (id == 204 && q2count == 0)// ���� ã���� ��
        {
            q2count++;
        }
        else if (id == 207 && q2count > 0) // Ű�� �������¿��� ��ȣ�ۿ� ���� ��
        {
            questObject[4].SetActive(false); // �����ִ� �� ����
            questObject[5].SetActive(true); //�����ִ� �� ���
            SoundManager.instance.PlaySoundEffect("opendoor1");
        }
    }
    public void Q3Execution(int id) //�� 2�� ����Ʈ
    {
        if (id == 302 && q3count <= 1)// ����ġ ������
        {
            q3count++;
            questObject[6].SetActive(false);
            questObject[7].SetActive(true); // ���� ����
            SoundManager.instance.PlaySoundEffect("opendoor2");
        }
        else if (id == 302 && q3count >= 2)// ����ġ�� �ٽ� ������
        {
            q3count++;
            questObject[6].SetActive(true);
            questObject[7].SetActive(false); // �ٽ� ���� ���� 
            SoundManager.instance.PlaySoundEffect("closedoor");
            if (q3count == 4)
                q3count = 0;
        }
        else if (id == 308 && q31count == 0)// �׾Ƹ��ȿ� ���� ã�� ��
        {
            q31count++;
        }

        else if (id == 304 && q31count == 1)// �׾Ƹ� ���踦 �԰��� ���ڸ� �� ��
        {
            q31count++;
            questObject[8].SetActive(false);
            questObject[9].SetActive(true);
            SoundManager.instance.PlaySoundEffect("openbox");
        }
    }
    public void Q4Execution(int id) //�� 2�� ����Ʈ
    {
        if (id == 401 && q4count == 0)// ���ڸ� �μ� ��
        {
            q4count++;
            questObject[10].SetActive(false);
            questObject[11].SetActive(true);
            SoundManager.instance.PlaySoundEffect("crushbox");
        }
    }
    public void Q5Execution(int id) //�� 2�� ����Ʈ
    {
        if (id == 501 && q5count == 0)//����� ��ȣ�ۿ����� ��
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

    public void MapMove(int id) //�� 2�� ����Ʈ
    {
        if (id == 300 && q2count == 1)// �ڷ���Ʈ ���� ��ȣ�ۿ� ��
        {
            playerObject.transform.position = new Vector3(-57, 10, 0); //��2�� �̵�
            q2count--;
        }
        else if (id == 300 && q31count == 2)// �ڷ���Ʈ ���� ��ȣ�ۿ� ��
        {
            playerObject.transform.position = new Vector3(-40, 21, 0); //��3�� �̵�
            q31count--;
        }
        else if (id == 300 && q4count == 1)// �ڷ���Ʈ ���� ��ȣ�ۿ� ��
        {
            playerObject.transform.position = new Vector3(-27, 5, 0); //��4�� �̵�
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
