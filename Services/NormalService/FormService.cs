using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.Interface;

// Made by Christian

namespace CTTSite.Services.NormalService
{
    public class FormService : IFormService
    {
        public List<Form> GetForms(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveFormUserDAO(string user,Form form)
        {
            throw new NotImplementedException();
        }

        #region Activity Diary
       
        public FormActivityDiary GetFormActivityDiary(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFormActivityDiary(FormActivityDiary form)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormActivityDiary(FormActivityDiary form)
        {
            throw new NotImplementedException();
        }

        public FormActivityDiary DeleteFormActivityDiary(int id)
        {
            throw new NotImplementedException();
        }

        public void SubmitFormActivityDiary(FormActivityDiary form)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Activity List
        public FormActivityList GetFormActivityList(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFormActivityList(FormActivityList form)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormActivityList(FormActivityList form)
        {
            throw new NotImplementedException();
        }

        public FormActivityList DeleteFormActivityList(int id)
        {
            throw new NotImplementedException();
        }

        public void SubmitFormActivityList(FormActivityList form)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Activity Schedule
        public FormActivitySchedule GetFormActivitySchedule(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFormActivitySchedule(FormActivitySchedule form)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormActivitySchedule(FormActivitySchedule form)
        {
            throw new NotImplementedException();
        }

        public FormActivitySchedule DeleteFormActivitySchedule(int id)
        {
            throw new NotImplementedException();
        }

        public void SubmitFormActivitySchedule(FormActivitySchedule form)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Hot Cross Bun
        public FormHotCrossBun FormHotCrossBun(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFormHotCrossBun(FormHotCrossBun form)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormHotCrossBun(FormHotCrossBun form)
        {
            throw new NotImplementedException();
        }

        public FormHotCrossBun DeleteFormHotCrossBun(int id)
        {
            throw new NotImplementedException();
        }

        public void SubmitFormHotCrossBun(FormHotCrossBun form)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Sleep Diary
        public FormSleepDiary GetFormSleepDiary(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFormSleepDiary(FormSleepDiary form)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormSleepDiary(FormSleepDiary form)
        {
            throw new NotImplementedException();
        }

        public FormSleepDiary DeleteFormSleepDiary(int id)
        {
            throw new NotImplementedException();
        }

        public void SubmitFormSleepDiary(FormSleepDiary form)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
