using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class administracionpanoramica : MonoBehaviour
{
    public  GameObject images;
    int i;
    public GameObject panel;
    public TextMeshProUGUI texto;
    private string[] mensajes;
    void Start()
    {
        i = 0;
        images.transform.GetChild(i).gameObject.SetActive(true);
        mensajes = new string[images.transform.childCount];
        for (int x = 0; x < mensajes.Length - 1; x++)
        {
            mensajes[x] = "";
        }
        mensajes[0] = "Año 2055: En un mundo donde la naturaleza ha sido descuidada, el corazón de Javier se inunda de tristeza al ver la devastación a su alrededor...Javier, un anciano, está mirando con tristeza por la ventana de su casa. Frente a él se extienden dos paisajes devastados: una playa contaminada y una ciudad que ha dejado de lado los espacios naturales.";
        mensajes[5] = "De repente, una gran burbuja color cian aparece flotando desde el cielo y explota suavemente junto a Javier. La burbuja mágica lo rejuvenece en un instante, transformándolo en un joven adulto lleno de vigor. Mirando a la burbuja que permanece junto a él, empieza a hacer preguntas...";
        mensajes[6] = "Javier (jóven adulto): ¿Qué ha pasado? ¿Dónde estoy... Qué es esta burbuja?";
        mensajes[8] = "Burbuja Cian: No temas, Javier. Soy una burbuja mágica del tiempo, y te he traído 30 años atrás(2025) para evitar la destrucción que viste. Ahora tienes una nueva oportunidad para salvar estos lugares y cumplir con los objetivos de desarrollo sostenible.                                                                       Javier: ¿Sostenibilidad? ¿Cómo puedo ayudar?";
        mensajes[10] = "Burbuja Cian: Empieza por limpiar la playa... Debemos garantizar agua limpia y sanear los mares. Pero ten cuidado, Black Bubble no quiere que logres tu misión. Javier y la Burbuja Cian salen de la casa y miran un camino que se divide en dos direcciones: Playa y Ciudad. Javier elige el camino hacia la playa...";
        mensajes[11] = "Burbuja Cian: Nuestro primer objetivo es la playa. Construir un futuro mejor comienza con un océano limpio. ¡Vamos allá!";
        mensajes[12] = "Burbuja Cian: Recuerda, Black Bubble evitara a toda costa limpies la playa. Es una burbuja que nació producto de la contaminación de los mares, así que para derrotarla tendrás que limpiar toda la playa. ¡Puedes hacerlo, Javier!";
        texto.text = mensajes[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (mensajes[i] == "") panel.gameObject.SetActive(false);
        else panel.gameObject.SetActive(true); 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i == images.transform.childCount - 1) SceneManager.LoadScene(2);
            else
            {
                i++;
                for (int x = 0; x < images.transform.childCount; x++)
                {
                    if (x == i) images.transform.GetChild(x).gameObject.SetActive(true);
                    else images.transform.GetChild(x).gameObject.SetActive(false);
                    
                }
                texto.text = mensajes[i];
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (i == 0) SceneManager.LoadScene(0);
            else
            {
                i--;
                for (int x = 0; x < images.transform.childCount; x++)
                {
                    if (x == i) images.transform.GetChild(x).gameObject.SetActive(true);
                    else images.transform.GetChild(x).gameObject.SetActive(false);
                    
                }
                texto.text = mensajes[i];
            }
        }
    }
}
