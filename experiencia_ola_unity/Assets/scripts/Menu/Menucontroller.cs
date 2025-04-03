using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Transform[] letterPositions; // Posiciones de O, L, A
    public Camera mainCamera;
    public float moveDuration = 1.5f;

    public GameObject[] canvases; // Canvas de O, L, A
    private int currentIndex = 0;

    void Start()
    {
        // Asegurar que solo el primer Canvas esté activo
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == 0);
        }
    }

    public void MoveToNextLetter()
    {
        if (currentIndex < letterPositions.Length - 1)
        {
            int nextIndex = currentIndex + 1;

            // Activamos el siguiente Canvas antes de mover la cámara
            canvases[nextIndex].SetActive(true);

            // Mover la cámara y luego desactivar el Canvas anterior
            LeanTween.move(mainCamera.gameObject, letterPositions[nextIndex].position, moveDuration)
                .setEase(LeanTweenType.easeInOutCubic)
                .setOnComplete(() => {
                    canvases[currentIndex].SetActive(false); // Ahora desactivamos el Canvas anterior
                    currentIndex = nextIndex; // Actualizamos el índice
                });
        }
    }
}
