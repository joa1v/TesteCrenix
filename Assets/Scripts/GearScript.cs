using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GearScript : MonoBehaviour
{
    public GearsManager gearsManager;
    private bool selected;
    private bool attached;
    private bool spinClockwise;
    private Vector3 initialPos;
    public float rotSpeed;
    private RaycastHit2D hit;
    private GearPlacementScript gearPlacement;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (selected)
            transform.position = Input.mousePosition;
        if (attached)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    public void Hold()
    {
        selected = true;
        if (attached)
        {
            gearsManager.gearsPlacedCount--;
            attached = false;
        }
        if (gearPlacement)
        {
            gearPlacement.isFilled = false;
            gearPlacement = null;
        }
    }

    public void Drop()
    {
        selected = false;
        //CHECA SE NA HORA QUE SOLTOU O MOUSE, FOI EM UMA LUGAR DE COLOCAR ENGRENAGEM
        if (hit && hit.transform.GetComponent<GearPlacementScript>())
        {
            gearPlacement = hit.transform.GetComponent<GearPlacementScript>();
            //CHECA SE É P GIRAR HORARIO OU ANTI-HORARIO
            if (hit.transform.tag == "SpinClockwise")
                spinClockwise = true;
            else if (hit.transform.tag == "SpinAntiClockwise")
                spinClockwise = false;
            //SÓ GRUDA SE O LUGAR DE COLOCAR ESTIVER VAZIO
            if (!gearPlacement.isFilled)
            {
                attached = true;
                gearsManager.gearsPlacedCount++;
                gearPlacement.isFilled = true;
            }
        }
    }

    public void StartSpin()
    {
        if (spinClockwise)
        {
            SpinClockwise();
        }
        else
            SpinAnticlockwise();
    }
    public void SpinClockwise()
    {
        GetComponent<Rigidbody2D>().angularVelocity = -rotSpeed;
    }

    public void SpinAnticlockwise()
    {
        GetComponent<Rigidbody2D>().angularVelocity = rotSpeed;
    }

    public void ResetPos()
    {
        transform.position = initialPos;
        attached = false;
        gearsManager.gearsPlacedCount = 0;
        StopSpin();
    }

    public void StopSpin()
    {
        GetComponent<Rigidbody2D>().rotation = 0;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
