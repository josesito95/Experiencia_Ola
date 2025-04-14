using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorLetras : MonoBehaviour
{
    public GameObject letraO;
    public GameObject letraL;
    public GameObject letraA;

    public Material materialEncendido;

    private bool oActiva = false;
    private bool lActiva = false;
    private bool aActiva = false;

    public void ActivarLetra(CuboInteractivo.LetraTipo letra)
    {
        switch (letra)
        {
            case CuboInteractivo.LetraTipo.O:
                if (!oActiva) Activar(letraO); oActiva = true;
                break;
            case CuboInteractivo.LetraTipo.L:
                if (!lActiva) Activar(letraL); lActiva = true;
                break;
            case CuboInteractivo.LetraTipo.A:
                if (!aActiva) Activar(letraA); aActiva = true;
                break;
        }

        if (oActiva && lActiva && aActiva)
        {
            Debug.Log("¡Logo completo!");
            // Podés aquí mostrar un botón o animación
        }
    }

    private void Activar(GameObject letra)
    {
        Renderer rend = letra.GetComponent<Renderer>();
        rend.material = materialEncendido;
        rend.material.EnableKeyword("_EMISSION");
        rend.material.SetColor("_EmissionColor", new Color(242f / 255f, 103f / 255f, 73f / 255f) * 1f);

    }
}