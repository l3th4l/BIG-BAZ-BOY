internal sealed class PositionContainer : Saveable
{
    private PositionState positionState;

    public override void Load(EntityState entityState)
    {
        this.positionState = (PositionState)entityState;
        this.transform.position = this.positionState.Position;
    }

    public override EntityState Save()
    {
        this.positionState = new PositionState(this.transform.position);
        return this.positionState;
    }
}