namespace Robots.Grasshopper;

public class ReactionVectorToList : GH_Component
{
    public ReactionVectorToList() : base("ToReactionVector", "ToReactionVector", "Convert to Reaction Vector", "Robots", "Utility") { }
    public override GH_Exposure Exposure => GH_Exposure.primary;
    public override Guid ComponentGuid => new("{28757575-698f-4dea-841e-bc1defe7f52d}");
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconBmade");

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddNumberParameter("Reaction", "A", "Array", GH_ParamAccess.list);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddParameter(new ReactionParameter(), "List", "L", "List", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        var reaction = new List<double>(6);        
        if (!DA.GetDataList(0, reaction)) return;        

        var output = reaction.ToArray();
        DA.SetData(0, output);
    }
}
