using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScaleCollectible
{
    IEnumerator ScaleCollectibles(Collider other, float time, float speed);
}
