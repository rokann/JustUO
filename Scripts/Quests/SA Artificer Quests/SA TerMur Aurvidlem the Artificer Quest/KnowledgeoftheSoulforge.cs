using Server.Items;

namespace Server.Engines.Quests
{
    public class KnowledgeoftheSoulforge : BaseQuest
    {
        public KnowledgeoftheSoulforge()
        {
            AddObjective(new ObtainObjective(typeof (EnchantEssence), "Enchanted Essence", 50, 0x2DB2));

            AddReward(new BaseReward(typeof (ScrollBox), 1, "Knowledge"));
        }

        public override bool DoneOnce
        {
            get { return true; }
        }

        public override object Title
        {
            get { return "Knowledge of the Soulforge"; }
        }

        public override object Description
        {
            get { return 1112526; }
        }

        public override object Refuse
        {
            get { return 1112546; }
        }

        public override object Uncomplete
        {
            get { return 1112547; }
        }

        public override object Complete
        {
            get { return 1112527; }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            var version = reader.ReadInt();
        }
    }
}