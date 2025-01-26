using UnityEngine;
using TMPro; // Aseg�rate de tener esto para usar TextMeshPro

public class TrashCounter : MonoBehaviour

{   
    public TextMeshProUGUI trashText; // Cambiar a TextMeshProUGUI
    public int trashCount ;
    private RandomObjectSpawner spawner;

    public int TrashCount // Propiedad para acceder a trashCount
    {
        get { return trashCount; }
    }

    void Start()
    {
        // Asegurarse de que el texto inicial se muestra
        trashCount = 0;
        trashText.text = "Basura Recogida: " + trashCount;
    }

    // M�todo para incrementar el contador de basura
    public void IncrementTrashCount()
    {
        trashCount++;
        trashText.text = "Basura Recogida: " + trashCount;

        // Notifica al GestorDeBasura para verificar si es hora de activar el boss
        GestorDeBasura gestorDeBasura = GetComponent<GestorDeBasura>();
        if (gestorDeBasura != null)
        {
            gestorDeBasura.VerificarYActivarBoss();
            
        }
    }
}




