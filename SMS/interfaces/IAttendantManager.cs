using SMS.model;

namespace SMS.interfaces
{
    public interface IAttendantManager
    {
        void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post);
        Attendant GetAttendant(string staffId);
        Attendant GetAttendant(string staffId, string email);
        void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber);
        void DeleteAttendant(string staffId);
        Attendant Login(string staffId, string pin);
        void ViewAttendant(string staffId);
        void ViewAllAttendants();
        void ReadFromFile();
        void ReWriteToFile();
    }
}