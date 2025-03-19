using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : XRSimpleInteractable
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField]
    public Transform DraggedTransform; // set to parent door object
    public Vector3 LocalDragDirection; // set to -1, 0, 0
    public float DragDistance; // set to 0.8
    public int DoorWeight = 20;
    public GameObject LockingBar;

    private bool locked = true;
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_WorldDragDirection;
    private void Start()
    {
        m_WorldDragDirection = transform.TransformDirection(LocalDragDirection).normalized;

        m_StartPosition = DraggedTransform.position;
        m_EndPosition = m_StartPosition + m_WorldDragDirection * DragDistance;
    }

    public void Unlock()
    {
        LockingBar.SetActive(false);
        locked = false;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (isSelected && !locked)
        {
            var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);

            Vector3 selfToInteractor = interactorTransform.position - transform.position;
            float dotProduct = Vector3.Dot(selfToInteractor, m_WorldDragDirection);

            float speed = dotProduct * DoorWeight * Time.deltaTime;

            DraggedTransform.position = Vector3.MoveTowards(DraggedTransform.position, m_EndPosition, speed);

            float distanceFromStart = Vector3.Dot(DraggedTransform.position - m_StartPosition, m_WorldDragDirection);
            if (distanceFromStart < 0) // Prevent moving past start
            {
                DraggedTransform.position = m_StartPosition;

            }
        }
    }
}
