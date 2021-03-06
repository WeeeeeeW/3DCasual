﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGameFeel : MonoBehaviour
{
    public Vector3 boucestrength;
    public bool once = true;
    private void OnTriggerEnter(Collider other)
    {
        if (once && other.transform.tag == "Player")
            StartCoroutine(platformbouce());
    }

    IEnumerator platformbouce()
    {
        once = false;
        Vector3 _desiredBouncePos = transform.position - boucestrength;
        Vector3 _originalPos = transform.position;
        while (transform.position.y - _desiredBouncePos.y > .01f)
        {
            transform.position = Vector3.Lerp(transform.position, _desiredBouncePos, .7f);
            yield return new WaitForSeconds(.01f);
        }
        while (_originalPos.y - transform.position.y > .01f)
        {
            transform.position = Vector3.Lerp(transform.position, _originalPos, .7f);
            yield return new WaitForSeconds(.01f);
        }
    }
}
