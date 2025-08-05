using TestAdvacedCsharpCode.Base;

namespace TestAdvacedCsharpCode.Concrete
{
    public class LowercaseTransformer : ResponseTransformer
    {
        //public override string Trasform(string input)
        //{
        //    return input.ToLowerInvariant();
        //}

        public override string Transform(string input) => input.ToLowerInvariant();
       
    }
}
