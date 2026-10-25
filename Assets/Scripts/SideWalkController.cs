using System.Collections.Generic;
using UnityEngine;

public sealed class SideWalkController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.2f;
    [SerializeField] private float walkFrequency = 7.5f;
    [SerializeField] private float walkAngle = 28f;
    [SerializeField] private Vector2 xLimits = new(-10.5f, 10.5f);

    private readonly Dictionary<Transform, Quaternion> restRotations = new();
    private Transform leftThigh;
    private Transform rightThigh;
    private Transform leftUpperArm;
    private Transform rightUpperArm;
    private Transform pelvis;
    private Vector3 pelvisRestPosition;
    private float walkTime;

    private void Awake()
    {
        leftThigh = FindBone("thigh_l");
        rightThigh = FindBone("thigh_r");
        leftUpperArm = FindBone("upperarm_l");
        rightUpperArm = FindBone("upperarm_r");
        pelvis = FindBone("pelvis");

        Remember(leftThigh);
        Remember(rightThigh);
        Remember(leftUpperArm);
        Remember(rightUpperArm);
        if (pelvis != null) pelvisRestPosition = pelvis.localPosition;
    }

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x + input * moveSpeed * Time.deltaTime, xLimits.x, xLimits.y);
        transform.position = position;

        if (Mathf.Abs(input) > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, input > 0f ? 90f : -90f, 0f);
            walkTime += Time.deltaTime * walkFrequency;
            AnimateWalk(Mathf.Sin(walkTime));
        }
        else
        {
            walkTime = 0f;
            AnimateWalk(0f);
        }
    }

    private void AnimateWalk(float phase)
    {
        ApplySwing(leftThigh, phase * walkAngle);
        ApplySwing(rightThigh, -phase * walkAngle);
        ApplySwing(leftUpperArm, -phase * walkAngle * 0.7f);
        ApplySwing(rightUpperArm, phase * walkAngle * 0.7f);

        if (pelvis != null)
            pelvis.localPosition = pelvisRestPosition + Vector3.forward * (Mathf.Abs(phase) * 0.025f);
    }

    private void ApplySwing(Transform bone, float angle)
    {
        if (bone != null && restRotations.TryGetValue(bone, out Quaternion rest))
            bone.localRotation = rest * Quaternion.AngleAxis(angle, Vector3.right);
    }

    private void Remember(Transform bone)
    {
        if (bone != null) restRotations[bone] = bone.localRotation;
    }

    private Transform FindBone(string boneName)
    {
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
            if (child.name.Equals(boneName, System.StringComparison.OrdinalIgnoreCase)) return child;
        return null;
    }
}
