using System.Numerics;
using Content.Shared._DV.Psionics.Components;
using Content.Shared._DV.Psionics.Components.PsionicPowers;
using Content.Shared._DV.Psionics.Events;
using Content.Shared._DV.Psionics.Events.PowerActionEvents;
using Content.Shared.Abilities.Psionics;
using Content.Shared.Actions;
using Content.Shared.Popups;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Prototypes;

namespace Content.Shared._DV.Psionics.Systems.PsionicPowers;

public sealed partial class PyrokinesisPowerSystem : BasePsionicPowerSystem<NewPyrokinesisPowerComponent, PyrokinesisActionEvent>
{

    [Dependency] private readonly SharedPhysicsSystem _physics = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly SharedGunSystem _gunSystem = default!;

    protected override void OnPowerUsed(Entity<NewPyrokinesisPowerComponent> psionic, ref PyrokinesisActionEvent args)
    {
        var startPos = _transform.GetMapCoordinates(args.Performer);
        var targetPos = _transform.ToMapCoordinates(args.Target);
        var userVelocity = _physics.GetMapLinearVelocity(args.Performer);

        var delta = targetPos.Position - startPos.Position;
        if (delta.EqualsApprox(Vector2.Zero))
            delta = new(.01f, 0);

        args.Handled = true;
        var ent = Spawn(args.Prototype, startPos);
        _gunSystem.ShootProjectile(ent, delta, userVelocity, args.Performer, args.Performer, 12f);
    }

}
