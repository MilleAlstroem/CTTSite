using CTTSite.Models;
using CTTSite.Models.Forms;

// Made by Christian

namespace CTTSite.Services.Interface
{
    public interface IFormService
    {
        List<Form> GetForms(string email);
        
       
        FormActivityDiary GetFormActivityDiary(int id);

        void CreateFormActivityDiary(FormActivityDiary form);

        void UpdateFormActivityDiary(FormActivityDiary form);

        FormActivityDiary DeleteFormActivityDiary(int id);
      
        void SubmitFormActivityDiary(FormActivityDiary form);


       
        FormActivityList GetFormActivityList(int id);

        void CreateFormActivityList(FormActivityList form);

        void UpdateFormActivityList(FormActivityList form);

        FormActivityList DeleteFormActivityList(int id);

        void SubmitFormActivityList(FormActivityList form);


        FormActivitySchedule GetFormActivitySchedule(int id);

        void CreateFormActivitySchedule(FormActivitySchedule form);

        void UpdateFormActivitySchedule(FormActivitySchedule form);

        FormActivitySchedule DeleteFormActivitySchedule(int id);

        void SubmitFormActivitySchedule(FormActivitySchedule form);


        FormHotCrossBun FormHotCrossBun(int id);

        void CreateFormHotCrossBun(FormHotCrossBun form);

        void UpdateFormHotCrossBun(FormHotCrossBun form);

        FormHotCrossBun DeleteFormHotCrossBun(int id);

        void SubmitFormHotCrossBun(FormHotCrossBun form);


        FormSleepDiary GetFormSleepDiary(int id);

        void CreateFormSleepDiary(FormSleepDiary form);

        void UpdateFormSleepDiary(FormSleepDiary form);

        FormSleepDiary DeleteFormSleepDiary(int id);

        void SubmitFormSleepDiary(FormSleepDiary form);


    }
}
