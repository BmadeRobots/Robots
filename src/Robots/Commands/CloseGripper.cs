using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Robots.Commands;

public class CloseGripper(double speed,double force) : Command
{
    public double Speed { get; } = speed;
    public double Force { get; } = force;


    protected override void Populate()
    {
        //This is a dummy command for internal ROS node, no actual robot code is generated
    }


    public override string ToString() => $"Command (Close Gripper with {Speed} mm/s and apply {Force} N force)";
}
