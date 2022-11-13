using System;
using System.Collections.Generic;
using System.IO;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class AdminManager : IAdminManager
    {
        ITransactionManager _iTransactionManager = new TransactionManager();
        public static List<Admin> ListOfAdmin = new List<Admin>();
        public string AdminFilePath = @"./Files/admin.txt";
        public string FileDirect = @"./Files";
        public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            int id;
            if (ListOfAdmin != null)
            {
                id = ListOfAdmin.Count + 1;
            }
            else
            {
                id = 1;
            }
            // string staffId = "AZ" + new Random(new Random().Next(1000)).Next(1100000).ToString();

                var admin = new Admin(id, User.GenerateRandomId(), firstName, lastName, email, phoneNumber, pin, post);
                ListOfAdmin.Add(admin);
                using (var streamWriter = new StreamWriter(AdminFilePath, append: true))
                {
                    streamWriter.WriteLine(admin.WriteToFIle());
                }
                Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
            
        }
        public void DeleteAdmin(string staffId)
        {
            var admin = GetAdmin(staffId);
            if (admin != null)
            {
                Console.WriteLine($"{admin.FirstName} {admin.LastName} Successfully deleted. ");
                ListOfAdmin.Remove(admin);
                ReWriteToFile();
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Admin GetAdmin(string staffId)
        {
            foreach (var item in ListOfAdmin)
            {
                if (item.StaffId == staffId)
                {
                    return item;
                }
            }
            return null;
        }
        public Admin GetAdmin(string staffId, string email)
        {
            foreach (var item in ListOfAdmin)
            {
                if (item.StaffId == staffId || item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }
        public Admin Login(string staffId, string pin)
        {
            foreach (var item in ListOfAdmin)
            {
                if (item.StaffId == staffId.ToUpper() && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber)
        {
            var admin = GetAdmin(staffId);
            if (admin != null)
            {
                admin.FirstName = firstName;
                admin.LastName = lastName;
                admin.PhoneNumber = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void ReWriteToFile()
        {
            File.WriteAllText(AdminFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(AdminFilePath, append: true))
            {
                foreach (var item in ListOfAdmin)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
        
        public void ReadFromFile()
        {
            if (!Directory.Exists(FileDirect)) Directory.CreateDirectory(FileDirect);

            if (!File.Exists(AdminFilePath))
            {
                var fileStream = new FileStream(AdminFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(AdminFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var adminManager = streamReader.ReadLine();
                    ListOfAdmin.Add(Admin.ConvertToAdmin(adminManager));
                }
            }
        }
    }
}