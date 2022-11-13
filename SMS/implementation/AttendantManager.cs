using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class AttendantManager : IAttendantManager
    {
        public static List<Attendant> ListOfAttendant = new List<Attendant>();
        public string AttendantFilePath = @"./Files/attendant.txt";
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            var id = ListOfAttendant.Count + 1;
            // string staffId = "AT" + new Random(id).Next(100000).ToString();
            var attendant = new Attendant(id, User.GenerateRandomId(), firstName, lastName, email, phoneNumber, pin, post);
            //    Verifying Attendant Email
            if (GetAttendant(attendant.StaffId, email) == null)
            {
                ListOfAttendant.Add(attendant);
                using (var streamWriter = new StreamWriter(AttendantFilePath, append: true))
                {
                    streamWriter.WriteLine(attendant.WriteToFIle());
                }
                Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
            }
            else
            {
                Console.WriteLine("Attendant already exist. \nKindly Go to Update to Update the Attendant Details");
            }

            // End
        }
        public void DeleteAttendant(string staffId)
        {
            var attendant = GetAttendant(staffId);
            if (attendant.StaffId != null)
            {
                Console.WriteLine($"{attendant.FirstName} {attendant.LastName} Successfully deleted. ");
                ListOfAttendant.Remove(attendant);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Attendant GetAttendant(string staffId)
        {
            return ListOfAttendant.FirstOrDefault(item => item.StaffId == staffId);
        }
        public Attendant GetAttendant(string staffId, string email)
        {
            foreach (var item in ListOfAttendant)
            {
                if (item.StaffId == staffId || item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }
        public void ViewAttendant(string staffId)
        {
            foreach (var item in ListOfAttendant)
            {
                Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Email}\t{item.StaffId}\t{item.Post}");
            }
        }
        public Attendant Login(string staffId, string pin)
        {
            foreach (var item in ListOfAttendant)
            {
                if (item.StaffId.ToUpper() == staffId.ToUpper() && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber)
        {
            var attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                attendant.FirstName = firstName;
                attendant.LastName = lastName;
                attendant.PhoneNumber = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void ViewAllAttendants()
        {
            foreach (var item in ListOfAttendant)
            {
                Console.WriteLine($"{item.StaffId} {item.LastName} {item.FirstName} {item.Email} {item.PhoneNumber}");
            }
        }
        public void ReWriteToFile()
        {
            File.WriteAllText(AttendantFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(AttendantFilePath, append: true))
            {
                foreach (var item in ListOfAttendant)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
        public void ReadFromFile()
        {
            if (!File.Exists(AttendantFilePath))
            {
                var fileStream = new FileStream(AttendantFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(AttendantFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    // if (streamReader.Peek() == -1)
                    // {
                        var attendantManager = streamReader.ReadLine();
                        ListOfAttendant.Add(Attendant.ConvertToAttendant(attendantManager));
                    // }
                }
            }
        }
    }
}