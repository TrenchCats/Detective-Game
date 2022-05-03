using MitchDroo.DetectiveGame.Quests;
using NUnit.Framework;

namespace MitchDroo.DetectiveGame.Tests.Quests
{
    // https://stackoverflow.com/questions/59312203/how-to-unit-test-c-sharp-events-with-xunit

    [TestFixture]
    public class ParallelQuestSpec
    {
        [Test]
        public void StartQuest_QuestIsStarted()
        {
            Quest quest = new Quest("Parent Test", QuestType.Nested);
            quest.SetNestedQuestType(NestedQuestType.Parallel);
            Quest quest1 = new Quest("Test 1", QuestType.None);
            quest.AddQuest(quest1);
            Quest quest2 = new Quest("Test 2", QuestType.None);
            quest.AddQuest(quest2);
            Quest quest3 = new Quest("Test 3", QuestType.None);
            quest.AddQuest(quest3);

            quest.Start();

            Assert.AreEqual(QuestStatus.InProgress, quest.GetStatus(), "Parent Quest Was Not Started");
            Assert.AreEqual(QuestStatus.InProgress, quest1.GetStatus(), "Child Quest 1 Was Not Started");
            Assert.AreEqual(QuestStatus.InProgress, quest2.GetStatus(), "Child Quest 2 Was Not Started");
            Assert.AreEqual(QuestStatus.InProgress, quest3.GetStatus(), "Child Quest 3 Was Not Started");
        }
    }
}
