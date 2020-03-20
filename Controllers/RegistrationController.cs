using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AFIAPITest.Models;
using AFIAPITest.Models.Repository;
using System.Text.RegularExpressions;
using AFIAPITest.Services;
using AFIAPITest.Interfaces;
namespace AFIAPITest.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IDataRepository<Registration> _dataRepository;
        private readonly IValidation _validation;

        public RegistrationController(IDataRepository<Registration> dataRepository, IValidation validation )
        {
            _dataRepository = dataRepository;
            _validation = validation;
        }

        // GET: api/registration
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Registration> registrations = _dataRepository.GetAll();
            return Ok(registrations);
        }

        // GET: api/registration/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Registration registration = _dataRepository.Get(id);

            if (registration == null)
                return NotFound("The Registration record couldn't be found.");

            return Ok(registration);
        }

        // POST: api/registration
        [HttpPost]
        public IActionResult Post([FromBody] Registration registration)
        {
            if (registration == null)
                return BadRequest("Registration is null.");

            string validRecord = Validate(registration);
            if (validRecord != "")
                return BadRequest(validRecord);

            _dataRepository.Add(registration);
            return CreatedAtRoute(
                  "Get",
                  new { Id = registration.Id },
                  registration);
        }

        // PUT: api/registration/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Registration registration)
        {
            if (registration == null)
                return BadRequest("Registration is null.");

            string validRecord = Validate(registration);
            if (validRecord != "")
                return BadRequest(validRecord);

            Registration registrationToUpdate = _dataRepository.Get(id);
            if (registrationToUpdate == null)
                return NotFound("The Registration record couldn't be found.");


            _dataRepository.Update(registrationToUpdate, registration);
            return NoContent();
        }

        // DELETE: api/registration/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Registration registration = _dataRepository.Get(id);
            if (registration == null)
                throw new ArgumentException($"Registration ID {id} does not exist.", nameof(id));
            

            _dataRepository.Delete(registration);
            return NoContent();
        }
        /// <summary>
        /// Validate Registration model meets requirements
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Validate(Registration entity)
        {
            //Validation valid = new Validation();
            string validationError = "";
            
            //Check length of Firstname
            if(!_validation.NameLength(entity.Firstname).Result)
                validationError = "Firstname needs to be >3 and < 50 characters in length. \r\n";
            
            //Check length of Surname
            if (!_validation.NameLength(entity.Surname).Result)
                validationError += "Surname needs to be >3 and < 50 characters in length. \r\n";

            //Check that policy number matches the following format XX-999999. Where XX are any capitalised alpha character followed by a hyphen and 6 numbers.
            if (! (_validation.PolicyCheck(entity.PolicyReference).Result))
                validationError += "Policy Reference is in the wrong format XX-999999. \r\n";

            if (entity.DOB != null || !string.IsNullOrEmpty(entity.Email))
            {
                //Check Age is at least 18
                if (entity.DOB != null)
                {
                    if (_validation.CalcAge((DateTime)entity.DOB).Result < 18)
                        validationError += "Registrant needs to be at least 18 years old. \r\n";
                }
                //Check email format matches required pattern
                if (!string.IsNullOrEmpty(entity.Email))
                {
                    if (!(_validation.EmailCheck(entity.Email).Result))
                        validationError += "Email required string of at least 4 alpha numeric chars followed by an ‘@’ sign and then another string of at least 2 alpha numeric chars. The email address should end in either ‘.com’ or ‘.co.uk’.. \r\n";
                }
            }
            else
            {
                validationError += "Registration must contain either a Date of Birth or Email \r\n";
            }

            return (validationError);

        }

    }
}
