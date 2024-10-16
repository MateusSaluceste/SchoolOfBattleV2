using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;   // O objeto que a câmera vai seguir (o jogador)
    public float smoothSpeed = 0.125f; // Velocidade de suavização
    public Vector3 offset;     // Deslocamento da câmera em relação ao jogador

    void Start()
    {
        // Tenta encontrar o objeto com a tag "Player" se não foi atribuído no editor
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        // Define a posição desejada da câmera, mantendo o eixo Z fixo (geralmente em 2D ele é -10 ou outro valor constante)
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;

        // Suaviza a transição da câmera entre a posição atual e a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplica a nova posição suavizada à câmera
        transform.position = smoothedPosition;
    }
}