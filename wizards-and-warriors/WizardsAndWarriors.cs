internal abstract class Character
{
    public abstract int DamagePoints(Character target);
    public virtual bool Vulnerable() => false;
    public override string ToString() => $"Character is a {GetType().Name}";
}

internal class Warrior : Character
{
    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

internal class Wizard : Character
{
    private bool _prepared;
    public override bool Vulnerable() => !_prepared;
    public override int DamagePoints(Character target) => _prepared ? 12 : 3;
    public void PrepareSpell() => _prepared = true;
}
