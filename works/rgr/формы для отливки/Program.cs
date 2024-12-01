using System.Diagnostics;
class forms
{
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        //for (int c = 1; c <= 13; c++)
        //{
        string[] lines = File.ReadAllLines($"C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Формы\\Формы для отливки\\input13.txt");
        int n = int.Parse(lines[0]);
        List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
        for (int i = 1; i <= n; i++)
        {
            string[] detail = lines[i].Split(' ');
            string top = detail[0] + detail[1] + detail[2] + detail[3] + detail[4];
            string near = detail[5] + detail[6] + detail[7] + detail[8] + detail[9];
            string lower = detail[10] + detail[11] + detail[12] + detail[13] + detail[14];
            string distant = detail[15] + detail[16] + detail[17] + detail[18] + detail[19];
            string det = top + near + lower + distant;
            bool found = false;
            for (int j = n + 1; j <= 2 * n + n; j++)
            {
                string[] forms1 = lines[j].Split(" ");
                string formtop1 = forms1[0] + forms1[1] + forms1[2] + forms1[3] + forms1[4];
                string formdistant1 = forms1[5] + forms1[6] + forms1[7] + forms1[8] + forms1[9];
                string formlower1 = forms1[10] + forms1[11] + forms1[12] + forms1[13] + forms1[14];
                string formlower1rev = new string(formlower1.Reverse().ToArray());
                string form1 = formtop1 + formdistant1 + formlower1;
                string formrot1 = Rotateform1(form1);
                string formdistant1rev = new string(formdistant1.Reverse().ToArray());
                for (int k = j + 1; k <= 2 * n + n; k++)
                {
                    string[] forms2 = lines[k].Split(" ");
                    string formtop2 = forms2[0] + forms2[1] + forms2[2] + forms2[3] + forms2[4];
                    string formdistant2 = forms2[5] + forms2[6] + forms2[7] + forms2[8] + forms2[9];
                    string formlower2 = forms2[10] + forms2[11] + forms2[12] + forms2[13] + forms2[14];
                    string form2 = formtop2 + formdistant2 + formlower2;
                    string formrot2 = Rotateform2(form2);
                    string formdistant2rev = new string(formdistant2.Reverse().ToArray());
                    string formlower2rev = new string(formlower2.Reverse().ToArray());
                    string form1razv = new string(form1.Reverse().ToArray());
                    string form2razv = new string(form2.Reverse().ToArray());
                    if (formtop1 == formlower2 && formtop2 == formlower1)
                    {
                        string formpoln1 = Rotateform1(form1).Substring(10, 5) + formdistant2rev + Rotateform1(form1).Substring(0, 5) + formdistant1rev.ToString();
                        string formpoln2 = Rotateform1(form2).Substring(10, 5) + formdistant1rev + Rotateform1(form2).Substring(0, 5) + formdistant2rev.ToString();
                        string formpoln1rev = formtop1 + formdistant2 + formlower1 + formdistant1;
                        string formpoln2rev = formtop2 + formdistant1 + formlower2 + formdistant2;
                        string formpoln11 = formtop1 + formdistant2rev + formlower1 + formdistant1;
                        string formpoln22 = formtop2 + formdistant1rev + formlower2 + formdistant2;

                        if (formpoln1 == det || RotateDetailMatch(formpoln1, det) ||
                            formpoln2 == det || RotateDetailMatch(formpoln2, det) ||
                            formlower1rev == det || RotateDetailMatch(formpoln1rev, det) ||
                            formpoln2rev == det || RotateDetailMatch(formpoln2rev, det) ||
                            formpoln11 == det || RotateDetailMatch(formpoln11, det) ||
                            formpoln22 == det || RotateDetailMatch(formpoln22, det))
                        {
                            pairs.Add(Tuple.Create(j - n, k - n));
                        }
                    }
                    else if (formtop1 == formrot2.Substring(0, 5) && formlower1 == formrot2.Substring(10, 5))
                    {
                        string formpoln1 = formtop1 + formrot2.Substring(5, 5) + formlower1 + formdistant1;
                        string formpoln2 = formtop2 + formrot1.Substring(5, 5) + formlower2 + formdistant2;

                        if (formpoln1 == det || RotateDetailMatch(formpoln1, det) || formpoln2 == det || RotateDetailMatch(formpoln2, det))
                        {
                            pairs.Add(Tuple.Create(j - n, k - n));
                        }
                    }
                }
            }
        }
        for (int i = 0; i < pairs.Count; i++)
        {
            bool first = false;
            bool second = false;
            int temp1 = pairs[i].Item1;
            int temp2 = pairs[i].Item2;
            for (int j = 0; j < pairs.Count; j++)
            {
                if (i != j)
                {
                    if (temp1 == pairs[j].Item1 || temp1 == pairs[j].Item2)
                    {
                        first = true;
                    }
                    if (temp2 == pairs[j].Item1 || temp2 == pairs[j].Item2)
                    {
                        second = true;
                    }
                }
                if (first && second)
                {
                    pairs.RemoveAt(i);
                    i--;
                    break;
                }
            }
        }

