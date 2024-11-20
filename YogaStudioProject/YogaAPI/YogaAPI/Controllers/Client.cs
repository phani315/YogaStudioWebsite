using Entity;
using Microsoft.AspNetCore.Mvc;
using REPO;
using System.Numerics;
using System.Reflection;

namespace YogaAPI.Controllers
{
    [Route("Client/V1")]
    [ApiController]
    public class Client : Controller
    {
        private readonly IRepo repo;
        public Client(IRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("Getallclasses")]
        public async Task<IActionResult> Getallclasses(int ClientId)
        {
            try
            {
                List<ClientAllClasses> list = await repo.Getallclasses(ClientId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("Getallworkshops")]
        public async Task<IActionResult> Getallworkshops(int ClientId)
        {
            try
            {
                List<Workshop> list = await repo.Getallworkshops(ClientId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        [HttpGet]
        [Route("GetRegisteredClasses")]
        public async Task<IActionResult> GetRegisteredClasses(int ClientId)
        {
            try
            {
                List<ClientRegClasses> list = await repo.GetRegisteredClasses(ClientId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        [Route("GetRegisteredWorkshops")]
        public async Task<IActionResult> GetRegisteredWorkshops(int ClientId)
        {
            try
            {
                List<ClientRegWorkshops> list = await repo.GetRegisteredWorkshops(ClientId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("cancelworkshoporclass")]
        public async void cancelworkshoporclass(int Id, int ClientId, string Type)
        {
            try
            {
                repo.cancelworkshoporclass(Id,ClientId, Type);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RegsterClass")]
        public async void RegsterClass(int ClassId,int ClientId)
        {
            try
            {
                 repo.RegsterClass(ClassId,ClientId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("RegsterWorkshop")]
        public async void RegsterWorkshop(int ClassId, int ClientId)
        {
            try
            {
                repo.RegsterWorkshop(ClassId, ClientId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
