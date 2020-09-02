using UnityEngine;

public class SingletonPath : MonoBehaviour
{

    public static SingletonPath Instance { get; private set;}

    public LineRenderer lineRendererBlue;
    public LineRenderer lineRendererRed;

    public Transform[] bluePathWaypoints;
    Vector3[] bluePathPositions;

    public Transform[] redPathWaypoints;
    Vector3[] redPathPositions;

    public int BlueIndex = 0;
    public int RedIndex = 0;

    private void Awake()
    {
        if (Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            //Sahne değişiminde oluşacak olan kopya nesneyi yok eder.
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        lineRendererBlue.startColor = Color.blue;
        lineRendererBlue.endColor = Color.blue;
        lineRendererRed.startColor = Color.red;
        lineRendererRed.endColor = Color.red;

            bluePathPositions = new Vector3[bluePathWaypoints.Length];
            lineRendererBlue.positionCount = bluePathWaypoints.Length;
            for (int i = 0; i < bluePathWaypoints.Length; i++)
            {
            bluePathPositions[i] = bluePathWaypoints[i].position;
            lineRendererBlue.SetPositions(bluePathPositions);
            }

            redPathPositions = new Vector3[redPathWaypoints.Length];
            lineRendererRed.positionCount = redPathWaypoints.Length;
            for (int i = 0; i < redPathWaypoints.Length; i++)
            {
            redPathPositions[i] = redPathWaypoints[i].position;
            lineRendererRed.SetPositions(redPathPositions);
            }
    }
    public Vector3 getBluePoint(bool isPathSwitched)
    {
        if (isPathSwitched)
        {
            return redPathPositions[redPathWaypoints.Length - BlueIndex-1];
        }
      return bluePathPositions[BlueIndex];
    }
    public Vector3 getRedPoint(bool isPathSwitched)
    {
        if (isPathSwitched)
        {
            return bluePathPositions[bluePathWaypoints.Length - RedIndex - 1];
        }
            return redPathPositions[RedIndex];
    }
    public int blueGetLength()
    {
        return bluePathWaypoints.Length;
    }
    public int redGetLength()
    {
        return redPathWaypoints.Length;
    }
    public void updateIndex(bool isBlueCar, bool isPathSwitched)
    {
        if (isBlueCar)
        {
            BlueIndex++;
        }
        else RedIndex++;
    }
    public void resetIndex(bool isBlueCar)
    {
        if (isBlueCar)
        {
            BlueIndex=-1;
        }
        else RedIndex=-1;
    }
    public void switchSides(bool isBlueCar)
    {
        if (isBlueCar)
        {
            BlueIndex = RedIndex;
        }
        else
        {
            RedIndex = BlueIndex;
        }
    }
}
