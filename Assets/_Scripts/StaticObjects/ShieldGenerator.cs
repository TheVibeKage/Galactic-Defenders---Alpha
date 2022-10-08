using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : ObjectBase
{
    protected void OnDestroy(){
        Instantiate(_damagedObject, transform.position, transform.rotation);
    }
}
