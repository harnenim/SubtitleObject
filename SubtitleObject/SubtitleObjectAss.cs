using System.Collections.Generic;

namespace Subtitle
{
    public class Ass : ISubtitleObject<Ass>
    {
        public static List<string> cols = new List<string>(new string[] { "Layer", "Start", "End", "Style", "Name", "MarginL", "MarginR", "MarginV", "Effect", "Text" });
        public int start;
        public int end;
        public string style;
        public string text;

        public static string Int2Time(int time)
        {
            int h = (time / 360000);
            int m = (time / 6000) % 60;
            int s = (time / 100) % 60;
            int ds = time % 100;
            return h + ":" + IntPadding(m) + ":" + IntPadding(s) + "." + IntPadding(ds);
        }
        public static string IntPadding(int value)
        {
            return (value < 10 ? "0" : "") + value;
        }
        public static int Time2Int(string time)
        {
            string[] vs = time.Split(':');
            return (int.Parse(vs[0]) * 360000) + (int.Parse(vs[1]) * 6000) + (int.Parse(vs[2].Replace(".", "")));
        }

        public string ToTxt()
        {
            return "Dialogue: 0," + Int2Time(start) + "," + Int2Time(end) + "," + style + ",,0,0,0,," + text;
        }
        public static string Ass2txt(List<Ass> asss)
        {
            string result = "";
            foreach (Ass ass in asss)
                result += ass.ToTxt() + "\r\n";
            return result;
        }

        public static string SColorFromAttr(string soColor)
        {
            return soColor.Length == 6 ? "&H" + soColor.Substring(4, 2) + soColor.Substring(2, 2) + soColor.Substring(0, 2) + "&" : "";
        }
        public string ColorToAttr(string soColor)
        {
            return "" + soColor.Substring(6, 2) + soColor.Substring(4, 2) + soColor.Substring(2, 2);
        }
        public string ColorFromAttr(string attrColor)
        {
            return SColorFromAttr(attrColor);
        }

        public List<Attr> ToAttr()
        {
            List<Attr> result = new List<Attr>();

            int index = 0;
            int pos = 0;
            Attr last = new Attr();
            result.Add(last);

            while ((pos = text.IndexOf('{', index)) >= 0)
            {
                last.text += text.Substring(index, pos - index).Replace("\\N", "\n");

                int endPos = text.IndexOf('}', pos);
                string attrString = text.Substring(pos + 1, endPos - pos - 1);

                int mode = -1;
                int tagStart = 0, tagEnd = 0;
                string tag = null;
                for (pos = 0; pos < attrString.Length; pos++)
                {
                    switch (mode)
                    {
                        case -1: // 태그 시작 전
                            while (pos < attrString.Length && attrString[pos] != '\\') pos++;
                            mode = 0;
                            tagStart = pos + 1;
                            pos--;
                            break;

                        case 0: // 태그
                            for (tagEnd = tagStart; tagEnd < attrString.Length; tagEnd++)
                            {
                                if (attrString[tagEnd] == '\\')
                                    break;
                                else if (attrString[tagEnd] == '(')
                                {
                                    mode++;
                                    pos = tagEnd + 1;
                                    break;
                                }
                            }
                            if (mode > 0) break;
                            if (tagStart == tagEnd) break;

                            tag = attrString.Substring(tagStart, tagEnd - tagStart);

                            if (tag.StartsWith("c") || tag.StartsWith("1c"))
                            {
                                if (last.text.Length > 0)
                                    result.Add((last = new Attr(last)));

                                if (tag.StartsWith("c"))
                                    tag = "1" + tag;
                                if (tag.Length >= 11 && tag[2] == '&' && tag[3] == 'H' && tag[10] == '&')
                                    last.fc = ColorToAttr(tag.Substring(2, 9));
                                else
                                    last.fc = "";
                            }
                            else if (tag.StartsWith("fn"))
                            {
                                if (last.text.Length > 0)
                                    result.Add((last = new Attr(last)));
                                last.fn = (tag.Length > 2) ? tag.Substring(2) : "";
                            }
                            else if (tag.StartsWith("b"))
                            {
                                if (last.text.Length > 0)
                                    result.Add((last = new Attr(last)));
                                last.b = (tag.Length >= 2 && tag[1] == '1');
                            }
                            else if (tag.StartsWith("u"))
                            {
                                if (last.text.Length > 0)
                                    result.Add((last = new Attr(last)));
                                last.u = (tag.Length >= 2 && tag[1] == '1');
                            }
                            else if (tag.StartsWith("i"))
                            {
                                if (last.text.Length > 0)
                                    result.Add((last = new Attr(last)));
                                last.i = (tag.Length >= 2 && tag[1] == '1');
                            }

                            mode = 0;
                            pos = tagEnd;
                            tagStart = tagEnd + 1;
                            break;

                        default: // 괄호
                            for (; pos < attrString.Length; pos++)
                            {
                                if (attrString[pos] == ')')
                                {
                                    mode--;
                                    break;
                                }
                            }
                            break;
                    }
                }

                index = endPos + 1;
            }
            last.text += text.Substring(index).Replace("\n", "\\n");

            return result;
        }
        public Ass FromAttr(List<Attr> attrs)
        {
            string text = "";
            List<string[]> lastAttrs = new List<string[]>();

            Attr last = new Attr();
            foreach (Attr attr in attrs)
            {
                if (!last.b && attr.b) text += "{\\b1}";
                else if (last.b && !attr.b) text += "{\\b}";

                if (!last.i && attr.i) text += "{\\i1}";
                else if (last.i && !attr.i) text += "{\\i}";

                if (!last.u && attr.u) text += "{\\u1}";
                else if (last.u && !attr.u) text += "{\\u}";

                if (!last.fn.Equals(attr.fn)) text += "{\\fn" + attr.fn + "}";

                if (!last.fc.Equals(attr.fc)) text += "{\\c" + ColorFromAttr(attr.fc) + "}";

                text += attr.text;
                last = attr;
            }

            this.text = text.Replace("}{", "").Replace("\n", "\\N");
            return this;
        }

