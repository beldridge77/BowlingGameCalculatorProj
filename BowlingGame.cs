namespace BowlingGameCalculator
{
    internal class BowlingGame
    {        
        private int currentRoll = 0;
        public const int TotalFramesCount = 10;
        public const int StartingFramePinCount = 10;
        public List<Frame> Frames { get; } = new List<Frame>(10);
       
        public int ScoreGame()
        {           
            int score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                Frame currentFrame = new Frame();
                
                currentFrame.RollOne = RandomRollPinCount(StartingFramePinCount + 1);
                currentFrame.PinsDownCount = currentFrame.RollOne;                                

                if (currentFrame.PinsDownCount ==  10)
                {
                    currentFrame.IsStrike = true;
                    currentFrame.IsFrameComplete = true;
                }
                else 
                {                    
                    currentFrame.RollTwo = RandomRollPinCount(StartingFramePinCount - currentFrame.RollOne + 1);                    
                    currentFrame.PinsDownCount += currentFrame.RollTwo;                                        
                }

                if(currentFrame.PinsDownCount == 10 && !currentFrame.IsStrike)
                {
                    currentFrame.IsSpare = true;
                    currentFrame.FrameTotalScore = currentFrame.PinsDownCount;
                    currentFrame.IsFrameComplete = true;
                }
                
                if(Frames.Count == 9)
                {
                    currentFrame.IsFinalFrame = true;
                }

                if(Frames.Count == 9 && currentFrame.IsStrike)
                {
                    currentFrame.RollTwo = RandomRollPinCount(StartingFramePinCount - currentFrame.RollOne + 1);
                }

                if(Frames.Count == 9 && currentFrame.IsStrike && currentFrame.RollTwo == 10)
                {
                    currentFrame.RollThree = RandomRollPinCount(StartingFramePinCount - (currentFrame.RollOne + currentFrame.RollTwo + 1));
                }

                Frames.Add(currentFrame);                                
            }

            int frameCount = 0;
            foreach (var frame in Frames) 
            {                
                if (!frame.IsStrike && !frame.IsSpare)
                {
                    score += (frame.RollOne + frame.RollTwo + frame.RollThree);
                }
                

                if(frame.IsSpare)
                {
                    score += (frame.RollOne + frame.RollTwo);                    
                }
                

                if(frame.IsStrike)
                {
                    if (Frames[frameCount+1].IsStrike)
                    {
                        score += (frame.RollOne + Frames[frameCount +1].RollOne + Frames[frameCount + 1].RollTwo);                        
                    }                
                    else
                    {
                        score += (frame.RollOne + frame.RollTwo);                        
                    }                    
                }

                frameCount++;
            }

            return score;
        }

        public static int RandomRollPinCount(int topOfRange)
        {
            Random rnd = new Random();
            int randomPinCount = rnd.Next(0, topOfRange);

            return randomPinCount;
        }
    }
}
