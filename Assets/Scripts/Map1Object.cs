using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Map1Object : MonoBehaviour
{
    void Start()
    {
        transform.DOShakePosition(2f).SetLoops(-1);
    }
}
