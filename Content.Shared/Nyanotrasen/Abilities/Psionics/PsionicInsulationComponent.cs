namespace Content.Shared.Abilities.Psionics
{
    [RegisterComponent]
    public sealed partial class PsionicInsulationComponent : Component
    {
        public bool Passthrough = true;

        public List<String> SuppressedFactions = new();
    }
}
