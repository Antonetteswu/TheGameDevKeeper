

using UnityEngine;

public static class AnimatorExtensions
{
    /// <summary>
    /// Returns true if the animator has a parameter with the given name.
    /// </summary>
    public static bool HasParameter(this Animator animator, string paramName)
    {
        if (animator == null || string.IsNullOrEmpty(paramName))
            return false;

        var pars = animator.parameters;
        for (int i = 0; i < pars.Length; i++)
        {
            if (pars[i].name == paramName)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Safely sets a bool parameter if it exists. Logs a warning once per missing parameter per animator instance.
    /// </summary>
    public static void SafeSetBool(this Animator animator, string paramName, bool value)
    {
        if (animator == null) return;
        if (animator.HasParameter(paramName))
        {
            animator.SetBool(paramName, value);
        }
        else
        {
            Debug.LogWarning($"Animator parameter '{paramName}' does not exist on '{animator.gameObject.name}'. Add it in the Animator window or fix the name in code.");
        }
    }

    /// <summary>
    /// Safely sets an int parameter if it exists.
    /// </summary>
    public static void SafeSetInt(this Animator animator, string paramName, int value)
    {
        if (animator == null) return;
        if (animator.HasParameter(paramName))
        {
            animator.SetInteger(paramName, value);
        }
        else
        {
            Debug.LogWarning($"Animator parameter '{paramName}' does not exist on '{animator.gameObject.name}'.");
        }
    }

    /// <summary>
    /// Safely sets a float parameter if it exists.
    /// </summary>
    public static void SafeSetFloat(this Animator animator, string paramName, float value)
    {
        if (animator == null) return;
        if (animator.HasParameter(paramName))
        {
            animator.SetFloat(paramName, value);
        }
        else
        {
            Debug.LogWarning($"Animator parameter '{paramName}' does not exist on '{animator.gameObject.name}'.");
        }
    }

    /// <summary>
    /// Safely sets a trigger parameter if it exists.
    /// </summary>
    public static void SafeSetTrigger(this Animator animator, string paramName)
    {
        if (animator == null) return;
        if (animator.HasParameter(paramName))
        {
            animator.SetTrigger(paramName);
        }
        else
        {
            Debug.LogWarning($"Animator parameter '{paramName}' does not exist on '{animator.gameObject.name}'.");
        }
    }

    /// <summary>
    /// Safely resets a trigger parameter if it exists.
    /// </summary>
    public static void SafeResetTrigger(this Animator animator, string paramName)
    {
        if (animator == null) return;
        if (animator.HasParameter(paramName))
        {
            animator.ResetTrigger(paramName);
        }
        else
        {
            Debug.LogWarning($"Animator parameter '{paramName}' does not exist on '{animator.gameObject.name}'.");
        }
    }
}