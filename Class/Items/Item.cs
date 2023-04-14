public interface Item
{
    public string Name { get; }

    public void consumeItem(PartyBase party, PartyBase enemyParty);
}
