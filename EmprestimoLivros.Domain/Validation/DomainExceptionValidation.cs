using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string Error): base(Error) { }

        public static void when(bool hasError, string errorMessage)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(errorMessage);
            }
        }
    }
}
