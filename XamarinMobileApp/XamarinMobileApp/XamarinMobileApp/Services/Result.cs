using System.Collections.Generic;

namespace XamarinMobileApp.Services
{
    public class Result<T>
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public bool HasError => ErrorMessages.Count > 0;
        public T Data { get; set; }
    }
}
