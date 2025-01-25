using System.Collections;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float speed = 1f; // Velocidad de movimiento del mar
    public float amplitude = 4f; // Amplitud del movimiento vertical
    public float upperLimit = 1f; // Límite superior constante
    public float upperWaitTime = 2f; // Tiempo de espera en la posición superior
    public float lowerWaitTime = 3f; // Tiempo de espera en la posición inferior

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
                // Calcular la posición en la parte inferior usando amplitude
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




/*using System.Collections;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float speed = 1.5f; // Velocidad de movimiento del mar ajustada
    public float amplitude = 10f; // Amplitud del movimiento vertical aumentada
    public float upperWaitTime = 2f; // Tiempo de espera en la posición superior
    public float lowerWaitTime = 3f; // Tiempo de espera en la posición inferior

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
                float pingPong = Mathf.PingPong(Time.time * speed, amplitude * 2) - amplitude;
                transform.position = new Vector3(transform.position.x, startPosition.y + pingPong, transform.position.z);

                // Check for upper position wait
                if (Mathf.Approximately(pingPong, amplitude))
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(upperWaitTime);
                    isWaiting = false;
                }
                // Check for lower position wait
                else if (Mathf.Approximately(pingPong, -amplitude))
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

*/