﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;
using System.Reflection;
using System.Linq;

namespace CareerCloud.UnitTests.Assignment2
{
    [TestCategory("Assignment 2 Tests")]
    [TestClass]
    public class Assingment2Marking
    {

        private const string _assemblyUnderTest = "CareerCloud.ADODataAccessLayer.dll";

        private SystemCountryCodePoco _systemCountry;
        private ApplicantEducationPoco _applicantEducation;
        private ApplicantProfilePoco _applicantProfile;
        private ApplicantJobApplicationPoco _applicantJobApplication;
        private CompanyJobPoco _companyJob;
        private CompanyProfilePoco _companyProfile;
        private CompanyDescriptionPoco _companyDescription;
        private SystemLanguageCodePoco _systemLangCode;
        private ApplicantResumePoco _applicantResume;
        private ApplicantSkillPoco _applicantSkills;
        private ApplicantWorkHistoryPoco _appliantWorkHistory;
        private CompanyJobEducationPoco _companyJobEducation;
        private CompanyJobSkillPoco _companyJobSkill;
        private CompanyJobDescriptionPoco _companyJobDescription;
        private CompanyLocationPoco _companyLocation;
        private SecurityLoginPoco _securityLogin;
        private SecurityLoginsLogPoco _securityLoginLog;
        private SecurityRolePoco _securityRole;
        private SecurityLoginsRolePoco _securityLoginRole;

        private Type[] _types;

        [TestInitialize]
        public void Init_Pocos()
        {
            ApplicantEducationRepository poco = new ApplicantEducationRepository();
            _types = Assembly.LoadFrom(_assemblyUnderTest).GetTypes();

            SystemCountry_Init();
            CompanyProfile_Init();
            SystemLangCode_Init();
            CompanyDescription_Init();
            CompanyJob_Init();
            CompanyJobEducation_Init();
            CompanyJobSkill_Init();
            CompanyJobDescription_Init();
            CompanyLocation_Init();
            SecurityLogin_Init();
            ApplicantProfile_Init();
            SecurityLoginLog_Init();
            SecurityRole_Init();
            SecurityLoginRole_Init();
            ApplicantEducation_Init();
            ApplicantResume_Init();
            ApplicantSkills_Init();
            AappliantWorkHistory_Init();
            ApplicantJobApplication_Init();
        }

        #region DTOCreation
        [TestMethod]
        public void Assingment_2_DTO_Creation()
        {
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantEducationRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantJobApplicationRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantProfileRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantResumeRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantSkillRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "ApplicantWorkHistoryRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyDescriptionRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobDescriptionRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobEducationRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyJobSkillRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyLocationRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "CompanyProfleRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginLogRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityLoginRoleRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SecurityRoleRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SystemCountryCodeRepository"));
            Assert.IsTrue(_types.Any(t => t.Name == "SystemLanguageCodeRepository"));
        }
        #endregion DTOCreation

        #region PocoInitialization
        private void ApplicantJobApplication_Init()
        {
            _applicantJobApplication = new ApplicantJobApplicationPoco()
            {
                Id = Guid.NewGuid(),
                ApplicationDate = Faker.Date.Recent(),
                Applicant = _applicantProfile.Id,
                Job = _companyJob.Id
            };
        }

        private void AappliantWorkHistory_Init()
        {
            _appliantWorkHistory = new ApplicantWorkHistoryPoco()
            {
                Id = Guid.NewGuid(),
                Applicant = _applicantProfile.Id,
                CompanyName = Truncate(Faker.Lorem.Sentence(), 150),
                CountryCode = _systemCountry.Code,
                EndMonth = 12,
                EndYear = 1999,
                JobDescription = Truncate(Faker.Lorem.Sentence(), 500),
                JobTitle = Truncate(Faker.Lorem.Sentence(), 50),
                Location = Faker.Address.StreetName(),
                StartMonth = 1,
                StartYear = 1999
            };
        }

        private void ApplicantSkills_Init()
        {
            _applicantSkills = new ApplicantSkillPoco()
            {
                Applicant = _applicantProfile.Id,
                Id = Guid.NewGuid(),
                EndMonth = 12,
                EndYear = 1999,
                Skill = Truncate(Faker.Lorem.Sentence(), 100),
                SkillLevel = Truncate(Faker.Lorem.Sentence(), 10),
                StartMonth = 1,
                StartYear = 1999
            };
        }

        private void ApplicantResume_Init()
        {
            _applicantResume = new ApplicantResumePoco()
            {
                Applicant = _applicantProfile.Id,
                Id = Guid.NewGuid(),
                Resume = Faker.Lorem.Paragraph(),
                LastUpdated = Faker.Date.Recent()
            };
        }

        private void ApplicantEducation_Init()
        {
            _applicantEducation = new ApplicantEducationPoco()
            {
                Id = Guid.NewGuid(),
                Applicant = _applicantProfile.Id,
                Major = Faker.Education.Major(),
                CertificateDiploma = Faker.Education.Major(),
                StartDate = Faker.Date.Past(3),
                CompletionDate = Faker.Date.Past(1),
                CompletionPercent = (byte)Faker.Number.RandomNumber(1)
            };
        }

