using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Transform[] letterPositions; // Posiciones de O, L, A
    public Camera mainCamera;
    public float moveDuration = 1.5f;

    public GameObject[] canvases; // Canvas de O, L, A
    private int currentIndex = 0;
    private bool isMoving = false; // Para evitar múltiples clics durante el movimiento

    void Start()
    {
        // Solo el primer canvas está activo al iniciar
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == 0);
        }
    }

    public void MoveToNextLetter()
    {
        if (isMoving || currentIndex >= letterPositions.Length - 1)
            return;

        isMoving = true;

        int nextIndex = currentIndex + 1;

        // Desactivamos el canvas actual antes de mover
        canvases[currentIndex].SetActive(false);

        // Movemos la cámara
        LeanTween.move(mainCamera.gameObject, letterPositions[nextIndex].position, moveDuration)
            .setEase(LeanTweenType.easeInOutCubic)
            .setOnComplete(() =>
            {
                // Activamos el nuevo canvas cuando termina el movimiento
                canvases[nextIndex].SetActive(true);
                currentIndex = nextIndex;
                isMoving = false;
            });
    }
}
