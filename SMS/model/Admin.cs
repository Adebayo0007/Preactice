namespace SMS.model
{
    public class Admin : User
    {
        public string Post { get; set; }
        // public double Wallet { get; set; }
        public Admin(int id, string staffId, string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(id, staffId, firstName, lastName, email, phoneNumber, pin)
        {
            Post = post;
            // Wallet = wallet;
        }
        public string WriteToFIle()
        {
            // 3Nc043d&.R342)wsdj1T733h2y future encoding
            return $"{Id}%%%%%{StaffId}%%%%%{FirstName}%%%%%{LastName}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Post}";
        }

        public static Admin ConvertToAdmin(string adminAllFromText)
        {
            var adminConvert = adminAllFromText.Split("%%%%%");
            return new Admin(int.Parse(adminConvert[0]), adminConvert[1], adminConvert[2], adminConvert[3], adminConvert[4], adminConvert[5], adminConvert[6], adminConvert[7]);
        }
    }
}