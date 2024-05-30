public class Water : Item
{
    public float thirst = 30;

    public override void ItemUsed()
    {
        base.ItemUsed();
        CharacterManager.Instance.Player.condition.uiCondition.thirst.Add(thirst);
    }
}