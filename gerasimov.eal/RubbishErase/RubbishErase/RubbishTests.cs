using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace fefu
{
    class Test
    {
        private struct testList
        {
            public bool eng;
            public bool rus;
            public bool dig;
            public string whiteList;
            public string blackList;
            public string input;
            public string output;
        }

        private static testList[] createTests()
        {
            testList[] tests = new testList[20];

            //string consists of rubbish
            tests[0].eng = false;
            tests[0].rus = false;
            tests[0].dig = false;
            tests[0].whiteList = "";
            tests[0].blackList = "";
            tests[0].input = "qwertyéöóêåí<>/.,?123";
            tests[0].output = "all characters were rubbish";

            //whitelist check, all characters are rubbish except char "/"
            tests[1].eng = false;
            tests[1].rus = false;
            tests[1].dig = false;
            tests[1].whiteList = "/";
            tests[1].blackList = "";
            tests[1].input = "qwertyéöóêåí<>/.,?123";
            tests[1].output = "/";

            //whitelist check for each type of symbols (eng, rus, dig)
            tests[2].eng = false;
            tests[2].rus = false;
            tests[2].dig = false;
            tests[2].whiteList = "q<1";
            tests[2].blackList = "";
            tests[2].input = "qwertyéöóêåí<>/.,?123";
            tests[2].output = "q<1";

            //each type is allowed
            tests[3].eng = true;
            tests[3].rus = true;
            tests[3].dig = true;
            tests[3].whiteList = "";
            tests[3].blackList = "";
            tests[3].input = "qwertyéöóêåí<>/.,?123";
            tests[3].output = "qwertyéöóêåí123";

            //blacklist check
            tests[4].eng = true;
            tests[4].rus = true;
            tests[4].dig = true;
            tests[4].whiteList = "";
            tests[4].blackList = "q";
            tests[4].input = "qwertyéöóêåí<>/.,?123";
            tests[4].output = "wertyéöóêåí123";

            //blacklist check for each type of symbols (eng, rus, dig)
            tests[5].eng = true;
            tests[5].rus = true;
            tests[5].dig = true;
            tests[5].whiteList = "";
            tests[5].blackList = "q1";
            tests[5].input = "qwertyéöóêåí<>/.,?123";
            tests[5].output = "wertyéöóêåí23";

            //blacklist whitelist collision test (blacklist is more significant ofc)
            tests[6].eng = true;
            tests[6].rus = true;
            tests[6].dig = true;
            tests[6].whiteList = "<>";
            tests[6].blackList = "q1>";
            tests[6].input = "qwertyéöóêåí<>/.,?123";
            tests[6].output = "wertyéöóêåí<23";

            tests[7].eng = false;
            tests[7].rus = true;
            tests[7].dig = true;
            tests[7].whiteList = "";
            tests[7].blackList = "";
            tests[7].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[7].output = "àÀáÁâÂ123";

            tests[8].eng = false;
            tests[8].rus = false;
            tests[8].dig = false;
            tests[8].whiteList = "abcdef!";
            tests[8].blackList = "";
            tests[8].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[8].output = "abc!";

            tests[9].eng = false;
            tests[9].rus = false;
            tests[9].dig = false;
            tests[9].whiteList = "BÁ,/";
            tests[9].blackList = "";
            tests[9].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[9].output = "BÁ,/";

            tests[10].eng = true;
            tests[10].rus = false;
            tests[10].dig = false;
            tests[10].whiteList = "BÁ,/";
            tests[10].blackList = "";
            tests[10].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[10].output = "aAbBcCÁ,/";

            tests[11].eng = false;
            tests[11].rus = true;
            tests[11].dig = false;
            tests[11].whiteList = "BÁ,/";
            tests[11].blackList = "";
            tests[11].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[11].output = "BàÀáÁâÂ,/";

            tests[12].eng = false;
            tests[12].rus = false;
            tests[12].dig = true;
            tests[12].whiteList = "BÁ,/";
            tests[12].blackList = "";
            tests[12].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[12].output = "BÁ123,/";

            tests[13].eng = true;
            tests[13].rus = true;
            tests[13].dig = true;
            tests[13].whiteList = "";
            tests[13].blackList = "";
            tests[13].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[13].output = "aAbBcCàÀáÁâÂ123";

            tests[14].eng = true;
            tests[14].rus = true;
            tests[14].dig = false;
            tests[14].whiteList = "2";
            tests[14].blackList = "";
            tests[14].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[14].output = "aAbBcCàÀáÁâÂ2";

            tests[15].eng = false;
            tests[15].rus = false;
            tests[15].dig = false;
            tests[15].whiteList = "1234567/<>";
            tests[15].blackList = "";
            tests[15].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[15].output = "123<>/";

            tests[16].eng = false;
            tests[16].rus = true;
            tests[16].dig = false;
            tests[16].whiteList = "";
            tests[16].blackList = "";
            tests[16].input = " a A b B c C à À á Á â Â 1 2 3 < > ? ! . , / ";
            tests[16].output = "à À á Á â Â";

            //spaces
            tests[17].eng = true;
            tests[17].rus = false;
            tests[17].dig = false;
            tests[17].whiteList = "?";
            tests[17].blackList = "";
            tests[17].input = "a     AbBcCà   ÀáÁ    âÂ123    <>?!.,/";
            tests[17].output = "a AbBcC ?";

            tests[18].eng = false;
            tests[18].rus = false;
            tests[18].dig = false;
            tests[18].whiteList = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[18].blackList = "";
            tests[18].input = "aAbBcCàÀáÁâÂ123<>?!.,/";
            tests[18].output = "aAbBcCàÀáÁâÂ123<>?!.,/";

            //another rubbish
            tests[19].eng = true;
            tests[19].rus = true;
            tests[19].dig = true;
            tests[19].whiteList = "<>?!";
            tests[19].blackList = "";
            tests[19].input = "";
            tests[19].output = "all characters were rubbish";

            return tests;
        }
        public static void runTest()
        {
            testList[] tests = createTests();
            int count = 0;
            foreach (var item in tests)
            {
                var result = test(item.eng, item.rus, item.dig, item.whiteList, item.blackList, item.input, item.output);
                Console.WriteLine($"Test {count++}: {result.Key}\nTime: {result.Value}ms \n");
            }
        }
        private static KeyValuePair<bool, long> test(bool eng, bool rus, bool dig, string whiteList, string blackList, string input, string output)
        {
            bool flag = false;
            Stopwatch stopwatch = new Stopwatch();
            fefu.RubbishEraser.MainClass f = new fefu.RubbishEraser.MainClass(eng, rus, dig, whiteList, blackList);
            stopwatch.Start();
            if (f.SB(input) + f.checkEmpty(input) == output) flag = true;
            stopwatch.Stop();
            var result = new KeyValuePair<bool, long>(flag, stopwatch.ElapsedMilliseconds);
            return result;
        }
    }
}