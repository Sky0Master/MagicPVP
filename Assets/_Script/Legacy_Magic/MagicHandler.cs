using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MagicHandler : NetworkBehaviour
{
    List<Magic> magicList = new List<Magic>();
    public Magic currentMagic;

    //[Command]
    public void AddMagic(Magic magic)
    {
       magicList.Add(magic);
       if (currentMagic == null)
       {
            currentMagic = magic;
       }
    }
    //[Command]
    public void UseMagic()
    {
        if (currentMagic == null)
        {
            return;
        }
        currentMagic.Use();

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
