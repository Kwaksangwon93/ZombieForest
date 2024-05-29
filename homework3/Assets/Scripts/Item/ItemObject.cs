using UnityEngine;

public class ItemObject : MonoBehaviour, IUseable
{
    public ItemData data;

    public string GetUsePrompt()
    {
        string str = $"{data.name}\n{data.description}";
        return str;
    }

    public void OnUse()
    {
        CharacterManager.Instance.Player.data = data;
        CharacterManager.Instance.Player.useItem?.Invoke();
        Destroy(gameObject);
    }
}