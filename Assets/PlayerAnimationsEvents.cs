using UnityEngine;

public class  Entity_AnimationsEvents : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    public void DamageTargets() => entity.DamageTargets();
    private void DisableMovementAndJump() => entity.EnableMovementAndJump(false);

    private void EnableMovementAndJump() => entity.EnableMovementAndJump(true);
    }

         