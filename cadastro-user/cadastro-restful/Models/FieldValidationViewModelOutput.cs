using System.Collections.Generic;

namespace cadastro_restfull.Models
{
    public class FieldValidationViewModelOutput
    {
        public IEnumerable<string> Error {get; private set;}

        public FieldValidationViewModelOutput(IEnumerable<string> erros)
        {
            Error = erros;
        }
    }
}
