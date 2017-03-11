﻿/*
 * MIT License
 * 
 * Copyright (c) [2017] [Travis Offtermatt]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using ChangeDresser.UI.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using Verse;
using Verse.AI;

namespace ChangeDresser
{
    class Building_ChangeMirror : Building
    {
        private JobDef changeApparelColorJobDef = DefDatabase<JobDef>.GetNamed("ChangeApparelColor", true);
        private JobDef changeHairStyleJobDef = DefDatabase<JobDef>.GetNamed("ChangeHairStyle", true);
        private JobDef changeSkinColorJobDef = DefDatabase<JobDef>.GetNamed("ChangeSkinColor", true);
        private JobDef changeHeadTypeJobDef = DefDatabase<JobDef>.GetNamed("ChangeHeadType", true);

        public readonly List<CurrentEditorEnum> SupportedEditors = new List<CurrentEditorEnum>();

        public override void SpawnSetup(Map map)
        {
            base.SpawnSetup(map);

            SupportedEditors.Add(CurrentEditorEnum.ApparelColor);
            SupportedEditors.Add(CurrentEditorEnum.Hair);
            SupportedEditors.Add(CurrentEditorEnum.HeadType);
            SupportedEditors.Add(CurrentEditorEnum.SkinColor);
        }

        [DebuggerHidden]
        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn myPawn)
        {
            List<FloatMenuOption> list = new List<FloatMenuOption>();
            if (myPawn.apparel.WornApparel.Count > 0)
            {
                list.Add(new FloatMenuOption(
                    "Change outfit's colors",
                    delegate
                    {
                        Job job = new Job(this.changeApparelColorJobDef, this);
                        myPawn.jobs.TryTakeOrderedJob(job);
                    }));
            }
            
            list.Add(new FloatMenuOption(
                "Change hair style",
                delegate
                {
                    Job job = new Job(this.changeHairStyleJobDef, this);
                    myPawn.jobs.TryTakeOrderedJob(job);
                }));

            list.Add(new FloatMenuOption(
                "Change skin color",
                delegate
                {
                    Job job = new Job(this.changeSkinColorJobDef, this);
                    myPawn.jobs.TryTakeOrderedJob(job);
                }));

            list.Add(new FloatMenuOption(
                "Change head type",
                delegate
                {
                    Job job = new Job(this.changeHeadTypeJobDef, this);
                    myPawn.jobs.TryTakeOrderedJob(job);
                }));
            return list;
        }
    }
}