using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // ?i?m camera c� th? theo d�i

    public float smoothing; //bien l�m min de camera muot hon

    Vector3 offset; //vi tr� cua nh�n vat ??n v? tr� c?a camera

    float lowY; //khi b? r?i xu?ng camera s? kh�ng ?i theo nh�n v?t

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; //offset 1 = v? tr� cam hien tai - vi tr� c?a nh�n v?t

        lowY = transform.position.y; //lowY= vi tr� mac dinh theo truc y
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCampos = offset + target.position; // v? tri cam = vi tri cua nhan vat + offset

        transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime); // di chuyen vi tri cam1 sang vi tri cam2 , transform.position : vi tri hien tai

        /* if (transform.position.y < lowY) //neu vi tri hien tai truc y < truc y mac dinh

             transform.position = new Vector3(transform.position.x, lowY, transform.position.z); // khi nhan vat roi xuong se co vi tri camera moi */

        /*if (transform.position.y > lowY) //kh�a camera .. camera kh�ng th? di chuy?n l�n n?u nh�n v?t nh?y

            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);*/
    }
}
