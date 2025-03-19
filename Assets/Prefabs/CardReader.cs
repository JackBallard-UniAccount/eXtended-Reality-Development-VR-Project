using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [Header("CardReader Settings")]
    public XRSocketInteractor socket;
    public GameObject Card;
    
    public DoorScript Door;
    private Vector3 keycardInPos;
    private Vector3 keycardOutPos;
    bool swipIsValid = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        Quaternion quaternion;
        Card.transform.GetPositionAndRotation(out keycardInPos, out quaternion);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        keycardOutPos = Card.transform.position;
        if(keycardInPos.y - keycardOutPos.y >= 0.22f)
        {
            swipIsValid = true;
            Door.Unlock();
        }
        else
        {
            swipIsValid = false;
        }
        Debug.Log(keycardInPos);
        Debug.Log(keycardOutPos);
        Debug.Log(swipIsValid);

    }
}
