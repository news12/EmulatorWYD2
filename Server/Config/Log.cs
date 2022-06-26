using NLog;

namespace Application.Config
{
    public class Log
    {
        //logs
        public static Logger? LogApp { get; set; }
        public static Logger? LogUser { get; set; }
        public static Logger? LogDb { get; set; }
        public static Logger? LogPacket { get; set; }
        // Atributos
        private static readonly string Lock = "";


        // Métodos
        public static void Write(object o, ConsoleColor c)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{Cfg.Time:dd/MM/yyyy HH:mm:ss.fffff}]: ");

                Console.ForegroundColor = c;
                Console.WriteLine($"{o}");

                Console.ResetColor();
            }
        }


        public static void Normal(object o) => Write(o, ConsoleColor.White);
        public static void Information(object o) => Write(o, ConsoleColor.Cyan);
        public static void Error(object o) => Write(o, ConsoleColor.Red);
        public static void Service(object o) => Write(o, ConsoleColor.Green);

        public static void Line() => Console.WriteLine();

        public static void Conn(Guid c, bool i) => Write($"Client Socket id {c} {(i ? "" : "des")}connected", ConsoleColor.Yellow);


    }
}
