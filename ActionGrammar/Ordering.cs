using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionGrammar
{
    public class ActionsOld
    {
        public string EndPeriod = ".";

        public string Text { get; init; }

        public ActionsOld() 
        {
            Text = EndPeriod;
        }
    }

    public class UserActions : ActionsOld
    {
        public string StartText = "I am ";

        public string Text { get; init; }

        public UserActions()
        {
            Text = StartText + EndPeriod;
        }
    }

    public class AutoActions : ActionsOld
    {
        public string StartText = "We are ";

        public string Text { get; init; }

        public AutoActions()
        {
            Text = StartText + EndPeriod;
        }
    }

    public abstract class OrderingActions : UserActions
    {
        public string MiddelText = " in order to ";
    }

    public class BiddingActions : OrderingActions
    {
        public string Text { get; init;}

        public BiddingActions()
        {
            StartText += "bidding ";

            MiddelText += "buy ";

            Text = StartText + MiddelText + EndPeriod;
        }

        public BiddingActions(OfferItem offer, OrderItem order)
        {
            StartText += "bidding " + offer.Text;

            MiddelText += "buy " + order.Text;

            Text = StartText + MiddelText + EndPeriod;
        }
    }
    public class AskingActions : OrderingActions
    {
        public string Text { get; init; }

        public AskingActions()
        {
            StartText += "asking ";

            MiddelText += "sell ";

            Text = StartText + MiddelText + EndPeriod;
        }
    }

    public class Ordering
    {
        public string Test { get; init; }

        public static string Offer = "";

        public static string Order = ""; 

        public Ordering()
        {
            Test = "I am";
        }
    }

    public class Bidding
    {
        public static string Format = $"I am {Bid} in order to {Buy}";

        public static Bid Bid;

        public static Buy Buy;
    }

    public class Bid
    {

    }

    public class Buy
    {

    }

    public class OfferItem
    {
        public string Text = "";
    }

    public class OrderItem
    {
        public string Text = "";
    }
}
