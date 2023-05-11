using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

// Made by Christian

namespace CTTSite.Services.NormalService
{


    public class FormService : IFormService
    {
        private DBServiceGeneric<FormActivityDiary> _activityDiaryService;
        private DBServiceGeneric<FormActivityList> _activityListService;
        private DBServiceGeneric<FormActivitySchedule> _activityScheduleService;
        private DBServiceGeneric<FormHotCrossBun> _hotCrossBunService;
        private DBServiceGeneric<FormSleepDiary> _sleepDiaryService;
        private IEmailService _emailService;

        private List<FormActivityDiary> _activityDiaries { get; set; }
        private List<FormActivityList> _activityLists { get; set; }
        private List<FormActivitySchedule> _activitySchedules { get; set; }
        private List<FormHotCrossBun> _hotCrossBuns { get; set; }
        private List<FormSleepDiary> _sleepDiaries { get; set; }



        public FormService(DBServiceGeneric<FormActivityDiary> activityDiaryService, DBServiceGeneric<FormActivityList> activityListService, DBServiceGeneric<FormActivitySchedule> activityScheduleService, DBServiceGeneric<FormHotCrossBun> hotCrossBunService, DBServiceGeneric<FormSleepDiary> sleepDiaryService, IEmailService emailService)
        {
            _activityDiaryService = activityDiaryService;
            _activityListService = activityListService;
            _activityScheduleService = activityScheduleService;
            _hotCrossBunService = hotCrossBunService;
            _sleepDiaryService = sleepDiaryService;
            _emailService = emailService;

            _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();
            _activityLists = _activityListService.GetObjectsAsync().Result.ToList();
            _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();
            _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();
            _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();

        }


        #region Activity Diary

        public FormActivityDiary GetFormActivityDiaryById(int id)
        {
            _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();
            FormActivityDiary form;

            foreach (FormActivityDiary formActivityDiary in _activityDiaries)
            {
                if (formActivityDiary.ID == id)
                {
                    form = formActivityDiary;
                    return form;
                }
            }
            return null;
        }

        public FormActivityDiary GetFormActivityDiaryByUserEmail(string email)
        {
            _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();
            FormActivityDiary form;

            foreach (FormActivityDiary formActivityDiary in _activityDiaries)
            {
                if (formActivityDiary.UserEmail == email)
                {
                    form = formActivityDiary;
                    return form;
                }
            }
            return null;
        }

