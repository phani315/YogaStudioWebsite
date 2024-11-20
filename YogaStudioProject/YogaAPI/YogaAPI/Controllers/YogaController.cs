using Entity;
using Microsoft.AspNetCore.Mvc;
using REPO;
using System.Numerics;
using System.Reflection;

namespace YogaAPI.Controllers
{
    [Route("Admin/V1")]
    [ApiController]
    public class YogaController : Controller
    {
       private readonly IRepo repo;
        public YogaController(IRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public async Task<IActionResult> GetAllClient()
        {
            try
            {
                List<Clientmodel> list = await repo.getClientByIdAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient(string Name, string Email, string PhoneNumber, string Gender, string password)
        {
            try
            {
                List<Clientmodel> list = await repo.AddClient(Name, Email, PhoneNumber, Gender, password);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("UpdateClient")]
        public async Task<IActionResult> UpdateClient(int ClientID,string Name, string Email, string PhoneNumber, string Gender, string password)
        {
            try
            {
                List<Clientmodel> list = await repo.UpdateClient(ClientID,Name, Email, PhoneNumber, Gender, password);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RemoveClient")]
        public async Task<IActionResult> RemoveClient(int ClientID)
        {
            try
            {
                List<Clientmodel> list = await repo.RemoveClient(ClientID);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //workshop

        [HttpGet]
        [Route("GetAllWorkshops")]
        public async Task<IActionResult> getWorkshopByIdAsync()
        {
            try
            {
                List<Workshop> list = await repo.getWorkshopByIdAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        [HttpPost]
        [Route("AddWorkshop")]
        public async Task<IActionResult> AddWorkshop(string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price, string Prerequisites, string EquipmentRequired, string RegistrationDeadline, int MaxCapacity, int CurrentCapacity, string CancellationDeadline,string WorkshopDate, int StudioId, int WaitingList)
        {
            try
            {
                List<Workshop> list = await repo.AddWorkshop(Name, InstructorID, StartTime, EndTime, Description, Price, Prerequisites, EquipmentRequired, RegistrationDeadline, MaxCapacity, CurrentCapacity, CancellationDeadline, WorkshopDate,StudioId, WaitingList);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("UpdateWorkshop")]
        public async Task<IActionResult> UpdateWorkshop(int WorkshopId, string Name, int InstructorID, string StartTime, string EndTime, string Description, int Price, string Prerequisites, string EquipmentRequired, string RegistrationDeadline, int MaxCapacity, int CurrentCapacity, string CancellationDeadline,string WorkshopDate, int StudioId, int WaitingList)
        {
            try
            {
                List<Workshop> list = await repo.UpdateWorkshop(WorkshopId, Name, InstructorID, StartTime, EndTime, Description, Price, Prerequisites, EquipmentRequired, RegistrationDeadline, MaxCapacity, CurrentCapacity, CancellationDeadline, WorkshopDate, StudioId, WaitingList);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RemoveWorkshop")]
        public async Task<IActionResult> RemoveWorkshop(int WorkshopId)
        {
            try
            {
                List<Workshop> list = await repo.RemoveWorkshop( WorkshopId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //Class

        [HttpGet]
        [Route("GetAllClasses")]
        public async Task<IActionResult> getClassByIdAsync()
        {
            try
            {
                List<Classes> list = await repo.getClassByIdAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        [HttpPost]
        [Route("AddClass")]
        public async Task<IActionResult> AddClass(string Name, int InstructorId, string StartTime, string EndTime, string ClassDateForm, int MaxCapacity, int CurrentCapacity, int WaitingList, string Description, string ClassDateTo, int Price, string ClassLevel, string CancellationDeadline, int StudioId)
        {
            try
            {
                List<Classes> list = await repo.AddClass(Name, InstructorId, StartTime, EndTime, ClassDateForm, MaxCapacity, CurrentCapacity, WaitingList, Description, ClassDateTo, Price, ClassLevel, CancellationDeadline, StudioId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("UpdateClass")]
        public async Task<IActionResult> UpdateClass(int ClassId, string Name, int InstructorId, string StartTime, string EndTime, string ClassDateForm, int MaxCapacity, int CurrentCapacity, int WaitingList, string Description, string ClassDateTo, int Price, string ClassLevel, string CancellationDeadline, int StudioId)
        {
            try
            {
                List<Classes> list = await repo.UpdateClass( ClassId,  Name,  InstructorId,  StartTime,  EndTime,  ClassDateForm,  MaxCapacity,  CurrentCapacity,  WaitingList,  Description,  ClassDateTo,  Price,  ClassLevel,  CancellationDeadline, StudioId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RemoveClass")]
        public async Task<IActionResult> RemoveClass(int ClassId)
        {
            try
            {
                List<Classes> list = await repo.RemoveClass(ClassId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //Instrouctor

        [HttpGet]
        [Route("GetAllInstructor")]
        public async Task<IActionResult> getInstructorByIdAsync()
        {
            try
            {
                List<Instructor> list = await repo.getInstructorByIdAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("AddInstructor")]
        public async Task<IActionResult> AddInstructor(int StudioId, string Name, string Email, string Ph_num, int YearOfExperience)
        {
            try
            {
                List<Instructor> list = await repo.AddInstructor( StudioId,  Name,  Email,  Ph_num,  YearOfExperience);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("UpdateInstructor")]
        public async Task<IActionResult> UpdateInstructor(int StudioId, int InstructorID, string Name, string Email, string Ph_num, int YearOfExperience)
        {
            try
            {
                List<Instructor> list = await repo.UpdateInstructor( StudioId,  InstructorID,  Name,  Email,  Ph_num,  YearOfExperience);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RemoveInstructor")]
        public async Task<IActionResult> RemoveInstructor(int InstructorID)
        {
            try
            {
                List<Instructor> list = await repo.RemoveInstructor(InstructorID);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("GetLogindetails")]
        public async Task<IActionResult> GetLogindetails(string Email, string password)
        {
            try
            {
                List<Logindetails> list = await repo.GetLogindetails( Email,  password);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //studio

        [HttpGet]
        [Route("GetAllStudio")]
        public async Task<IActionResult> getstudioByIdAsync()
        {
            try
            {
                List<studio> list = await repo.getstudioByIdAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("Addstudio")]
        public async Task<IActionResult> Addstudio(string Name, string Address, string City, string State, int Zipcode, string Email, string StudioOwner, string Description, string StartDate)
        {
            try
            {
                List<studio> list = await repo.Addstudio(Name,Address,City,State,Zipcode,Email,StudioOwner,Description,StartDate);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
