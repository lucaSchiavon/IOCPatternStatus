using TestAdvacedCsharpCode.Base;

namespace TestAdvacedCsharpCode.Concrete
{
    public class UppercaseTransformer : ResponseTransformer
    {
        //qui avviene la configurazione personalizzata nel client
        //facendo l'override di Trasform
        public override string Transform(string input)
        {
            //qui si scrive il comportamento personalizzato
            return input.ToUpperInvariant();
        }
    }
}
