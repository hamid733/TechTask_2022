using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using TechTalk.SpecFlow;
using TechTask_2022.Support;

namespace TechTask_2022.StepDefinitions
{
    [Binding]
    public class Api_TestsStepDefinitions : Common
    {
        OrdersApi order = new OrdersApi();
        dynamic actual_fields = new List<object>(){};
        dynamic actual_order = new List<object>() { };


        [When(@"I call the orders api")]
        public void WhenICallTheOrdersApi()
        {
            actual_fields = order.get_response_keys();
             
        }

        [Then(@"the following order items should be displayed against a single order")]
        public void check_order_details(Table table)
        {
            var expected_fields = get_table_values("Field", table);
            Assert.AreEqual(expected_fields, actual_fields, "Unexpected values in the order details");
        }
        
        [When(@"I request the order details by passing the order id '([^']*)'")]
        public void WhenIRequestTheOrderDetailsByPassingAnId(string id)
        {
            actual_order = order.get_response_values(id);
        }

        [Then(@"the correct order record should be recieved matching the id")]
        public void ThenTheCorrectOrderRecordShouldBeRecievedMatchingTheId(Table table)
        {
            dynamic expected_order = new List<object>() { }; 
            expected_order.Add(get_table_values("createdAt", table)[0]);
            expected_order.Add(get_table_values("cakeName", table)[0]);
            expected_order.Add(get_table_values("price", table)[0]);
            expected_order.Add(get_table_values("clientEmail", table)[0]);
            expected_order.Add(get_table_values("orderid", table)[0]);
            Assert.AreEqual(expected_order, actual_order, "Unexpected order value");

        }
        [Then(@"the reponse should be a valid json")]
        public void ThenTheReponseShouldBeAValidJson()
        {
            throw new PendingStepException();
        }


    }
}
