using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using UnityEditor.Animations;
using Unity.VisualScripting;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine.UIElements;
using UnityEditor.ShaderKeywordFilter;
using System.Data;


// Store values of positions and rotations of plant by calling in a stack
public class TransformationsInfo
{
    public Vector3 position;
    public Quaternion rotation;
}



public class LsystemScript : MonoBehaviour
{

    [SerializeField]
    private float length = 2f;

    [SerializeField]
    private float angleTurn = 30f;

    [SerializeField]
    private float width = 1f;

    [SerializeField]
    private int iterations = 4;

    [SerializeField]
    public float variance = 10f;

    [SerializeField]
    [Range(0, 5)]
    public int treeTypes = 0;


    public GameObject Tree = null;

    [SerializeField]
    private GameObject Branch;
    [SerializeField]
    private GameObject Leaf;
    [SerializeField]
    private GameObject LeafPink;
    [SerializeField]
    private GameObject LeafPurple;
    [SerializeField]
    private GameObject TreeParent;


    private const string axiom = "X";

    private Stack<TransformationsInfo> transformStack;

    // Dictionary to store rules for a single plant
    private Dictionary<char, string> rule1, rule2, rule3, rule4, rule5, rule6;
    private Dictionary<char, string> currentPlant;


    //List to store all dictionary rules of plants
    private List<Dictionary<char, string>> rules = new List<Dictionary<char, string>>();

    private int iterationsLastFrame;
    private float angleLastFrame;
    private float widthLastFrame;
    private float lengthLastFrame;
    private Vector3 currentPos;
    private Vector3 nextPos;
    private string currentString = string.Empty;
    private Vector3 initPosition = Vector3.zero;
    private float[] randomRotationValues = new float[100];


    // Use this for initialisation
    void Start() 
    {

        transformStack = new Stack<TransformationsInfo>();

        iterationsLastFrame = iterations;
        angleLastFrame = angleTurn;
        widthLastFrame = width;
        lengthLastFrame = length;

        for (int i = 0; i < randomRotationValues.Length; i++)
        {
            randomRotationValues[i] = UnityEngine.Random.Range(-5f, 5f);
        }

        // Rules -> Each dictionary correspond to a diff plant
        try
        {
            // Acidic loving plants
            // Tree 1 - Rhododendron + slight pink
            rule1 = new Dictionary<char, string>
        {
            { 'X', "[*+FX]X[+F#X][/+F#-FX#]" },
            { 'F', "FF" }
        };

            // Tree 2 - Camellia 
            rule2 = new Dictionary<char, string>
        {
            { 'X', "[F[-X+F[+FX]][*-X+F[+FX]][/-X+F[+FX]-X]]" },
            { 'F', "FF" }
        };

            // Tree 3 - Azelea (same rule as tree 3 but need pink for some places)
            rule3 = new Dictionary<char, string>
        {
            { 'X', "[F[-X+F[+FX#]][*-X+F[+FX#]][/-X+F[+FX#]-X]#]" },
            { 'F', "FF" }
        };

            // Alkaline-loving plants
            // Tree 4 - Moor grass
            rule4 = new Dictionary<char, string>
        {
            { 'X', "[F[/-X+F[+FX]-X]][*FX/F*X][F/*F]" },
            { 'F', "FF" }
        };
            // Tree 5 - Lavender (same rule as tree 3 but need purple for some places)
            rule5 = new Dictionary<char, string>
        {
            { 'X', "[F^^^[/-X^^^+F^^[+FX^^^]-X^^^]][*FX^^/F*X^^][F^/*F^^]" },
            { 'F', "FF" }
        };

            // Tree 6 - Phacelia -adapted by Paul Brooke's L-system sticks
            rule6 = new Dictionary<char, string>
        {
            { 'X', "[F[+X/FX+/*^^^]F[-X/F+/F*^^^]+X/*XF^^^]" },
            { 'F', "FF" }
        };
          

            rules.Add(rule1);
            rules.Add(rule2);
            rules.Add(rule3);
            rules.Add(rule4);
            rules.Add(rule5);
            rules.Add(rule6);

            Generate();
            
        } catch(Exception ex) { Debug.Log(ex.ToString()); }
    }



    private void Generate()
    {

        Destroy(Tree);

        Tree = Instantiate(TreeParent);

        currentString = axiom;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            foreach (char c in currentString)
            {
                // Append rule corresponding to key if current string contains key else append current string
                sb.Append(currentPlant.ContainsKey(c) ? currentPlant[c] : c.ToString());

            }

            currentString = sb.ToString();
            sb = new StringBuilder(); // Reset string builder at every iteration
        }

        //Debug.Log(currentString);