        private void SecurityLoginRole_Init()
        {
            _securityLoginRole = new SecurityLoginsRolePoco()
            {
                Id = Guid.NewGuid(),
                Login = _securityLogin.Id,
                Role = _securityRole.Id
            };
        }

        private void SecurityRole_Init()
        {
            _securityRole = new SecurityRolePoco()
            {
                Id = Guid.NewGuid(),
                IsInactive = true,
                Role = Truncate(Faker.Company.Industry(), 50)

            };
        }

        private void SecurityLoginLog_Init()
        {
            _securityLoginLog = new SecurityLoginsLogPoco()
            {
                Id = Guid.NewGuid(),
                IsSuccesful = true,
                Login = _securityLogin.Id,
                LogonDate = Faker.Date.PastWithTime(),
                SourceIP = Faker.Internet.IPv4().PadRight(15)
            };
        }

        private void ApplicantProfile_Init()
        {
            _applicantProfile = new ApplicantProfilePoco
            {
                Id = Guid.NewGuid(),
                Login = _securityLogin.Id,
                City = Faker.Address.CityPrefix(),
                Country = _systemCountry.Code,
                Currency = "CAN".PadRight(10),
                CurrentRate = 71.25M,
                CurrentSalary = 67500,
                Province = Truncate(Faker.Address.Province(), 10).PadRight(10),
                Street = Truncate(Faker.Address.StreetName(), 100),
                PostalCode = Truncate(Faker.Address.CanadianZipCode(), 20).PadRight(20)
            };
        }

        private void SecurityLogin_Init()
        {
            _securityLogin = new SecurityLoginPoco()
            {
                Login = Faker.User.Email(),
                AgreementAccepted = Faker.Date.PastWithTime(),
                Created = Faker.Date.PastWithTime(),
                EmailAddress = Faker.User.Email(),
                ForceChangePassword = false,
                FullName = Faker.Name.FullName(),
                Id = Guid.NewGuid(),
                IsInactive = false,
                IsLocked = false,
                Password = Faker.User.Password(),
                PasswordUpdate = Faker.Date.Forward(),
                PhoneNumber = "555-416-9889",
                PrefferredLanguage = "EN".PadRight(10)
            };
        }

        private void CompanyLocation_Init()
        {
            _companyLocation = new CompanyLocationPoco()
            {
                Id = Guid.NewGuid(),
                City = Faker.Address.CityPrefix(),
                Company = _companyProfile.Id,
                CountryCode = _systemCountry.Code,
                Province = Faker.Address.ProvinceAbbreviation(),
                Street = Faker.Address.StreetName(),
                PostalCode = Faker.Address.CanadianZipCode()
            };
        }

        private void CompanyJobDescription_Init()
        {
            _companyJobDescription = new CompanyJobDescriptionPoco()
            {
                Id = Guid.NewGuid(),
                Job = _companyJob.Id,
                JobDescriptions = Truncate(Faker.Lorem.Paragraph(), 999),
                JobName = Truncate(Faker.Lorem.Sentence(), 99)
            };
        }

        private void CompanyJobSkill_Init()
        {
            _companyJobSkill = new CompanyJobSkillPoco()
            {
                Id = Guid.NewGuid(),
                Importance = 2,
                Job = _companyJob.Id,
                Skill = Truncate(Faker.Lorem.Sentence(), 100),
                SkillLevel = String.Concat(Faker.Lorem.Letters(10))
            };
        }

        private void CompanyJobEducation_Init()
        {
            _companyJobEducation = new CompanyJobEducationPoco()
            {
                Id = Guid.NewGuid(),
                Importance = 2,
                Job = _companyJob.Id,
                Major = Truncate(Faker.Lorem.Sentence(), 100)
            };
        }

        private void CompanyJob_Init()
        {
            _companyJob = new CompanyJobPoco()
            {
                Id = Guid.NewGuid(),
                Company = _companyProfile.Id,
                IsCompanyHidden = false,
                IsInactive = false,
                ProfileCreated = Faker.Date.Past()
            };
        }

        private void CompanyDescription_Init()
        {
            _companyDescription = new CompanyDescriptionPoco()
            {
                Id = Guid.NewGuid(),
                CompanyDescription = Faker.Company.CatchPhrase(),
                CompanyName = Faker.Company.CatchPhrasePos(),
                LanguageId = _systemLangCode.LanguageID,
                Company = _companyProfile.Id
            };
        }

        private void SystemLangCode_Init()
        {
            _systemLangCode = new SystemLanguageCodePoco()
            {
                LanguageID = String.Concat(Faker.Lorem.Letters(10)),
                NativeName = Truncate(Faker.Lorem.Sentence(), 50),
                Name = Truncate(Faker.Lorem.Sentence(), 50)
            };
        }

        private void CompanyProfile_Init()
        {
            _companyProfile = new CompanyProfilePoco()
            {
                CompanyWebsite = Faker.Internet.Host(),
                ContactName = Faker.Name.FullName(),
                ContactPhone = "416-555-8799",
                RegistrationDate = Faker.Date.Past(),
                Id = Guid.NewGuid(),
                CompanyLogo = new byte[10]
            };
        }

        private void SystemCountry_Init()
        {
            _systemCountry = new SystemCountryCodePoco
            {
                Code = String.Concat(Faker.Lorem.Letters(10)),
                Name = Truncate(Faker.Name.FullName(), 50)
            };
        }

