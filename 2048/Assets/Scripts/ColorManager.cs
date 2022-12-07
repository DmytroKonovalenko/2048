using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instanse;
    public Color[] CellColors;
    [Space(5)]
    public Color PointsDarkColor;
    public Color PointsLightColor;
    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
    }
}
