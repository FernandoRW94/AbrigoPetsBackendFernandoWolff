using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AbrigoPetsBackend.Data;
using AbrigoPetsBackend.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AbrigoPetsBackend.Controllers
{
    public class PetsApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/PetsApi/GetPetsList")]
        public string GetPetsList()
        {
            var pets = _context.Pet.ToList().OrderBy(x => x.Name);
            var result = JsonConvert.SerializeObject(pets);
            return result;
        }

        [HttpGet]
        [Route("/PetsApi/GetPet")]
        public JsonResult GetPet(int id)
        {
            var pet = _context.Pet.FirstOrDefault(x => x.PetId == id);
            
            return Json(pet);
        }

        [HttpPost]
        [Route("PetsApi/UpdatePet")]
        public async Task<JsonResult> UpdatePetAsync([FromBody] dynamic model)
        {
            var petId = (int) model.PetId;
            var petRecord = _context.Pet.FirstOrDefault(x => x.PetId == petId);

            dynamic result = new ExpandoObject();

            if (petRecord != null)
            {
                petRecord.Age = model.Age;
                petRecord.Breed = model.Breed;
                petRecord.Castrated = model.Castrated;
                petRecord.DateOfArrival = model.DateOfArrival;
                petRecord.Description = model.Description;
                petRecord.Name = model.Name;
                petRecord.NextVaccine = model.NextVaccine;
                petRecord.Note = model.Note;
                petRecord.Sex = model.Sex;
                petRecord.Size = model.Size;
                petRecord.ToBeAdopted = model.ToBeAdopted;
                petRecord.Type = model.Type;
                petRecord.UpToDateVaccines = model.UpToDateVaccines;


                try
                {
                    _context.Update(petRecord);
                    await _context.SaveChangesAsync();

                    result.Success = true;
                    result.Message = "O Pet foi atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = "O pet não pode ser atualizado. Por favor tente mais tarde.";
                }
            }
            else
            {
                result.Success = false;
                result.Message = "O pet em questão não existe.";
            }

            return Json(result);
        }

        [HttpPost]
        [Route("/PetsApi/CreateNewPet")]
        public async Task<JsonResult> CreateNewPetAsync([FromBody] dynamic model)
        {
            var pet = new Pet()
            {
                Age = model.Age,
                Breed = model.Breed,
                Castrated = model.Castrated,
                DateOfArrival = model.DateOfArrival,
                Description = model.Description,
                Name = model.Name,
                NextVaccine = model.NextVaccine,
                Note = model.Note,
                Sex = model.Sex,
                Size = model.Size,
                ToBeAdopted = model.ToBeAdopted,
                Type = model.Type,
                UpToDateVaccines = model.UpToDateVaccines
            };

            dynamic result = new ExpandoObject();

            try
            {
                _context.Pet.Add(pet);

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Sucesso ao registrar o novo pet.";
                result.NewId = pet.PetId;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return Json(result);
        }

        [HttpGet]
        [Route("/PetsApi/GetManagementInfos")]
        public JsonResult GetManagementInfos(int id = 1)
        {
            var shelter = _context.Shelter.FirstOrDefault(x => x.ShelterId == id);

            return Json(shelter);
        }

        [HttpPost]
        [Route("PetsApi/UpdateShelter")]
        public async Task<JsonResult> UpdateShelter([FromBody] dynamic model)
        {
            var shelterRecord = _context.Shelter.FirstOrDefault(x => x.ShelterId == 1);

            dynamic result = new ExpandoObject();

            if (shelterRecord != null)
            {
                shelterRecord.ShelterName = model.ShelterName;
                shelterRecord.ShelterMoney = model.ShelterMoney;
                shelterRecord.LastRevenue = model.LastRevenue;
                shelterRecord.LastExpense = model.LastExpense;
                shelterRecord.TotalFood = model.TotalFood;

                try
                {
                    _context.Update(shelterRecord);
                    await _context.SaveChangesAsync();

                    result.Success = true;
                    result.Message = "O abrigo foi atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = "O abrigo não pode ser atualizado. Por favor tente enviar a alteração novamente.";
                }
            }
            else
            {
                result.Success = false;
                result.Message = "O abrigo em questão não existe.";
            }

            return Json(result);
        }
    }
}