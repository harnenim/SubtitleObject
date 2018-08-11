using System;
using System.Collections.Generic;
using Subtitle;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Smi smi = new Smi() { text = "가<font face='궁서체'>나<font color='#abcdef' face=\"돋움체\" fade=\"in\">다</font>라</font>마<b>바</b>사<br>아<u>자</u>차<b>카<u>타<i>파</i></u></b>하" };
            Ass ass;
            string text;
            SmiFile file;
            List<Attr> attrs;
            bool doThis = false;

            doThis = true;
            if (doThis)
            {
                Console.WriteLine("샘플1");
                Console.WriteLine(smi);
                Console.WriteLine();

                Console.WriteLine("SMI -> 자체 형식");
                attrs = smi.ToAttr();
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> ASS (fade 손실)");
                ass = new Ass().FromAttr(attrs);
                Console.WriteLine(ass.text);
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> SMI");
                smi = new Smi().FromAttr(attrs);
                Console.WriteLine(smi.text);
                Console.WriteLine();

                Console.WriteLine("ASS -> 자체 형식");
                attrs = ass.ToAttr();
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> SMI");
                smi = new Smi().FromAttr(attrs);
                Console.WriteLine(smi.text);
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> ASS");
                ass = new Ass().FromAttr(attrs);
                Console.WriteLine(ass.text);
                Console.WriteLine();

                Console.WriteLine();
            }

            doThis = false;
            if (doThis)
            {
                Console.WriteLine("샘플2");
                text = "<Sync Start=1000><P Class=KRCC>\n"
                    + "asdf\n"
                    + "<Sync Start=1250><P Class=KRCC >\n"
                    + "가<font color='#abcdef'>나</font>다<font color='#9abcde' fade='in'>라</font>마<font color='#89abcd' fade='out'>바</font>사\n"
                    + "<Sync Start=1500><P Class=KRCC >\n"
                    + "가<font color='#abcdef'>나</font>다<font color='#9abcde'>라</font>마<font color='#000000'>바</font>사\n"
                    ;
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine("가공");
                file = new SmiFile().FromTxt(text);
                Smi.Normalize(file.body);
                text = Smi.Smi2txt(file.body);
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine();
            }

            doThis = false;
            if (doThis)
            {
                Console.WriteLine("샘플3");
                text = "<Sync Start=61379><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">I</font><font color=\"#997722\">n the dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In</font> <font color=\"#997722\">the dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=61687><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In t</font><font color=\"#997722\">he dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In th</font><font color=\"#997722\">e dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the</font> <font color=\"#997722\">dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=61957><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In the d</font><font color=\"#997722\">reaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the dr</font><font color=\"#997722\">eaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the dre</font><font color=\"#997722\">aming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the drea</font><font color=\"#997722\">ming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=62595><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In the dream</font><font color=\"#997722\">ing 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the dreami</font><font color=\"#997722\">ng 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the dreamin</font><font color=\"#997722\">g 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<font color=\"#cccc88\">In the dreaming</font> <font color=\"#997722\">誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=63710><P Class=KRCC>\n"
                    ;
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine("가공");
                file = new SmiFile().FromTxt(text);
                Smi.FillEmptySync(file.body);
                text = Smi.Smi2txt(file.body);
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine();
            }

            doThis = false;
            if (doThis)
            {
                Console.WriteLine("샘플4");
                smi.text = "테스트<font typing='TypeWriter'>테스트</font>테스트";
                Console.WriteLine(smi.text);
                Console.WriteLine();

                Console.WriteLine("SMI -> 자체 형식");
                attrs = smi.ToAttr();
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> ASS");
                ass = new Ass().FromAttr(attrs);
                Console.WriteLine(ass.text);
                Console.WriteLine();

                Console.WriteLine("자체 형식 -> SMI");
                smi = new Smi().FromAttr(attrs);
                Console.WriteLine(smi.text);
                Console.WriteLine();
            }

            doThis = false;
            if (doThis)
            {
                Console.WriteLine("샘플5");
                text = "<Sync Start=1000><P Class=KRCC>\n"
                    + "테스트　　　테스트\n"
                    + "<Sync Start=2000><P Class=KRCC>\n"
                    + "테스트<font typing='typewriter'>텍스트</font>테스트\n"
                    + "<Sync Start=3000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard'>텍스트</font>테스트\n"
                    + "<Sync Start=4000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard'>테스트</font>테스트\n"
                    + "<Sync Start=5000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard(0,1)'>테스트</font>테스트\n"
                    + "<Sync Start=6000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard(1,1)'>테스트</font>테스트\n"
                    + "<Sync Start=7000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard'>테test</font>테스트\n"
                    + "<Sync Start=8000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard invisible'>테test</font>테스트\n"
                    + "<Sync Start=9000><P Class=KRCC>\n"
                    + "테스트<font typing='keyboard hangeul'>테test</font><br>테스트\n"
                    + "<Sync Start=10000><P Class=KRCC>\n"
                    + "테스트테스트<font typing='keyboard'>테스트</font>\n"
                    + "<Sync Start=11000><P Class=KRCC>\n"
                    + "테스트테스트테스트\n"
                    ;
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine("가공");
                file = new SmiFile().FromTxt(text);
                Smi.Normalize(file.body);
                text = Smi.Smi2txt(file.body);
                Console.WriteLine(text);
                Console.WriteLine();
            }

            doThis = false;
            if (doThis)
            {
                string input = "실홰롻튄즤륢 ㅁㄴㅇㄻㄴ";
                Console.WriteLine("입력값");
                Console.WriteLine(input);
                Console.WriteLine();

                Console.WriteLine("타자기");
                char[] type = Typing.ToType(input, Typing.Mode.typewriter);
                Typing typing = new Typing(Typing.Mode.typewriter, Typing.Cursor.invisible);
                foreach (char c in type)
                {
                    typing.Type(c);
                    Console.WriteLine(typing.Out());
                }

                Console.WriteLine();

                Console.WriteLine("키보드");
                type = Typing.ToType(input, Typing.Mode.keyboard);
                typing = new Typing(Typing.Mode.keyboard, Typing.Cursor.invisible);
                foreach (char c in type)
                {
                    typing.Type(c);
                    Console.WriteLine(typing.Out());
                }
            }

            doThis = false;
            if (doThis)
            {
                Console.WriteLine("샘플 몇이냐");
                text = "<Sync Start=1379><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">I</font><font color=\"#997722\">n the dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=61533><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In</font> <font color=\"#997722\">the dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=1687><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In t</font><font color=\"#997722\">he dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=61777><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In th</font><font color=\"#997722\">e dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=61867><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the</font> <font color=\"#997722\">dreaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=1957><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In the d</font><font color=\"#997722\">reaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=62116><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the dr</font><font color=\"#997722\">eaming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=62276><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the dre</font><font color=\"#997722\">aming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=62435><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the drea</font><font color=\"#997722\">ming 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=2595><P Class=KRCC>\n"
                    + "<font color=\"#cccc88\">In the dream</font><font color=\"#997722\">ing 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=62873><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the dreami</font><font color=\"#997722\">ng 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=63152><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the dreamin</font><font color=\"#997722\">g 誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=63431><P Class=KRCC	>\n"
                    + "<font color=\"#cccc88\">In the dreaming</font> <font color=\"#997722\">誰かのために</font><br>In the dreaming 누군가를 위해서\n"
                    + "<Sync Start=3710><P Class=KRCC>asdf\n";
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine("중간싱크 조절 가공");
                file = new SmiFile().FromTxt(text);
                Smi.Normalize(file.body);
                text = Smi.Smi2txt(file.body);
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine();
            }


            doThis = false;
            if (doThis)
            {
                text = "<Sync Start=1293110><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">나란히 날아가는 한 쌍의 새</font></i>"
                    + "<Sync Start=1299594><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">손을 맞잡은</font></i>"
                    + "<Sync Start=1302545><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">부모·자식이 만드는 그림자</font></i>"
                    + "<Sync Start=1305823><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">저녁 해가 비춘 아름다운 것</font></i>"
                    + "<Sync Start=1312310><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">그런 “평범”한 게 눈부셨어</font></i>"
                    + "<Sync Start=1318632><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">푸른색 벤치가 허전해서</font></i>"
                    + "<Sync Start=1323976><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">나 혼자 외톨이 로 느껴졌어</font></i>"
                    + "<Sync Start=1331612><P Class=KRCC>"
                    + "&nbsp;"
                    + "<Sync Start=1333917><P Class=KRCC>"
                    + "<i><font color=\"#ccbbdd\">평범한 게 좋아서</font></i>";

                doThis = false;
                if (doThis)
                {
                    text = "<Sync Start=65483><P Class=KRCC >\n"
                        + "카나???\n"
                        + "<Sync Start=66293><P Class=KRCC >\n"
                        + "&nbsp;\n"
                        + "<Sync Start=68324><P Class=KRCC>\n"
                        + "하루코 ???\n"
                        + "<Sync Start=69054><P Class=KRCC >\n"
                        + "&nbsp;\n"
                        + "<Sync Start=72223><P Class=KRCC >\n"
                        + "슈퍼바이저\n"
                        + "<Sync Start=73504><P Class=KRCC >\n"
                        + "&nbsp;\n"
                        + "<Sync Start=169787><P Class=KRCC >\n"
                        + "히도미 미나세 이노리\n"
                        + "<Sync Start=170883><P Class=KRCC >\n"
                        + "&nbsp;\n"
                        + "<Sync Start=172325><P Class=KRCC >\n"
                        + "진유\n"
                        + "사와시로 미유키\n"
                        + "<Sync Start=173349><P Class=KRCC >\n"
                        + "&nbsp;\n"
                        + "<Sync Start=175555><P Class=KRCC >\n"
                        + "라하루\n"
                        + "하야시바라 메구미\n"
                        + "<Sync Start=176463><P Class=KRCC >\n"
                        + "슈퍼바이저 캐릭터 원안 주제가\n"
                        + "<Sync Start=177671><P Class=KRCC >\n"
                        + "&nbsp;";
                }

                file = new SmiFile().FromTxt(text);
                List<Ass> assBody = new AssFile().FromSync(file.ToSync()).body;
                foreach (Ass line in assBody)
                {
                    Console.WriteLine(line.ToTxt());
                }
            }

            System.Threading.Thread.Sleep(int.MaxValue);
        }
    }
}
