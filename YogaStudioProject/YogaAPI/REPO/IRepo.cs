using Entity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace REPO
{
    public interface IRepo
    {
        public Task<List<Clientmodel>> getClientByIdAsync();

        public Task<List<Clientmodel>> AddClient(string Name,string Email,string PhoneNumber,string Gender,string password);
        public Task<List<Clientmodel>> UpdateClient(int ClientID,string Name, string Email, string PhoneNumber, string Gender, string password);
        public Task<List<Clientmodel>> RemoveClient(int ClientID);


        //Workshop
        public Task<List<Workshop>> getWorkshopByIdAsync();

        public Task<List<Workshop>> AddWorkshop(string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price,string Prerequisites,string EquipmentRequired,string RegistrationDeadline, int MaxCapacity, int CurrentCapacity,string CancellationDeadline,string WorkshopDate, int StudioId, int WaitingList);
        public Task<List<Workshop>> UpdateWorkshop(int WorkshopId, string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price, string Prerequisites, string EquipmentRequired, string RegistrationDeadline, int MaxCapacity, int CurrentCapacity, string CancellationDeadline,string WorkshopDate, int StudioId, int WaitingList);
        public Task<List<Workshop>> RemoveWorkshop(int WorkshopId);


        // class
        public Task<List<Classes>> getClassByIdAsync();

        public Task<List<Classes>> AddClass(string Name,int InstructorId,string StartTime,string EndTime,string ClassDateForm,int MaxCapacity,int CurrentCapacity,int WaitingList,string Description,string ClassDateTo,int Price,string ClassLevel,string CancellationDeadline, int StudioId);
        public Task<List<Classes>> UpdateClass(int ClassId, string Name, int InstructorId, string StartTime, string EndTime, string ClassDateForm, int MaxCapacity, int CurrentCapacity, int WaitingList, string Description, string ClassDateTo, int Price, string ClassLevel, string CancellationDeadline, int StudioId);
        public Task<List<Classes>> RemoveClass(int ClassId);

        //Instructor
        public Task<List<Instructor>> getInstructorByIdAsync();

        public Task<List<Instructor>> AddInstructor(int StudioId,string Name,string Email,string Ph_num,int YearOfExperience);
        public Task<List<Instructor>> UpdateInstructor(int StudioId,int InstructorID, string Name, string Email, string Ph_num, int YearOfExperience);
        public Task<List<Instructor>> RemoveInstructor(int InstructorID);

        //Login

        public Task<List<Logindetails>> GetLogindetails(string Email, string password);

        //studio

        public Task<List<studio>> getstudioByIdAsync();
        public Task<List<studio>> Addstudio(string Name, string Address, string City, string State, int Zipcode, string Email, string StudioOwner, string Description, string StartDate);


        //Client

        public Task<List<ClientAllClasses>> Getallclasses(int ClientId);
        public Task<List<Workshop>> Getallworkshops(int ClientId);
        public Task<List<ClientRegClasses>> GetRegisteredClasses(int ClientId);
        public Task<List<ClientRegWorkshops>> GetRegisteredWorkshops(int ClientId);
        public void cancelworkshoporclass(int Id, int ClientId, string Type);
        public void RegsterClass(int ClassId,int ClientId);
        public void RegsterWorkshop(int ClassId, int ClientId);

    }
}
