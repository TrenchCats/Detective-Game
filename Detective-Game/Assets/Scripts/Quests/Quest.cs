using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MitchDroo.DetectiveGame.Quests
{
    public class Quest
    {
        private string _title;
        private QuestType _type;
        private QuestStatus _status = QuestStatus.NotStarted;
        private NestedQuestType _nestedQuestType = NestedQuestType.Sequential;
        private List<Quest> _childQuests = new List<Quest>();

        public event Action<QuestStatus> OnStatusChange;

        public Quest(string title, QuestType type)
        {
            _title = title;
            _type = type;
        }

        public void Start()
        {
            SetStatus(QuestStatus.InProgress);
            ResetTimer();

            if (_type == QuestType.Nested)
            {
                if (_nestedQuestType == NestedQuestType.Sequential)
                {
                    _childQuests[0].Start();
                }
                else if (_nestedQuestType == NestedQuestType.Parallel)
                {
                    foreach (Quest quest in _childQuests)
                    {
                        quest.Start();
                    }
                }
            }
        }

        private void SetStatus(QuestStatus status)
        {
            _status = status;
            OnStatusChange?.Invoke(status);
        }

        private void ResetTimer()
        {
            
        }

        public void SetNestedQuestType(NestedQuestType nestedQuestType)
        {
            _nestedQuestType = nestedQuestType;
        }

        public void AddQuest(Quest quest)
        {
            _childQuests.Add(quest);
        }

        public QuestStatus GetStatus()
        {
            return _status;
        }
    }
}