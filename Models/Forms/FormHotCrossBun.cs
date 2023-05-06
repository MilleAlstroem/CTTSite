namespace CTTSite.Models.Forms
{
    // Made by Christian
    public class FormHotCrossBun : Form
    {
        
        public string Trigger { get; set; } 
        public string Thoughts { get; set; }
        public string Emotions { get; set; }
        public string Behaviours { get; set; }
        public string Physical { get; set; }
        
        public FormHotCrossBun()
        {
        }
        
        public FormHotCrossBun(string trigger, string thoughts, string emotions, string behaviours, string physical)
        {
            Trigger = trigger;
            Thoughts = thoughts;
            Emotions = emotions;
            Behaviours = behaviours;
            Physical = physical;
        }

        public override string ToString()
        {
            return $"Trigger: {Trigger}\nThoughts: {Thoughts}\nEmotions: {Emotions}\nBehaviours: {Behaviours}\nPhysical: {Physical}";
        }
    }
}
