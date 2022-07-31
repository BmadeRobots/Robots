using Rhino.Geometry;

namespace Robots;

public abstract class RobotArm : Mechanism
{
    internal virtual int SolutionCount => 8;

    internal RobotArm(string model, Manufacturers manufactuer, double payload, Plane basePlane, Mesh baseMesh, Joint[] joints) : base(model, manufactuer, payload, basePlane, baseMesh, joints, false) { }

    protected override void SetStartPlanes()
    {
        var startPose = GetStartPose();
        var kinematics = Kinematics(startPose);

        for (int i = 0; i < Joints.Length; i++)
        {
            Plane plane = kinematics.Planes[i + 1];
            plane.InverseOrient(ref BasePlane);
            Joints[i].Plane = plane;
        }
    }

    protected abstract JointTarget GetStartPose();
}
