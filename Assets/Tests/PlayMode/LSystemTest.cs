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

    // Input Event Handler Tests

    //[UnityTest]
    //public IEnumerator SoilLifted()
    //{
    //    Vector3 liftedSoilValues = new Vector3(379.7141f, 500f, 390.2904f);

    //    GameObject targetObject = GameObject.Find("1,1");

    //    //var invokeChange = targetObject.GetComponent<ScaleSoil>().liftedSoilState;

    //    //invokeChange = false;

    //    targetObject.GetComponent<ScaleSoil>().ChangeSoil();

    //    yield return null;

    //    Assert.AreEqual(liftedSoilValues, targetObject.transform.localScale);

    //}

    //[UnityTest]
    //public IEnumerator ChangeColourSoil()
    //{

    //    Color materialColour = Color.yellow;
        

    //    // Find the GameObject with the PointerEnterHandler attached
    //    var targetObject = GameObject.Find("1,1"); // Unshaded Soil
    //    //Renderer materialRenderer = targetObject.GetComponent<Renderer>();
    //    //var targetObjectMaterial = targetObject.GetComponent<Material>().color;
    //    //Renderer renderer = GetComponent <Renderer>();

    //    //var componentScript = targetObject.AddComponent<HoverColourChange>();
    //    //var lightIntensity = targetObject.AddComponent<LsystemScript>().lightIntensity = 2;


    //    // Add a MeshRenderer component to the new GameObject
    //    //Renderer renderer = targetObject.AddComponent<MeshRenderer>();

    //    // Create a new material and set its color
    //    //Material material = new Material(Shader.Find("Standard")); // You can use a different shader if needed
    //    //material.color = materialColour;

    //    // Assign the material to the Renderer's material
    //    //renderer.material = material;

    //    // Get the EventSystem (if not found, create one)
    //    EventSystem eventSystem = EventSystem.current;

    //    GameObject eventSystemObject = new GameObject("EventSystem");
    //    eventSystemObject.AddComponent<EventSystem>();
    //    eventSystemObject.AddComponent<StandaloneInputModule>();
    //    eventSystem = eventSystemObject.GetComponent<EventSystem>();


    //    // Simulate the pointer entering the GameObject
    //    PointerEventData pointerEventData = new PointerEventData(eventSystem);
    //    pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2); // Set pointer position to center of screen
    //    eventSystem.RaycastAll(pointerEventData, new List<RaycastResult>());
    //    ExecuteEvents.Execute(targetObject, pointerEventData, ExecuteEvents.pointerEnterHandler);

    //    // Wait for a short time to allow events to be processed
    //    yield return null;


    //    // Verify the expected behavior (e.g., change in UI state)
    //    // For example, you can check if the GameObject's color changes upon pointer enter
    //    //Assert.IsTrue(targetObject.GetComponent<Renderer>().material.color == Color.yellow);
    //    //Debug.Log(targetObject.GetComponent<MeshRenderer>().material.color);

    //    //GetComponent<Renderer>().material.color = kubus.GetComponent<Renderer>().material.GetColor("_Color");

    //    Assert.AreEqual(Color.yellow, targetObject.GetComponent<Renderer>().material.color);


    //    //yield return null;

    //}
}






    // -----------------------------------------------------------------

//    // A Test behaves as an ordinary method
//    [Test]
//    public void NewTestScriptSimplePasses()
//    {
//        // Use the Assert class to test conditions
//    }

//    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
//    // `yield return null;` to skip a frame.
//    [UnityTest]
//    public IEnumerator NewTestScriptWithEnumeratorPasses()
//    {
//        // Use the Assert class to test conditions.
//        // Use yield to skip a frame.
//        yield return null;
//    }
//}
