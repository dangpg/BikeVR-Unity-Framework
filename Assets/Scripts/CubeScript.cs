using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Renderer _cubeRenderer;
    private IBLEManager _bleManager;

    // Start is called before the first frame update
    void Start()
    {
        _cubeRenderer = GetComponent<Renderer>();
        _bleManager = GameObject.FindGameObjectWithTag("BLEManager").GetComponent<IBLEManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_bleManager.GetCharacteristic<IRCharacteristic>().Value)
        {
            _cubeRenderer.material.color = Color.green;
        }
        else
        {
            _cubeRenderer.material.color = Color.red;
        }
    }
}