        public SyncAttr ToSync()
        {
            return new SyncAttr()
            {
                start = start * 10,
                end = end * 10,
                startType = (style.StartsWith("［") ? SyncType.frame : SyncType.normal),
                endType = (style.EndsWith("］") ? SyncType.frame : SyncType.normal),
                text = ToAttr()
            };
        }
        public Ass FromSync(SyncAttr sync)
        {
            start = sync.start / 10;
            end = sync.end / 10;
            style = 
                ( (sync.startType == SyncType.normal && sync.endType == SyncType.normal)
                ? "Default"
                : ( (sync.startType == SyncType.frame ? "［" : "（")
                  + (sync.endType   == SyncType.frame ? "］" : "）")
                  )
                );
            FromAttr(sync.text);
            return this;
        }
    }
    public class AssFile : ISubtitleFile<Ass, AssFile>
    {
        public string header = "";
        public List<Ass> body = new List<Ass>();

        public string ToTxt()
        {
            string result = header.Replace("\n", "\r\n");

            foreach (Ass ass in body)
                result += ass.ToTxt() + "\r\n";

            return result;
        }
        public AssFile FromTxt(string txt)
        {
            header = "";
            body = new List<Ass>();

            string[] lines = txt.Replace("\r\n", "\n").Split('\n');

            foreach (string l in lines)
            {
                if (l.StartsWith("Format:"))
                {
                    string[] line = l.Trim().Split(',');
                    Ass.cols = new List<string>();
                    foreach (string v in line)
                    {
                        Ass.cols.Add(v.Trim());
                    }
                }
                else if (l.StartsWith("Dialogue:"))
                {
                    string[] line = l.Trim().Split(',');
                    /*
                    for (int i = 0; i < line.Length; i++)
                    {

                    }
                    */
                    Ass ass = new Ass
                    {
                        start = Ass.Time2Int(line[1]),
                        end = Ass.Time2Int(line[2]),
                        style = line[3],
                        text = line[9]
                    };
                    for (int i = 10; i < line.Length; i++)
                    {
                        ass.text += "," + line[i];
                    }
                    body.Add(ass);
                }
            }

            return this;
        }

        public List<SyncAttr> ToSync()
        {
            List<SyncAttr> result = new List<SyncAttr>();
            foreach (Ass ass in body)
            {
                result.Add(ass.ToSync());
            }
            return result;
        }
        public AssFile FromSync(List<SyncAttr> syncs)
        {
            List<Ass> asss = new List<Ass>();
            foreach (SyncAttr sync in syncs)
            {
                asss.Add(new Ass().FromSync(sync));
            }
            body = asss;
            return this;
        }
    }
}
