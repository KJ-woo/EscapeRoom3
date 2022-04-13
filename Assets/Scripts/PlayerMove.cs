using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public GameManager manager;

    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    private BoxCollider2D boxCollider;


    bool isHorizonMove;// 수평 이동 판단 여부
    float h;
    float v;
    Vector3 dirVec;

    public Text talkText; //UI대화창 텍스트
    public GameObject talkPanel;
    public int textIndex = 0;//순차적으로 대화창을 출력하기위한 변수
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
        h = manager.isExecution ? 0 : Input.GetAxisRaw("Horizontal");//좌우
        v = manager.isExecution ? 0 : Input.GetAxisRaw("Vertical");//상하

        bool hDown = manager.isExecution ? false : Input.GetButtonDown("Horizontal");
        bool hUp = manager.isExecution ? false : Input.GetButtonUp("Horizontal");

        bool vDown = manager.isExecution ? false : Input.GetButtonDown("Vertical");
        bool vUp = manager.isExecution ? false : Input.GetButtonUp("Vertical");

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
            manager.Execution(scanObject);
            manager.QuestExecution(scanObject);
        }

    }
    void FixedUpdate()
    {

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);


        rigid.velocity = moveVec * Speed;

        //레이캐스트 작동하는지 확인
        Debug.DrawRay(rigid.position, dirVec * 0.9f, new Color(1, 0, 0));
        int layerMask = (1 << LayerMask.NameToLayer("DummyObject")) + (1 << LayerMask.NameToLayer("Object"));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.9f, layerMask);

        if (rayHit.collider != null)//만약 뭔가 발견하면
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }



}