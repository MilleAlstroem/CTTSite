﻿namespace CTTSite.Models.Forms
{
    public class FormActivityList
    {
        public int Id { get; set; }
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
