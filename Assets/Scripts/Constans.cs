using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constans {

    private static Constans instance;
    public static Constans Instance { get { return instance; } }

    public static bool IsGameDone { get; set; }

    public static float clickedValue { get; set; }

    public static int swipeCount { get; set; }
}
