using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.BL.Factories;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace CPMS.BL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _repository;
        private readonly IDeveloperFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<DeveloperDTO> _logger;

        public DeveloperService(IDeveloperRepository repository, IMapper mapper, ILogger<DeveloperDTO> logger,
            IDeveloperFactory factory
        )
        {
            _repository = repository;
            _factory = factory;
            _mapper = mapper;
            _logger = logger;
        }

        // source: // source: http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management
        public Developer Add(Developer user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            // find if user exists
            var existingUsers = _repository.FindByConditionAync(x => x.UserName == user.UserName);
            if (existingUsers.Result.Count() != 0)
                throw new Exception("Username \"" + user.UserName + "\" is already taken");

            byte[] passwordHash, passwordSalt;

            // create password secret
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var developer = _mapper.Map<DeveloperDTO>(user);

            developer.PasswordHash = passwordHash;
            developer.PasswordSalt = passwordSalt;

            var result = _factory.Create(developer);

            return result;
        }

        public Developer Add(Developer item)
        {
            throw new NotImplementedException();
        }

        // source: http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management
        public Developer Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var findUser = _repository.FindByConditionAync(x => x.UserName == username);
            var user = findUser.Result.FirstOrDefault();
            
            if (user == null)
                return null;
            
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return _mapper.Map<Developer>(user);
        }

        public async Task Delete(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                _repository.Delete(item);
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with delete Developer : {e}");
            }
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            var users = await _repository.GetAll();
            var result = users != null ? _mapper.Map<IEnumerable<Developer>>(users) : null;
            return result;
        }

        public async Task<Developer> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var result = _mapper.Map<Developer>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with find Developer : {e}");
            }

            return null;
        }

        public void Update(Developer item)
        {
            try
            {
                _repository.Update(_mapper.Map<DeveloperDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Developer : {e}");
            }
        }

        // source: http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // source: http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
