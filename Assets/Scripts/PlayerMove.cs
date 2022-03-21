using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    private BoxCollider2D boxCollider;
    public LayerMask LayerMask;
    bool isHorizonMove;// ���� �̵� �Ǵ� ����
    float h;
    float v;
    Vector3 dirVec;

    

    GameObject scanObject;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");//�¿�
        v = Input.GetAxisRaw("Vertical");//����

        bool hDown = Input.GetButtonDown("Horizontal");
        bool hUp = Input.GetButtonUp("Horizontal");

        bool vDown = Input.GetButtonDown("Vertical");
        bool vUp = Input.GetButtonUp("Vertical");

        if (vUp || hDown)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;

        if (anim.GetInteger("VAxisRaw") != v)
        {
            anim.SetBool("Change", true);
            anim.SetInteger("VAxisRaw", (int)v);
        }
        else if (anim.GetInteger("HAxisRaw") != h)
        {
            anim.SetBool("Change", true);
            anim.SetInteger("HAxisRaw", (int)h);
        }
        else
            anim.SetBool("Change", false);


        //����ĳ��Ʈ ����
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (vDown && h == 1)
            dirVec = Vector3.right;
        else if (vDown && h == -1)
            dirVec = Vector3.left;

        //�����̽��ٷ� ������Ʈ���� ��ȣ�ۿ�
        if(Input.GetButtonDown("Jump") && scanObject !=null)
        {
            //Debug.Log(scanObject.name); //Ȯ�ο�
        }
    }
    void FixedUpdate()
    {

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);


        rigid.velocity = moveVec * Speed;

        //����ĳ��Ʈ �۵��ϴ��� Ȯ��
        //Debug.DrawRay(rigid.position, dirVec * 0.6f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.6f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)//���� ���� �߰��ϸ�
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

}
