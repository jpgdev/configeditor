using System;
using ConfigEditor.Logging;

namespace ConfigEditor.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = new ConsoleLoggerFactory();


            JsonParser parser = new JsonParser(loggerFactory);

            string str = @"{
                                'a' : 123,
                                'B' : 'Hdsfsf',
                                'C' : {
                                    'C1' : 1
                                },
                                'D' : [ 1, 2, 3, 4, 5]
                            }";


            var r = parser.Parse(str);


            parser.ParseJObject(r);

            Console.ReadLine();

        }
    }
}
