// This file was generated automatically by the Snowball to C# compiler

#pragma warning disable 0164
#pragma warning disable 0162

namespace Snowball
{
    using System;
    using System.Text;
    
    ///<summary>
    ///  This class was automatically generated by a Snowball to Java compiler 
    ///  It implements the stemming algorithm defined by a snowball script.
    ///</summary>
    /// 
    [System.CodeDom.Compiler.GeneratedCode("Snowball", "1.0.0")]
    public partial class DutchStemmer : Stemmer
    {
        private int I_p2;
        private int I_p1;
        private bool B_e_found;

        private static string g_v = "aeiouy\u00E8";
        private static string g_v_I = "aeiouy\u00E8I";
        private static string g_v_j = "aeiouy\u00E8j";
        private readonly Among[] a_0;
        private readonly Among[] a_1;
        private readonly Among[] a_2;
        private readonly Among[] a_3;
        private readonly Among[] a_4;
        private readonly Among[] a_5;

        /// <summary>
        ///   Initializes a new instance of the <see cref="DutchStemmer"/> class.
        /// </summary>
        /// 
        public DutchStemmer()
        {
            a_0 = new[] 
            {
                new Among("", -1, 6),
                new Among("\u00E1", 0, 1),
                new Among("\u00E4", 0, 1),
                new Among("\u00E9", 0, 2),
                new Among("\u00EB", 0, 2),
                new Among("\u00ED", 0, 3),
                new Among("\u00EF", 0, 3),
                new Among("\u00F3", 0, 4),
                new Among("\u00F6", 0, 4),
                new Among("\u00FA", 0, 5),
                new Among("\u00FC", 0, 5)
            };

            a_1 = new[] 
            {
                new Among("", -1, 3),
                new Among("I", 0, 2),
                new Among("Y", 0, 1)
            };

            a_2 = new[] 
            {
                new Among("dd", -1, -1),
                new Among("kk", -1, -1),
                new Among("tt", -1, -1)
            };

            a_3 = new[] 
            {
                new Among("ene", -1, 2),
                new Among("se", -1, 3),
                new Among("en", -1, 2),
                new Among("heden", 2, 1),
                new Among("s", -1, 3)
            };

            a_4 = new[] 
            {
                new Among("end", -1, 1),
                new Among("ig", -1, 2),
                new Among("ing", -1, 1),
                new Among("lijk", -1, 3),
                new Among("baar", -1, 4),
                new Among("bar", -1, 5)
            };

            a_5 = new[] 
            {
                new Among("aa", -1, -1),
                new Among("ee", -1, -1),
                new Among("oo", -1, -1),
                new Among("uu", -1, -1)
            };

        }



        private int r_prelude()
        {
            int among_var;
            // (, line 41
            // test, line 42
            {
                int c1 = cursor;
                // repeat, line 42
                while (true)
                {
                    int c2 = cursor;
                    // (, line 42
                    // [, line 43
                    bra = cursor;
                    // substring, line 43
                    among_var = find_among(a_0);
                    if (among_var == 0)
                    {
                        goto lab0;
                    }
                    // ], line 43
                    ket = cursor;
                    switch (among_var) 
                    {
                        case 0:
                            {
                                goto lab0;
                            }
                        case 1:
                            // (, line 45
                            // <-, line 45
                            slice_from("a");
                            break;
                        case 2:
                            // (, line 47
                            // <-, line 47
                            slice_from("e");
                            break;
                        case 3:
                            // (, line 49
                            // <-, line 49
                            slice_from("i");
                            break;
                        case 4:
                            // (, line 51
                            // <-, line 51
                            slice_from("o");
                            break;
                        case 5:
                            // (, line 53
                            // <-, line 53
                            slice_from("u");
                            break;
                        case 6:
                            // (, line 54
                            // next, line 54
                            if (cursor >= limit)
                            {
                                goto lab0;
                            }
                            cursor++;
                            break;
                    }
                    continue;
                lab0: ; 
                    cursor = c2;
                    break;
                }
                cursor = c1;
            }
            // try, line 57
            {
                int c3 = cursor;
                // (, line 57
                // [, line 57
                bra = cursor;
                // literal, line 57
                if (!(eq_s("y")))
                {
                    {
                        cursor = c3;
                        goto lab1;
                    }
                }
                // ], line 57
                ket = cursor;
                // <-, line 57
                slice_from("Y");
            lab1: ; 
            }
            // repeat, line 58
            while (true)
            {
                int c4 = cursor;
                while (true)
                {
                    // goto, line 58
                    int c5 = cursor;
                    // (, line 58
                    if (in_grouping(g_v, 97, 232, false) != 0)
                    {
                        goto lab3;
                    }
                    // [, line 59
                    bra = cursor;
                    // or, line 59
                    {
                        int c6 = cursor;
                        // (, line 59
                        // literal, line 59
                        if (!(eq_s("i")))
                        {
                            goto lab5;
                        }
                        // ], line 59
                        ket = cursor;
                        if (in_grouping(g_v, 97, 232, false) != 0)
                        {
                            goto lab5;
                        }
                        // <-, line 59
                        slice_from("I");
                        goto lab4;
                    lab5: ; 
                        cursor = c6;
                        // (, line 60
                        // literal, line 60
                        if (!(eq_s("y")))
                        {
                            goto lab3;
                        }
                        // ], line 60
                        ket = cursor;
                        // <-, line 60
                        slice_from("Y");
                    }
                lab4: ; 
                    cursor = c5;
                    break;
                lab3: ; 
                    cursor = c5;
                    // goto, line 58
                    if (cursor >= limit)
                    {
                        goto lab2;
                    }
                    cursor++;
                }
                continue;
            lab2: ; 
                cursor = c4;
                break;
            }

            return 1;
        }

