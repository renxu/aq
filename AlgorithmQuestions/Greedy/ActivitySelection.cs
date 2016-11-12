using System;
using System.Collections.Generic;

namespace AlgorithmQuestions
{
    public static class ActivitySelection
    {
        public class Activity
        {
            public Activity(int start, int end)
            {
                if (start < 0 || end < 0 || start >= end)
                {
                    throw new ArgumentException();
                }

                this.Start = start;
                this.End = end;
            }

            public int Start { get; private set; }

            public int End { get; private set; }
        }

        public static IList<Activity> SelectActivities(IList<Activity> activities)
        {
            if (activities == null)
            {
                throw new ArgumentNullException("activities");
            }

            var results = new List<Activity>();
            if (activities.Count <= 1)
            {
                results.AddRange(activities);
            }
            else
            {
                // Loop throught activities, 
                // add the activity to the chosen list when it has no overlapping with the already chosen list.
                foreach(var activity in activities)
                {
                    bool overlapped = false;
                    foreach(var result in results)
                    {
                        if(IsOverlapping(activity, result))
                        {
                            overlapped = true;
                            break;
                        }
                    }

                    if (!overlapped)
                    {
                        results.Add(activity);
                    }
                }
            }

            return results;
        }

        private static bool IsOverlapping(Activity activity1, Activity activity2)
        {
            return !IsNotOverlapping(activity1, activity2);
        }

        private static bool IsNotOverlapping(Activity activity1, Activity activity2)
        {
            return activity2.End <= activity1.Start || activity2.Start >= activity1.End;
        }
    }

    
}
