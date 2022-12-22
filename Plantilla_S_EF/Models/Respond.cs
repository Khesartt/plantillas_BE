using System.Linq;
using System.Collections.Generic;


namespace Plantilla_S_EF.Models
{
    public class Respond<T>
    {
        public Respond()
        {
            error = false;
            message = "se realiza la solicitud de manera exitosa";
        }
        public bool error { get; set; }
        public string message { get; set; }
        public IQueryable<T> resultsQ { get; set; }
        public List<T> resultsL { get; set; }
        public T result { get; set; }
    }
}
