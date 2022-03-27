using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    private BoxCollider2D boxCollider;
    public LayerMask LayerMask;
    bool isHorizonMove;// 수평 이동 판단 여부
    float h;
    float v;
    Vector3 dirVec;

    public TextManager manager;
    public Text talkText;

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
        h = Input.GetAxisRaw("Horizontal");//좌우
        v = Input.GetAxisRaw("Vertical");//상하

        bool hDown = Input.GetButtonDown("Horizontal");
        bool hUp = Input.GetButtonUp("Horizontal");

        bool vDown = Input.GetButtonDown("Vertical");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;


        if (anim.GetInteger("VAxisRaw") != v)//상하키 눌렀을 때
        {
            anim.SetBool("Change", true);
            anim.SetInteger("VAxisRaw", (int)v);
        }

        else if (anim.GetInteger("HAxisRaw") != h) // 좌우키 눌렀을때
        {
            anim.SetBool("Change", true);
            anim.SetInteger("HAxisRaw", (int)h);
        }
        else
            anim.SetBool("Change", false);


        //레이캐스트 방향
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

        //스페이스바로 오브젝트와의 상호작용
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            if(scanObject.layer == LayerMask.NameToLayer("DummyObject"))
                talkText.text = "나에겐 필요없는 것 같다... 다른걸 찾아보자.....";
        }
    }
    void FixedUpdate()
    {

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);


        rigid.velocity = moveVec * Speed;

        //레이캐스트 작동하는지 확인
        Debug.DrawRay(rigid.position, dirVec * 0.9f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.9f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)//만약 뭔가 발견하면
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

}