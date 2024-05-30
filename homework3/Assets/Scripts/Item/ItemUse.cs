using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IUseable
{
    public string GetUsePrompt();
    public void OnUse();
}

public class ItemUse : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curUseGameObject;
    private IUseable curUseable;
    private Item curUseItem;

    public TextMeshProUGUI promptText;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance,layerMask))
            {
                if (hit.collider.gameObject != curUseGameObject)
                {
                    curUseGameObject = hit.collider.gameObject;
                    curUseable = hit.collider.GetComponent<IUseable>();
                    curUseItem = hit.collider.GetComponent<Item>();
                    SetPromptText();
                }
            }
            else
            {
                curUseGameObject = null;
                curUseable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curUseable.GetUsePrompt();
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curUseable != null)
        {
            curUseable.OnUse();
            curUseItem.ItemUsed();
            curUseGameObject = null;
            curUseable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}