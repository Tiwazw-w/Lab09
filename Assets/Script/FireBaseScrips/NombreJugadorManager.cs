using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
//using Firebase.Unity.Editor;
using System.Collections.Generic;

public class NombreJugadorManager : MonoBehaviour
{
    public InputField inputField;
    public Button guardarButton;

    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        guardarButton.onClick.AddListener(GuardarNombreEnFirebase);
    }

    void GuardarNombreEnFirebase()
    {
        string nombreJugador = inputField.text;
        if (string.IsNullOrEmpty(nombreJugador))
        {
            Debug.LogWarning("El nombre del jugador no puede estar vacío.");
            return;
        }

        string key = reference.Child("nombres").Push().Key;
        Dictionary<string, object> nombreUpdates = new Dictionary<string, object>();
        nombreUpdates["/nombres/" + key] = nombreJugador;

        reference.UpdateChildrenAsync(nombreUpdates).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Nombre del jugador guardado exitosamente.");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Error al guardar el nombre del jugador: " + task.Exception);
            }
        });
    }
}

