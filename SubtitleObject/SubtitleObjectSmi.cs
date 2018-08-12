using System;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Subtitle
{
    public class Smi : ISubtitleObject<Smi>
    {
        public int start = 0;
        public SyncType syncType = SyncType.normal;
        public string text = "";

        public string ToTxt()
        {
            return "<Sync Start=" + start + "><P Class=KRCC" + (syncType == SyncType.inner ? "\t" : (syncType == SyncType.frame ? " " : "")) + ">\r\n" + text;
        }
        public static string Smi2txt(List<Smi> smis)
        {
            string result = "";
            foreach (Smi smi in smis)
                result += smi.ToTxt() + "\r\n";
            return result;
        }

        public static string SToAttrColor(string soColor)
        {
            switch (soColor)
            {
                case "red": return "FF0000";
                case "crimson": return "DC143C";
                case "firebrick": return "B22222";
                case "maroon": return "800000";
                case "darkred": return "8B0000";
                case "brown": return "A52A2A";
                case "sienna": return "A0522D";
                case "saddlebrown": return "8B4513";
                case "indianred": return "CD5C5C";
                case "rosybrown": return "BC8F8F";
                case "lightcoral": return "F08080";
                case "salmon": return "FA8072";
                case "darksalmon": return "E9967A";
                case "coral": return "FF7F50";
                case "tomato": return "FF6347";
                case "sandybrown": return "F4A460";
                case "lightsalmon": return "FFA07A";
                case "peru": return "CD853F";
                case "chocolate": return "D2691E";
                case "orangered": return "FF4500";
                case "orange": return "FFA500";
                case "darkorange": return "FF8C00";
                case "tan": return "D2B48C";
                case "peachpuff": return "FFDAB9";
                case "bisque": return "FFE4C4";
                case "moccasin": return "FFE4B5";
                case "navajowhite": return "FFDEAD";
                case "wheat": return "F5DEB3";
                case "burlywood": return "DEB887";
                case "darkgoldenrod": return "B8860B";
                case "goldenrod": return "DAA520";
                case "gold": return "FFD700";
                case "yellow": return "FFFF00";
                case "lightgoldenrodyellow": return "FAFAD2";
                case "palegoldenrod": return "EEE8AA";
                case "khaki": return "F0E68C";
                case "darkkhaki": return "BDB76B";
                case "lawngreen": return "7CFC00";
                case "greenyellow": return "ADFF2F";
                case "chartreuse": return "7FFF00";
                case "lime": return "00FF00";
                case "limegreen": return "32CD32";
                case "yellowgreen": return "9ACD32";
                case "olive": return "808000";
                case "olivedrab": return "6B8E23";
                case "darkolivegreen": return "556B2F";
                case "forestgreen": return "228B22";
                case "darkgreen": return "006400";
                case "green": return "008000";
                case "seagreen": return "2E8B57";
                case "mediumseagreen": return "3CB371";
                case "darkseagreen": return "8FBC8F";
                case "lightgreen": return "90EE90";
                case "palegreen": return "98FB98";
                case "springgreen": return "00FF7F";
                case "mediumspringgreen": return "00FA9A";
                case "teal": return "008080";
                case "darkcyan": return "008B8B";
                case "lightseagreen": return "20B2AA";
                case "mediumaquamarine": return "66CDAA";
                case "cadetblue": return "5F9EA0";
                case "steelblue": return "4682B4";
                case "aquamarine": return "7FFFD4";
                case "powderblue": return "B0E0E6";
                case "paleturquoise(AFEEEE": return "";
                case "lightblue": return "ADD8E6";
                case "lightsteelblue": return "B0C4DE";
                case "skyblue": return "87CEEB";
                case "lightskyblue": return "87CEFA";
                case "mediumturquoise": return "48D1CC";
                case "turquoise": return "40E0D0";
                case "darkturquoise": return "00CED1";
                case "aqua": return "00FFFF";
                case "cyan": return "00FFFF";
                case "deepskyblue": return "00BFFF";
                case "dodgerblue": return "1E90FF";
                case "cornflowerblue": return "6495ED";
                case "royalblue": return "4169E1";
                case "blue": return "0000FF";
                case "mediumblue": return "0000CD";
                case "navy": return "000080";
                case "darkblue": return "00008B";
                case "midnightblue": return "191970";
                case "darkslateblue": return "483D8B";
                case "slateblue": return "6A5ACD";
                case "mediumslateblue": return "7B68EE";
                case "mediumpurple": return "9370DB";
                case "darkorchid": return "9932CC";
                case "darkviolet": return "9400D3";
                case "blueviolet": return "8A2BE2";
                case "mediumorchid": return "BA55D3";
                case "plum": return "DDA0DD";
                case "lavender": return "E6E6FA";
                case "thistle": return "D8BFD8";
                case "orchid": return "DA70D6";
                case "violet": return "EE82EE";
                case "indigo": return "4B0082";
                case "darkmagenta": return "8B008B";
                case "purple": return "800080";
                case "mediumvioletred": return "C71585";
                case "deeppink": return "FF1493";
                case "fuchsia": return "FF00FF";
                case "magenta": return "FF00FF";
                case "hotpink": return "FF69B4";
                case "palevioletred": return "DB7093";
                case "lightpink": return "FFB6C1";
                case "pink": return "FFC0CB";
                case "mistyrose": return "FFE4E1";
                case "blanchedalmond": return "FFEBCD";
                case "lightyellow": return "FFFFE0";
                case "cornsilk": return "FFF8DC";
                case "antiquewhite": return "FAEBD7";
                case "papayawhip": return "FFEFD5";
                case "lemonchiffon": return "FFFACD";
                case "beige": return "F5F5DC";
                case "linen": return "FAF0E6";
                case "oldlace": return "FDF5E6";
                case "lightcyan": return "E0FFFF";
                case "aliceblue": return "F0F8FF";
                case "whitesmoke": return "F5F5F5";
                case "lavenderblush": return "FFF0F5";
                case "floralwhite": return "FFFAF0";
                case "mintcream": return "F5FFFA";
                case "ghostwhite": return "F8F8FF";
                case "honeydew": return "F0FFF0";
                case "seashell": return "FFF5EE";
                case "ivory": return "FFFFF0";
                case "azure": return "F0FFFF";
                case "snow": return "FFFAFA";
                case "white": return "FFFFFF";
                case "gainsboro": return "DCDCDC";
                case "lightgrey": return "D3D3D3";
                case "silver": return "C0C0C0";
                case "darkgray": return "A9A9A9";
                case "lightslategray": return "778899";
                case "slategray": return "708090";
                case "gray": return "808080";
                case "dimgray": return "696969";
                case "darkslategray": return "2F4F4F";
                case "black": return "000000";
                default: return soColor.Substring(1);
            }
        }
        public string ColorToAttr(string soColor)
        {
            return SToAttrColor(soColor);
        }
        public string ColorFromAttr(string attrColor)
        {
            return "#" + attrColor;
        }

        private class SmiStatus
        {
            public int b = 0;
            public int i = 0;
            public int u = 0;
            public List<int> fs = new List<int>();
            public List<string> fn = new List<string>();
            public List<string> fc = new List<string>();
            public List<int> fade = new List<int>();
            public List<Attr.TypingAttr> typing = new List<Attr.TypingAttr>();
            public List<string[]> fontAttrs = new List<string[]>();
            public SmiStatus SetB(bool isOpen)
            {
                if (isOpen) b++;
                else if (b > 0) b--;
                return this;
            }
            public SmiStatus SetI(bool isOpen)
            {
                if (isOpen) i++;
                else if (i > 0) i--;
                return this;
            }
            public SmiStatus SetU(bool isOpen)
            {
                if (isOpen) u++;
                else if (u > 0) u--;
                return this;
            }
            public SmiStatus SetFont(List<string[]> attrs)
            {
                if (attrs != null)
                {
                    string[] thisAttrs = new string[attrs.Count];
                    for (int i = 0; i < attrs.Count; i++)
                    {
                        thisAttrs[i] = attrs[i][0];
                        switch (attrs[i][0])
                        {
                            case "size":
                                try
                                {
                                    fs.Add(Convert.ToInt32(attrs[i][1]));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                                break;
                            case "face":
                                fn.Add(attrs[i][1]);
                                break;
                            case "color":
                                fc.Add(SToAttrColor(attrs[i][1]));
                                break;
                            case "fade":
                                fade.Add(attrs[i][1].Equals("in") ? 1 : attrs[i][1].Equals("out") ? -1 : 0);
                                break;
                            case "typing":
                                {
                                    string[] attr = attrs[i][1].Split(' ');
                                    string mode = attr[0];
                                    Match match;
                                    Attr.TypingAttr tAttr = null;

                                    if (mode.Equals("typewriter"))
                                    {
                                        tAttr = new Attr.TypingAttr(Typing.Mode.typewriter);
                                    }
                                    else if ((match = Regex.Match(mode, "typewriter\\(([0-9]+),([0-9]+)\\)")).Success)
                                    {
                                        tAttr = new Attr.TypingAttr(Typing.Mode.typewriter
                                            , Convert.ToInt32(match.Groups[1].ToString())
                                            , Convert.ToInt32(match.Groups[2].ToString()));
                                    }
                                    else if (mode.Equals("keyboard"))
                                    {
                                        tAttr = new Attr.TypingAttr(Typing.Mode.keyboard);
                                    }
                                    else if ((match = Regex.Match(mode, "keyboard\\(([0-9]+),([0-9]+)\\)")).Success)
                                    {
                                        tAttr = new Attr.TypingAttr(Typing.Mode.keyboard
                                            , Convert.ToInt32(match.Groups[1].ToString())
                                            , Convert.ToInt32(match.Groups[2].ToString()));
                                    }

                                    if (tAttr == null)
                                    {
                                        thisAttrs[i] = "";
                                    }
                                    else
                                    {
                                        if (attr.Length > 1)
                                        {
                                            switch (attr[1])
                                            {
                                                case "invisible":
                                                    tAttr.cursor = Typing.Cursor.invisible;
                                                    break;
                                                case "hangeul":
                                                    tAttr.cursor = Typing.Cursor.hangeul;
                                                    break;
                                            }
                                        }
                                        typing.Add(tAttr);
                                    }
                                }
                                break;
                        }
                    }
                    fontAttrs.Add(thisAttrs);
                }
                else if (fontAttrs != null) // ?? null 올 수 있는 게 맞던가?
                {
                    string[] lastAttrs = fontAttrs[fontAttrs.Count - 1];
                    foreach (string attr in lastAttrs)
                    {
                        switch (attr)
                        {
                            case "size":
                                fs.RemoveAt(fs.Count - 1);
                                break;
                            case "face":
                                fn.RemoveAt(fn.Count - 1);
                                break;
                            case "color":
                                fc.RemoveAt(fc.Count - 1);
                                break;
                            case "fade":
                                fade.RemoveAt(fade.Count - 1);
                                break;
                            case "typing":
                                typing.RemoveAt(typing.Count - 1);
                                break;
                        }
                    }
                    fontAttrs.RemoveAt(fontAttrs.Count - 1);
                }
                return this;
            }
        }
        private static void SetStyle(Attr attr, SmiStatus status)
        {
            attr.b = status.b > 0;
            attr.i = status.i > 0;
            attr.u = status.u > 0;
            attr.fs = (status.fs.Count > 0) ? status.fs[status.fs.Count - 1] : 0;
            attr.fn = (status.fn.Count > 0) ? status.fn[status.fn.Count - 1] : "";
            attr.fc = (status.fc.Count > 0) ? status.fc[status.fc.Count - 1] : "";
            attr.fade = (status.fade.Count > 0) ? status.fade[status.fade.Count - 1] : 0;
            attr.typing = (status.typing.Count > 0) ? status.typing[status.typing.Count - 1] : null;
        }
        public static List<Attr> ToAttr(string text)
        {
            List<Attr> result = new List<Attr>();

            int index = 0;
            int pos = 0;
            SmiStatus status = new SmiStatus();
            Attr last = new Attr();
            result.Add(last);

            while ((pos = text.IndexOf('<', index)) >= 0)
            {
                #region 태그명
                int tagNameLength = 0;
                while (pos + 1 + tagNameLength < text.Length
                    && text[pos + 1 + tagNameLength] != ' '
                    && text[pos + 1 + tagNameLength] != '>'
                    && text[pos + 1 + tagNameLength] != '\r'
                    && text[pos + 1 + tagNameLength] != '\n'
                    && text[pos + 1 + tagNameLength] != '\t'
                    ) tagNameLength++;

                string tagName = text.Substring(pos + 1, tagNameLength).ToUpper();
                int attrPos = pos + 1 + tagNameLength;
                #endregion

                #region 태그 속성
                List<string[]> attrs = new List<string[]>();
                if (text[attrPos] == '>')
                {
                    attrPos++;
                }
                else
                {
                    if (tagName[0].Equals('/')) // 종료 태그
                    {
                        attrPos = text.IndexOf('>', attrPos) + 1;
                    }
                    else
                    {
                        int mode = 0;
                        int attrNameStart = attrPos, attrValueStart = 0;
                        string name = "";

                        while (mode >= 0)
                        {
                            switch (mode)
                            {
                                case 0: // 속성 이름
                                    {
                                        for (; mode == 0 && attrPos < text.Length; attrPos++)
                                        {
                                            switch (text[attrPos])
                                            {
                                                case '>':
                                                    if (attrPos - attrNameStart > 0)
                                                    {
                                                        // 이름만 있는 속성
                                                        attrs.Add(new string[] {
                                                                text.Substring(attrNameStart, attrPos - attrNameStart).ToLower(),
                                                                null
                                                            });
                                                    }
                                                    mode = -1;
                                                    break;
                                                case ' ':
                                                case '\t':
                                                case '\r':
                                                case '\n':
                                                    if (attrPos - attrNameStart > 0)
                                                    {
                                                        // 이름만 있는 속성
                                                        attrs.Add(new string[] {
                                                                text.Substring(attrNameStart, attrPos - attrNameStart).ToLower(),
                                                                null
                                                            });
                                                    }
                                                    attrNameStart = attrPos + 1;
                                                    break;
                                                case '=':
                                                    // 이름 끝, 값 시작
                                                    name = text.Substring(attrNameStart, attrPos - attrNameStart).ToLower();
                                                    mode = 1;
                                                    attrValueStart = attrPos + 1;
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 1: // 속성 값
                                    {
                                        for (; mode == 1 && attrPos < text.Length; attrPos++)
                                        {
                                            switch (text[attrPos])
                                            {
                                                case '>':
                                                    // 값 끝
                                                    attrs.Add(new string[] {
                                                            name,
                                                            text.Substring(attrNameStart, attrPos - attrNameStart).ToLower()
                                                        });
                                                    mode = -1;
                                                    attrPos++;
                                                    break;
                                                case ' ':
                                                case '\t':
                                                case '\r':
                                                case '\n':
                                                    // 값 끝
                                                    attrs.Add(new string[] {
                                                            name,
                                                            text.Substring(attrValueStart, attrPos - attrValueStart).ToLower()
                                                        });
                                                    mode = 0;
                                                    attrNameStart = attrPos + 1;
                                                    break;
                                                case '\'':
                                                    if (attrPos == attrValueStart)
                                                    {
                                                        mode = 2;
                                                        attrValueStart++;
                                                    }
                                                    break;
                                                case '"':
                                                    if (attrPos == attrValueStart)
                                                    {
                                                        mode = 3;
                                                        attrValueStart++;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 2: // 속성 값 (작은 따옴표)
                                    {
                                        for (; mode == 2 && attrPos < text.Length; attrPos++)
                                        {
                                            switch (text[attrPos])
                                            {
                                                case '\\':
                                                    attrPos++;
                                                    break;
                                                case '\'':
                                                    // 값 끝
                                                    attrs.Add(new string[] {
                                                            name,
                                                            text.Substring(attrValueStart, attrPos - attrValueStart).ToLower()
                                                        });
                                                    mode = 0;
                                                    attrNameStart = attrPos + 1;
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case 3: // 속성 값 (큰 따옴표)
                                    {
                                        for (; mode == 3 && attrPos < text.Length; attrPos++)
                                        {
                                            switch (text[attrPos])
                                            {
                                                case '\\':
                                                    attrPos++;
                                                    break;
                                                case '"':
                                                    // 값 끝
                                                    attrs.Add(new string[] {
                                                            name,
                                                            text.Substring(attrValueStart, attrPos - attrValueStart).ToLower()
                                                        });
                                                    mode = 0;
                                                    attrNameStart = attrPos + 1;
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
                #endregion

                if (tagName[0].Equals('/')) // 종료 태그
                {
                    tagName = tagName.Substring(1);
                    switch (tagName)
                    {
                        case "B":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetB(false));
                            break;
                        case "I":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetI(false));
                            break;
                        case "U":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetU(false));
                            break;
                        case "FONT":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetFont(null));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (tagName)
                    {
                        case "B":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetB(true));
                            break;
                        case "I":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetI(true));
                            break;
                        case "U":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetU(true));
                            break;
                        case "FONT":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", ""));
                            if (last.text.Length > 0)
                                result.Add((last = new Attr()));
                            SetStyle(last, status.SetFont(attrs));
                            break;
                        case "BR":
                            last.text += WebUtility.HtmlDecode(text.Substring(index, pos - index).Replace("\n", "")) + "\n";
                            break;
                        default:
                            last.text += WebUtility.HtmlDecode(text.Substring(index, attrPos - index).Replace("\n", ""));
                            break;
                    }
                }

                index = attrPos;
            }
            last.text += WebUtility.HtmlDecode(text.Substring(index));

            return result;
        }
        public List<Attr> ToAttr()
        {
            return ToAttr(text);
        }
        public Smi FromAttr(List<Attr> attrs)
        {
            string text = "";
            List<string[]> lastAttrs = new List<string[]>();

            Attr last = new Attr();
            foreach (Attr attr in attrs)
            {
                if (!last.b && attr.b) text += "<B>";
                else if (last.b && !attr.b) text += "</B>";

                if (!last.i && attr.i) text += "<I>";
                else if (last.i && !attr.i) text += "</I>";

                if (!last.u && attr.u) text += "<U>";
                else if (last.u && !attr.u) text += "</U>";

                if (last.fs != attr.fs
                    || !last.fn.Equals(attr.fn)
                    || !last.fc.Equals(attr.fc)
                    || !last.fade.Equals(attr.fade)
                    || (last.typing == null && attr.typing != null)
                    || (last.typing != null && attr.typing == null)
                    )
                {
                    // 기존에 속성이 있었을 때만 닫는 태그
                    if (last.fs > 0 || !last.fn.Equals("") || !last.fc.Equals("") || last.fade > 0 || last.typing != null)
                        text += "</FONT>";

                    // 신규 속성이 있을 때만 여는 태그
                    if (attr.fs > 0 || !attr.fn.Equals("") || !attr.fc.Equals("") || attr.fade > 0 || attr.typing != null)
                    {
                        text += "<FONT";
                        if (attr.fs > 0) text += " size=\"" + attr.fs + "\"";
                        if (!attr.fn.Equals("")) text += " face=\"" + attr.fn + "\"";
                        if (!attr.fc.Equals("")) text += " color=\"" + ColorFromAttr(attr.fc) + "\"";
                        if (attr.fade != 0) text += " fade=\"" + (attr.fade > 0 ? "in" : "out") + "\"";
                        if (attr.typing != null) text += " typing=\"" + attr.typing.mode.ToString() + "(" + attr.typing.start + "," + attr.typing.end + ") " + attr.typing.cursor.ToString() + "\"";
                        text += ">";
                    }
                }

                text += WebUtility.HtmlEncode(attr.text);
                last = attr;
            }

            this.text = text.Replace("\n", "<br>");
            return this;
        }

        public SyncAttr ToSync() {
            return new SyncAttr()
            {
                start = start,
                startType = syncType,
                text = ToAttr()
            };
        }
        public Smi FromSync(SyncAttr sync)
        {
            start = sync.start;
            syncType = sync.startType;
            FromAttr(sync.text);
            return this;
        }

        public static float GetLineWidth(string text)
        {
            return Width.GetWidth(ToAttr(text));
        }

        private class Color
        {
            public int index;
            public bool isIn;
            private int r = 255;
            private int g = 255;
            private int b = 255;
            private int V(char c)
            {
                if (c >= '0' && c <= '9')
                    return c - '0';
                if (c >= 'a' && c <= 'z')
                    return c - 'a' + 10;
                if (c >= 'A' && c <= 'Z')
                    return c - 'A' + 10;
                return 0;
            }
            private int V(string hex)
            {
                int v = 0;
                foreach (char c in hex)
                    v = v * 16 + V(c);
                return v;
            }
            public Color(int index, bool isIn, string color)
            {
                this.index = index;
                this.isIn = isIn;
                r = V(color.Substring(0, 2));
                g = V(color.Substring(2, 2));
                b = V(color.Substring(4, 2));
            }
            private char C(int v)
            {
                if (v < 10)
                    return (char)(v + '0');
                return (char)(v + 'A' - 10);
            }
            private string Hex(int v)
            {
                return "" + C(v / 16) + C(v % 16);
            }
            public string Get(int value, int total)
            {
                return Hex(r * value / total) + Hex(g * value / total) + Hex(b * value / total);
            }
        }
        public static void Normalize(List<Smi> smis)
        {
            int startIndex = -1;
            for (int i = 1; i < smis.Count; i++)
            {
                if (smis[i].syncType == SyncType.inner)
                {
                    if (startIndex < 0)
                    {
                        startIndex = i - 1;
                    }
                }
                else
                {
                    if (startIndex >= 0)
                    {
                        int endIndex = i;
                        if (smis[startIndex].syncType == smis[endIndex].syncType)
                        {
                            int startSync = smis[startIndex].start;
                            int endSync = smis[endIndex].start;
                            int count = endIndex - startIndex;

                            for (int j = 1; j < count; j++)
                            {
                                smis[startIndex + j].start = ((count - j) * startSync + j * endSync) / count;
                            }
                        }
                        startIndex = -1;
                    }
                }
            }

            for (int i = 0; i < smis.Count - 1; i++)
            {
                Smi smi = smis[i];
                if (smi.syncType != smis[i + 1].syncType)
                    // 전후 싱크 타입이 맞을 때만 안전함
                    continue;

                string lower = smi.text.ToLower();
                if (lower.IndexOf(" fade=") > 0)
                {
                    List<Color> fadeColors = new List<Color>();
                    List<Attr> attrs = smi.ToAttr();
                    for (int j = 0; j < attrs.Count; j++)
                    {
                        if (attrs[j].fade != 0)
                        {
                            string color = (attrs[j].fc.Length == 6) ? attrs[j].fc : "ffffff";
                            fadeColors.Add(new Color(j, attrs[j].fade > 0, color));
                            attrs[j].fade = 0;
                        }
                    }
                    if (fadeColors.Count == 0)
                        continue;

                    int start = smi.start, end = smis[i + 1].start;
                    int frames = (int)Math.Round((end - start) * 24 / 1001.0);

                    foreach (Color color in fadeColors)
                    {
                        Attr attr = attrs[color.index];
                        if (color.isIn)
                            attr.fc = color.Get(1, 2 * frames);
                        else
                            attr.fc = color.Get(2 * frames - 1, 2 * frames);
                    }
                    smi.FromAttr(attrs);
                    for (int j = 1; j < frames; j++)
                    {
                        foreach (Color color in fadeColors)
                        {
                            Attr attr = attrs[color.index];
                            if (color.isIn)
                                attr.fc = color.Get(1 + 2 * j, 2 * frames);
                            else
                                attr.fc = color.Get(2 * frames - (1 + 2 * j), 2 * frames);
                        }
                        smis.Insert(i + j, new Smi()
                        {
                            start = (start * (frames - j) + end * j) / frames,
                            //syncType = 2,
                            syncType = SyncType.inner
                        }.FromAttr(attrs));
                    }
                    i += frames - 1;
                }
                else if (lower.IndexOf(" typing=") > 0)
                {
                    // 타이핑은 한 싱크에 하나만 가능
                    int attrIndex = -1;
                    Attr attr = null;
                    List<Attr> attrs = smi.ToAttr();
                    bool isLastAttr = false;
                    for (int j = 0; j < attrs.Count; j++)
                    {
                        if (attrs[j].typing != null)
                        {
                            string color = (attrs[j].fc.Length == 6) ? attrs[j].fc : "ffffff";
                            attr = attrs[(attrIndex = j)];
                            string remains = "";
                            for (int k = j + 1; k < attrs.Count; k++)
                                remains += attrs[k].text;
                            isLastAttr = remains.Length == 0 || remains.StartsWith("\n");
                            if (!isLastAttr)
                            {
                                int length = 0;
                                for (int k = j + 1; k < attrs.Count; k++)
                                    length += attrs[k].text.Length;
                                isLastAttr = (length == 0);
                            }
                            break;
                        }
                    }
                    if (attr == null)
                        continue;

                    List<string> types = Typing.ToType(attr.text, attr.typing.mode, attr.typing.cursor);
                    float width = GetLineWidth(attr.text);

                    int start = smi.start, end = smis[i + 1].start;
                    int count = types.Count - attr.typing.end - attr.typing.start;
                    if (count < 1) continue;

                    int typingStart = attr.typing.start;
                    attr.typing = null;
                    smis.RemoveAt(i);
                    for (int j = 0; j < count; j++)
                    {
                        string text = types[j + typingStart];
                        attr.text = Width.GetAppend(GetLineWidth(text), width) + (isLastAttr ? "​" : "");

                        List<Attr> tAttrs = new List<Attr>();
                        tAttrs.AddRange(attrs.GetRange(0, attrIndex));
                        tAttrs.AddRange(new Smi() { text = text }.ToAttr());
                        tAttrs.Add(attr);
                        if (!isLastAttr)
                            tAttrs.AddRange(attrs.GetRange(attrIndex + 1, attrs.Count - attrIndex - 1));

                        smis.Insert(i + j, new Smi()
                        {
                            start = (start * (count - j) + end * (j)) / count,
                            syncType = j == 0 ? smi.syncType : SyncType.inner
                        }.FromAttr(tAttrs));
                    }
                    i += count - 1;
                }
            }
        }

        public static void FillEmptySync(List<Smi> smis)
        {
            for (int i = 0; i < smis.Count - 1; i++)
            {
                Smi smi = smis[i];
                if (smi.syncType != smis[i + 1].syncType)
                    // 전후 싱크 타입이 맞을 때만 안전함
                    continue;

                string[] lines = smi.text.Replace("\r\n", "\n").Split('\n');
                if (lines.Length < 2)
                    // 한 줄이면 필요 없음
                    continue;

                int start = smi.start, end = smis[i + 1].start;
                int length = lines.Length;

                smi.text = lines[0];
                for (int j = 1; j < length; j++)
                {
                    smis.Insert(i + j, new Smi()
                    {
                        start = (start * (length - j) + end * j) / length,
                        syncType = SyncType.inner,
                        text = lines[j]
                    });
                }
            }
        }
    }
    public class SmiFile : ISubtitleFile<Smi, SmiFile>
    {
        public string header = ""; // 세부적으로 나누려다가 주석도 있고 해서 일단 패스
        public string footer = "";
        public List<Smi> body = new List<Smi>();

        public string ToTxt()
        {
            return
                header.Replace("\n", "\r\n") +
                Smi.Smi2txt(body) +
                footer.Replace("\n", "\r\n");
        }
        public SmiFile FromTxt(string txt)
        {
            txt = txt.Replace("\r\n", "\n");
            header = "";
            footer = "";
            body = new List<Smi>();

            int index = 0;
            int pos = 0;
            Smi last = null; ;

            while ((pos = txt.IndexOf('<', index)) >= 0)
            {
                if (txt.Length > pos + 6 && txt.Substring(pos, 6).ToUpper().Equals("<SYNC "))
                {
                    if (last == null)
                        header = txt.Substring(0, pos);
                    else
                        last.text += txt.Substring(index, pos - index);

                    int start = 0;
                    index = txt.IndexOf('>', pos + 6) + 1;
                    if (index == 0)
                    {
                        index = txt.Length;
                        break;
                    }
                    string[] attrs = txt.Substring(pos + 6, index - pos - 7).ToLower().Split(' ');
                    foreach (string attr in attrs)
                    {
                        if (attr.StartsWith("start="))
                        {
                            start = Convert.ToInt32(attr.Substring(6));
                            break;
                        }
                    }

                    body.Add(last = new Smi() { start = start });
                }
                else if (txt.Length > pos + 4 && txt.Substring(pos, 3).ToUpper().Equals("<P "))
                {
                    index = txt.IndexOf('>', pos + 3) + 1;
                    if (index == 0)
                    {
                        index = txt.Length;
                        break;
                    }
                    switch (txt[index - 2])
                    {
                        case ' ':
                            last.syncType = SyncType.frame;
                            break;
                        case '\t':
                            last.syncType = SyncType.inner;
                            break;
                    }
                }
                else if (txt.Length > pos + 6 && txt.Substring(pos, 7).ToUpper().Equals("</BODY>"))
                {
                    if (last == null)
                        header = txt.Substring(0, pos);
                    else
                        last.text += txt.Substring(index, pos - index);
                    footer = txt.Substring(pos);
                    index = txt.Length;
                    break;
                }
                else
                {
                    pos++;
                    if (last == null)
                        header = txt.Substring(0, pos);
                    else
                        last.text += txt.Substring(index, pos - index);
                    index = pos;
                }
            }

            if (last == null)
                header = txt.Substring(0);
            else
                last.text += txt.Substring(index);

            foreach (Smi smi in body)
            {
                if (smi.text.Length > 0)
                {
                    if (smi.text[0] == '\n')
                        smi.text = smi.text.Substring(1);

                    if (smi.text.Length > 1 && smi.text[smi.text.Length - 1] == '\n')
                        smi.text = smi.text.Substring(0, smi.text.Length - 1);
                }
            }

            return this;
        }

        public List<SyncAttr> ToSync()
        {
            List<SyncAttr> result = new List<SyncAttr>();

            if (body.Count > 0)
            {
                int i = 0;
                SyncAttr last = null;
                for (; i + 1 < body.Count; i++)
                {
                    if (body[i].text.Replace("&nbsp;", "").Length == 0)
                        continue;

                    last = body[i].ToSync();
                    last.end = (body[i + 1].start > 0 ? body[i + 1].start : 0);
                    last.endType = body[i + 1].syncType;
                    result.Add(last);
                }
                result.Add(last = body[i].ToSync());
            }

            return result;
        }
        public SmiFile FromSync(List<SyncAttr> syncs)
        {
            List<Smi> smis = new List<Smi>();

            if (syncs.Count > 0)
            {
                int i = 0;

                Smi last;
                smis.Add(new Smi().FromSync(syncs[i]));

                smis.Add(last = new Smi()
                {
                    start = syncs[i].end,
                    syncType = syncs[i].endType,
                    text = "&nbsp;"
                });

                for (i = 1; i < syncs.Count; i++)
                {
                    if (last.start == syncs[i].start)
                        last.FromAttr(syncs[i].text);
                    else
                        smis.Add(new Smi().FromSync(syncs[i]));

                    smis.Add(last = new Smi()
                    {
                        start = syncs[i].end,
                        syncType = syncs[i].endType,
                        text = "&nbsp;"
                    });
                }
            }

            body = smis;
            return this;
        }
    }
}
