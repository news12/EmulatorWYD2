
namespace Application.Class.BotTelegram
{
    public static class BotConfig
    {
        public static int[] Admins = { 1999458712, 1541778479 };
        public enum MenuOptions : int
        {
            None,
            Donate,
            Item,
            MSG,
            Notice,
            UserName,
            DonateValue,
            AdminName,
            Log,
            Confirm,
            Cancel

        }

        public readonly static string BotToken = "2124888932:AAHgTKOhqYnjogVs3meZzVDQ8vafEslZ9qA";
    }
}
