public class ResultTable : Table
{
    public QuestResult activeQuestResult;
    public float activeQuestResultChance;

    public void AssignQuest(Hero hero, QuestResult questResult)
    {
        questResult.setHero(hero);
        questResult.state = QuestResultState.Assigned;
    }
}