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
        textData.Add(100, new string[] { "�ǰ� �������ִ� ������ ���δ�..", "�ڼ��� ���� ������ ����� ���� ���δ�...." });
        textData.Add(101, new string[] { "�������� ���� ������ ������ �� ����.." }); // �칰
        textData.Add(102, new string[] { "������ִ�..", "���ڸ� �� �� �ִ� ����� ������?\n����� ã�ƺ���.." });// map1 ����
        textData.Add(103, new string[] { "��¦�̴� ���̴�. ������ �ʿ����� ���� �� ����." }); //map1 ������ ���� ��
        textData.Add(104, new string[] { "�ǰ� �������ִ� ������ ���δ�..", "�ڼ��� ���� ������ ����� ���� ���δ�...." });
        textData.Add(105, new string[] { "�ǰ� �������ִ� ������ ���δ�..", "�ڼ��� ���� ������ ����� ���� ���δ�...." });


    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // ���̻� �����ִ� �ؽ�Ʈ ������ ���� ��
            return null;
        else
            return textData[id][textIndex];
    }


}
