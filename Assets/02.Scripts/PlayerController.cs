using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float jumpForce = 680.0f; // 점프의 힘
    private float autoMoveSpeed = 2.0f; // 자동 이동 속도
    private float maxWalkSpeed = 7.0f; // 최대 이동 속도
    private bool GroundFlag = false;
    private Animator animator;
    private int jumpCount = 0; // 점프 카운트
    //점수UI
    public Text ScoreText;
    public int ScorePoint = 0;
    //플레이어 HP바
    public float PlayerHP = 100.0f;
    public Image HpBar;
    //카메라
    private Camera mainCamera;
    private bool isSpinning = false; // 회전 중인지 여부

    void Start()
    {
        this.rbody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (transform.position.y < -20.0f)
        {
            PlayerHP = 0;
            HpBar.fillAmount = 0;
            Debug.Log("플레이어 낙사");
            Debug.Log("최고점수 : " + ScorePoint);
            SceneManager.LoadScene("EndScene");
        }

        // 점프 및 더블 점프
        if (Input.GetKeyDown(KeyCode.Space) && (GroundFlag || jumpCount < 1))
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0); // 현재 y 속도를 초기화
            rbody.AddForce(transform.up * jumpForce);
            jumpCount++;
            if (jumpCount == 1)
            {
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsDoubleJumping", false);
            }
            else
            {
                animator.SetBool("IsDoubleJumping", true);
            }
        }

        // 우측으로 자동 이동
        if (!isSpinning)
        {
            Vector2 newVelocity = rbody.velocity;
            newVelocity.x = autoMoveSpeed;
            float speedx = Mathf.Abs(newVelocity.x);

            // 이동 속도 제한
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxWalkSpeed, maxWalkSpeed);

            rbody.velocity = newVelocity;

            // 방향 전환 (항상 오른쪽을 향하게 함)
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;

            // 애니메이터 속도 설정
            this.animator.speed = speedx / 2.0f;
        }
    }

    public void ScoreUp()
    {
        ScorePoint += 100;
        ScoreText.text = ScorePoint.ToString();
    }

    public void PlayerHPMinus()
    {
        PlayerHP -= 10.0f;
        if (PlayerHP < 1)
        {
            Debug.Log("최고점수 : " + ScorePoint);
            SceneManager.LoadScene("EndScene");
        }
        HpBar.fillAmount = PlayerHP / 100.0f;
    }

    public void SpinPlayer()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinRoutine());
        }
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;
        float spinDuration = 1.5f; // 회전 지속 시간
        float spinSpeed = 720.0f; // 회전 속도 (도/초)
        float elapsedTime = 0.0f;

        while (elapsedTime < spinDuration)
        {
            float rotationAmount = spinSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 회전 완료 후 원래 각도로 복귀
        transform.rotation = Quaternion.identity;
        isSpinning = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GroundFlag = true;
        jumpCount = 0; // 땅에 닿으면 점프 카운트 초기화
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
        animator.SetBool("IsWalking", true); // Walk 상태로 돌아가기
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GroundFlag = false;
        animator.SetBool("IsWalking", false); // 공중에 있을 때 Walk 상태 해제
    }
}
