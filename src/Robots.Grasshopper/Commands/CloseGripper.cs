namespace Robots.Grasshopper.Commands;

public class CloseGripper : GH_Component
{
    public CloseGripper() : base("CloseGripper", "CloseGripper", "Close gripper and apply a clamping force to the object \n Caution: This only works with the BMade ROS server with Franka Robot", "Robots", "Commands") { }
    public override GH_Exposure Exposure => GH_Exposure.secondary;
    public override Guid ComponentGuid => new("{1cf40b1b-4c25-4517-ba23-15113e21350c}");
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconBmade");

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddNumberParameter("Speed", "S", "Speed", GH_ParamAccess.item);
        pManager.AddNumberParameter("Force", "F", "Force", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddParameter(new CommandParameter(), "Command", "C", "Command", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        double speed = 0;
        double force = 0;

        if (!DA.GetData(0, ref speed)) return;
        if (!DA.GetData(1, ref force)) return;



        var command = new Robots.Commands.CloseGripper(speed,force);
        DA.SetData(0, command);
    }
}
