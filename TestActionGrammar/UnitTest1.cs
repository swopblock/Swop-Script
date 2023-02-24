using ActionGrammar;

namespace TestActionGrammar
{
    public class UnitTestActionsAndItems
    {
        [Fact]
        public void TestActionEndsWith()
        {
            var action = new Actions();

            string message = action.Text;

            Assert.True(message.EndsWith("."));
        }

        [Fact]
        public void TestOfferItem()
        {
            var offer = new OfferItem();

            Assert.Equal("", offer.Text);
        }

        [Fact]
        public void TestOrderItem() 
        {
            var order = new OrderItem();

            Assert.Equal("", order.Text);
        }
    }

    public class UnitTestUserActions
    {
        [Fact]
        public void TestStartsWith()
        {
            var userAction = new UserActions();

            string message = userAction.Text;

            Assert.True(message.StartsWith("I am "));
        }

        [Fact]
        public void TestEndsWith()
        {
            var userAction = new UserActions();

            string message = userAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }

    public class UnitTestBiddingActions
    {

        [Fact]
        public void TestBiddingStartsWith()
        {
            var biddingAction = new BiddingActions();

            string message = biddingAction.Text;

            Assert.True(message.StartsWith("I am bidding "));
        }

        [Fact]
        public void TestBiddingMiddelText()
        {
            var biddingAction = new BiddingActions();

            string Render = biddingAction.Text;

            Assert.True(Render.Contains(" in order to buy "));
        }

        [Fact]
        public void TestBiddingEndWith()
        {
            var biddingAction = new BiddingActions();

            string message = biddingAction.Text;

            Assert.True(message.EndsWith("."));
        }

        [Fact]
        public void TestBiddingText()
        {
            var offer = new OfferItem();

            var order = new OrderItem();
            
            var biddingAction = new BiddingActions(offer, order);

            Assert.Equal($"I am bidding {order.Text} in order to buy {offer.Text}.", biddingAction.Text);
        }
    }

    public class UnitTestAskingActions
    { 
        [Fact]
        public void TestAskingStartsWith()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.StartsWith("I am asking "));
        }

        [Fact]
        public void TestAskingMiddelText()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.Contains(" in order to sell "));
        }

        [Fact]
        public void TestAskingEndWith()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }





    public class UnitTestAutoActions
    {
        [Fact]
        public void TestAutoActionsStartsWith()
        {
            var autoAction = new AutoActions();

            string message = autoAction.Text;

            Assert.True(message.StartsWith("We are "));
        }

        [Fact]
        public void TestAutoActionsEndsWith()
        {

            var autoAction = new AutoActions();

            string message = autoAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }
}