using DAO;
using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace REPO
{
    public class Repo : IRepo
    {
        private readonly DataAccessLayer context;
        public Repo(DataAccessLayer context)
        {
            this.context = context;
        }
        public async Task<List<Clientmodel>> getClientByIdAsync()
        {
            try
            { 
                string procedure_getinfo = "exec [dbo].[GetAllClients]";
                using(var connection= this.context.CreateConnection())
                {
                    return (await connection.QueryAsync<Clientmodel>(procedure_getinfo)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public async Task<List<Clientmodel>> AddClient(string Name, string Email, string PhoneNumber, string Gender, string password)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    param.Add("@Email", Email);
                    param.Add("@PhoneNumber", PhoneNumber);
                    param.Add("@Gender", Gender);
                    param.Add("@password", password);
                    return (await connection.QueryAsync<Clientmodel>("[dbo].[AddClient]", param,commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Clientmodel>> UpdateClient(int ClientID, string Name, string Email, string PhoneNumber, string Gender, string password)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param= new DynamicParameters();
                    param.Add("@ClientID", ClientID);
                    param.Add("@Name", Name);
                    param.Add("@Email",Email);
                    param.Add("@PhoneNumber", PhoneNumber);
                    param.Add("@Gender", Gender);
                    param.Add("@password", password);
                    return (await connection.QueryAsync<Clientmodel>("[dbo].[UpdateClient]",param,commandType:CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Clientmodel>> RemoveClient(int ClientID)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClientID", ClientID);
                    return (await connection.QueryAsync<Clientmodel>("[dbo].[RemoveClient]", param,commandType:CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //Workshop
        public async Task<List<Workshop>> getWorkshopByIdAsync()
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    return (await connection.QueryAsync<Workshop>("[dbo].[GetAllWorkshop]", commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public async Task<List<Workshop>> AddWorkshop(string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price, string Prerequisites, string EquipmentRequired, string RegistrationDeadline, int MaxCapacity, int CurrentCapacity, string CancellationDeadline,string WorkshopDate, int StudioId,int WaitingList)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    param.Add("@InstructorID", InstructorID);
                    param.Add("@StartTime", StartTime);
                    param.Add("@EndTime", EndTime);
                    param.Add("@Description", Description);
                    param.Add("@Price", Price);
                    param.Add("@Prerequisites", Prerequisites);
                    param.Add("@EquipmentRequired", EquipmentRequired);
                    param.Add("@RegistrationDeadline", RegistrationDeadline);
                    param.Add("@MaxCapacity", MaxCapacity);
                    param.Add("@CurrentCapacity", CurrentCapacity);
                    param.Add("@CancellationDeadline", CancellationDeadline);
                    param.Add("@WorkshopDate", WorkshopDate);
                    param.Add("@StudioId", StudioId);
                    param.Add("@WaitingList", WaitingList);
                    return (await connection.QueryAsync<Workshop>("[dbo].[AddWorkshop]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Workshop>> UpdateWorkshop(int WorkshopId, string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price, string Prerequisites, string EquipmentRequired, string RegistrationDeadline, int MaxCapacity, int CurrentCapacity, string CancellationDeadline,string WorkshopDate, int StudioId,int WaitingList)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@WorkshopId", WorkshopId);
                    param.Add("@Name", Name);
                    param.Add("@InstructorID", InstructorID);
                    param.Add("@StartTime", StartTime);
                    param.Add("@EndTime", EndTime);
                    param.Add("@Description", Description);
                    param.Add("@Price", Price);
                    param.Add("@Prerequisites", Prerequisites);
                    param.Add("@EquipmentRequired", EquipmentRequired);
                    param.Add("@RegistrationDeadline", RegistrationDeadline);
                    param.Add("@MaxCapacity", MaxCapacity);
                    param.Add("@CurrentCapacity", CurrentCapacity);
                    param.Add("@CancellationDeadline", CancellationDeadline);
                    param.Add("@WorkshopDate", WorkshopDate);
                    param.Add("@StudioId", StudioId);
                    param.Add("@WaitingList", WaitingList);
                    return (await connection.QueryAsync<Workshop>("[dbo].[UpdateWorkshop]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Workshop>> RemoveWorkshop(int WorkshopId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@WorkshopId", WorkshopId);
                    return (await connection.QueryAsync<Workshop>("[dbo].[RemoveWorkshop]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }


        //class

        public async Task<List<Classes>> getClassByIdAsync()
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    return (await connection.QueryAsync<Classes>("[dbo].[GetAllClasses]", commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public async Task<List<Classes>> AddClass(string Name, int InstructorId, string StartTime, string EndTime, string ClassDateForm, int MaxCapacity, int CurrentCapacity, int WaitingList, string Description, string ClassDateTo, int Price, string ClassLevel, string CancellationDeadline,int StudioId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    param.Add("@InstructorId", InstructorId);
                    param.Add("@StartTime", StartTime);
                    param.Add("@EndTime", EndTime);
                    param.Add("@ClassDateForm", ClassDateForm);
                    param.Add("@MaxCapacity", MaxCapacity);
                    param.Add("@CurrentCapacity", CurrentCapacity);
                    param.Add("@WaitingList", WaitingList);
                    param.Add("@Description", Description);
                    param.Add("@ClassDateTo", ClassDateTo);
                    param.Add("@Price", Price);
                    param.Add("@ClassLevel", ClassLevel);
                    param.Add("@CancellationDeadline", CancellationDeadline);
                    param.Add("@StudioId", StudioId);
                    return (await connection.QueryAsync<Classes>("[dbo].[AddClass]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Classes>> UpdateClass(int ClassId, string Name, int InstructorId, string StartTime, string EndTime, string ClassDateForm, int MaxCapacity, int CurrentCapacity, int WaitingList, string Description, string ClassDateTo, int Price, string ClassLevel, string CancellationDeadline,int StudioId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClassId", ClassId);
                    param.Add("@Name", Name);
                    param.Add("@InstructorID", InstructorId);
                    param.Add("@StartTime", StartTime);
                    param.Add("@EndTime", EndTime);
                    param.Add("@ClassDateForm", ClassDateForm);
                    param.Add("@MaxCapacity", MaxCapacity);
                    param.Add("@CurrentCapacity", CurrentCapacity);
                    param.Add("@WaitingList", WaitingList);
                    param.Add("@Description", Description);
                    param.Add("@ClassDateTo", ClassDateTo);
                    param.Add("@Price", Price);
                    param.Add("@ClassLevel", ClassLevel);
                    param.Add("@CancellationDeadline", CancellationDeadline);
                    param.Add("@StudioId", StudioId);
                    return (await connection.QueryAsync<Classes>("[dbo].[UpdateClass]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Classes>> RemoveClass(int ClassId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClassId", ClassId);
                    return (await connection.QueryAsync<Classes>("[dbo].[RemoveClass]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }


        //Instructor

        public async Task<List<Instructor>> getInstructorByIdAsync()
        {
            try
            {
                
                using (var connection = this.context.CreateConnection())
                {
                    return (await connection.QueryAsync<Instructor>("[dbo].[GetAllInstructors]", commandType:CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Instructor>> AddInstructor(int StudioId, string Name, string Email, string PhoneNumber, int YearOfExperience)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@StudioId", StudioId);
                    param.Add("@Name", Name);
                    param.Add("@Email", Email);
                    param.Add("@PhoneNumber", PhoneNumber);
                    param.Add("@YearOfExperience", YearOfExperience);
                    return (await connection.QueryAsync<Instructor>("[dbo].[AddInstructor]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Instructor>> UpdateInstructor(int StudioId, int InstructorID, string Name, string Email, string PhoneNumber, int YearOfExperience)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@StudioId", StudioId);
                    param.Add("@InstructorID", InstructorID);
                    param.Add("@Name", Name);
                    param.Add("@Email", Email);
                    param.Add("@PhoneNumber", PhoneNumber);
                    param.Add("@YearOfExperience", YearOfExperience);
                    return (await connection.QueryAsync<Instructor>("[dbo].[UpdateInstructor]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Instructor>> RemoveInstructor(int InstructorID)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@InstructorID", InstructorID);
                    return (await connection.QueryAsync<Instructor>("[dbo].[RemoveInstructor]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public async Task<List<Logindetails>> GetLogindetails(string Email,string password)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                { 
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Email", Email);
                    param.Add("@password", password);
                    return (await connection.QueryAsync<Logindetails>("[dbo].[GetLogindetails]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }


        //studio

        public async Task<List<studio>> getstudioByIdAsync()
        {
            try
            {
                using(var connection = this.context.CreateConnection())
                {
                    return (await connection.QueryAsync<studio>("[dbo].[Getstudio]", commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<studio>> Addstudio(string Name, string Address, string City, string State, int Zipcode, string Email, string StudioOwner, string Description, string StartDate)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    param.Add("@Address", Address);
                    param.Add("@City", City);
                    param.Add("@State", State);
                    param.Add("@Zipcode", Zipcode);
                    param.Add("@Email", Email);
                    param.Add("@StudioOwner", StudioOwner);
                    param.Add("@Description", Description);
                    param.Add("@StartDate", StartDate);
                    return (await connection.QueryAsync<studio>("[dbo].[AddStudio]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //Client

        public async Task<List<ClientAllClasses>> Getallclasses(int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClientId", ClientId);
                    return (await connection.QueryAsync<ClientAllClasses>("[dbo].[GetallClasses_Client]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Workshop>> Getallworkshops(int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClientId", ClientId);
                    return (await connection.QueryAsync<Workshop>("[dbo].[GetallWorkshops_Client]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public async Task<List<ClientRegClasses>> GetRegisteredClasses(int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClientId", ClientId);
                    return (await connection.QueryAsync<ClientRegClasses>("[dbo].[ClassReservation_List]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async Task<List<ClientRegWorkshops>> GetRegisteredWorkshops(int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClientId", ClientId);
                    return (await connection.QueryAsync<ClientRegWorkshops>("[dbo].[WorkshopReservation_List]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void cancelworkshoporclass(int Id, int ClientId, string Type)
        {
            try
            {
                using(var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", Id);
                    param.Add("@ClientId", ClientId);
                    param.Add("@Type", Type);
                    (await connection.QueryAsync("[dbo].[Cancle_Cls_WS]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void RegsterClass(int ClassId, int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClassId", ClassId);
                    param.Add("@ClientId", ClientId);
                    (await connection.QueryAsync("[dbo].[Reservation_Class]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void RegsterWorkshop(int ClassId, int ClientId)
        {
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ClassId", ClassId);
                    param.Add("@ClientId", ClientId);
                    (await connection.QueryAsync("[dbo].[Reservation_Workshop]", param, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
