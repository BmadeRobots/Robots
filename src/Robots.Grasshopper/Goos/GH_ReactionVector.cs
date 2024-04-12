using GH_IO.Serialization;
using Grasshopper.Kernel.Types;

namespace Robots.Grasshopper;

public class GH_ReactionVector : GH_Goo<double[]>
{
    public GH_ReactionVector() { Value = []; }
    public GH_ReactionVector(GH_ReactionVector goo) { Value = goo.Value; }
    public GH_ReactionVector(double[] native) { Value = native; }
    public override IGH_Goo Duplicate() => new GH_ReactionVector(this);
    public override bool IsValid => true;
    public override string TypeName => "Reactions";
    public override string TypeDescription => "Reactions";
    public override string ToString() => string.Join(",", Value.Select(x => $"{x:0.#####}"));

    public override bool CastFrom(object source)
    {
        switch (source)
        {
            case GH_Number number:
                Value = [number.Value];
                return true;
            case GH_Integer integer:
                Value = [(double)integer.Value];
                return true;
            case GH_String text:
                {
                    if (string.IsNullOrWhiteSpace(text.Value))
                    {
                        Value = [];
                        return true;
                    }

                    string[] texts = text.Value.Split(',');
                    double[] values = new double[texts.Length];

                    for (int i = 0; i < texts.Length; i++)
                    {
                        if (!GH_Convert.ToDouble_Secondary(texts[i], ref values[i]))
                            return false;
                    }

                    Value = values;
                    return true;
                }
        }

        return false;
    }

    public override bool CastTo<Q>(ref Q target)
    {
        if (typeof(Q).IsAssignableFrom(typeof(double[])))
        {
            target = (Q)(object)Value;
            return true;
        }

        return false;
    }

    public override bool Write(GH_IWriter writer)
    {
        writer.SetDoubleArray("Value", Value);

        return true;
    }

    public override bool Read(GH_IReader reader)
    {
        Value = reader.GetDoubleArray("Value");
        return true;
    }
}
