using Grasshopper.Kernel.Types;

namespace Robots.Grasshopper;

public class GH_MaxForce : GH_Goo<double>
{
    public GH_MaxForce() { Value = 0.0f; }
    public GH_MaxForce(GH_MaxForce goo) { Value = goo.Value; }
    public GH_MaxForce(double native) { Value = native; }
    public override IGH_Goo Duplicate() => new GH_MaxForce(this);
    public override bool IsValid => true;
    public override string TypeName => "MaxForce";
    public override string TypeDescription => "MaxForce";
    public override string ToString() => Value.ToString();

    public override bool CastFrom(object source)
    {
        switch (source)
        {
            case GH_Number number:
                Value = number.Value;
                return true;
            case GH_Integer integer:
                Value = (double)integer.Value;
                return true;
            case GH_String text:
                {
                    if (string.IsNullOrWhiteSpace(text.Value))
                    {
                        Value = 0.0;
                        return true;
                    }

                    string texts = text.Value;
                    double value = 0.0;
                    if (!GH_Convert.ToDouble_Primary(texts, ref value))
                    {
                        return false;
                    }

                    Value = value;
                    return true;
                }
        }

        return false;
        
    }

    public override bool CastTo<Q>(ref Q target)
    {
        if (typeof(Q).IsAssignableFrom(typeof(double)))
        {
            target = (Q)(object)Value;
            return true;
        }

        return false;
    }
}
