using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    Animator anim;
    bool walking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            walking = true;

            //Tomamos el numero que nos devuelve Input.GetAxisRaw(-1, 0 o 1) y lo multiplicamos por el movimiento
            //Si multiplico por -1 va para atras, por 1 adelante y 0 no se mueve
            transform.position += transform.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            //Lo mismo con la rotacion, 1 a la derecha, -1 a la izq, 0 no rota
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * 360 * rotSpeed * Time.deltaTime);
        }
        else
        {
            walking = false;
        }

        anim.SetBool("Walking", walking);
        anim.SetFloat("Direction", Input.GetAxisRaw("Vertical"));
    }
}
