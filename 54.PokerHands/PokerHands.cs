namespace _54.PokerHands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;


    public class PokerHands
    {
        public static bool IsRoyalFlush(string[] hand, Dictionary<char, int> weights)
        {
            if ((hand[0][0] == 'T') && (hand[1][0] == 'J') && (hand[2][0] == 'Q')
                && (hand[3][0] == 'K') && (hand[4][0] == 'A') &&
                (hand[0][1] == hand[1][1]) && (hand[1][1] == hand[2][1]) && (hand[2][1] == hand[3][1])
                && (hand[3][1] == hand[4][1]))
            {
                return true;
            }
            return false;
        }

        public static bool IsStraightFlush(string[] hand, Dictionary<char, int> weights)
        {
            int firstCardWeight = weights[hand[0][0]];
            bool isStraightFlush = true;
            for (int i = 1; i < hand.Length; i++)
            {
                isStraightFlush = isStraightFlush && ((firstCardWeight + i) == weights[hand[i][0]]);
            }
            if ((hand[0][1] == hand[1][1]) && (hand[1][1] == hand[2][1]) && (hand[2][1] == hand[3][1])
                && (hand[3][1] == hand[4][1]))
            {
                return isStraightFlush && !IsRoyalFlush(hand, weights);
            }
            return false;
        }

        public static bool IsOnePair(string[] hand)
        {
            if ((hand[0][0] == hand[1][0]) ^ (hand[1][0] == hand[2][0]) ^ (hand[2][0] == hand[3][0])
                ^ (hand[3][0] == hand[4][0]))
            {
                return true;
            }
            return false;
        }

        public static bool IsThreeOfAKind(string[] hand)
        {
            if (((hand[0][0] == hand[1][0]) && (hand[1][0] == hand[2][0])) ^
                ((hand[1][0] == hand[2][0]) && (hand[2][0] == hand[3][0])) ^
                ((hand[2][0] == hand[3][0]) && (hand[3][0] == hand[4][0])))
            {
                return true;
            }
            return false;
        }

        public static bool IsFourOfAKind(string[] hand)
        {
            if (((hand[0][0] == hand[1][0]) && (hand[1][0] == hand[2][0]) && (hand[2][0] == hand[3][0])) ^
                ((hand[1][0] == hand[2][0]) && (hand[2][0] == hand[3][0]) && (hand[3][0] == hand[4][0])))
            {
                return true;
            }
            return false;
        }

        public static bool IsTwoPairs(string[] hand)
        {
            if (((hand[0][0] == hand[1][0]) && (hand[2][0] == hand[3][0])) ^
                ((hand[0][0] == hand[1][0]) && (hand[3][0] == hand[4][0])) ^
                ((hand[1][0] == hand[2][0]) && (hand[3][0] == hand[4][0])))
            {
                return true;
            }
            return false;
        }

        public static bool IsStraight(string[] hand, Dictionary<char, int> weights)
        {

            int firstCardWeight = weights[hand[0][0]];
            bool isStraight = true;
            for (int i = 1; i < hand.Length; i++)
            {
                isStraight = isStraight && ((firstCardWeight + i) == weights[hand[i][0]]);
            }
            return isStraight;
        }

        public static bool IsFlush(string[] hand)
        {
            if ((hand[0][1] == hand[1][1]) && (hand[1][1] == hand[2][1]) && (hand[2][1] == hand[3][1])
                && (hand[3][1] == hand[4][1]))
            {
                return true;
            }
            return false;
        }

        public static bool IsFullHouse(string[] hand)
        {
            if (((hand[0][0] == hand[1][0]) && (hand[1][0] == hand[2][0]) && (hand[3][0] == hand[4][0])) ^
                ((hand[0][0] == hand[1][0]) && (hand[2][0] == hand[3][0]) && (hand[3][0] == hand[4][0])))
            {
                return true;
            }
            return false;
        }

        public static void Main()
        {
            List<string[]> hands = new List<string[]>(2000);
            Dictionary<char, int> weights = new Dictionary<char, int>();
            weights.Add('2', 2);
            weights.Add('3', 3);
            weights.Add('4', 4);
            weights.Add('5', 5);
            weights.Add('6', 6);
            weights.Add('7', 7);
            weights.Add('8', 8);
            weights.Add('9', 9);
            weights.Add('T', 10);
            weights.Add('J', 11);
            weights.Add('Q', 12);
            weights.Add('K', 13);
            weights.Add('A', 14);

            Dictionary<char, char> suits = new Dictionary<char, char>();
            suits.Add('C', 'C');
            suits.Add('D', 'D');
            suits.Add('H', 'H');
            suits.Add('S', 'S');

            using (StreamReader sr = new StreamReader(@"..\..\p054_poker.txt"))
            {
                char[] buffer = new char[30];
                while (sr.ReadBlock(buffer, 0, 30) != 0)
                {
                    string[] twoHands = new string(buffer, 0, 29).Split(' ');
                    string[] firstHand = { twoHands[0], twoHands[1], twoHands[2], twoHands[3], twoHands[4] };
                    string[] secondHand = { twoHands[5], twoHands[6], twoHands[7], twoHands[8], twoHands[9] };
                    hands.Add(firstHand.OrderBy(p => weights[p[0]]).ThenBy(q => suits[q[1]]).ToArray());
                    hands.Add(secondHand.OrderBy(p => weights[p[0]]).ThenBy(q => suits[q[1]]).ToArray());
                    buffer = new char[30];
                }
            }
            
            int counter = 0;
            for (int i = 0; i < hands.Count - 1; i += 2)
            {
                if (IsRoyalFlush(hands[i], weights).CompareTo(IsRoyalFlush(hands[i + 1], weights)) > 0)
                {
                    counter++;
                    continue;
                }
                else if (IsStraightFlush(hands[i], weights).CompareTo(IsStraightFlush(hands[i + 1], weights)) > 0 && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if (IsStraightFlush(hands[i], weights) && IsStraightFlush(hands[i + 1], weights) && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][4][0]] > weights[hands[i + 1][4][0]])
                    {
                        counter++;
                        continue;
                    }
                }
                else if (IsFourOfAKind(hands[i]).CompareTo(IsFourOfAKind(hands[i + 1])) > 0 && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i+1], weights))
                {
                    counter++;
                    continue;
                }
                else if(IsFourOfAKind(hands[i]) && IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][3][0]] > weights[hands[i + 1][3][0]])
                    {
                        counter++;
                        continue;
                    }
                }
                else if (IsFullHouse(hands[i]).CompareTo(IsFullHouse(hands[i + 1])) > 0 && !IsFourOfAKind(hands[i + 1])
                     && !IsStraightFlush(hands[i + 1], weights) && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if(IsFullHouse(hands[i]) && IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1])
                     && !IsStraightFlush(hands[i + 1], weights) && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (hands[i][0] == hands[i][1] && hands[i][1] == hands[i][2])
                    {
                        if (hands[i + 1][0] == hands[i + 1][1] && hands[i + 1][1] == hands[i + 1][2])
                        {
                            if (weights[hands[i][0][0]] > weights[hands[i + 1][0][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                        else
                        {
                            if (weights[hands[i][0][0]] > weights[hands[i + 1][3][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (hands[i + 1][0] == hands[i + 1][1] && hands[i + 1][1] == hands[i + 1][2])
                        {
                            if (weights[hands[i][3][0]] > weights[hands[i + 1][0][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                        else
                        {
                            if (weights[hands[i][3][0]] > weights[hands[i + 1][3][0]])
                            {
                                counter++;
                                continue;
                            }
                        }   
                    }
                }
                else if (IsFlush(hands[i]).CompareTo(IsFlush(hands[i + 1])) > 0 && !IsFullHouse(hands[i + 1]) &&
                     !IsFourOfAKind(hands[i + 1])
                     && !IsStraightFlush(hands[i + 1], weights) && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if(IsFlush(hands[i]) && IsFlush(hands[i + 1]) && !IsFullHouse(hands[i + 1]) &&
                     !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights) &&
                    !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][4][0]] > weights[hands[i + 1][4][0]])
                    {
                        counter++;
                        continue;
                    }
                }
                else if (IsStraight(hands[i], weights).CompareTo(IsStraight(hands[i + 1], weights)) > 0 && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if (IsStraight(hands[i], weights) && IsStraight(hands[i + 1], weights) && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][4][0]] > weights[hands[i + 1][4][0]])
                    {
                        counter++;
                        continue;
                    }
                }
                else if (IsThreeOfAKind(hands[i]).CompareTo(IsThreeOfAKind(hands[i + 1])) > 0 && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if (IsThreeOfAKind(hands[i]) && IsThreeOfAKind(hands[i + 1]) && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][2][0]] > weights[hands[i + 1][2][0]])
                    {
                        counter++;
                        continue;
                    }
                }
                else if (IsTwoPairs(hands[i]).CompareTo(IsTwoPairs(hands[i + 1])) > 0 && !IsThreeOfAKind(hands[i + 1])
                    && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if (IsTwoPairs(hands[i]) && IsTwoPairs(hands[i + 1]) && !IsThreeOfAKind(hands[i + 1])
                    && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if (weights[hands[i][4][0]] > weights[hands[i + 1][4][0]])
                    {
                        counter++;
                        continue;
                    }
                    else if (weights[hands[i][4][0]] == weights[hands[i + 1][4][0]])
                    {
                        if (weights[hands[i][1][0]] > weights[hands[i + 1][1][0]])
                        {
                            counter++;
                            continue;
                        }
                        else if (weights[hands[i][1][0]] == weights[hands[i + 1][1][0]])
                        {
                            int distinct1 = weights[hands[i][0][0]];
                            int distinct2 = weights[hands[i + 1][0][0]];
                            for (int j = 1; j < 5; j++)
                            {
                                distinct1 ^= weights[hands[i][j][0]];
                                distinct2 ^= weights[hands[i + 1][j][0]];
                            }
                            if(distinct1 > distinct2)
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                }
                else if (IsOnePair(hands[i]).CompareTo(IsOnePair(hands[i + 1])) > 0 && !IsTwoPairs(hands[i + 1])
                    && !IsThreeOfAKind(hands[i + 1])
                    && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    counter++;
                    continue;
                }
                else if (IsOnePair(hands[i]) && IsOnePair(hands[i + 1]) && !IsTwoPairs(hands[i + 1])
                    && !IsThreeOfAKind(hands[i + 1])
                    && !IsStraight(hands[i + 1], weights)
                    && !IsFlush(hands[i + 1])
                    && !IsFullHouse(hands[i + 1]) && !IsFourOfAKind(hands[i + 1]) && !IsStraightFlush(hands[i + 1], weights)
                    && !IsRoyalFlush(hands[i + 1], weights))
                {
                    if ((weights[hands[i][0][0]] == weights[hands[i][1][0]]) || (weights[hands[i][1][0]] == weights[hands[i][2][0]]))
                    {
                        if ((weights[hands[i + 1][0][0]] == weights[hands[i + 1][1][0]]) || (weights[hands[i + 1][1][0]] == weights[hands[i + 1][2][0]]))
                        {
                            if (weights[hands[i][1][0]] > weights[hands[i + 1][1][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                        else if ((weights[hands[i + 1][2][0]] == weights[hands[i + 1][3][0]]) || (weights[hands[i + 1][3][0]] == weights[hands[i + 1][4][0]]))
                        {
                            if (weights[hands[i][1][0]] > weights[hands[i + 1][3][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if ((weights[hands[i + 1][0][0]] == weights[hands[i + 1][1][0]]) || (weights[hands[i + 1][1][0]] == weights[hands[i + 1][2][0]]))
                        {
                            if (weights[hands[i][3][0]] > weights[hands[i + 1][1][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                        else if ((weights[hands[i + 1][2][0]] == weights[hands[i + 1][3][0]]) || (weights[hands[i + 1][3][0]] == weights[hands[i + 1][4][0]]))
                        {
                            if (weights[hands[i][3][0]] > weights[hands[i + 1][3][0]])
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                }
                else if (!IsOnePair(hands[i]) && !IsOnePair(hands[i + 1]) && !IsTwoPairs(hands[i + 1])
                    && !IsThreeOfAKind(hands[i+1]) && !IsStraightFlush(hands[i+1], weights) && !IsStraight(hands[i+1], weights)
                    && !IsRoyalFlush(hands[i+1], weights) && !IsFullHouse(hands[i+1]) && !IsFourOfAKind(hands[i+1])
                    && !IsFlush(hands[i+1]))
                {
                    if (weights[hands[i][4][0]] > weights[hands[i + 1][4][0]])
                    {
                        counter++;
                        continue;
                    }
                    else if (weights[hands[i][4][0]] == weights[hands[i + 1][4][0]])
                    {
                        if (weights[hands[i][3][0]] > weights[hands[i + 1][3][0]])
                        {
                            counter++;
                            continue;
                        }
                        else if (weights[hands[i][3][0]] == weights[hands[i + 1][3][0]])
                        {
                            if (weights[hands[i][2][0]] > weights[hands[i + 1][2][0]])
                            {
                                counter++;
                                continue;
                            }
                            else if (weights[hands[i][2][0]] == weights[hands[i + 1][2][0]])
                            {
                                if (weights[hands[i][1][0]] > weights[hands[i + 1][1][0]])
                                {
                                    counter++;
                                    continue;
                                }
                                else if (weights[hands[i][1][0]] == weights[hands[i + 1][1][0]])
                                {
                                    if (weights[hands[i][0][0]] > weights[hands[i + 1][0][0]])
                                    {
                                        counter++;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}