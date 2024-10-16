using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;   // O objeto que a c�mera vai seguir (o jogador)
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o
    public Vector3 offset;     // Deslocamento da c�mera em rela��o ao jogador

    void Start()
    {
        // Tenta encontrar o objeto com a tag "Player" se n�o foi atribu�do no editor
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        // Define a posi��o desejada da c�mera, mantendo o eixo Z fixo (geralmente em 2D ele � -10 ou outro valor constante)
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;

        // Suaviza a transi��o da c�mera entre a posi��o atual e a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplica a nova posi��o suavizada � c�mera
        transform.position = smoothedPosition;
    }
}