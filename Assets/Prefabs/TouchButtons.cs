using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButtons : XRBaseInteractable
{
    [Header("Button Settings")]
    public NumberPad NumberPad;
    public string ButtonNumber;
    public Material ActiveMaterial;
    public Material BaseMaterial;
    public Renderer m_RendererToChange;

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
        base.OnHoverEntered(args);
        
        NumberPad.ButtonPressed(ButtonNumber);
        m_RendererToChange.material = ActiveMaterial;
        
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        m_RendererToChange.material = BaseMaterial;
        base.OnHoverExited(args);
    }
}
