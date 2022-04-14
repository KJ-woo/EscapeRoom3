using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
   
    Dictionary<int, string[]> textData;
    Dictionary<int[], string[]> caseData;

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
        textData.Add(102, new string[] { "������ִ�..", "���⼭�� �� �� �ִ� ����� ���� �� ����.\n�ٸ� �� ã�ƺ���..." });// map1 ����
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
        textData.Add(207, new string[] { "ö��..", "���� ����ִ� �ڷ� ���� ���踦 ã�ƺ���.." });//����X
        textData.Add(208, new string[] { "........ö��! ���� ���ȴ�."});//����O

        textData.Add(300, new string[] { "�̵���.....","���? �Ҿ����ؼ� ����̵��� ���� �ʴ´�\n�̵����� ã�� �񼮰� �����ϸ� �̵��� �� �� ����." });
        textData.Add(301, new string[] { "������ ��","�����̴� ����...������ ����....����..ã�ƶ�...�о��" });
        textData.Add(302, new string[] { "���� �ִ� ����ġ�� ������ �ؿ� �ִ� ���� ���ȴ�." });
        textData.Add(303, new string[] { "����ġ�� �ٽ� ������ �ؿ� �ִ� ���� �ٽ� ������.\n�ٽ� ������ ���� ����." });
        textData.Add(304, new string[] { "....ö��! ���ڰ� ���ȴ�!\n���ڿ��� �ڷ���Ʈ�� �ʿ��� �̵����� �־���.!\n���� ������ҷ� �̵��ұ�?" }); //���踦 ã���� ��, ����
        textData.Add(305, new string[] { "������ִ�..", "���ڸ� �� �� �ִ� ����� ������?\n���踦 ã�ƺ���" });// ���踦 �� ã���� ��, ����
        textData.Add(306, new string[] { "�̹� �̵����� �����.\n���� ��ҷ� �̵�����" });// ��������
        textData.Add(307, new string[] { "�׾Ƹ� �ȿ� �ƹ��͵� ������.", "�ٸ� �׾Ƹ��� ã�ƺ���" });// ����x �׾Ƹ�
        textData.Add(308, new string[] { "�׾Ƹ� �ȿ� ���踦 ã�Ҵ�!", "���ڸ� �����.." });


        textData.Add(400, new string[] { "��Ī�� ��","����....��Ī...�ݵ��..." }); //��3 ǥ����
        textData.Add(401, new string[] { "���ڸ� �μ̴�.\n�ȿ� �Ǵٸ� ���ڰ� �־���!" }); // ��Ī�� �ƴ� ������Ʈ
        textData.Add(402, new string[] { "���� ��Ī�� �Ǿ���." });

        textData.Add(500, new string[] { "���� �׸��� ��","��.. ��������.....�� ������.." });
        textData.Add(501, new string[] { "�⵵��.....","�⵵�� ���� �� ���� ��������.." });
        textData.Add(502, new string[] { "�ʹ� ���ſ� ��¦���� �ʴ´�...\n���� ����� ������?" });
        textData.Add(503, new string[] { "���� �������� ���� �ű� �� ���� �� ����....","���� �Űܺ���." });
    }
    public string getText(int id,int textIndex)
    {
        if (textIndex == textData[id].Length) // ���̻� �����ִ� �ؽ�Ʈ ������ ���� ��
            return null;
        else
            return textData[id][textIndex];
    }
 

}