        public async Task CreateFormActivityDiary(FormActivityDiary form)
        {
            _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();
            _activityDiaries.Add(form);
            await _activityDiaryService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivityDiary(FormActivityDiary formN)
        {
            if (formN != null)
            {
                FormActivityDiary formO = GetFormActivityDiaryByUserEmail(formN.UserEmail);
                if (formO != null)
                {

                    formN.ID = formO.ID;
                    formN.UserEmail = formO.UserEmail;

                    formO = formN;

                    await _activityDiaryService.UpdateObjectAsync(formO);
                    _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();

                }

            }

        }

        public async Task DeleteFormActivityDiary(FormActivityDiary form)
        {

            if (form != null)
            {

                await _activityDiaryService.DeleteObjectAsync(form);
                _activityDiaries = _activityDiaryService.GetObjectsAsync().Result.ToList();
            }

        }

        public async Task SubmitFormActivityDiary(FormActivityDiary form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Activity Diary: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity Diary: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivityDiary(form);
        }
        #endregion

        #region Activity List

        
        public FormActivityList GetFormActivityListById(int id)
        {
            _activityLists = _activityListService.GetObjectsAsync().Result.ToList();
            FormActivityList form;

            foreach (FormActivityList formActivityList in _activityLists)
            {
                if (formActivityList.ID == id)
                {
                    form = formActivityList;
                    return form;
                }
            }
            return null;
        }

        public FormActivityList GetFormActivityListByUserEmail(string email)
        {
            _activityLists = _activityListService.GetObjectsAsync().Result.ToList();
            FormActivityList form;

            foreach (FormActivityList formActivityList in _activityLists)
            {
                if (formActivityList.UserEmail == email)
                {
                    form = formActivityList;
                    return form;
                }
            }
            return null;
        }

        public async Task CreateFormActivityList(FormActivityList form)
        {
            _activityLists = _activityListService.GetObjectsAsync().Result.ToList();
            _activityLists.Add(form);
            await _activityListService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivityList(FormActivityList formN)
        {
            if (formN != null)
            {
                FormActivityList formO = GetFormActivityListByUserEmail(formN.UserEmail);
                if (formO != null)
                {

                    formN.ID = formO.ID;
                    formN.UserEmail = formO.UserEmail;

                    formO = formN;

                    await _activityListService.UpdateObjectAsync(formO);
                    _activityLists = _activityListService.GetObjectsAsync().Result.ToList();

                }

            }

        }

        public async Task DeleteFormActivityList(FormActivityList form)
        {

            if (form != null)
            {

                await _activityListService.DeleteObjectAsync(form);
                _activityLists = _activityListService.GetObjectsAsync().Result.ToList();
            }

        }

        public async Task SubmitFormActivityList(FormActivityList form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Activity List: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity List: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivityList(form);
        }
        #endregion

        #region Activity Schedule
        public FormActivitySchedule GetFormActivityScheduleById(int id)
        {
            _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();
            FormActivitySchedule form;

            foreach (FormActivitySchedule formActivitySchedule in _activitySchedules)
            {
                if (formActivitySchedule.ID == id)
                {
                    form = formActivitySchedule;
                    return form;
                }
            }
            return null;
        }

        public FormActivitySchedule GetFormActivityScheduleByUserEmail(string email)
        {
            _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();
            FormActivitySchedule form;

            foreach (FormActivitySchedule formActivitySchedule in _activitySchedules)
            {
                if (formActivitySchedule.UserEmail == email)
                {
                    form = formActivitySchedule;
                    return form;
                }
            }
            return null;
        }

        public async Task CreateFormActivitySchedule(FormActivitySchedule form)
        {
            _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();
            _activitySchedules.Add(form);
            await _activityScheduleService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivitySchedule(FormActivitySchedule formN)
        {
            if (formN != null)
            {
                FormActivitySchedule formO = GetFormActivityScheduleByUserEmail(formN.UserEmail);
                if (formO != null)
                {

                    formN.ID = formO.ID;
                    formN.UserEmail = formO.UserEmail;

                    formO = formN;

                    await _activityScheduleService.UpdateObjectAsync(formO);
                    _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();

                }

            }

        }

        public async Task DeleteFormActivitySchedule(FormActivitySchedule form)
        {

            if (form != null)
            {

                await _activityScheduleService.DeleteObjectAsync(form);
                _activitySchedules = _activityScheduleService.GetObjectsAsync().Result.ToList();
            }

        }

        public async Task SubmitFormActivitySchedule(FormActivitySchedule form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Activity Schedule: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity Schedule: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivitySchedule(form);
        }
        #endregion

        #region Hot Cross Bun
        public FormHotCrossBun GetFormHotCrossBunById(int id)
        {
            _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();
            FormHotCrossBun form;

            foreach (FormHotCrossBun formHotCrossBun in _hotCrossBuns)
            {
                if (formHotCrossBun.ID == id)
                {
                    form = formHotCrossBun;
                    return form;
                }
            }
            return null;
        }

        public FormHotCrossBun GetFormHotCrossBunByUserEmail(string email)
        {
            _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();
            FormHotCrossBun form;

            foreach (FormHotCrossBun formHotCrossBun in _hotCrossBuns)
            {
                if (formHotCrossBun.UserEmail == email)
                {
                    form = formHotCrossBun;
                    return form;
                }
            }
            return null;
        }

        public async Task CreateFormHotCrossBun(FormHotCrossBun form)
        {
            _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();
            _hotCrossBuns.Add(form);
            await _hotCrossBunService.AddObjectAsync(form);
        }

        public async Task UpdateFormHotCrossBun(FormHotCrossBun formN)
        {
            if (formN != null)
            {
                FormHotCrossBun formO = GetFormHotCrossBunByUserEmail(formN.UserEmail);
                if (formO != null)
                {                  

                    formN.ID = formO.ID;
                    formN.UserEmail = formO.UserEmail;

                    formO = formN;
                    
                    await _hotCrossBunService.UpdateObjectAsync(formO);
                    _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();

                }              
                
            }

        }

        public async Task DeleteFormHotCrossBun(FormHotCrossBun form)
        {
            
            if (form != null)
            {
                
                await _hotCrossBunService.DeleteObjectAsync(form);
                _hotCrossBuns = _hotCrossBunService.GetObjectsAsync().Result.ToList();
            }
            
        }

        public async Task SubmitFormHotCrossBun(FormHotCrossBun form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Hot Cross Bun: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Hot Cross Bun: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormHotCrossBun(form);            
        }
        #endregion

        #region Sleep Diary
        public FormSleepDiary GetFormSleepDiaryById(int id)
        {
            _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();
            FormSleepDiary form;

            foreach (FormSleepDiary formSleepDiary in _sleepDiaries)
            {
                if (formSleepDiary.ID == id)
                {
                    form = formSleepDiary;
                    return form;
                }
            }
            return null;
        }

        public FormSleepDiary GetFormSleepDiaryByUserEmail(string email)
        {
            _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();
            FormSleepDiary form;

            foreach (FormSleepDiary formSleepDiary in _sleepDiaries)
            {
                if (formSleepDiary.UserEmail == email)
                {
                    form = formSleepDiary;
                    return form;
                }
            }
            return null;
        }

        public async Task CreateFormSleepDiary(FormSleepDiary form)
        {
            _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();
            _sleepDiaries.Add(form);
            await _sleepDiaryService.AddObjectAsync(form);
        }

        public async Task UpdateFormSleepDiary(FormSleepDiary formN)
        {
            if (formN != null)
            {
                FormSleepDiary formO = GetFormSleepDiaryByUserEmail(formN.UserEmail);
                if (formO != null)
                {

                    formN.ID = formO.ID;
                    formN.UserEmail = formO.UserEmail;

                    formO = formN;

                    await _sleepDiaryService.UpdateObjectAsync(formO);
                    _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();

                }

            }

        }

        public async Task DeleteFormSleepDiary(FormSleepDiary form)
        {

            if (form != null)
            {

                await _sleepDiaryService.DeleteObjectAsync(form);
                _sleepDiaries = _sleepDiaryService.GetObjectsAsync().Result.ToList();
            }

        }

        public async Task SubmitFormSleepDiary(FormSleepDiary form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Sleep Diary: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Sleep Diary: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormSleepDiary(form);
        }
        #endregion
    }
}
