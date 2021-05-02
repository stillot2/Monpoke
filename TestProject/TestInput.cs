using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    class TestInput
    {
        public enum TestIndex {
            VALID = 0,
            MORETEAMS = 1,
            LESSTEAMS = 2,
            INVALIDMONPOKEHP = 3,
            INVALIDMONPOKEAP = 4,
            EARLYCHOOSE = 5,
            LATECREATE = 6,
            INVALIDCHOOSE = 7,
            INVALIDATTACK = 8,
        };
        public string[] inputs =
        {
            "sample_input.txt",
            "more_teams.txt",
            "less_teams.txt",
            "invalid_hp.txt",
            "invalid_ap.txt",
            "early_choose.txt",
            "late_create.txt",
            "invalid_choose.txt",
            "invalid_attack.txt",
        };
    }
}
