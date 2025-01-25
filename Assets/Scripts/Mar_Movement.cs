using System.Collections;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float speed = 1f; // Velocidad de movimiento del mar
    public float amplitude = 1f; // Amplitud del movimiento vertical
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



/*using System.Collections;
using UnityEngine;

public class MarMovement : MonoBehaviour
{
    public float alturaMovimiento = 0.5f;  // Altura máxima a la que el mar subirá  
    public float velocidadMovimiento = 1f;  // Velocidad del movimiento  
    public float tiempoArriba = 2f;  // Tiempo en la posición alta  
    public float tiempoAbajo = 5f;  // Tiempo en la posición baja  

    private Vector3 posicionInicial;  // Para guardar la posición inicial del mar  

    void Start()
    {
        // Guardar la posición inicial del objeto  
        posicionInicial = transform.position;
        // Iniciar el ciclo de movimiento  
        StartCoroutine(MoverMar());
    }

    private IEnumerator MoverMar()
    {
        while (true) // Ciclo infinito  
        {
            // Subir el mar  
            yield return StartCoroutine(SubirMar());
            // Esperar tiempo en la parte alta  
            yield return new WaitForSeconds(tiempoArriba);
            // Bajar el mar  
            yield return StartCoroutine(BajarMar());
            // Esperar tiempo en la parte baja  
            yield return new WaitForSeconds(tiempoAbajo);
        }
    }

    private IEnumerator SubirMar()
    {
        float tiempoTranscurrido = 0f;
        Vector3 posicionFinal = posicionInicial + new Vector3(0, alturaMovimiento, 0); // Nueva posición al subir  

        // Movimiento hacia arriba  
        while (tiempoTranscurrido < alturaMovimiento / velocidadMovimiento)
        {
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, tiempoTranscurrido / (alturaMovimiento / velocidadMovimiento));
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Esperar un frame  
        }

        // Asegurarse de que esté exactamente en la posición final  
        transform.position = posicionFinal;
    }

    private IEnumerator BajarMar()
    {
        float tiempoTranscurrido = 0f;
        Vector3 posicionFinal = posicionInicial; // Regresar a la posición inicial  

        // Movimiento hacia abajo  
        while (tiempoTranscurrido < alturaMovimiento / velocidadMovimiento)
        {
            transform.position = Vector3.Lerp(posicionFinal + new Vector3(0, alturaMovimiento, 0), posicionFinal, tiempoTranscurrido / (alturaMovimiento / velocidadMovimiento));
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Esperar un frame  
        }

        // Asegurarse de que esté en la posición inicial  
        transform.position = posicionFinal;
    }
}*/