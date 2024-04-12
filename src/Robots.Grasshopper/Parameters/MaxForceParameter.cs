namespace Robots.Grasshopper;

public class MaxForceParameter : GH_PersistentParam<GH_MaxForce>
{
    public MaxForceParameter() : base("Max Force", "Force", "The max force in z-axis allowed before executing the reaction motion", "Robots", "Parameters") { }
    public override GH_Exposure Exposure => GH_Exposure.tertiary;
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconTargetParam");
    public override Guid ComponentGuid => new("{f89f1fd9-5055-490e-8497-f38fff97edf1}");
    protected override GH_MaxForce PreferredCast(object data) =>
        data is double cast ? new GH_MaxForce(cast) : null!;

    protected override GH_GetterResult Prompt_Singular(ref GH_MaxForce value)
    {
        value = new GH_MaxForce();
        return GH_GetterResult.success;
    }

    protected override GH_GetterResult Prompt_Plural(ref List<GH_MaxForce> values)
    {
        values = [];
        return GH_GetterResult.success;
    }
}
