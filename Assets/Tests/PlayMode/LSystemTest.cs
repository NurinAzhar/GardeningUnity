using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Schema;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.TestTools;
using static LsystemScript;
using static SoilPH;

public class LSystemTest
{

    

    [UnityTest]
    public IEnumerator SoilCheckAcidic()
    {
        var soil = new GameObject();
        var soilWithComponent = soil.AddComponent<SoilPH>();

        soilWithComponent.phRange = UnityEngine.Random.Range(0f, 6.9f);

        soilWithComponent.Update_ForTest();

        Assert.IsTrue(soilWithComponent.phLevel == SoilPh.Acidic);

        yield return null;

    }

    [UnityTest]
    public IEnumerator SoilCheckAlkaline()
    {
        var soil = new GameObject();
        var soilWithComponent = soil.AddComponent<SoilPH>();

        soilWithComponent.phRange = UnityEngine.Random.Range(7.1f, 14f);

        soilWithComponent.Update_ForTest();

        Assert.IsTrue(soilWithComponent.phLevel == SoilPh.Alkaline);

        yield return null;

    }

    [UnityTest]
    public IEnumerator SoilCheckNeutral()
    {
        var soil = new GameObject();
        var soilWithComponent = soil.AddComponent<SoilPH>();

        soilWithComponent.phRange = 7;

        soilWithComponent.Update_ForTest();

        Assert.IsTrue(soilWithComponent.phLevel == SoilPh.Neutral);

        yield return null;

    }
}


