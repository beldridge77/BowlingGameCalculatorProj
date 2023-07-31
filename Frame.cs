namespace BowlingGameCalculator
{
    public class Frame
    {        
        public int RollOne { get; set; } = 0;
        public int RollTwo { get; set; } = 0;
        public int RollThree { get; set; } = 0;    
        public int PinsDownCount { get; set; }
        public bool IsStrike { get; set; } = false;
        public bool IsSpare { get; set; } = false;
        public bool IsFinalFrame { get; set; } = false;
        public bool IsFrameComplete { get; set; } = false;
        public int FrameTotalScore { get; set; } = 0;
    }
}
