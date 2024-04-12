namespace Robots.Grasshopper.Commands;

public class OpenGripper : GH_Component
{
    public OpenGripper() : base("OpenGripper", "OpenGripper", "Open Gripper to desired distance \n Caution: This only works with the BMade ROS server with Franka Robot", "Robots", "Commands") { }
    public override GH_Exposure Exposure => GH_Exposure.secondary;
    public override Guid ComponentGuid => new("{15f1c514-50ce-43ac-bb62-f7516454c94c}");
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconBmade");

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddNumberParameter("Width", "W", "Width in MM", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddParameter(new CommandParameter(), "Command", "C", "Command", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        double width = 0;

        if (!DA.GetData(0, ref width)) return;

        var command = new Robots.Commands.OpenGripper(width);
        DA.SetData(0, command);
    }
}