        //string[] lines2 = File.ReadAllLines($"C:\\Users\\Дмитрий\\Desktop\\олимпиады\\Формы\\Формы для отливки\\output{c}.txt");
        //List<Tuple<int, int>> expectedResults = new List<Tuple<int, int>>();
        //bool proverka = true;

        //foreach (string line in lines2)
        //{
        //    string[] parts = line.Split(' ');
        //    int item1 = int.Parse(parts[0]);
        //    int item2 = int.Parse(parts[1]);
        //    expectedResults.Add(Tuple.Create(item1, item2));
        //}

        //if (pairs.Count != expectedResults.Count)
        //{
        //    proverka = false;
        //}
        //for (int i = 0; i < pairs.Count; i++)
        //{
        //    if (pairs[i].Item1 != expectedResults[i].Item1 || pairs[i].Item2 != expectedResults[i].Item2)
        //    {
        //        proverka = false;
        //    }
        //}
        //if (proverka)
        //{
        //    Console.WriteLine("true");
        //}
        //else {  Console.WriteLine("false"); }
        //}
        
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Item1} {pair.Item2}");
        }
        Console.WriteLine();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        static bool RotateDetailMatch(string form, string det)
        {
            return form == RotateDetail(det, 1) || form == RotateDetail(det, 2) || form == RotateDetail(det, 3);
        }
        static string Rotateform1(string form1)
        {
            string formtoprot = form1[4].ToString() + form1[3].ToString() + form1[2].ToString() + form1[1].ToString() + form1[0].ToString();
            string formdistantrot = form1[9].ToString() + form1[8].ToString() + form1[7].ToString() + form1[6].ToString() + form1[5].ToString();
            string formlowerrot = form1[14].ToString() + form1[13].ToString() + form1[12].ToString() + form1[11].ToString() + form1[10].ToString();

            return formtoprot + formdistantrot + formlowerrot;
        }
        static string Rotateform2(string form2)
        {
            string formtoprot = form2[4].ToString() + form2[3].ToString() + form2[2].ToString() + form2[1].ToString() + form2[0].ToString();
            string formdistantrot = form2[9].ToString() + form2[8].ToString() + form2[7].ToString() + form2[6].ToString() + form2[5].ToString();
            string formlowerrot = form2[14].ToString() + form2[13].ToString() + form2[12].ToString() + form2[11].ToString() + form2[10].ToString();

            return formtoprot + formdistantrot + formlowerrot;
        }
        static string RotateDetail(string det, int x)
        {
            string top = det[0].ToString() + det[1].ToString() + det[2].ToString() + det[3].ToString() + det[4].ToString();
            string near = det[5].ToString() + det[6].ToString() + det[7].ToString() + det[8].ToString() + det[9].ToString();
            string lower = det[10].ToString() + det[11].ToString() + det[12].ToString() + det[13].ToString() + det[14].ToString();
            string distant = det[15].ToString() + det[16].ToString() + det[17].ToString() + det[18].ToString() + det[19].ToString();
            switch (x)
            {
                case 1: return distant + top + near + lower;
                case 2: return lower + distant + top + near;
                case 3: return near + lower + distant + top;
                default: return det;
            }
        }
    }
}
