using TMPro;
using UnityEngine;

namespace DSS.Logging
{

public class Logger : MonoBehaviour
{
    // --------- //
    // VARIABLES //
    // --------- //

    [SerializeField] private RectTransform container = null;

    [SerializeField] private TextMeshProUGUI logTextMeshPrefab = null;
    [SerializeField] private TextMeshProUGUI warningTextMeshPrefab = null;
    [SerializeField] private TextMeshProUGUI errorTextMeshPrefab = null;

    // --------------- //
    // SINGLETON STUFF //
    // --------------- //

    private static Logger _instance = null;
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Logger>();
            }

            if (_instance == null)
            {
                Debug.LogError("No Logger instance found in scene. Perhaps you forgot to add it?");
            }

            return _instance;
        }
    }

    // -------------- //
    // PUBLIC METHODS //
    // -------------- //

    public void Log(string message)
    {
        InstantiateText(message, logTextMeshPrefab);
    }

    public void LogWarning(string message)
    {
        InstantiateText(message, warningTextMeshPrefab);
    }

    public void LogError(string message)
    {
        InstantiateText(message, errorTextMeshPrefab);
    }

    // --------------- //
    // PRIVATE METHODS //
    // --------------- //

    private void Start()
    {
        if (container.childCount == 0)
        {
            container.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        container.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        container.gameObject.SetActive(false);
    }

    private void InstantiateText(string message, TextMeshProUGUI prefab)
    {
        if (this.enabled)
        {
            container.gameObject.SetActive(true);
        }
        
        TextMeshProUGUI entry = Instantiate(prefab, container);
        entry.text = (container.childCount - 1) + " : " + message;
    }
}

}  // namespace DSS.Logging