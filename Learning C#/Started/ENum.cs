using System;

namespace Enumsuption
{
    class Enumsuption
    {
        public enum RocketStage
        {
            PreLaunch,
            Liftoff,
            StageSeparation,
            OrbitInsertion,
            Reentry,
            Landing
        }


        public class Rocket
        {

            public RocketStage stages = RocketStage.PreLaunch;
            public void AdvanceStages()
            {
                switch (stages)
                {
                    case RocketStage.PreLaunch:
                        Console.WriteLine("Preparing for launch.");
                        stages = RocketStage.Liftoff;
                        break;
                    case RocketStage.Liftoff:
                        Console.WriteLine("Liftoff! Rocket is ascending.");
                        stages = RocketStage.StageSeparation;
                        break;
                    case RocketStage.StageSeparation:
                        Console.WriteLine("Stage separation successful.");
                        stages = RocketStage.OrbitInsertion;
                        break;
                    case RocketStage.OrbitInsertion:
                        Console.WriteLine("Rocket has reached orbit.");
                        stages = RocketStage.Reentry;
                        break;
                    case RocketStage.Reentry:
                        Console.Write("Reentering Earth's atmosphere.");
                        stages = RocketStage.Landing;
                        break;
                    case RocketStage.Landing:
                        Console.WriteLine("Rocket has landed successfully.");
                        break;
                }
            }

            public bool isCompleted()
            {
                return stages == RocketStage.Landing;
            }
        }


        public class Launch
        {

            // Rocket SpaceX = new Rocket();
            public static void Run()
            {
                Rocket SpaceX = new Rocket();

                while (!SpaceX.isCompleted())
                {
                    SpaceX.AdvanceStages();
                }
            }
        }

    }
}