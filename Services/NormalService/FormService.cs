using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

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
            FormActivityDiary form;

            foreach (FormActivityDiary formActivityDiary in _activityDiaries) 
            {
                if(formActivityDiary.ID == id)
                {
                    form = formActivityDiary;
                    return form;
                }
            }
            return null;
        }

        public FormActivityDiary GetFormActivityDiaryByUserEmail(string email)
        {
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
            _activityDiaries.Add(form);           
            await _activityDiaryService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivityDiary(FormActivityDiary formN)
        {
            if(formN != null)
            {
                FormActivityDiary formO = GetFormActivityDiaryById(formN.ID);
                if(formO != null)
                {
                    formO = formN;
                    await _activityDiaryService.UpdateObjectAsync(formO);
                }
            }
           
        }

        public async Task<FormActivityDiary> DeleteFormActivityDiary(int id)
        {
            FormActivityDiary form = GetFormActivityDiaryById(id);
            if(form != null)
            {
                _activityDiaries.Remove(form);
                await _activityDiaryService.DeleteObjectAsync(form);
                return form;
            }
            return null;
        }

        public async Task SubmitFormActivityDiary(FormActivityDiary form, string email)
        {           
            _emailService.SendEmail(new Email(form.ToString(), "Activity Diary: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity Diary: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivityDiary(form.ID);
            _activityDiaries.Remove(form);

        }
        #endregion

        #region Activity List
        public FormActivityList GetFormActivityListById(int id)
        {
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
            _activityLists.Add(form);
            await _activityListService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivityList(FormActivityList formN)
        {
            if (formN != null)
            {
                FormActivityList formO = GetFormActivityListById(formN.ID);
                if (formO != null)
                {
                    formO = formN;
                    await _activityListService.UpdateObjectAsync(formO);
                }
            }

        }

        public async Task<FormActivityList> DeleteFormActivityList(int id)
        {
            FormActivityList form = GetFormActivityListById(id);
            if (form != null)
            {
                _activityLists.Remove(form);
                await _activityListService.DeleteObjectAsync(form);
                return form;
            }
            return null;
        }

        public async Task SubmitFormActivityList(FormActivityList form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Activity List: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity List: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivityList(form.ID);
            _activityLists.Remove(form);

        }
        #endregion

        #region Activity Schedule
        public FormActivitySchedule GetFormActivityScheduleById(int id)
        {
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
            _activitySchedules.Add(form);
            await _activityScheduleService.AddObjectAsync(form);
        }

        public async Task UpdateFormActivitySchedule(FormActivitySchedule formN)
        {
            if (formN != null)
            {
                FormActivitySchedule formO = GetFormActivityScheduleById(formN.ID);
                if (formO != null)
                {
                    formO = formN;
                    await _activityScheduleService.UpdateObjectAsync(formO);
                }
            }

        }

        public async Task<FormActivitySchedule> DeleteFormActivitySchedule(int id)
        {
            FormActivitySchedule form = GetFormActivityScheduleById(id);
            if (form != null)
            {
                _activitySchedules.Remove(form);
                await _activityScheduleService.DeleteObjectAsync(form);
                return form;
            }
            return null;
        }

        public async Task SubmitFormActivitySchedule(FormActivitySchedule form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Activity Schedule: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Activity Schedule: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivitySchedule(form.ID);
            _activitySchedules.Remove(form);

        }
        #endregion

        #region Hot Cross Bun
        public FormHotCrossBun GetFormHotCrossBunById(int id)
        {
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
            _hotCrossBuns.Add(form);
            await _hotCrossBunService.AddObjectAsync(form);
        }

        public async Task UpdateFormHotCrossBun(FormHotCrossBun formN)
        {
            if (formN != null)
            {
                FormHotCrossBun formO = GetFormHotCrossBunById(formN.ID);
                if (formO != null)
                {
                    formO = formN;
                    await _hotCrossBunService.UpdateObjectAsync(formO);
                }
            }

        }

        public async Task<FormHotCrossBun> DeleteFormHotCrossBun(int id)
        {
            FormHotCrossBun form = GetFormHotCrossBunById(id);
            if (form != null)
            {
                _hotCrossBuns.Remove(form);
                await _hotCrossBunService.DeleteObjectAsync(form);
                return form;
            }
            return null;
        }

        public async Task SubmitFormHotCrossBun(FormHotCrossBun form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Hot Cross Bun: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Hot Cross Bun: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivitySchedule(form.ID);
            _hotCrossBuns.Remove(form);

        }
        #endregion

        #region Sleep Diary
        public FormSleepDiary GetFormSleepDiaryById(int id)
        {
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
            _sleepDiaries.Add(form);
            await _sleepDiaryService.AddObjectAsync(form);
        }

        public async Task UpdateFormSleepDiary(FormSleepDiary formN)
        {
            if (formN != null)
            {
                FormSleepDiary formO = GetFormSleepDiaryById(formN.ID);
                if (formO != null)
                {
                    formO = formN;
                    await _sleepDiaryService.UpdateObjectAsync(formO);
                }
            }

        }

        public async Task<FormSleepDiary> DeleteFormSleepDiary(int id)
        {
            FormSleepDiary form = GetFormSleepDiaryById(id);
            if (form != null)
            {
                _sleepDiaries.Remove(form);
                await _sleepDiaryService.DeleteObjectAsync(form);
                return form;
            }
            return null;
        }

        public async Task SubmitFormSleepDiary(FormSleepDiary form, string email)
        {
            _emailService.SendEmail(new Email(form.ToString(), "Sleep Diary: " + email, email));
            _emailService.SendEmail(new Email(form.ToString(), "Sleep Diary: " + email, "chilterntalkingtherapies@gmail.com"));
            await DeleteFormActivitySchedule(form.ID);
            _sleepDiaries.Remove(form);

        }
        #endregion
    }
}
