using UnityEngine;


public class camaraPersonaje : MonoBehaviour
{
    [SerializeField] private Transform target; // Target personaje
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    //decirle a la cámara “no te pegues tanto al personaje, muévete un poco más arriba, al costado, o atrás”

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        //suaviza el movimiento de la camara.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}

