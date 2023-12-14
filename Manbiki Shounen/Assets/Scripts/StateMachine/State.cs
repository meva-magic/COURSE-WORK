using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();
}
