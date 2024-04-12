using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Robots.Commands;

public class OpenGripper(double width) : Command
{
    public double Width { get; } = width;    


    protected override void Populate()
    {
        //This is a dummy command for internal ROS node, no actual robot code is generated
    }


    public override string ToString() => $"Command (Open Gripper to {Width} mm)";
}
