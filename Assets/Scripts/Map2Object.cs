using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Map2Object : MonoBehaviour
{
    void Start()
    {
        transform.DOShakeScale(5f).SetLoops(-1);
    }
}