        #endregion PocoInitialization

        [TestMethod]
        public void Assignment2_General_GetAll_General_Test()
        {
            ApplicantEducationRepository repo = new ApplicantEducationRepository();
            var types = Assembly.LoadFrom(_assemblyUnderTest).GetTypes();
            foreach (var type in types)
            {
                foreach (MethodInfo member in type.GetMembers().Where(m => m.Name == "GetAll"))
                {
                    if (!type.ContainsGenericParameters)
                    {
                        object classInstance = Activator.CreateInstance(type, null);
                        object result = member.Invoke(classInstance, new object[] { null });
                        Assert.IsNotNull(result);
                    }
                }
            }
        }

        [TestMethod]
        public void Assignment2_DeepDive_CRUD_Test()
        {
            SystemCountryCodeAdd();
            SystemCountryCodeCheck();
            SystemCountryCodeUpdate();
            SystemCountryCodeCheck();

            SystemLanguageCodeAdd();
            SystemLanguageCodeCheck();
            SystemLanguageCodeUpdate();
            SystemLanguageCodeCheck();

            CompanyProfileAdd();



            CompanyDescriptionAdd();
            CompanyJobAdd();
            CompanyJobDescriptionAdd();
            CompanyLocationAdd();
            CompanyJobEducationAdd();
            CompanyJobSkillAdd();

            SecurityLoginAdd();
            SecurityLoginLogAdd();
            SecurityRoleAdd();
            SecurityLoginRoleAdd();

            ApplicantProfileAdd();
            ApplicantEducationAdd();
            ApplicantJobApplicationAdd();
            ApplicantResumeAdd();
            ApplicantSkillAdd();

            ApplicantWorkHistoryAdd();
            ApplicantWorkHistoryCheck();
            ApplicantWorkHistoryUpdate();
            ApplicantWorkHistoryCheck();


            #region Cleanup
            ApplicantWorkHistoryRemove();
            ApplicantSkillRemove();
            ApplicantResumeRemove();

            ApplicantJobApplicationRemove();
            ApplicantEducationRemove();
            ApplicantProfileRemove();

            SecurityLoginRoleRemove();
            SecurityRoleRemove();
            SecurityLoginLogRemove();
            SecurityLoginRemove();

            CompanyJobSkillRemove();
            CompanyJobEducationRemove();
            CompanyLocationRemove();
            CompanyJobDescRemove();
            CompanyJobRemove();
            CompanyDescriptionRemove();
            CompanyProfileRemove();

            SystemLanguageCodeRemove();
            SystemCountryCodeRemove();

            #endregion
        }

