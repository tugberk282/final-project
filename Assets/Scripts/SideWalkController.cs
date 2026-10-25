using System.Collections.Generic;
using UnityEngine;

public sealed class SideWalkController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.2f;
    [SerializeField] private float walkFrequency = 7.5f;
    [SerializeField] private float walkAngle = 28f;
    [SerializeField] private Vector2 xLimits = new(-10.5f, 10.5f);
    [SerializeField] private Vector2 zLimits = new(-9.5f, 9.5f);

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
        Vector3 input = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        Vector3 position = transform.position;
        position += input * moveSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, xLimits.x, xLimits.y);
        position.z = Mathf.Clamp(position.z, zLimits.x, zLimits.y);
        transform.position = position;

        if (input.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(input, Vector3.up);
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
