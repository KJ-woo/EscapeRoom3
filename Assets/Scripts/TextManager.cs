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
        //map1 1�� ������
        textData.Add(100, new string[] { "�ǰ� �������ִ� ������ ���δ�..", "�ڼ��� ���� ������ ����� ���� ���δ�...." });
        textData.Add(101, new string[] { "�������� ���� ������ ������ �� ����.." }); // �칰
        textData.Add(102, new string[] { "������ִ�..", "���ڸ� �� �� �ִ� ����� ������?\n����� ã�ƺ���.." });// map1 ����
        textData.Add(103, new string[] { "��¦�̴� ���̴�. ������ �ʿ����� ���� �� ����." }); //map1 ������ ���� ��
        textData.Add(104, new string[] { "�������� �װ��� ���� ���� �� ����.","��� ���� �ö󰡰� �ʹٸ� ��ȥ�� ��� �׾Ƹ��� ��������." }); //map1 ������ ���� ��
        textData.Add(105, new string[] { "�Ѱ��� ��ȥ�� ����� �ִ� �׾Ƹ��� �����ߴ�." });//�׾Ƹ�1
        textData.Add(106, new string[] { "�ΰ��� ��ȥ�� ����� �ִ� �׾Ƹ��� �����ߴ�." });//�׾Ƹ�2
        textData.Add(107, new string[] { "������ ��ȥ�� ����� �ִ� �׾Ƹ��� �����ߴ�." });//�׾Ƹ�3
        textData.Add(108, new string[] { "���� ���� ��ȥ�� �޷��־�߸� ������ �� �ִ�." });//ǥ����

        textData.Add(201, new string[] { "���� ����", "���� ��ǰ�� ã�ƺ��� Ż���� �� �ִ� ���𰡸� ���� �� ���� ������?" });//ǥ����
        textData.Add(202, new string[] { "1�� ���� ����", "ã�ƺ����� �ƹ��͵� ������ �ʾҴ�." });//ǥ����
        textData.Add(203, new string[] { "2�� ���� ����", "���� �ִ°� ����. ������ ������ �ʿ��Ѱ� �ƴ� �� ���� ���δ�.", "�ٸ� ������ ã�ƺ���." });//ǥ����
        textData.Add(204, new string[] { "3�� ���� ����", "����ó�� ���̴� ������ ã�Ҵ�!", "���� ��ο� ������ִ� ���� �ִµ� �̰ɷ� �� �� ���� ������?" });//ǥ����
        textData.Add(205, new string[] { "4�� ���� ����", "��¦�̾�!, �ȿ��� ���� �����δ�. ���� ��ǰ�� ���踦 ã�Ƽ� ��������.." });//ǥ����
        textData.Add(206, new string[] { "���� 200�� 1~4�� �� ���⼭ ����..." });//ǥ����
        textData.Add(207, new string[] { "........ö��!", "���� ���ȴ�." });//��

        textData.Add(300, new string[] { "......����!" });

    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // ���̻� �����ִ� �ؽ�Ʈ ������ ���� ��
            return null;
        else
            return textData[id][textIndex];
    }


}
