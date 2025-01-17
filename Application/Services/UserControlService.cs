using Domain;
using Domain.Adapters;
using Domain.Entities.Repository;
using Domain.Entities.Services;
using Domain.Services;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserControlService : IUserControlService
    {
        private readonly IUserRepository _repository;
        public UserControlService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultService> CreateNutritionistUserAsync(NutritionistUser user)
        {
            ValidateLicenseNumber(user.License_Number);
            ValidateEmail(user.Email);
            ValidadePassword(user.Password);

            var id = await _repository.Insert(user);

            if (id == null)
                return Result(false, id);

            return Result(true, id);
        }
        public async Task<ResultService> CreatePatientUserAsync(PatientUser user)
        {
            ValidateEmail(user.Email);
            ValidadePassword(user.Password);
            var id = await _repository.Insert(user);

            if (id == null)
                return Result(false);

            return Result(true, id);
        }
        public async Task<ResultService> UpdateNutritionistUserAsync(NutritionistUser user)
        {

            ValidateField(user.License_Number, ValidateLicenseNumber);
            ValidateField(user.Email, ValidateEmail);
            ValidateField(user.Password, ValidadePassword);

            var id = await _repository.Update(user);

            if (id == null)
                return Result(false, id);

            return Result(true, id);
        }
        public async Task<ResultService> UpdatePatientUserAsync(PatientUser user)
        {

            ValidateField(user.Email, ValidateEmail);
            ValidateField(user.Password, ValidadePassword);

            var id = await _repository.Update(user);

            if (id == null)
                return Result(false, id);

            return Result(true, id);
        }
        public async Task<ResultService> DeleteUserAsync(string id)
        {

            var retorno = await _repository.Delete(id);

            if (retorno == null)
                return Result(false);

            return Result(true, retorno);
        }

        public async Task<ResultService> GetPatientAsync(string id)
        {

            var retorno = await _repository.GetPatient(id);

            if (retorno == null)
                return Result(false);

            return Result(true, userObject: retorno);
        }
        public async Task<ResultService> GetNutritionistAsync(string id)
        {
            var retorno = await _repository.GetNutritionist(id);

            if (retorno == null)
                return Result(false);

            return Result(true, userObject: retorno);
        }
        public async Task<ResultService> GetNutritionistsAsync()
        {
            var retorno = await _repository.GetNutritionists();

            if (retorno == null)
                return Result(false);

            return Result(true, userObject: retorno);
        }
     
        private static void ValidateField(string field, Action<string> validation)
        {
            if (!string.IsNullOrEmpty(field))  
            {
                validation(field);  
            }
        }

        private static void ValidateLicenseNumber(string lincese)
        {
            if(string.IsNullOrEmpty(lincese))
                throw new ValidationException("Erro ao cadastrar Nutricionista (CRN nulo)");
        }

        private static void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ValidationException("Erro ao cadastrar User (Email invalido)");
        }
        private static void ValidadePassword(string password)
        {
            if (password.Length < 5)
                throw new ValidationException("Erro ao cadastrar User (Minimo 5 caracteres)");
        }


        private static ResultService Result(bool sucess, string? message = null, object? userObject = null)
        {
            var result = new ResultService()
            {
                Message = message,
                Success = sucess,
                Data = userObject
            };

            return result;
        }

      
    }
}