        foreach (char c in currentString)
        {

            switch (c)
            {
                // Move forward by line length drawing a line
                case 'F':
                    initPosition = transform.position;
                    transform.Translate(Vector3.up * 2 * length);

                    GameObject segment = currentString[(c + 1) % currentString.Length] == 'X' || currentString[(c + 3) % currentString.Length] == 'F' 
                                          && currentString[(c + 4) % currentString.Length] == 'X' ? Instantiate(Leaf) : Instantiate(Branch);

                    //GameObject segment = Instantiate(Branch);
                    segment.transform.SetParent(Tree.transform);
                    segment.GetComponent<LineRenderer>().SetPosition(0, initPosition);
                    segment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    segment.GetComponent<LineRenderer>().startWidth = width;
                    segment.GetComponent<LineRenderer>().endWidth = width;

                    break;

                // No rule attach -> Just to read character
                case 'X':
                    break;

                // Turn left by turning angle
                case '+':
                    transform.Rotate(Vector3.back * angleTurn * (1 + variance / 100 * randomRotationValues[c % randomRotationValues.Length]));
                    break;

                // Turn right by turning angle
                case '-':
                    transform.Rotate(Vector3.forward * angleTurn * (1 + variance / 100 * randomRotationValues[c % randomRotationValues.Length]));
                    break;

                // Turn forwards (into the screen) by turning angle
                case '*':
                    transform.Rotate(Vector3.up * 120 * (1 + variance / 100 * randomRotationValues[c % randomRotationValues.Length]));
                    break;

                // Turn backwards (out of screen) by turning angle
                case '/':
                    transform.Rotate(Vector3.down * 120 * (1 + variance / 100 * randomRotationValues[c % randomRotationValues.Length]));
                    break;

                // Draw pink leaves
                case '#':
                    // Drawing the pink leaves with LeafPink Line Renderer
                    nextPos = new Vector3(10, 10, 10);

                    currentPos = gameObject.transform.position;

                    GameObject leafPink = Instantiate(LeafPink);
                    leafPink.transform.SetParent(Tree.transform);
                    leafPink.GetComponent<LineRenderer>().SetPosition(0, currentPos);
                    leafPink.GetComponent<LineRenderer>().SetPosition(1, currentPos + nextPos);
                    leafPink.GetComponent<LineRenderer>().startWidth = 8;
                    leafPink.GetComponent<LineRenderer>().endWidth = 1;

                    break;

                // Draw purple leaves
                case '^':
                    // Drawing the purple leaves with Leaf Line Renderer
                    nextPos = new Vector3(10, 10, 10);

                    currentPos = gameObject.transform.position;

                    GameObject leafPurple = Instantiate(LeafPurple);
                    leafPurple.transform.SetParent(Tree.transform);
                    leafPurple.GetComponent<LineRenderer>().SetPosition(0, currentPos);
                    leafPurple.GetComponent<LineRenderer>().SetPosition(1, currentPos + nextPos);
                    leafPurple.GetComponent<LineRenderer>().startWidth = 8;
                    leafPurple.GetComponent<LineRenderer>().endWidth = 1;

                    break;

                // Push current state onto TransformationsInfo() stack
                case '[':
                    transformStack.Push(new TransformationsInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });

                    break;

                // Pop current state from the stack
                case ']':
                    TransformationsInfo transforms = transformStack.Pop();
                    transform.position = transforms.position;
                    transform.rotation = transforms.rotation;

                    // Drawing the leaves with Leaf Line Renderer
                    nextPos = new Vector3(10, 10, 10);

                    currentPos = gameObject.transform.position;

                    GameObject leaf = Instantiate(Leaf);
                    leaf.transform.SetParent(Tree.transform);
                    leaf.GetComponent<LineRenderer>().SetPosition(0, currentPos);
                    leaf.GetComponent<LineRenderer>().SetPosition(1, currentPos + nextPos);
                    leaf.GetComponent<LineRenderer>().startWidth = 8;
                    leaf.GetComponent<LineRenderer>().endWidth = 1;

                    break;

                default:
                    throw new InvalidOperationException("Invalid L-System Operation");
            }


        }
    }


    // Update is called once per frame
    void Update()
    {
        if (iterationsLastFrame != iterations ||
                angleLastFrame != angleTurn ||
                widthLastFrame != width ||
                lengthLastFrame != length)
        {
            Generate();
        }

        if (treeTypes == 0)
        {
            currentPlant = rules[0];
            Generate();
        }
        else if (treeTypes == 1)
        {
            currentPlant = rules[1];
            Generate();
        }
        else if (treeTypes == 2)
        {
            currentPlant = rules[2];
            Generate();
        }
        else if (treeTypes == 3)
        {
            currentPlant = rules[3];
            Generate();
        }
        else if (treeTypes == 4)
        {
            currentPlant = rules[4];
            Generate();
        }
        else if (treeTypes == 5)
        {
            currentPlant = rules[5];
            Generate();
        }


    }
}
