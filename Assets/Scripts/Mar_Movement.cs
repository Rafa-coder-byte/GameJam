using System.Collections;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float speed = 1f; // Velocidad de movimiento del mar
    public float amplitude = 4f; // Amplitud del movimiento vertical
    public float upperLimit = 1f; // L�mite superior constante
    public float upperWaitTime = 2f; // Tiempo de espera en la posici�n superior
    public float lowerWaitTime = 3f; // Tiempo de espera en la posici�n inferior

    private Vector3 startPosition;
    private bool isWaiting = false;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveSea());
    }

    IEnumerator MoveSea()
    {
        while (true)
        {
            if (!isWaiting)
            {
                // Calcular la posici�n en la parte inferior usando amplitude
                float newYPosition = upperLimit - Mathf.PingPong(Time.time * speed, amplitude);

                transform.position = new Vector3(transform.position.x, startPosition.y + newYPosition, transform.position.z);

                // Check for upper position wait
                if (Mathf.Approximately(newYPosition, upperLimit))
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(upperWaitTime);
                    isWaiting = false;
                }
                // Check for lower position wait
                else if (Mathf.Approximately(newYPosition, upperLimit - amplitude))
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(lowerWaitTime);
                    isWaiting = false;
                }
            }
            yield return null;
        }
    }
}




