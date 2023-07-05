namespace NashraExtractions.JsonFiles
{
    internal class Login
    {
        public string UserName { get; set;}
        private string Password { get; set;}
        public int type { get; set; }
        public bool IsAuthenticated { get; set;}    
    }
}