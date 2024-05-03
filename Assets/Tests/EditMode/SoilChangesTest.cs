using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SoilChangesTest
{

    // A Test behaves as an ordinary method
    [Test]
    public void AcidicPHvalue()
    {
        float phRange = UnityEngine.Random.Range(0f, 6.9f);
        float ph = 7.0f;

        Assert.IsTrue(phRange < ph);
        
    }

    [Test]
    public void AlkalinePHValue()
    {
        float phRange = UnityEngine.Random.Range(7.1f, 14f);
        float phBorderStart = 7f;
        float phBorderEnd = 14.0f;

        Assert.IsTrue(phRange <= phBorderEnd && phRange > phBorderStart);

    }







    // -----------------------------------------------------------------------------

    // A Test behaves as an ordinary method
    [Test]
    public void SoilChangesTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SoilChangesTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
