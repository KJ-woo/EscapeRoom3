using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndObject : MonoBehaviour
{
    public GameManager manager;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "End")
        {
            manager.isEnding = true; //���� �÷������� ��,
        }
    }
}
