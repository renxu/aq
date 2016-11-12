using System;
using System.Collections.Generic;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class ActivitySelectionTests
    {
        [TestMethod]
        public void ActivitySelection_CommonCase()
        {
            var activities = new List<ActivitySelection.Activity>();
            activities.Add(new ActivitySelection.Activity(1, 2));
            activities.Add(new ActivitySelection.Activity(3, 4));
            activities.Add(new ActivitySelection.Activity(0, 6));
            activities.Add(new ActivitySelection.Activity(5, 7));
            activities.Add(new ActivitySelection.Activity(8, 9));
            activities.Add(new ActivitySelection.Activity(5, 9));
            var results = ActivitySelection.SelectActivities(activities);
            Console.WriteLine("Examine the results manually.");
        }
    }
}
