using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using TechTask_2022.Support;

namespace TechTask_2022
{
    internal class OrdersApi : Common
    {
        internal dynamic check_order_details(string id)
        {
            var options = new RestClientOptions(readConfig("orders_api"))
            {
                ThrowOnAnyError = true,
                MaxTimeout = 3000
            };
            try
            {
                var client = new RestClient(options);
                var request = new RestRequest();
                request.AddHeader("Accept", "*/*");
                if (id != "0")
                {

                    request.Resource = id;
                    var response = client.Execute(request);
                    var json_result = JObject.Parse(response.Content);
                    return json_result;

                }
                else
                {
                    var api_response = client.Execute(request);
                    var api_json_result = JsonConvert.DeserializeObject<List<dynamic>>(api_response.Content);
                    return api_json_result;
                }

              }
            catch (Exception)
            {

                throw;
            }

        }
        internal dynamic get_response_keys()
        {
            dynamic actual_fields = new List<object>() { };
            var response = (List<dynamic>)check_order_details("0");
            var first_order = response[0];
            foreach (var item in first_order)
            {
                actual_fields.Add(item.Name);
            }
            return actual_fields;
        }
        internal dynamic get_response_values(string id)
        {
            dynamic actual_vals = new List<object>() { };
            //var response = (List<dynamic>)check_order_details("2");
            var order_details = check_order_details(id);
            foreach (var item in order_details)
            {
                actual_vals.Add(item.Value.ToString());
            }
            return actual_vals;
        }

        internal bool checkjson_response()
        {
            string order_schema = @"{  
                                      'type': 'object',
                                      'properties':
                                      {
                                        'createdDate': {'type':'string'},
                                        'cakeName': {'type': 'string',
                                         'price': {'type':'string'}
                                        }
                                      }
                                    }";
            try
            {
                JObject order_details = check_order_details("2");
                JsonSchema schema = JsonSchema.Parse(order_schema);
                return order_details.IsValid(schema);
            }
            catch (Exception)
            {

                throw;
            }
                       

        }
    }
}
