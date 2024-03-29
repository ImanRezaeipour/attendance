using System;
using System.Collections.Generic;
using System.Linq;
using GTS.Clock.Model;


namespace GTS.Clock.Model.Concepts.Operations
{
    public static class Operation
    { 
        public static PairableScndCnpValue Intersect(BaseScndCnpValue Concept1, BaseScndCnpValue Concept2)
        {
            if (Concept1 != null && Concept2 != null)
            {
                var pairsResult = (from BB in
                                       (from A in ((PairableScndCnpValue)Concept1).Pairs
                                        from B in ((PairableScndCnpValue)Concept2).Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseScndCnpValue Concept1, BaseShift Concept2)
        {
            if (Concept1 != null && Concept2 != null && Concept1.Value != 0 && Concept2.Value != 0)
            {
                var pairsResult = (from BB in
                                       (from A in ((PairableScndCnpValue)Concept1).Pairs
                                        from B in Concept2.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(PairableScndCnpValue Concept1, PairableScndCnpValue Concept2)
        {
            if (Concept1 != null && Concept2 != null)
            {
                var pairsResult = (from BB in
                                       (from A in ((PairableScndCnpValue)Concept1).Pairs
                                        from B in ((PairableScndCnpValue)Concept2).Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseScndCnpValue Concept1, PairableScndCnpValuePair Pair)
        {
            if (Concept1 != null && Pair != null)
            {
                IList<IPair> tmp = new List<IPair>();
                tmp.Add(Pair);
                var pairsResult = (from BB in
                                       (from A in ((PairableScndCnpValue)Concept1).Pairs
                                        from B in tmp
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(PairableScndCnpValuePair Pair1, PairableScndCnpValuePair Pair2)
        {
            if (Pair1 != null && Pair2 != null )
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2.Add(Pair2);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(ShiftPair Pair1, PairableScndCnpValuePair Pair2)
        {
            if (Pair1 != null && Pair2 != null)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2.Add(Pair2);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(ProceedTrafficPair Pair1, ShiftPair Pair2)
        {
            if (Pair1 != null && Pair2 != null)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2.Add(Pair2);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseShift shift, PairableScndCnpValuePair pairableScndCnpValuePair)
        {
            if (shift != null && pairableScndCnpValuePair != null)
            {
                IList<IPair> tmp = new List<IPair>();
                tmp.Add(pairableScndCnpValuePair);
                var pairsResult = (from BB in
                                       (from A in shift.Pairs
                                        from B in tmp
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseShift shift, ProceedTraffic proceedTraffic)
        {
            if (shift != null && proceedTraffic != null && proceedTraffic.PairCount != 0)
            {
                var pairsResult = (from BB in
                                       (from A in shift.Pairs
                                        from B in proceedTraffic.Pairs.Where(x => x.IsFilled)
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseShift shift, ProceedTrafficPair pair)
        {
            if (shift != null && pair != null)
            {
                IList<IPair> tmp = new List<IPair>();
                tmp.Add(pair);
                var pairsResult = (from BB in
                                       (from A in shift.Pairs
                                        from B in tmp
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseShift shift, BaseScndCnpValue Concept2)
        {
            if (shift != null && Concept2 != null && Concept2.Value != 0)
            {
                var pairsResult = (from BB in
                                       (from A in shift.Pairs
                                        from B in ((PairableScndCnpValue)Concept2).Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseShift shift, IList<IPair> PairList)
        {
            if (shift != null && PairList != null && PairList.Count != 0)
            {
                var pairsResult = (from BB in
                                       (from A in shift.Pairs
                                        from B in PairList
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IList<IPair> PairList, ProceedTrafficPair pair)
        {
            if (PairList != null && pair != null)
            {
                IList<IPair> tmp = new List<IPair>();
                tmp.Add(pair);
                var pairsResult = (from BB in
                                       (from A in PairList
                                        from B in tmp
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IList<IPair> PairList, IPairableConceptValue<IPair> Concept1)
        {
            if (PairList != null && Concept1 != null && Concept1.PairValues != 0 )
            {
                var pairsResult = (from BB in
                                       (from A in PairList
                                        from B in Concept1.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }        
        public static PairableScndCnpValue Intersect(IList<IPair> PairList, ProceedTraffic Concept1)
        {
            if (PairList != null && Concept1 != null && Concept1.PairValues != 0)
            {
                var pairsResult = (from BB in
                                       (from A in PairList
                                        from B in Concept1.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IList<IPair> PairList1, IList<IPair> PairList2)
        {
            if (PairList1 != null && PairList2 != null)
            {
                var pairsResult = (from BB in
                                       (from A in PairList1
                                        from B in PairList2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, BaseShift shift)
        {
            if (Pair1 != null && shift != null && shift.PairCount > 0)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in shift.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, ProceedTraffic proceedTraffic)
        {
            if (Pair1 != null && proceedTraffic != null && proceedTraffic.PairCount > 0)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in proceedTraffic.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, IList<IPair> PairList)
        {
            
           
            if (Pair1 != null && PairList != null && PairList.Count > 0)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in PairList
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, BaseScndCnpValue Concept2)
        {
            if (Pair1 != null && Concept2 != null && ((PairableScndCnpValue)Concept2).PairCount > 0)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2 = ((PairableScndCnpValue)Concept2).Pairs;

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, IPair Pair2)
        {
            if (Pair1 != null && Pair2 != null)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2.Add(Pair2);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, ShiftPair Pair2)
        {
            if (Pair1 != null && Pair2 != null)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<IPair> tmp2 = new List<IPair>();
                tmp2.Add(Pair2);

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(BaseScndCnpValue Concept1, ProceedTraffic Concept2)
        {
            if (Concept1 != null && Concept2 != null)
            {
                var pairsResult = (from BB in
                                       (from A in ((PairableScndCnpValue)Concept1).Pairs
                                        from B in Concept2.Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(Permit permit1, BaseScndCnpValue Concept1)
        {
            if (permit1 != null && Concept1 != null)
            {
                var pairsResult = (from BB in
                                       (from A in permit1.Pairs
                                        from B in ((PairableScndCnpValue)Concept1).Pairs
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Intersect(IPair Pair1, Permit Permit1)
        {
            if (Pair1 != null && Permit1 != null)
            {
                IList<IPair> tmp1 = new List<IPair>();
                tmp1.Add(Pair1);
                IList<PermitPair> tmp2 = new List<PermitPair>();
                tmp2 = Permit1.Pairs;

                var pairsResult = (from BB in
                                       (from A in tmp1
                                        from B in tmp2
                                        select new PairableScndCnpValuePair(Math.Max(A.From, B.From), Math.Min(A.To, B.To)))
                                   where BB.From < BB.To
                                   select BB);
                return new PairableScndCnpValue(pairsResult.OfType<IPair>().ToList<IPair>());
            }
            return new PairableScndCnpValue();
        }

        public static PairableScndCnpValue Differance(IList<IPair> PairList, BaseScndCnpValue Concept2)
        {
            if ((PairList != null && Concept2 != null) &&
                    PairList.Count != 0 && ((PairableScndCnpValue)Concept2).PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = (from A in PairList
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in ((PairableScndCnpValue)Concept2).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, Concept2);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First State
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (PairList != null && PairList.Count != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (IPair pair in PairList)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue Concept1, BaseScndCnpValue Concept2)
        {
            if ((Concept1 != null && Concept2 != null) &&
                    ((PairableScndCnpValue)Concept1).PairCount != 0 && ((PairableScndCnpValue)Concept2).PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = (from A in ((PairableScndCnpValue)Concept1).Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in ((PairableScndCnpValue)Concept2).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, Concept2);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First State
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (Concept1 != null && ((PairableScndCnpValue)Concept1).PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (IPair pair in ((PairableScndCnpValue)Concept1).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(BaseShift categorisedShift, BaseScndCnpValue baseScndCnpValue)
        {
            if ((categorisedShift != null && baseScndCnpValue != null) &&
                 (categorisedShift.PairCount != 0 && ((PairableScndCnpValue)baseScndCnpValue).PairCount != 0))
            {
                bool neededIntersect = false;
                var q1 = (from A in categorisedShift.Pairs 
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in ((PairableScndCnpValue)baseScndCnpValue).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, baseScndCnpValue);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (categorisedShift != null && categorisedShift.PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (ShiftPair pair in categorisedShift.Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(PairableScndCnpValuePair pair, BaseShift shift)
        {
            if ((shift != null && pair != null) &&
                    shift.PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = pair;
                var q2 = (from B in shift.Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                neededIntersect = false;
                foreach (var B in q2)
                {
                    PairableScndCnpValue anySimilarity = Operation.Intersect(pair, B);
                    if (anySimilarity.PairCount != 0)
                    {

                        if (q1.From < B.From && q1.To > B.To) // First STote
                        {
                            TempList.AppendPair(new PairableScndCnpValuePair(q1.From, B.From));
                            TempList.AppendPair(new PairableScndCnpValuePair(B.To, q1.To));
                        }

                        if (q1.From < B.From && q1.To <= B.To && B.From < q1.To) // Second State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(q1.From, B.From));
                        }


                        if (q1.From >= B.From && q1.To > B.To && q1.From < B.To) // Third State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(B.To, q1.To));
                        }

                        if (q1.From >= B.From && q1.To <= B.To)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        TempList.AddPair(q1);
                    }

                    if (TempList.Pairs.Count != 0)
                    {
                        if (neededIntersect || List1.Pairs.Count > 0)
                        {

                            List1 = Intersect(List1, TempList);
                            TempList.Pairs.Clear();
                        }
                        else
                        {
                            foreach (IPair item in TempList.Pairs)
                                List1.AppendPair(item);
                            TempList.Pairs.Clear();
                        }
                        neededIntersect = true;
                    }

                }
                foreach (IPair item in List1.Pairs)
                    myList.AppendPair(item);
                List1.Pairs.Clear();

                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (pair != null)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();

                    tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));

                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(IPair pair, BaseScndCnpValue Concept1)
        {
            if ((Concept1 != null && pair != null) &&
                    ((PairableScndCnpValue)Concept1).PairCount != 0)
            {
                IList<IPair> l1 = new List<IPair>();
                l1.Add(pair);
                return Differance(l1, ((PairableScndCnpValue)Concept1).Pairs);
            }
            else 
            {
                PairableScndCnpValue tmp = new PairableScndCnpValue();
                if (pair != null) 
                {                    
                    tmp.Pairs.Add(pair);
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
                tmp.Value = tmp.PairValues;
                return tmp;
            }
               
        }
        public static PairableScndCnpValue Differance(IPair pair, BaseShift shift)
        {
            if ((shift != null && pair != null) &&
                    shift.PairCount != 0)
            {
                IList<IPair> l1 = new List<IPair>();
                l1.Add(pair);
                IList<IPair> l2 = new List<IPair>();
                foreach (IPair p in shift.Pairs)
                {
                    l2.Add(p);
                }
                return Differance(l1, l2);
            }
            else
            {
                PairableScndCnpValue tmp = new PairableScndCnpValue();
                if (pair != null)
                {
                    tmp.Pairs.Add(pair);
                    return tmp;
                }
                tmp.Value = tmp.PairValues;
                return tmp;
            }

        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue baseScndCnpValue, BaseShift shift)
        {
            if ((shift != null && baseScndCnpValue != null) &&
                    (shift.PairCount != 0 && ((PairableScndCnpValue)baseScndCnpValue).PairCount != 0))
            {              
                bool neededIntersect = false;
                var q1 = (from A in ((PairableScndCnpValue)baseScndCnpValue).Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in shift.Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, shift);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (baseScndCnpValue != null && ((PairableScndCnpValue)baseScndCnpValue).PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (PairableScndCnpValuePair pair in ((PairableScndCnpValue)baseScndCnpValue).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue baseScndCnpValue, ShiftPair shiftPair)
        {
            if ((shiftPair != null && baseScndCnpValue != null) &&
                    (((PairableScndCnpValue)baseScndCnpValue).PairCount != 0))
            {
                bool neededIntersect = false;
                var q1 = (from A in ((PairableScndCnpValue)baseScndCnpValue).Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);              

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;

                    PairableScndCnpValue anySimilarity = Operation.Intersect(A, shiftPair);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < shiftPair.From && A.To > shiftPair.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, shiftPair.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(shiftPair.To, A.To));
                            }

                            if (A.From < shiftPair.From && A.To <= shiftPair.To && shiftPair.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, shiftPair.From));
                            }


                            if (A.From >= shiftPair.From && A.To > shiftPair.To && A.From < shiftPair.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(shiftPair.To, A.To));
                            }

                            if (A.From >= shiftPair.From && A.To <= shiftPair.To)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }                  

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (baseScndCnpValue != null && ((PairableScndCnpValue)baseScndCnpValue).PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (PairableScndCnpValuePair pair in ((PairableScndCnpValue)baseScndCnpValue).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue baseScndCnpValue, IPair _pair)
        {
            if ((_pair != null && baseScndCnpValue != null) &&
                    (((PairableScndCnpValue)baseScndCnpValue).PairCount != 0))
            {
                bool neededIntersect = false;
                var q1 = (from A in ((PairableScndCnpValue)baseScndCnpValue).Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;

                    PairableScndCnpValue anySimilarity = Operation.Intersect(A, _pair);
                    if (anySimilarity.PairCount != 0)
                    {

                        if (A.From < _pair.From && A.To > _pair.To) // First STote
                        {
                            TempList.AppendPair(new PairableScndCnpValuePair(A.From, _pair.From));
                            TempList.AppendPair(new PairableScndCnpValuePair(_pair.To, A.To));
                        }

                        if (A.From < _pair.From && A.To <= _pair.To && _pair.From < A.To) // Second State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(A.From, _pair.From));
                        }


                        if (A.From >= _pair.From && A.To > _pair.To && A.From < _pair.To) // Third State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(_pair.To, A.To));
                        }

                        if (A.From >= _pair.From && A.To <= _pair.To)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        TempList.AddPair(A);
                    }

                    if (TempList.Pairs.Count != 0)
                    {
                        if (neededIntersect || List1.Pairs.Count > 0)
                        {

                            List1 = Intersect(List1, TempList);
                            TempList.Pairs.Clear();
                        }
                        else
                        {
                            foreach (IPair item in TempList.Pairs)
                                List1.AppendPair(item);
                            TempList.Pairs.Clear();
                        }
                        neededIntersect = true;
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (baseScndCnpValue != null && ((PairableScndCnpValue)baseScndCnpValue).PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (PairableScndCnpValuePair pair in ((PairableScndCnpValue)baseScndCnpValue).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(BaseShift shift, ProceedTraffic proceedTraffic)
        {
            if ((shift != null && proceedTraffic != null) &&
                    shift.PairCount != 0 && proceedTraffic.PairCount != 0 )
            {
                if (proceedTraffic.Pairs.Where(x => x.IsFilled).Count() == 0)
                {
                    return new PairableScndCnpValue();
                }
                bool neededIntersect = false;
                var q1 = (from A in shift.Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in proceedTraffic.Pairs.Where(p => p.IsFilled == true)
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)


                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, proceedTraffic);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (shift != null && shift.PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (ShiftPair pair in shift.Pairs)
                    {
                        tmp.AppendPair(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();          
        }
        public static PairableScndCnpValue Differance(BaseShift shift, IList<IPair> PairList)
        {
            if ((shift != null && PairList != null) &&
                    shift.PairCount != 0 && PairList.Count != 0)
            {               
                bool neededIntersect = false;
                var q1 = (from A in shift.Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in PairList
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)


                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, PairList);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (shift != null && shift.PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (ShiftPair pair in shift.Pairs)
                    {
                        tmp.AppendPair(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(IList<IPair> PairList, BaseShift shift)
        {
            if ((shift != null && PairList != null) &&
                    shift.PairCount != 0)
            {               
                IList<IPair> l2 = new List<IPair>();
                foreach (IPair p in shift.Pairs)
                {
                    l2.Add(p);
                }
                return Differance(PairList , l2);
            }
            else
            {
                PairableScndCnpValue tmp = new PairableScndCnpValue();
                if (PairList != null)
                {
                   
                    foreach (IPair pair in PairList)
                    {
                        tmp.Pairs.Add(pair);
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
                return tmp;
            }

        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue Concept1, IList<IPair> PairList)
        {
            if ((PairList != null && Concept1 != null) &&
                    PairList.Count != 0 && ((PairableScndCnpValue)Concept1).PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = (from B in ((PairableScndCnpValue)Concept1).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from A in PairList
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, PairList);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First State
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (Concept1 != null && ((PairableScndCnpValue)Concept1).Pairs.Count != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (IPair pair in ((PairableScndCnpValue)Concept1).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(IPair l1, IPair l2)
        {

            bool neededIntersect = false;
            var A = l1;
            var B = l2;

            PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
            PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
            PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)


            neededIntersect = false;

            PairableScndCnpValue anySimilarity = Operation.Intersect((ProceedTrafficPair)l2, A);
            if (anySimilarity.PairCount != 0)
            {

                if (A.From < B.From && A.To > B.To) // First STote
                {
                    TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                    TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                }

                if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                {
                    TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                }


                if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                {
                    TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                }

                if (A.From >= B.From && A.To <= B.To)
                {
                    TempList.ClearPairs();
                }
            }
            else
            {
                TempList.AddPair(A);
            }

            if (TempList.Pairs.Count != 0)
            {
                if (neededIntersect || List1.Pairs.Count > 0)
                {

                    List1 = Intersect(List1, TempList);
                    TempList.Pairs.Clear();
                }
                else
                {
                    foreach (IPair item in TempList.Pairs)
                        List1.AppendPair(item);
                    TempList.Pairs.Clear();
                }
                neededIntersect = true;
            }


            foreach (IPair item in List1.Pairs)
                myList.AppendPair(item);
            List1.Pairs.Clear();

            myList.Value = myList.PairValues;
            return myList;

        }
        private static PairableScndCnpValue Differance(IList<IPair> l1, IList<IPair> l2)
        {

            bool neededIntersect = false;
            var q1 = (from A in l1
                      select A).OrderBy(t => t.From).ThenBy(t => t.To);
            var q2 = (from B in l2
                      select B).OrderBy(t => t.From).ThenBy(t => t.To);

            PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
            PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
            PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

            foreach (var A in q1)
            {
                neededIntersect = false;
                foreach (var B in q2)
                {
                    IList<IPair> tmp = new List<IPair>();
                    tmp.Add(A);
                    PairableScndCnpValue anySimilarity = Operation.Intersect(l2, tmp);
                    if (anySimilarity.PairCount != 0)
                    {
                        if (A.From < B.From && A.To > B.To) // First STote
                        {
                            TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                            TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                        }

                        if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                        }


                        if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                        {
                            TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                        }

                        if (A.From >= B.From && A.To <= B.To)
                        {
                            break;
                        }
                    }
                    else
                    {
                        TempList.AddPair(A);
                    }

                    if (TempList.Pairs.Count != 0)
                    {
                        if (neededIntersect || List1.Pairs.Count > 0)
                        {

                            List1 = Intersect(List1, TempList);
                            TempList.Pairs.Clear();
                        }
                        else
                        {
                            foreach (IPair item in TempList.Pairs)
                                List1.AppendPair(item);
                            TempList.Pairs.Clear();
                        }
                        neededIntersect = true;
                    }
                }

                foreach (IPair item in List1.Pairs)
                    myList.AppendPair(item);
                List1.Pairs.Clear();
            }
            myList.Value = myList.PairValues;
            return myList;

        }
        public static PairableScndCnpValue Differance(BaseScndCnpValue Concept1, Permit Permit1)
        {
            if ((Permit1 != null && Concept1 != null) &&
                    Permit1.Pairs.Count != 0 && ((PairableScndCnpValue)Concept1).PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = (from B in ((PairableScndCnpValue)Concept1).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from A in Permit1.Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, Permit1);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First State
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (Concept1 != null && ((PairableScndCnpValue)Concept1).Pairs.Count != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (IPair pair in ((PairableScndCnpValue)Concept1).Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(Permit Permit1, BaseScndCnpValue Concept2)
        {
            if ((Permit1 != null && Concept2 != null) &&
                    Permit1.PairCount != 0 && ((PairableScndCnpValue)Concept2).PairCount != 0)
            {
                bool neededIntersect = false;
                var q1 = (from A in Permit1.Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in ((PairableScndCnpValue)Concept2).Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, Concept2);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First State
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (Permit1 != null && Permit1.PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (PermitPair pair in Permit1.Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }
        public static PairableScndCnpValue Differance(Permit permit1, BaseShift shift)
        {
            if ((shift != null && permit1 != null) &&
                    (shift.PairCount != 0 && permit1.PairCount != 0))
            {
                bool neededIntersect = false;
                var q1 = (from A in permit1.Pairs
                          select A).OrderBy(t => t.From).ThenBy(t => t.To);
                var q2 = (from B in shift.Pairs
                          select B).OrderBy(t => t.From).ThenBy(t => t.To);

                PairableScndCnpValue myList = new PairableScndCnpValue(); //Main List
                PairableScndCnpValue List1 = new PairableScndCnpValue(); //Stors continious items of q2 (items of an specific area)
                PairableScndCnpValue TempList = new PairableScndCnpValue(); //Stors Current items of q2 (if it is in one of the areas)

                foreach (var A in q1)
                {
                    neededIntersect = false;
                    foreach (var B in q2)
                    {
                        PairableScndCnpValue anySimilarity = Operation.Intersect(A, shift);
                        if (anySimilarity.PairCount != 0)
                        {

                            if (A.From < B.From && A.To > B.To) // First STote
                            {
                                TempList.AppendPair(new PairableScndCnpValuePair(A.From, B.From));
                                TempList.AppendPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From < B.From && A.To <= B.To && B.From < A.To) // Second State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(A.From, B.From));
                            }


                            if (A.From >= B.From && A.To > B.To && A.From < B.To) // Third State
                            {
                                TempList.AddPair(new PairableScndCnpValuePair(B.To, A.To));
                            }

                            if (A.From >= B.From && A.To <= B.To)
                            {
                                break;
                            }
                        }
                        else
                        {
                            TempList.AddPair(A);
                        }

                        if (TempList.Pairs.Count != 0)
                        {
                            if (neededIntersect || List1.Pairs.Count > 0)
                            {

                                List1 = Intersect(List1, TempList);
                                TempList.Pairs.Clear();
                            }
                            else
                            {
                                foreach (IPair item in TempList.Pairs)
                                    List1.AppendPair(item);
                                TempList.Pairs.Clear();
                            }
                            neededIntersect = true;
                        }
                    }

                    foreach (IPair item in List1.Pairs)
                        myList.AppendPair(item);
                    List1.Pairs.Clear();
                }
                myList.Value = myList.PairValues;
                return myList;
            }
            else
            {
                if (permit1 != null && permit1.PairCount != 0)
                {
                    PairableScndCnpValue tmp = new PairableScndCnpValue();
                    foreach (PermitPair pair in permit1.Pairs)
                    {
                        tmp.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To));
                    }
                    tmp.Value = tmp.PairValues;
                    return tmp;
                }
            }
            return new PairableScndCnpValue();
        }

        public static PairableScndCnpValue Union(IPair Pair1, IList<IPair> PairList)
        {
            IList<IPair> result = new List<IPair>();
            if (PairList.Count > 0)
            {
                foreach (IPair pair in PairList)
                {
                    if (Operation.Intersect(Pair1, pair).PairValues > 0)
                    {
                        PairableScndCnpValuePair tmpPair = new PairableScndCnpValuePair(Math.Min(pair.From, Pair1.From),
                                                                                         Math.Max(pair.To, Pair1.To));
                        if (result.Count > 0)
                        {
                            foreach (IPair resultPair in result)
                            {
                                if (Operation.Intersect(resultPair, tmpPair).PairValues > 0)
                                {
                                    result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, tmpPair.From),
                                                                             Math.Max(resultPair.To, tmpPair.To)));
                                }
                            }
                        }
                        else
                            result.Add(tmpPair);
                    }
                    else
                    {
                        if (result.Count > 0)
                        {
                            foreach (IPair resultPair in result)
                            {
                                if (Operation.Intersect(resultPair, Pair1).PairValues > 0)
                                {
                                    result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, Pair1.From),
                                                                             Math.Max(resultPair.To, Pair1.To)));
                                    result.Remove(resultPair);
                                }
                            }
                            foreach (IPair resultPair in result)
                            {
                                if (Operation.Intersect(resultPair, pair).PairValues > 0)
                                {
                                    result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, pair.From),
                                                                             Math.Max(resultPair.To, pair.To)));
                                    result.Remove(resultPair);
                                }
                            }
                        }
                        else
                            result.Add(pair);
                    }
                }
            }
            else
                result.Add(Pair1);

            return new PairableScndCnpValue(result);
        }
        public static PairableScndCnpValue Union(PairableScndCnpValue Concept1, PairableScndCnpValue Concept2)
        {
            List<IPair> tmpList = new List<IPair>();
            if (Concept1 != null && Concept2 != null)
            {
                #region Comment
                //foreach (IPair pair1 in Concept1.Pairs)
                //{
                //    foreach (IPair pair2 in Concept2.Pairs)
                //    {
                //        if (Operation.Intersect(pair1, pair2).PairValues > 0)
                //        {
                //            PairableScndCnpValuePair tmpPair = new PairableScndCnpValuePair(Math.Min(pair1.From, pair2.From),
                //                                                                             Math.Max(pair1.To, pair2.To));
                //            if (result.Count > 0)
                //            {
                //                foreach (IPair resultPair in result)
                //                {
                //                    if (Operation.Intersect(resultPair, tmpPair).PairValues > 0)
                //                    {
                //                        result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, tmpPair.From),
                //                                                                 Math.Max(resultPair.To, tmpPair.To)));
                //                    }
                //                    else
                //                    {
                //                        result.Add(tmpPair);
                //                    }
                //                }
                //            }
                //            else
                //                result.Add(tmpPair);
                //        }
                //        else
                //        {
                //            if (result.Count > 0)
                //            {
                //                foreach (IPair resultPair in result)
                //                {
                //                    if (Operation.Intersect(resultPair, pair2).PairValues > 0)
                //                    {
                //                        result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, pair2.From),
                //                                                                 Math.Max(resultPair.To, pair2.To)));
                //                    }
                //                    else
                //                    {
                //                        result.Add(pair2);
                //                    }
                //                }
                //            }
                //            else
                //                result.Add(pair2);
                //        }
                //    }
                //    //pair1
                //    if (result.Count > 0)
                //    {
                //        foreach (IPair resultPair in result)
                //        {
                //            if (Operation.Intersect(resultPair, pair1).PairValues > 0)
                //            {
                //                result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, pair1.From),
                //                                                         Math.Max(resultPair.To, pair1.To)));
                //            }
                //            else
                //            {
                //                result.Add(pair1);
                //            }
                //        }
                //    }
                //    else
                //        result.Add(pair1);
                //} 
                #endregion
                                
                IList<IPair> list1 = Union(Concept1.Pairs);
                IList<IPair> list2 = Union(Concept2.Pairs);
               
                tmpList.AddRange(list1);
                tmpList.AddRange(list2);
                tmpList = Union(tmpList).ToList();   
            }

            return new PairableScndCnpValue(tmpList);
        }     
        public static IList<IPair> Union(IList<IPair> pairs) 
        {
            List<IPair> result = new List<IPair>();
            List<IPair> list1 = pairs.OrderBy(x => x.From).ThenBy(x => x.To)
                .Where(x => x.From != -1000 && x.To != -1000).ToList();
            int i = 0, j = 0;
            while (i < list1.Count)
            {
                while (j < list1.Count && list1[j].From <= list1[i].To)
                {
                    j++;
                }

                IPair thePair = new PairableScndCnpValuePair(list1[i].From, Math.Max(list1[i].To, list1[j - 1].To));
                result.Add(thePair);
                i = j;
            }
            return result;
        }
        public static IList<PermitPair> Union(IList<PermitPair> pairs)
        {
            List<PermitPair> result = new List<PermitPair>();
            List<PermitPair> list1 = pairs.OrderBy(x => x.From).ThenBy(x => x.To)
                .Where(x => x.From != -1000 && x.To != -1000).ToList();
            int i = 0, j = 0;
            while (i < list1.Count)
            {
                while (j < list1.Count && list1[j].From <= list1[i].To)
                {
                    j++;
                }

                PermitPair thePair = new PermitPair(list1[i].From, Math.Max(list1[i].To, list1[j - 1].To));
                thePair.Value = thePair.To - thePair.From;
                result.Add(thePair);
                i = j;
            }
            return result;
        }
        public static PairableScndCnpValue Union(PairableScndCnpValue Concept1)
        {
            List<IPair> result = new List<IPair>();
            List<IPair> list1 = Concept1.Pairs.OrderBy(x => x.From).ThenBy(x => x.To)
                .Where(x => x.From != -1000 && x.To != -1000).ToList();
            int i = 0, j = 0;
            while (i < list1.Count)
            {
                while (j < list1.Count && list1[j].From <= list1[i].To)
                {
                    j++;
                }

                IPair thePair = new PairableScndCnpValuePair(list1[i].From, Math.Max(list1[i].To, list1[j - 1].To));
                result.Add(thePair);
                i = j;
            }
            Concept1.ClearPairs();           
            foreach (IPair pair in result) 
            {
                Concept1.Pairs.Add(pair);
            }
            Concept1.Value = Concept1.PairValues;
            return Concept1;
        }
        public static PairableScndCnpValue Union(BaseScndCnpValue Concept1, BaseScndCnpValue Concept2)
        {
            List<IPair> tmpList = new List<IPair>();
            if (Concept1 != null && Concept2 != null)
            {
                #region Comment
                //foreach (IPair pair1 in Concept1.Pairs)
                //{
                //    foreach (IPair pair2 in Concept2.Pairs)
                //    {
                //        if (Operation.Intersect(pair1, pair2).PairValues > 0)
                //        {
                //            PairableScndCnpValuePair tmpPair = new PairableScndCnpValuePair(Math.Min(pair1.From, pair2.From),
                //                                                                             Math.Max(pair1.To, pair2.To));
                //            if (result.Count > 0)
                //            {
                //                foreach (IPair resultPair in result)
                //                {
                //                    if (Operation.Intersect(resultPair, tmpPair).PairValues > 0)
                //                    {
                //                        result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, tmpPair.From),
                //                                                                 Math.Max(resultPair.To, tmpPair.To)));
                //                    }
                //                    else
                //                    {
                //                        result.Add(tmpPair);
                //                    }
                //                }
                //            }
                //            else
                //                result.Add(tmpPair);
                //        }
                //        else
                //        {
                //            if (result.Count > 0)
                //            {
                //                foreach (IPair resultPair in result)
                //                {
                //                    if (Operation.Intersect(resultPair, pair2).PairValues > 0)
                //                    {
                //                        result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, pair2.From),
                //                                                                 Math.Max(resultPair.To, pair2.To)));
                //                    }
                //                    else
                //                    {
                //                        result.Add(pair2);
                //                    }
                //                }
                //            }
                //            else
                //                result.Add(pair2);
                //        }
                //    }
                //    //pair1
                //    if (result.Count > 0)
                //    {
                //        foreach (IPair resultPair in result)
                //        {
                //            if (Operation.Intersect(resultPair, pair1).PairValues > 0)
                //            {
                //                result.Add(new PairableScndCnpValuePair(Math.Min(resultPair.From, pair1.From),
                //                                                         Math.Max(resultPair.To, pair1.To)));
                //            }
                //            else
                //            {
                //                result.Add(pair1);
                //            }
                //        }
                //    }
                //    else
                //        result.Add(pair1);
                //} 
                #endregion

                IList<IPair> list1 = Union(((PairableScndCnpValue)Concept1).Pairs);
                IList<IPair> list2 = Union(((PairableScndCnpValue)Concept2).Pairs);

                tmpList.AddRange(list1);
                tmpList.AddRange(list2);
                tmpList = Union(tmpList).ToList();
            }

            return new PairableScndCnpValue(tmpList);
        }     


        public static int Minimum(int value1, int value2, int value3)
        {
            return Math.Min(Math.Min(value1, value2), value3);
        }
        public static int Minimum(int value1, int value2)
        {
            return Math.Min(value1, value2);
        }

        public static int Maximum(int value1, int value2, int value3)
        {
            return Math.Max(Math.Max(value1, value2), value3);
        }
        public static int Maximum(int value1, int value2)
        {
            return Math.Max(value1, value2);
        }

    }
}
