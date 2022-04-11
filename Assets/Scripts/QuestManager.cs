using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    Dictionary<int, string[]> questData;

    void Awake()
    {
        questData = new Dictionary<int, string[]>(); // 초기화
        InformData();
    }

    void InformData()
    {
        questData.Add(1, new string[] {"원혼불 수거"});
    }

    public int GetQuestIndex(int id)
    {
        return 
    }
}
