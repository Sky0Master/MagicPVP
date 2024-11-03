using UnityEngine;

public class PlatformControllerAnimate : MonoBehaviour
{
    Animator _animator;
    public string moveAnimKey = "move";
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            _animator.SetBool(moveAnimKey, true);
        }
        else{
            _animator.SetBool(moveAnimKey, false);
        }
    }
}
