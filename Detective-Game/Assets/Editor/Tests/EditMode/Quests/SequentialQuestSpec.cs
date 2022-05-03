using MitchDroo.DetectiveGame.Quests;
using NUnit.Framework;

namespace MitchDroo.DetectiveGame.Tests.Quests
{
    [TestFixture]
    public class SequentialQuestSpec
    {
        [Test]
		public void StartQuest_QuestIsStarted()
        {
            Quest quest = new Quest("Parent Test", QuestType.Nested);
            quest.SetNestedQuestType(NestedQuestType.Sequential);
            Quest quest1 = new Quest("Test 1", QuestType.None);
            quest.AddQuest(quest1);
            Quest quest2 = new Quest("Test 2", QuestType.None);
            quest.AddQuest(quest2);
            Quest quest3 = new Quest("Test 3", QuestType.None);
            quest.AddQuest(quest3);

            quest.Start();

            Assert.AreEqual(QuestStatus.InProgress, quest.GetStatus(), "Parent Quest Was Not Started");
            Assert.AreEqual(QuestStatus.InProgress, quest1.GetStatus(), "Child Quest 1 Was Not Started");
            Assert.AreEqual(QuestStatus.NotStarted, quest2.GetStatus(), "Child Quest 2 Was Not Inactive");
            Assert.AreEqual(QuestStatus.NotStarted, quest3.GetStatus(), "Child Quest 3 Was Not Inactive");
        }
	}
}