        private int r_mark_regions()
        {
            // (, line 64
            I_p1 = limit;
            I_p2 = limit;
            {
                /* gopast */ 
                int ret = out_grouping(g_v, 97, 232, true);
                if (ret < 0)
                {
                    return 0;
                }

                cursor += ret;
            }
            {
                /* gopast */ 
                int ret = in_grouping(g_v, 97, 232, true);
                if (ret < 0)
                {
                    return 0;
                }

                cursor += ret;
            }
            // setmark p1, line 69
            I_p1 = cursor;
            // try, line 70
            // (, line 70
            if (!(I_p1 < 3))
            {
                goto lab0;
            }
            I_p1 = 3;
        lab0: ; 
            {
                /* gopast */ 
                int ret = out_grouping(g_v, 97, 232, true);
                if (ret < 0)
                {
                    return 0;
                }

                cursor += ret;
            }
            {
                /* gopast */ 
                int ret = in_grouping(g_v, 97, 232, true);
                if (ret < 0)
                {
                    return 0;
                }

                cursor += ret;
            }
            // setmark p2, line 71
            I_p2 = cursor;

            return 1;
        }

        private int r_postlude()
        {
            int among_var;
            // repeat, line 75
            while (true)
            {
                int c1 = cursor;
                // (, line 75
                // [, line 77
                bra = cursor;
                // substring, line 77
                among_var = find_among(a_1);
                if (among_var == 0)
                {
                    goto lab0;
                }
                // ], line 77
                ket = cursor;
                switch (among_var) 
                {
                    case 0:
                        {
                            goto lab0;
                        }
                    case 1:
                        // (, line 78
                        // <-, line 78
                        slice_from("y");
                        break;
                    case 2:
                        // (, line 79
                        // <-, line 79
                        slice_from("i");
                        break;
                    case 3:
                        // (, line 80
                        // next, line 80
                        if (cursor >= limit)
                        {
                            goto lab0;
                        }
                        cursor++;
                        break;
                }
                continue;
            lab0: ; 
                cursor = c1;
                break;
            }

            return 1;
        }

        private int r_R1()
        {
            if (!(I_p1 <= cursor))
            {
                return 0;
            }

            return 1;
        }

        private int r_R2()
        {
            if (!(I_p2 <= cursor))
            {
                return 0;
            }

            return 1;
        }

        private int r_undouble()
        {
            // (, line 90
            // test, line 91
            {
                int c1 = limit - cursor;
                // among, line 91
                if (find_among_b(a_2) == 0)
                {
                    return 0;
                }
                cursor = limit - c1;
            }
            // [, line 91
            ket = cursor;
            // next, line 91
            if (cursor <= limit_backward)
            {
                return 0;
            }
            cursor--;
            // ], line 91
            bra = cursor;
            // delete, line 91
            slice_del();

            return 1;
        }

        private int r_e_ending()
        {
            // (, line 94
            // unset e_found, line 95
            B_e_found = false;
            // [, line 96
            ket = cursor;
            // literal, line 96
            if (!(eq_s_b("e")))
            {
                return 0;
            }
            // ], line 96
            bra = cursor;
            {
                // call R1, line 96
                int ret = r_R1();
                if (ret == 0)
                    return 0;
                else if (ret < 0)
                    return ret;
            }
            // test, line 96
            {
                int c1 = limit - cursor;
                if (out_grouping_b(g_v, 97, 232, false) != 0)
                {
                    return 0;
                }
                cursor = limit - c1;
            }
            // delete, line 96
            slice_del();
            // set e_found, line 97
            B_e_found = true;
            {
                // call undouble, line 98
                int ret = r_undouble();
                if (ret == 0)
                    return 0;
                else if (ret < 0)
                    return ret;
            }

            return 1;
        }

