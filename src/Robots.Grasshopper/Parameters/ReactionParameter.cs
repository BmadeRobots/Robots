namespace Robots.Grasshopper;

public class ReactionParameter : GH_PersistentParam<GH_ReactionVector>
{
    public ReactionParameter() : base("Reaction parameter", "Reactions", "A list of numbers representing reaction vector", "Robots", "Parameters") { }
    public override GH_Exposure Exposure => GH_Exposure.tertiary;
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconJointsParam");
    public override Guid ComponentGuid => new("{2b85ef92-9747-4479-afcf-9238ede341ac}");
    protected override GH_ReactionVector PreferredCast(object data) =>
        data is double[] cast ? new GH_ReactionVector(cast) : null!;

    protected override GH_GetterResult Prompt_Singular(ref GH_ReactionVector value)
    {
        value = new GH_ReactionVector();
        return GH_GetterResult.success;
    }

    protected override GH_GetterResult Prompt_Plural(ref List<GH_ReactionVector> values)
    {
        values = [];
        return GH_GetterResult.success;
    }
}
