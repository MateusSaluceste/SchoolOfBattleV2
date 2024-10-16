using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    private Vector3 velocity;
    private Animator animator;
    private bool isMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura o input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Atualiza os parâmetros do Animator
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        // Determina o vetor de movimento
        Vector3 move = transform.right * x + transform.up * y;


        // Verifica se o personagem está se movendo
        isMoving = move.magnitude > 0;

        // Move o personagem
        controller.Move(move * speed * Time.deltaTime);

        // Atualiza o parâmetro "isMoving" no Animator
        animator.SetBool("isMoving", isMoving);
    }
}