using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    
    

    private Vector3 velocity;
    

    void Update()
    {
        // Recebe as entradas do teclado (WASD ou setas)
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * y;

        // Move o personagem
        controller.Move(move * speed * Time.deltaTime);
    }
}


