using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayer
{
    [UnityTest]
    public IEnumerator TestPlayerMovement()
    {
        GameObject player = new GameObject();
        

        yield return new WaitForEndOfFrame();
    }
}