        private int r_en_ending()
        {
            // (, line 101
            {
                // call R1, line 102
                int ret = r_R1();
                if (ret == 0)
                    return 0;
                else if (ret < 0)
                    return ret;
            }
            // and, line 102
            int c1 = limit - cursor;
            if (out_grouping_b(g_v, 97, 232, false) != 0)
            {
                return 0;
            }
            cursor = limit - c1;
            // not, line 102
            {
                int c2 = limit - cursor;
                // literal, line 102
                if (!(eq_s_b("gem")))
                {
                    goto lab0;
                }
                return 0;
            lab0: ; 
                cursor = limit - c2;
            }
            // delete, line 102
            slice_del();
            {
                // call undouble, line 103
                int ret = r_undouble();
                if (ret == 0)
                    return 0;
                else if (ret < 0)
                    return ret;
            }

            return 1;
        }

        private int r_standard_suffix()
        {
            int among_var;
            // (, line 106
            // do, line 107
            {
                int c1 = limit - cursor;
                // (, line 107
                // [, line 108
                ket = cursor;
                // substring, line 108
                among_var = find_among_b(a_3);
                if (among_var == 0)
                {
                    goto lab0;
                }
                // ], line 108
                bra = cursor;
                switch (among_var) 
                {
                    case 0:
                        {
                            goto lab0;
                        }
                    case 1:
                        // (, line 110
                        {
                            // call R1, line 110
                            int ret = r_R1();
                            if (ret == 0)
                                goto lab0;
                            else if (ret < 0)
                                return ret;
                        }
                        // <-, line 110
                        slice_from("heid");
                        break;
                    case 2:
                        // (, line 113
                        {
                            // call en_ending, line 113
                            int ret = r_en_ending();
                            if (ret == 0)
                                goto lab0;
                            else if (ret < 0)
                                return ret;
                        }
                        break;
                    case 3:
                        // (, line 116
                        {
                            // call R1, line 116
                            int ret = r_R1();
                            if (ret == 0)
                                goto lab0;
                            else if (ret < 0)
                                return ret;
                        }
                        if (out_grouping_b(g_v_j, 97, 232, false) != 0)
                        {
                            goto lab0;
                        }
                        // delete, line 116
                        slice_del();
                        break;
                }
            lab0: ; 
                cursor = limit - c1;
            }
            // do, line 120
            {
                int c2 = limit - cursor;
                {
                    // call e_ending, line 120
                    int ret = r_e_ending();
                    if (ret == 0)
                        goto lab1;
                    else if (ret < 0)
                        return ret;
                }
            lab1: ; 
                cursor = limit - c2;
            }
            // do, line 122
            {
                int c3 = limit - cursor;
                // (, line 122
                // [, line 122
                ket = cursor;
                // literal, line 122
                if (!(eq_s_b("heid")))
                {
                    goto lab2;
                }
                // ], line 122
                bra = cursor;
                {
                    // call R2, line 122
                    int ret = r_R2();
                    if (ret == 0)
                        goto lab2;
                    else if (ret < 0)
                        return ret;
                }
                // not, line 122
                {
                    int c4 = limit - cursor;
                    // literal, line 122
                    if (!(eq_s_b("c")))
                    {
                        goto lab3;
                    }
                    goto lab2;
                lab3: ; 
                    cursor = limit - c4;
                }
                // delete, line 122
                slice_del();
                // [, line 123
                ket = cursor;
                // literal, line 123
                if (!(eq_s_b("en")))
                {
                    goto lab2;
                }
                // ], line 123
                bra = cursor;
                {
                    // call en_ending, line 123
                    int ret = r_en_ending();
                    if (ret == 0)
                        goto lab2;
                    else if (ret < 0)
                        return ret;
                }
            lab2: ; 
                cursor = limit - c3;
            }
            // do, line 126
            {
                int c5 = limit - cursor;
                // (, line 126
                // [, line 127
                ket = cursor;
                // substring, line 127
                among_var = find_among_b(a_4);
                if (among_var == 0)
                {
                    goto lab4;
                }
                // ], line 127
                bra = cursor;
                switch (among_var) 
                {
                    case 0:
                        {
                            goto lab4;
                        }
                    case 1:
                        // (, line 129
                        {
                            // call R2, line 129
                            int ret = r_R2();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        // delete, line 129
                        slice_del();
                        // or, line 130
                        {
                            int c6 = limit - cursor;
                            // (, line 130
                            // [, line 130
                            ket = cursor;
                            // literal, line 130
                            if (!(eq_s_b("ig")))
                            {
                                goto lab6;
                            }
                            // ], line 130
                            bra = cursor;
                            {
                                // call R2, line 130
                                int ret = r_R2();
                                if (ret == 0)
                                    goto lab6;
                                else if (ret < 0)
                                    return ret;
                            }
                            // not, line 130
                            {
                                int c7 = limit - cursor;
                                // literal, line 130
                                if (!(eq_s_b("e")))
                                {
                                    goto lab7;
                                }
                                goto lab6;
                            lab7: ; 
                                cursor = limit - c7;
                            }
                            // delete, line 130
                            slice_del();
                            goto lab5;
                        lab6: ; 
                            cursor = limit - c6;
                            {
                                // call undouble, line 130
                                int ret = r_undouble();
                                if (ret == 0)
                                    goto lab4;
                                else if (ret < 0)
                                    return ret;
                            }
                        }
                    lab5: ; 
                        break;
                    case 2:
                        // (, line 133
                        {
                            // call R2, line 133
                            int ret = r_R2();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        // not, line 133
                        {
                            int c8 = limit - cursor;
                            // literal, line 133
                            if (!(eq_s_b("e")))
                            {
                                goto lab8;
                            }
                            goto lab4;
                        lab8: ; 
                            cursor = limit - c8;
                        }
                        // delete, line 133
                        slice_del();
                        break;
                    case 3:
                        // (, line 136
                        {
                            // call R2, line 136
                            int ret = r_R2();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        // delete, line 136
                        slice_del();
                        {
                            // call e_ending, line 136
                            int ret = r_e_ending();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        break;
                    case 4:
                        // (, line 139
                        {
                            // call R2, line 139
                            int ret = r_R2();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        // delete, line 139
                        slice_del();
                        break;
                    case 5:
                        // (, line 142
                        {
                            // call R2, line 142
                            int ret = r_R2();
                            if (ret == 0)
                                goto lab4;
                            else if (ret < 0)
                                return ret;
                        }
                        // Boolean test e_found, line 142
                        if (!(B_e_found))
                        {
                            goto lab4;
                        }
                        // delete, line 142
                        slice_del();
                        break;
                }
            lab4: ; 
                cursor = limit - c5;
            }
            // do, line 146
            {
                int c9 = limit - cursor;
                // (, line 146
                if (out_grouping_b(g_v_I, 73, 232, false) != 0)
                {
                    goto lab9;
                }
                // test, line 148
                {
                    int c10 = limit - cursor;
                    // (, line 148
                    // among, line 149
                    if (find_among_b(a_5) == 0)
                    {
                        goto lab9;
                    }
                    if (out_grouping_b(g_v, 97, 232, false) != 0)
                    {
                        goto lab9;
                    }
                    cursor = limit - c10;
                }
                // [, line 152
                ket = cursor;
                // next, line 152
                if (cursor <= limit_backward)
                {
                    goto lab9;
                }
                cursor--;
                // ], line 152
                bra = cursor;
                // delete, line 152
                slice_del();
            lab9: ; 
                cursor = limit - c9;
            }

            return 1;
        }

        private int stem()
        {
            // (, line 157
            // do, line 159
            {
                int c1 = cursor;
                {
                    // call prelude, line 159
                    int ret = r_prelude();
                    if (ret == 0)
                        goto lab0;
                    else if (ret < 0)
                        return ret;
                }
            lab0: ; 
                cursor = c1;
            }
            // do, line 160
            {
                int c2 = cursor;
                {
                    // call mark_regions, line 160
                    int ret = r_mark_regions();
                    if (ret == 0)
                        goto lab1;
                    else if (ret < 0)
                        return ret;
                }
            lab1: ; 
                cursor = c2;
            }
            // backwards, line 161
            limit_backward = cursor; cursor = limit;
            // do, line 162
            {
                int c3 = limit - cursor;
                {
                    // call standard_suffix, line 162
                    int ret = r_standard_suffix();
                    if (ret == 0)
                        goto lab2;
                    else if (ret < 0)
                        return ret;
                }
            lab2: ; 
                cursor = limit - c3;
            }
            cursor = limit_backward;
            // do, line 163
            {
                int c4 = cursor;
                {
                    // call postlude, line 163
                    int ret = r_postlude();
                    if (ret == 0)
                        goto lab3;
                    else if (ret < 0)
                        return ret;
                }
            lab3: ; 
                cursor = c4;
            }

            return 1;
        }

        /// <summary>
        ///   Stems the buffer's contents.
        /// </summary>
        /// 
        protected override bool Process()
        {
            return this.stem() > 0;
        }

    }
}

