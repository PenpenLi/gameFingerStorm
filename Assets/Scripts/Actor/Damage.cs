public class Damage
{
    public Damage()
    {
        this.DamageValue = 0;
        this.Stun = false;
        this.StunDuration = 0;
        this.Bleed = false;
        this.BleedDuration = 0f;
        this.BleedDps = 0;
        this.ShowCrit = false;
		this.ActorSpellName = ActorSpellName.None;
    }

    public float DamageValue { get; set; }

    public bool Stun { get; set; }

    public float StunDuration { get; set; }

    public bool Bleed { get; set; }

    public float BleedDuration { get; set; }

    public float BleedDps { get; set; }

    public bool ShowCrit { get; set; }
	
	public ActorSpellName ActorSpellName {get;set;}
}
