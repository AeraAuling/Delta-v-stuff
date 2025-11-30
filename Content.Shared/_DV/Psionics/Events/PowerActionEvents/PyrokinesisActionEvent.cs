using Content.Shared.Actions;
using Robust.Shared.Prototypes;

namespace Content.Shared._DV.Psionics.Events.PowerActionEvents;

/// <summary>
/// This gets fired when someone uses the MetapsionicPulse action.
/// </summary>
[ByRefEvent]
public sealed partial class PyrokinesisActionEvent : WorldTargetActionEvent
{
    /// <summary>
    /// What entity should be spawned.
    /// </summary>
    [DataField(required: true)]
    public EntProtoId Prototype;
}
