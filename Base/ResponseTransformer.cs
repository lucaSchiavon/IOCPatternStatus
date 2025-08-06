namespace TestAdvacedCsharpCode.Base
{
    public abstract class ResponseTransformer
    {
        //qui da qualche parte potrebbe esserci la logica dentro un metodo che chiama trasform...
        public abstract string Transform(string input);


        private void MetodoCheUsaTrasformInternamente()
        {
            //prima fa delle cose
            string result=Transform("testo");
            //poi ne fa altre
        }
    }
}
