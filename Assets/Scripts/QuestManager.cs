using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    Dictionary<int, string[]> questData;

    void Awake()
    {
        questData = new Dictionary<int, string[]>(); // �ʱ�ȭ
        InformData();
    }

    void InformData()
    {
        questData.Add(1, new string[] {"��ȥ�� ����"});
    }

    public int GetQuestIndex(int id)
    {
        return 
    }
}
