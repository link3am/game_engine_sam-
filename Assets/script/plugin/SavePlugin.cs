using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SavePlugin : MonoBehaviour
{
    [DllImport("plugin")]
    private static extern int GetId();

}
