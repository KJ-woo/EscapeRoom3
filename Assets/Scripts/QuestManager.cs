using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public GameObject[] questObject;
    Dictionary<int, string[]> questData;

    void Awake()
    {
        questData = new Dictionary<int, string[]>(); // �ʱ�ȭ
        InformData();
    }

    void InformData()
    {
        questData.Add(1, new string[] { "��ȥ�� ����" });
        questData.Add(2, new string[] { "��ȥ�� ����" });
        questData.Add(3, new string[] { "��ȥ�� ����" });
        questData.Add(1, new string[] { "��ȥ�� ����" });
        questData.Add(1, new string[] { "��ȥ�� ����" });
        questData.Add(1, new string[] { "��ȥ�� ����" });
    }

    public int GetQuestIndex(int id)
    {
        return questId;
    }

    /*void ShowObject()
    {
       switch (questId)
       {
            case 1:
                if()

        }
    }*/
}