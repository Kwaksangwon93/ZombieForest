public class FirstAid : Item
{
    public float health = 20;

    public override void ItemUsed()
    {
        base.ItemUsed();
        CharacterManager.Instance.Player.condition.uiCondition.health.Add(health);
    }
}