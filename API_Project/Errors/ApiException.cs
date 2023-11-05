namespace API_Project.Errors
{
    public class ApiException
    {
        public ApiException(int statuscode, string message, string datails)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.datails = datails;
        }

        public int statuscode { get; set; }
        public string message { get; set; }
        public string datails { get; set; }
    }
}
