using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public bool resetJump(bool comedown){
        comedown = false;
        return comedown;
    }

    public float resetJumpF(float jf){
        jf = 25f;
        return jf;
    }

    public int resetI(int i){
        i = 0;
        return i;
    }

    public void dragg(){
        Player.draggable = false;
    }
}
