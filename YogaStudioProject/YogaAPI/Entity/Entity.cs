using System.Net;
using System.Numerics;

namespace Entity
{
    public class Clientmodel
    {
        public string ClientID {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Ph_num { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }

    public class Workshop
    {
        public int WorkshopId {  get; set; }
        public string Name { get; set; }
        public string InstructorID { get; set; }
        public string StartTime { get; set;}
        public string EndTime { get; set;}
        public string Description {  get; set; }
        public int price { get; set; }
        public string Prerequisites {  get; set; }
        public string EquipmentRequired { get; set; }
        public string RegistrationDeadline {  get; set; }
        public int MaxCapacity {  get; set; }
        public int CurrentCapacity { get; set; }
        public string CancellationDeadline { get; set; }
        public string WorkshopDate { get; set; }  
        public string StudioId {  get; set; }
        public string WaitingList { get; set;}

    }

    public class Classes
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassDateForm { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public int WaitingList {  get; set; }
        public string Description { get; set; }
        public string ClassDateTo {  get; set; }
        public int Price { get; set;}
        public string ClassLevel { get;set; }
        public string CancellationDeadline { get; set; }
        public string StudioId { get; set; }
    }
    //int StudioId,int InstructorID, string Name, string Email, string Ph_num, int YearOfExperience
    public class Instructor
    {
        public int StudioId { get; set; }
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Ph_num { get; set; }
        public int YearOfExperience {  get; set; }
    }

    public class Logindetails 
    {
        public int ClientId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; }
        public string Email { get; set; }
        public string Ph_num { get; }
        public string Gender { get; }
        public string Password { get; set; }
        public string Role { get; }
    }

    public class  studio
    {
        //Id Name    Address City    State Zipcode Email StudioOwner Description StartDate
        public string Name {  get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string StudioOwner { get; set; }
        public string Description { get; set;}
        public string StartDate { get; set;}

    }

    public class ClientAllClasses
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassDateForm { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public int WaitingList { get; set; }
        public string Description { get; set; }
        public string ClassDateTo { get; set; }
        public int Price { get; set; }
        public string ClassLevel { get; set; }
        public string CancellationDeadline { get; set; }
        public string StudioId {  get; set; }
    }

    public class ClientAllWorkshops
    {
        public int WorkshopId { get; set; }
        public string Name { get; set; }
        public string InstructorID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public string Prerequisites { get; set; }
        public string EquipmentRequired { get; set; }
        public string RegistrationDeadline { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string CancellationDeadline { get; set; }
        public string StudioId { get; set; }
    }

    public class ClientRegClasses
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassDateForm { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public int WaitingList { get; set; }
        public string Description { get; set; }
        public string ClassDateTo { get; set; }
        public int Price { get; set; }
        public string ClassLevel { get; set; }
        public string CancellationDeadline { get; set; }
        public string StudioId { get; set; }
    }

    public class ClientRegWorkshops
    {
        public int WorkshopId { get; set; }
        public string Name { get; set; }
        public string InstructorID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public string Prerequisites { get; set; }
        public string EquipmentRequired { get; set; }
        public string RegistrationDeadline { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string CancellationDeadline { get; set; }
        public string StudioId { get; set; }
    }

}