        #region UpdateImplementation
        private void ApplicantWorkHistoryUpdate()
        {
            _appliantWorkHistory.CompanyName = Truncate(Faker.Lorem.Sentence(), 150);
            _appliantWorkHistory.EndMonth = 01;
            _appliantWorkHistory.EndYear = 2001;
            _appliantWorkHistory.JobDescription = Truncate(Faker.Lorem.Sentence(), 500);
            _appliantWorkHistory.JobTitle = Truncate(Faker.Lorem.Sentence(), 50);
            _appliantWorkHistory.Location = Faker.Address.StreetName();
            _appliantWorkHistory.StartMonth = 2;
            _appliantWorkHistory.StartYear = 1989;

            ApplicantWorkHistoryRepository repo = new ApplicantWorkHistoryRepository();
            repo.Update(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
        }

        private void SystemCountryCodeUpdate()
        {
            _systemCountry.Name = Truncate(Faker.Name.FullName(), 50);
            SystemCountryCodeRepository systemCountryCodeRepository = new SystemCountryCodeRepository();
            systemCountryCodeRepository.Update(new SystemCountryCodePoco[] { _systemCountry });
        }

        private void SystemLanguageCodeUpdate()
        {
            _systemLangCode.NativeName = Truncate(Faker.Lorem.Sentence(), 50);
            _systemLangCode.Name = Truncate(Faker.Lorem.Sentence(), 50);
            SystemLanguageCodeRepository systemLanguageCodeRepository = new SystemLanguageCodeRepository();
            systemLanguageCodeRepository.Update(new SystemLanguageCodePoco[] { _systemLangCode });

        }
        #endregion UpdateImplementation

        #region RemoveImplementation
        private void SystemLanguageCodeRemove()
        {
            SystemLanguageCodeRepository systemLanguageCodeRepo = new SystemLanguageCodeRepository();
            systemLanguageCodeRepo.Remove(new SystemLanguageCodePoco[] { _systemLangCode });
            Assert.IsNull(systemLanguageCodeRepo.GetSingle(t => t.LanguageID == _systemLangCode.LanguageID));
        }

        private void CompanyProfileRemove()
        {
            CompanyProfleRepository companyProfileRepo = new CompanyProfleRepository();
            companyProfileRepo.Remove(new CompanyProfilePoco[] { _companyProfile });
            Assert.IsNull(companyProfileRepo.GetSingle(t => t.Id == _companyProfile.Id));
        }

        private void CompanyDescriptionRemove()
        {
            CompanyDescriptionRepository companyDescriptionRepo = new CompanyDescriptionRepository();
            companyDescriptionRepo.Remove(new CompanyDescriptionPoco[] { _companyDescription });
            Assert.IsNull(companyDescriptionRepo.GetSingle(t => t.Id == _companyDescription.Id));
        }

        private void CompanyJobRemove()
        {
            CompanyJobRepository companyJobRepo = new CompanyJobRepository();
            companyJobRepo.Remove(new CompanyJobPoco[] { _companyJob });
            Assert.IsNull(companyJobRepo.GetSingle(t => t.Id == _companyJob.Id));
        }

        private void CompanyJobDescRemove()
        {
            CompanyJobDescriptionRepository companyJobDescRepo = new CompanyJobDescriptionRepository();
            companyJobDescRepo.Remove(new CompanyJobDescriptionPoco[] { _companyJobDescription });
            Assert.IsNull(companyJobDescRepo.GetSingle(t => t.Id == _companyJobDescription.Id));
        }

        private void CompanyLocationRemove()
        {
            CompanyLocationRepository companyLocationRepo = new CompanyLocationRepository();
            companyLocationRepo.Remove(new CompanyLocationPoco[] { _companyLocation });
            Assert.IsNull(companyLocationRepo.GetSingle(t => t.Id == _companyLocation.Id));
        }

        private void CompanyJobEducationRemove()
        {
            CompanyJobEducationRepository companyJobEducationRepo = new CompanyJobEducationRepository();
            companyJobEducationRepo.Remove(new CompanyJobEducationPoco[] { _companyJobEducation });
            Assert.IsNull(companyJobEducationRepo.GetSingle(t => t.Id == _companyJobEducation.Id));
        }

        private void CompanyJobSkillRemove()
        {
            CompanyJobSkillRepository companyJobSkillRepository = new CompanyJobSkillRepository();
            companyJobSkillRepository.Remove(new CompanyJobSkillPoco[] { _companyJobSkill });
            Assert.IsNull(companyJobSkillRepository.GetSingle(t => t.Id == _companyJobSkill.Id));
        }

        private void SystemCountryCodeRemove()
        {
            SystemCountryCodeRepository systemCountryCodeRepository = new SystemCountryCodeRepository();
            systemCountryCodeRepository.Remove(new SystemCountryCodePoco[] { _systemCountry });
            Assert.IsNull(systemCountryCodeRepository.GetSingle(t => t.Code == _systemCountry.Code));
        }

        private void SecurityLoginRemove()
        {
            SecurityLoginRepository securityLoginRepository = new SecurityLoginRepository();
            securityLoginRepository.Remove(new SecurityLoginPoco[] { _securityLogin });
            Assert.IsNull(securityLoginRepository.GetSingle(t => t.Id == _securityLogin.Id));
        }

        private void SecurityLoginLogRemove()
        {
            SecurityLoginLogRepository securityLoginLogRepository = new SecurityLoginLogRepository();
            securityLoginLogRepository.Remove(new SecurityLoginsLogPoco[] { _securityLoginLog });
            Assert.IsNull(securityLoginLogRepository.GetSingle(t => t.Id == _securityLoginLog.Id));
        }

        private void SecurityRoleRemove()
        {
            SecurityRoleRepository securityRoleRepository = new SecurityRoleRepository();
            securityRoleRepository.Remove(new SecurityRolePoco[] { _securityRole });
            Assert.IsNull(securityRoleRepository.GetSingle(t => t.Id == _securityRole.Id));
        }

        private void SecurityLoginRoleRemove()
        {
            SecurityLoginRoleRepository securityLoginRoleRepository = new SecurityLoginRoleRepository();
            securityLoginRoleRepository.Remove(new SecurityLoginsRolePoco[] { _securityLoginRole });
            Assert.IsNull(securityLoginRoleRepository.GetSingle(t => t.Id == _securityLoginRole.Id));
        }

        private void ApplicantProfileRemove()
        {
            ApplicantProfileRepository applicantProfileRepository = new ApplicantProfileRepository();
            applicantProfileRepository.Remove(new ApplicantProfilePoco[] { _applicantProfile });
            Assert.IsNull(applicantProfileRepository.GetSingle(t => t.Id == _applicantProfile.Id));
        }

        private void ApplicantEducationRemove()
        {
            ApplicantEducationRepository applicantEducationRepository = new ApplicantEducationRepository();
            applicantEducationRepository.Remove(new ApplicantEducationPoco[] { _applicantEducation });
            Assert.IsNull(applicantEducationRepository.GetSingle(t => t.Id == _applicantEducation.Id));
        }

        private void ApplicantJobApplicationRemove()
        {
            ApplicantJobApplicationRepository applicantJobApplicationRepository = new ApplicantJobApplicationRepository();
            applicantJobApplicationRepository.Remove(new ApplicantJobApplicationPoco[] { _applicantJobApplication });
            Assert.IsNull(applicantJobApplicationRepository.GetSingle(t => t.Id == _applicantJobApplication.Id));
        }

        private void ApplicantResumeRemove()
        {
            ApplicantResumeRepository applicantResumeRepository = new ApplicantResumeRepository();
            applicantResumeRepository.Remove(new ApplicantResumePoco[] { _applicantResume });
            ApplicantResumePoco applicantResumePoco = applicantResumeRepository.GetSingle(t => t.Id == _applicantResume.Id);
            Assert.IsNull(applicantResumePoco);
        }

        private void ApplicantSkillRemove()
        {
            ApplicantSkillRepository applicantSkillRepository = new ApplicantSkillRepository();
            applicantSkillRepository.Remove(new ApplicantSkillPoco[] { _applicantSkills });
            Assert.IsNull(applicantSkillRepository.GetSingle(t => t.Id == _applicantSkills.Id));
        }

        private void ApplicantWorkHistoryRemove()
        {
            ApplicantWorkHistoryRepository applicantWorkHistoryRepository = new ApplicantWorkHistoryRepository();
            applicantWorkHistoryRepository.Remove(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
            Assert.IsNull(applicantWorkHistoryRepository.GetSingle(t => t.Id == _appliantWorkHistory.Id));
        }

        #endregion RemoveImplementation

        #region AddImplementation
        private void ApplicantWorkHistoryAdd()
        {
            ApplicantWorkHistoryRepository applicantWorkHistoryRepository = new ApplicantWorkHistoryRepository();
            applicantWorkHistoryRepository.Add(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
        }

        private void ApplicantSkillAdd()
        {
            ApplicantSkillRepository applicantSkillRepository = applicantSkillRepository = new ApplicantSkillRepository();
            applicantSkillRepository.Add(new ApplicantSkillPoco[] { _applicantSkills });
            ApplicantSkillPoco applicantSkillPoco = applicantSkillRepository.GetSingle(t => t.Id == _applicantSkills.Id);
            Assert.IsNotNull(applicantSkillPoco);
            Assert.AreEqual(_applicantSkills.Id, applicantSkillPoco.Id);
            Assert.AreEqual(_applicantSkills.Applicant, applicantSkillPoco.Applicant);
            Assert.AreEqual(_applicantSkills.Skill, applicantSkillPoco.Skill);
            Assert.AreEqual(_applicantSkills.SkillLevel, applicantSkillPoco.SkillLevel);
            Assert.AreEqual(_applicantSkills.StartMonth, applicantSkillPoco.StartMonth);
            Assert.AreEqual(_applicantSkills.StartYear, applicantSkillPoco.StartYear);
            Assert.AreEqual(_applicantSkills.EndMonth, applicantSkillPoco.EndMonth);
            Assert.AreEqual(_applicantSkills.EndYear, applicantSkillPoco.EndYear);
        }

        private void ApplicantResumeAdd()
        {
            ApplicantResumeRepository applicantResumeRepository = new ApplicantResumeRepository();
            applicantResumeRepository.Add(new ApplicantResumePoco[] { _applicantResume });
            ApplicantResumePoco applicantResumePoco = applicantResumeRepository.GetSingle(t => t.Id == _applicantResume.Id);
            Assert.IsNotNull(applicantResumePoco);
            Assert.AreEqual(_applicantResume.Id, applicantResumePoco.Id);
            Assert.AreEqual(_applicantResume.Applicant, applicantResumePoco.Applicant);
            Assert.AreEqual(_applicantResume.Resume, applicantResumePoco.Resume);
            Assert.AreEqual(_applicantResume.LastUpdated.Value.Date, applicantResumePoco.LastUpdated.Value.Date);
        }

        private void ApplicantJobApplicationAdd()
        {
            ApplicantJobApplicationRepository applicantJobApplicationRepository = new ApplicantJobApplicationRepository();
            applicantJobApplicationRepository.Add(new ApplicantJobApplicationPoco[] { _applicantJobApplication });
            ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantJobApplicationRepository.GetSingle(t => t.Id == _applicantJobApplication.Id);
            Assert.IsNotNull(applicantJobApplicationPoco);
            Assert.AreEqual(_applicantJobApplication.Id, applicantJobApplicationPoco.Id);
            Assert.AreEqual(_applicantJobApplication.Applicant, applicantJobApplicationPoco.Applicant);
            Assert.AreEqual(_applicantJobApplication.Job, applicantJobApplicationPoco.Job);
            Assert.AreEqual(_applicantJobApplication.ApplicationDate.Date, applicantJobApplicationPoco.ApplicationDate.Date);
        }

        private void ApplicantEducationAdd()
        {
            ApplicantEducationRepository applicantEducationRepository = new ApplicantEducationRepository();
            applicantEducationRepository.Add(new ApplicantEducationPoco[] { _applicantEducation });
            ApplicantEducationPoco applicantEducationPoco = applicantEducationRepository.GetSingle(t => t.Id == _applicantEducation.Id);
            Assert.IsNotNull(applicantEducationPoco);
            Assert.AreEqual(_applicantEducation.Id, applicantEducationPoco.Id);
            Assert.AreEqual(_applicantEducation.Applicant, applicantEducationPoco.Applicant);
            Assert.AreEqual(_applicantEducation.Major, applicantEducationPoco.Major);
            Assert.AreEqual(_applicantEducation.CertificateDiploma, applicantEducationPoco.CertificateDiploma);
            Assert.AreEqual(_applicantEducation.StartDate.Value.Date, applicantEducationPoco.StartDate.Value.Date);
            Assert.AreEqual(_applicantEducation.CompletionDate.Value.Date, applicantEducationPoco.CompletionDate.Value.Date);
            Assert.AreEqual(_applicantEducation.CompletionPercent, applicantEducationPoco.CompletionPercent);
        }

        private void ApplicantProfileAdd()
        {
            ApplicantProfileRepository applicantProfileRepository = new ApplicantProfileRepository();
            applicantProfileRepository.Add(new ApplicantProfilePoco[] { _applicantProfile });
            ApplicantProfilePoco applicantProfilePoco = applicantProfileRepository.GetSingle(t => t.Id == _applicantProfile.Id);
            Assert.IsNotNull(applicantProfilePoco);
            Assert.AreEqual(_applicantProfile.Id, applicantProfilePoco.Id);
            Assert.AreEqual(_applicantProfile.Login, applicantProfilePoco.Login);
            Assert.AreEqual(_applicantProfile.CurrentSalary, applicantProfilePoco.CurrentSalary);
            Assert.AreEqual(_applicantProfile.CurrentRate, applicantProfilePoco.CurrentRate);
            Assert.AreEqual(_applicantProfile.Currency, applicantProfilePoco.Currency);
            Assert.AreEqual(_applicantProfile.Country, applicantProfilePoco.Country);
            Assert.AreEqual(_applicantProfile.Province, applicantProfilePoco.Province);
            Assert.AreEqual(_applicantProfile.Street, applicantProfilePoco.Street);
            Assert.AreEqual(_applicantProfile.City, applicantProfilePoco.City);
            Assert.AreEqual(_applicantProfile.PostalCode, applicantProfilePoco.PostalCode);
        }

        private void SecurityLoginRoleAdd()
        {
            //   Security_Logins_Roles
            SecurityLoginRoleRepository securityLoginRoleRepository = new SecurityLoginRoleRepository();
            securityLoginRoleRepository.Add(new SecurityLoginsRolePoco[] { _securityLoginRole });
            SecurityLoginsRolePoco securityLoginsRolePoco = securityLoginRoleRepository.GetSingle(t => t.Id == _securityLoginRole.Id);
            Assert.IsNotNull(securityLoginsRolePoco);
            Assert.AreEqual(_securityLoginRole.Id, securityLoginsRolePoco.Id);
            Assert.AreEqual(_securityLoginRole.Login, securityLoginsRolePoco.Login);
            Assert.AreEqual(_securityLoginRole.Role, securityLoginsRolePoco.Role);
        }

        private void SecurityRoleAdd()
        {
            //   Security_Roles
            SecurityRoleRepository securityRoleRepository = new SecurityRoleRepository();
            securityRoleRepository.Add(new SecurityRolePoco[] { _securityRole });
            SecurityRolePoco securityRolePoco = securityRoleRepository.GetSingle(t => t.Id == _securityRole.Id);
            Assert.IsNotNull(securityRolePoco);
            Assert.AreEqual(_securityRole.Id, securityRolePoco.Id);
            Assert.AreEqual(_securityRole.Role, securityRolePoco.Role);
            Assert.AreEqual(_securityRole.IsInactive, securityRolePoco.IsInactive);
        }

        private void SecurityLoginLogAdd()
        {
            SecurityLoginLogRepository securityLoginLogRepository = new SecurityLoginLogRepository();
            securityLoginLogRepository.Add(new SecurityLoginsLogPoco[] { _securityLoginLog });
            SecurityLoginsLogPoco securityLoginsLogPoco = securityLoginLogRepository.GetSingle(t => t.Id == _securityLoginLog.Id);
            Assert.IsNotNull(securityLoginsLogPoco);
            Assert.AreEqual(_securityLoginLog.Id, securityLoginsLogPoco.Id);
            Assert.AreEqual(_securityLoginLog.Login, securityLoginsLogPoco.Login);
            Assert.AreEqual(_securityLoginLog.SourceIP, securityLoginsLogPoco.SourceIP);
            Assert.AreEqual(_securityLoginLog.LogonDate.Date, securityLoginsLogPoco.LogonDate.Date);
        }

        private void SecurityLoginAdd()
        {
            SecurityLoginRepository securityLoginRepository = new SecurityLoginRepository();
            securityLoginRepository.Add(new SecurityLoginPoco[] { _securityLogin });
            SecurityLoginPoco securityLoginPoco = securityLoginRepository.GetSingle(t => t.Id == _securityLogin.Id);
            Assert.IsNotNull(securityLoginPoco);
            Assert.AreEqual(_securityLogin.Id, securityLoginPoco.Id);
            Assert.AreEqual(_securityLogin.Login, securityLoginPoco.Login);
            Assert.AreEqual(_securityLogin.Password, securityLoginPoco.Password);
            Assert.AreEqual(_securityLogin.Created.Date, securityLoginPoco.Created.Date);
            Assert.AreEqual(_securityLogin.PasswordUpdate, securityLoginPoco.PasswordUpdate);
            Assert.AreEqual(_securityLogin.AgreementAccepted.Value.Date, securityLoginPoco.AgreementAccepted.Value.Date);
            Assert.AreEqual(_securityLogin.IsLocked, securityLoginPoco.IsLocked);
            Assert.AreEqual(_securityLogin.IsInactive, securityLoginPoco.IsInactive);
            Assert.AreEqual(_securityLogin.EmailAddress, securityLoginPoco.EmailAddress);
            Assert.AreEqual(_securityLogin.PhoneNumber, securityLoginPoco.PhoneNumber);
            Assert.AreEqual(_securityLogin.FullName, securityLoginPoco.FullName);
            Assert.AreEqual(_securityLogin.ForceChangePassword, securityLoginPoco.ForceChangePassword);
            Assert.AreEqual(_securityLogin.PrefferredLanguage, securityLoginPoco.PrefferredLanguage);
        }

        private void CompanyJobSkillAdd()
        {
            CompanyJobSkillRepository companyJobSkillRepository = new CompanyJobSkillRepository();
            companyJobSkillRepository.Add(new CompanyJobSkillPoco[] { _companyJobSkill });
            CompanyJobSkillPoco companyJobSkillPoco = companyJobSkillRepository.GetSingle(t => t.Id == _companyJobSkill.Id);
            Assert.IsNotNull(companyJobSkillPoco);
            Assert.AreEqual(_companyJobSkill.Id, companyJobSkillPoco.Id);
            Assert.AreEqual(_companyJobSkill.Job, companyJobSkillPoco.Job);
            Assert.AreEqual(_companyJobSkill.Skill, companyJobSkillPoco.Skill);
            Assert.AreEqual(_companyJobSkill.SkillLevel, companyJobSkillPoco.SkillLevel);
            Assert.AreEqual(_companyJobSkill.Importance, companyJobSkillPoco.Importance);
        }

        private void CompanyJobEducationAdd()
        {
            CompanyJobEducationRepository companyJobEducationRepo = new CompanyJobEducationRepository();
            companyJobEducationRepo.Add(new CompanyJobEducationPoco[] { _companyJobEducation });
            CompanyJobEducationPoco companyJobEducationPoco = companyJobEducationRepo.GetSingle(t => t.Id == _companyJobEducation.Id);
            Assert.IsNotNull(companyJobEducationPoco);
            Assert.AreEqual(_companyJobEducation.Id, companyJobEducationPoco.Id);
            Assert.AreEqual(_companyJobEducation.Job, companyJobEducationPoco.Job);
            Assert.AreEqual(_companyJobEducation.Major, companyJobEducationPoco.Major);
            Assert.AreEqual(_companyJobEducation.Importance, companyJobEducationPoco.Importance);
        }

        private void CompanyLocationAdd()
        {
            CompanyLocationRepository companyLocationRepo = new CompanyLocationRepository();
            companyLocationRepo.Add(new CompanyLocationPoco[] { _companyLocation });
            CompanyLocationPoco companyLocationPoco = companyLocationRepo.GetSingle(t => t.Id == _companyLocation.Id);
            Assert.IsNotNull(companyLocationPoco);
            Assert.AreEqual(_companyLocation.Id, companyLocationPoco.Id);
            Assert.AreEqual(_companyLocation.Company, companyLocationPoco.Company);
            Assert.AreEqual(_companyLocation.CountryCode.PadRight(10), companyLocationPoco.CountryCode);
            Assert.AreEqual(_companyLocation.Province.PadRight(10), companyLocationPoco.Province);
            Assert.AreEqual(_companyLocation.Street, companyLocationPoco.Street);
            Assert.AreEqual(_companyLocation.City, companyLocationPoco.City);
            Assert.AreEqual(_companyLocation.PostalCode.PadRight(20), companyLocationPoco.PostalCode);
        }

        private void CompanyJobDescriptionAdd()
        {
            CompanyJobDescriptionRepository companyJobDescRepo = new CompanyJobDescriptionRepository();
            companyJobDescRepo.Add(new CompanyJobDescriptionPoco[] { _companyJobDescription });
            CompanyJobDescriptionPoco companyJobDescPoco = companyJobDescRepo.GetSingle(t => t.Id == _companyJobDescription.Id);
            Assert.IsNotNull(companyJobDescPoco);
            Assert.AreEqual(_companyJobDescription.Id, companyJobDescPoco.Id);
            Assert.AreEqual(_companyJobDescription.Job, companyJobDescPoco.Job);
            Assert.AreEqual(_companyJobDescription.JobDescriptions, companyJobDescPoco.JobDescriptions);
            Assert.AreEqual(_companyJobDescription.JobName, companyJobDescPoco.JobName);
        }

        private void CompanyJobAdd()
        {
            CompanyJobRepository companyJobRepo = new CompanyJobRepository();
            companyJobRepo.Add(new CompanyJobPoco[] { _companyJob });
            CompanyJobPoco companyJobPoco = companyJobRepo.GetSingle(t => t.Id == _companyJob.Id);
            Assert.IsNotNull(companyJobPoco);
            Assert.AreEqual(_companyJob.Id, companyJobPoco.Id);
            Assert.AreEqual(_companyJob.Company, companyJobPoco.Company);
            Assert.AreEqual(_companyJob.ProfileCreated, companyJobPoco.ProfileCreated);
            Assert.AreEqual(_companyJob.IsInactive, companyJobPoco.IsInactive);
            Assert.AreEqual(_companyJob.IsCompanyHidden, companyJobPoco.IsCompanyHidden);
        }

        private void CompanyDescriptionAdd()
        {
            CompanyDescriptionRepository companyDescriptionRepo = new CompanyDescriptionRepository();
            companyDescriptionRepo.Add(new CompanyDescriptionPoco[] { _companyDescription });
            CompanyDescriptionPoco companyDescriptionPoco = companyDescriptionRepo.GetSingle(t => t.Id == _companyDescription.Id);
            Assert.IsNotNull(companyDescriptionPoco);
            Assert.AreEqual(_companyDescription.Id, companyDescriptionPoco.Id);
            Assert.AreEqual(_companyDescription.CompanyDescription, companyDescriptionPoco.CompanyDescription);
            Assert.AreEqual(_companyDescription.CompanyName, companyDescriptionPoco.CompanyName);
            Assert.AreEqual(_companyDescription.LanguageId, companyDescriptionPoco.LanguageId);
            Assert.AreEqual(_companyDescription.Company, companyDescriptionPoco.Company);
        }

        private void CompanyProfileAdd()
        {
            CompanyProfleRepository companyProfileRepo = new CompanyProfleRepository();
            companyProfileRepo.Add(new CompanyProfilePoco[] { _companyProfile });
            CompanyProfilePoco companyProfilePoco = companyProfileRepo.GetSingle(t => t.Id == _companyProfile.Id);
            Assert.IsNotNull(companyProfilePoco);
            Assert.AreEqual(_companyProfile.CompanyWebsite, companyProfilePoco.CompanyWebsite);
            Assert.AreEqual(_companyProfile.ContactName, companyProfilePoco.ContactName);
            Assert.AreEqual(_companyProfile.ContactPhone, companyProfilePoco.ContactPhone);
            Assert.AreEqual(_companyProfile.RegistrationDate, companyProfilePoco.RegistrationDate);
            Assert.AreEqual(_companyProfile.Id, companyProfilePoco.Id);
        }

        private void SystemLanguageCodeAdd()
        {
            SystemLanguageCodeRepository systemLanguageCodeRepo = new SystemLanguageCodeRepository();
            systemLanguageCodeRepo.Add(new SystemLanguageCodePoco[] { _systemLangCode });
        }

        private void SystemCountryCodeAdd()
        {
            SystemCountryCodeRepository systemCountryCodeRepository = new SystemCountryCodeRepository();
            systemCountryCodeRepository.Add(new SystemCountryCodePoco[] { _systemCountry });
        }

        #endregion AddImplementation


        #region CheckImplementation
        private void ApplicantWorkHistoryCheck()
        {
            ApplicantWorkHistoryRepository applicantWorkHistoryRepository = new ApplicantWorkHistoryRepository();
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = applicantWorkHistoryRepository.GetSingle(t => t.Id == _appliantWorkHistory.Id);
            Assert.IsNotNull(applicantWorkHistoryPoco);
            Assert.AreEqual(_appliantWorkHistory.Id, applicantWorkHistoryPoco.Id);
            Assert.AreEqual(_appliantWorkHistory.Applicant, applicantWorkHistoryPoco.Applicant);
            Assert.AreEqual(_appliantWorkHistory.CompanyName, applicantWorkHistoryPoco.CompanyName);
            Assert.AreEqual(_appliantWorkHistory.CountryCode, applicantWorkHistoryPoco.CountryCode);
            Assert.AreEqual(_appliantWorkHistory.Location, applicantWorkHistoryPoco.Location);
            Assert.AreEqual(_appliantWorkHistory.JobTitle, applicantWorkHistoryPoco.JobTitle);
            Assert.AreEqual(_appliantWorkHistory.JobDescription, applicantWorkHistoryPoco.JobDescription);
            Assert.AreEqual(_appliantWorkHistory.StartMonth, applicantWorkHistoryPoco.StartMonth);
            Assert.AreEqual(_appliantWorkHistory.StartYear, applicantWorkHistoryPoco.StartYear);
            Assert.AreEqual(_appliantWorkHistory.EndMonth, applicantWorkHistoryPoco.EndMonth);
            Assert.AreEqual(_appliantWorkHistory.EndYear, applicantWorkHistoryPoco.EndYear);
        }

        public void SystemCountryCodeCheck()
        {
            SystemCountryCodeRepository systemCountryCodeRepository = new SystemCountryCodeRepository();
            SystemCountryCodePoco systemCountryCodePoco = systemCountryCodeRepository.GetSingle(t => t.Code == _systemCountry.Code);
            Assert.IsNotNull(systemCountryCodePoco);
            Assert.AreEqual(_systemCountry.Code, systemCountryCodePoco.Code);
            Assert.AreEqual(_systemCountry.Name, systemCountryCodePoco.Name);
        }

        private void SystemLanguageCodeCheck()
        {
            SystemLanguageCodeRepository systemLanguageCodeRepo = new SystemLanguageCodeRepository();
            SystemLanguageCodePoco systemLanguageCodePoco = systemLanguageCodeRepo.GetSingle(t => t.LanguageID == _systemLangCode.LanguageID);
            Assert.IsNotNull(systemLanguageCodePoco);
            Assert.AreEqual(systemLanguageCodePoco.LanguageID, _systemLangCode.LanguageID);
            Assert.AreEqual(systemLanguageCodePoco.NativeName, _systemLangCode.NativeName);
            Assert.AreEqual(systemLanguageCodePoco.Name, _systemLangCode.Name);
        }


        #endregion CheckImplementation

        private string Truncate(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.Length <= maxLength ? str : str.Substring(0, maxLength);
        }
    }

}