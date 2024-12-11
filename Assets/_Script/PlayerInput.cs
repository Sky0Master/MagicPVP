using UnityEngine;

namespace VinoUtility
{

[DefaultExecutionOrder(-99)]
public class PlayerInput : MonoBehaviour {

    public float XRaw {get; private set;}

    public float YRaw { get; private set;}
    
    public float MouseX { get; private set; }
    public float MouseY { get; private set;}
    public float MouseXRaw { get; private set; }
    public float MouseYRaw { get; private set; }
    
    public bool Fire1 { get; private set; }
    public bool Fire2 { get; private set; }
    public bool Fire1Hold { get; private set; }
    public bool Fire2Hold { get; private set; }

    public bool Interact { get; private set; }
    public bool InteractHold { get; private set; }

    
    public Vector2 AxisRaw()  { return new Vector2(XRaw, YRaw); }


   
    [HideInInspector]
    public KeyCode leftKey = KeyCode.A;
    
    [HideInInspector]
    public KeyCode rightKey = KeyCode.D;

    [HideInInspector]
    public KeyCode upKey = KeyCode.W;
    
    [HideInInspector]
    public KeyCode downKey = KeyCode.S;

    [HideInInspector]
    public KeyCode fire1Key = KeyCode.Mouse0;
    
    [HideInInspector]
    public KeyCode fire2Key = KeyCode.Mouse1;

    [HideInInspector]
    public KeyCode interactKey = KeyCode.E;

    public void HandleXY()
    {
        XRaw = 0f;  YRaw = 0f;
        if(Input.GetKey(leftKey))
        {
            XRaw += -1f;
        }
        if(Input.GetKey(rightKey))
        {
            XRaw += 1f;
        }
        if(Input.GetKey(upKey))
        {
            YRaw += 1f;
        }
        if(Input.GetKey(downKey))
        {
            YRaw += -1f;
        }
    }
    public void HandleFire()
    {
        Fire1 = Input.GetKeyDown(fire1Key);
        Fire2 = Input.GetKeyDown(fire2Key);
        Fire1Hold = Input.GetKey(fire1Key);
        Fire2Hold = Input.GetKey(fire2Key);
    }
    public void HandleMouse()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        MouseXRaw = Input.GetAxisRaw("Mouse X");
        MouseYRaw = Input.GetAxisRaw("Mouse Y");
    }
    public void HandleInteract()
    {
        Interact = Input.GetKeyDown(interactKey);
        InteractHold = Input.GetKey(interactKey);
    }
    private void Update() {
        HandleXY();
        HandleFire();
        HandleMouse();
        HandleInteract();
    }
    
}
}