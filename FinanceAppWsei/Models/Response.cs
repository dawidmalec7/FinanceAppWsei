using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinanceAppWsei.Models
{
    public class Response
    {
        public Response(object data = null, HttpStatusCode statusCode = HttpStatusCode.OK, string successMessage = null, string clientError = null, string devError = null, Exception ex = null)
        {
#if DEBUG
            StackTrace = ex?.ToString();
#endif
            DevError = devError;
            ClientError = clientError;
            SuccessMessage = successMessage;
            StatusCode = statusCode;
            Data = data;

        }

        /// <summary>
        /// Błąd dla developera
        /// </summary>
        public string DevError { get; set; }
        /// <summary>
        /// StackTrace
        /// </summary>
        public string StackTrace { get; set; }
        /// <summary>
        /// Błąd, który powinien się wyświetlać klientowi
        /// </summary>
        public string ClientError { get; set; }
        /// <summary>
        /// Wiadomość jeśli sukces
        /// </summary>
        public string SuccessMessage { get; set; }
        /// <summary>
        /// Status kod
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Zwracane dane jeśli są jakieś
        /// </summary>
        public object Data { get; set; }
    }
}
