namespace CTTSite.Models.Forms
{
    // Made by Christian
    public class FormActivityList : Form
    {
        
        public string Pleasure { get; set; }
        public string Exercise { get; set; }
        public string Achievement { get; set; }
        public string Social { get; set; }

        public FormActivityList()
        {
        }

        public FormActivityList(string pleasure, string exercise, string achievement, string social)
        {           
            Pleasure = pleasure;
            Exercise = exercise;
            Achievement = achievement;
            Social = social;
        }

        public override string ToString()
        {
            return $"Pleasure: {Pleasure}\nExercise: {Exercise}\nAchievement: {Achievement}\nSocial: {Social}";
        }
    }
}
