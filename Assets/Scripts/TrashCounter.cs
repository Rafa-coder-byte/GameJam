using UnityEngine;
using TMPro; // Asegúrate de tener esto para usar TextMeshPro

public class TrashCounter : MonoBehaviour
{
    public TextMeshProUGUI trashText; // Cambiar a TextMeshProUGUI
    private int trashCount = 0;

    void Start()
    {
        // Asegurarse de que el texto inicial se muestra
        trashText.text = "Basura Recogida: " + trashCount;
    }

    // Método para incrementar el contador de basura
    public void IncrementTrashCount()
    {
        trashCount++;
        trashText.text = "Basura Recogida: " + trashCount;
    }
}


